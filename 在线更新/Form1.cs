using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Text;

namespace 在线更新
{
    /// <summary>
    /// 自动更新模块
    /// </summary>
    public partial class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader chVersion;
        private System.Windows.Forms.ColumnHeader chProgress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvUpdateList;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.ProgressBar pbDownFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnFinish;
        private Label label4;
        private LinkLabel linkLabel1;
        private Label label3;
        private Label label2;
        private Label label5;
        private bool checkStatus = false;

        public Form1()
        {
            //允许子线程操作UI
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            new Thread(new ThreadStart(this.PerformTask)) { IsBackground = true }.Start();
        }

        //服务器更新地址
        private string updateUrl = string.Empty;
        private string tempUpdatePath = string.Empty;
        XmlFiles updaterXmlFiles = null;
        private int availableUpdate = 0;
        string mainAppExe = "";

        private void PerformTask()
        {
            //设置线程池最大线程数量
            ThreadPool.SetMaxThreads(1, 1);
            ThreadPool.QueueUserWorkItem(delegate { Run(); });
        }
        private void Run()
        {
            string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
            string serverXmlFile = string.Empty;


            try
            {
                //从本地读取更新配置文件信息
                updaterXmlFiles = new XmlFiles(localXmlFile);
            }
            catch
            {
                MessageBox.Show("配置文件出错!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            //获取服务器地址
            updateUrl = updaterXmlFiles.GetNodeValue("//Url");

            AppUpdater appUpdater = new AppUpdater();
            appUpdater.UpdaterUrl = updateUrl + "/UpdateList.xml";

            //与服务器连接,下载更新配置文件
            try
            {
                //tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" + "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_" + "y" + "_" + "x" + "_" + "m" + "_" + "\\";
                tempUpdatePath = Application.StartupPath + "//Updater/";
                appUpdater.DownAutoUpdateFile(tempUpdatePath);
            }
            catch
            {
                MessageBox.Show("与服务器连接失败,操作超时!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;

            }

            //获取更新文件列表
            Hashtable htUpdateFile = new Hashtable();

            serverXmlFile = tempUpdatePath + "\\UpdateList.xml";
            if (!File.Exists(serverXmlFile))
            {
                return;
            }
            try
            {
                availableUpdate = appUpdater.CheckForUpdate(serverXmlFile, localXmlFile, out htUpdateFile);
                if (availableUpdate > 0)
                {
                    this.labTitle.Text = "以下为更新文件列表：";
                    for (int i = 0; i < htUpdateFile.Count; i++)
                    {
                        string[] fileArray = (string[])htUpdateFile[i];
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                    }
                }
                else
                {
                    this.labTitle.Text = "当前已是最新版本，没有可用的更新！";
                }
                checkStatus = true;
            }
            catch (Exception)
            {
                checkStatus = false;
                this.labTitle.Text = "检查更新失败";
            }

        }
        #region Load事件
        private void FrmUpdate_Load(object sender, System.EventArgs e)
        {
            panel2.Visible = false;
            btnFinish.Visible = false;
        }
        #endregion

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            if (availableUpdate > 0)
            {
                Thread threadDown = new Thread(new ThreadStart(DownUpdateFile));
                threadDown.IsBackground = true;
                threadDown.Start();
            }
            else
            {
                if (checkStatus)
                {
                    MessageBox.Show("没有可用的更新!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("正在检查更新，请稍候...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

        }
        private void DownUpdateFile()
        {
            //关掉主进程
            mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
            Process[] allProcess = Process.GetProcesses();
            foreach (Process p in allProcess)
            {
                if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower())
                {
                    for (int i = 0; i < p.Threads.Count; i++)
                    {
                        p.Threads[i].Dispose();
                        p.Kill();
                    }
                }
            }
            WebClient wcClient = new WebClient();
            for (int i = 0; i < this.lvUpdateList.Items.Count; i++)
            {
                string UpdateFile = lvUpdateList.Items[i].Text.Trim();
                string updateFileUrl = updateUrl + lvUpdateList.Items[i].Text.Trim();
                long fileLength = 0;

                WebRequest webReq = WebRequest.Create(updateFileUrl);
                WebResponse webRes = webReq.GetResponse();
                fileLength = webRes.ContentLength;

                lbState.Text = "正在下载更新文件,请稍后...";
                pbDownFile.Value = 0;
                pbDownFile.Maximum = (int)fileLength;

                try
                {
                    Stream srm = webRes.GetResponseStream();
                    StreamReader srmReader = new StreamReader(srm);
                    byte[] bufferbyte = new byte[fileLength];
                    int allByte = (int)bufferbyte.Length;
                    int startByte = 0;
                    while (fileLength > 0)
                    {
                        Application.DoEvents();
                        int downByte = srm.Read(bufferbyte, startByte, allByte);
                        if (downByte == 0) { break; };
                        startByte += downByte;
                        allByte -= downByte;
                        pbDownFile.Value += downByte;

                        float part = (float)startByte / 1024;
                        float total = (float)bufferbyte.Length / 1024;
                        int percent = Convert.ToInt32((part / total) * 100);

                        this.lvUpdateList.Items[i].SubItems[2].Text = percent.ToString() + "%";

                    }

                    string tempPath = tempUpdatePath + UpdateFile;
                    CreateDirtory(tempPath);
                    FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Write(bufferbyte, 0, bufferbyte.Length);
                    srm.Close();
                    srmReader.Close();
                    fs.Close();


                }
                catch (WebException ex)
                {
                    MessageBox.Show("更新文件下载失败！" + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            InvalidateControl();
        }
        //创建目录
        private void CreateDirtory(string path)
        {
            if (!File.Exists(path))
            {
                string[] dirArray = path.Split('\\');
                string temp = string.Empty;
                for (int i = 0; i < dirArray.Length - 1; i++)
                {
                    temp += dirArray[i].Trim() + "\\";
                    if (!Directory.Exists(temp))
                        Directory.CreateDirectory(temp);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //打开资源驿站（www.zy13.net）
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
        //点击完成复制更新文件到应用程序目录
        private void btnFinish_Click(object sender, System.EventArgs e)
        {
           
            this.Dispose();
            try
            {
                CopyDirectory(tempUpdatePath, Directory.GetCurrentDirectory());
                System.IO.Directory.Delete(tempUpdatePath, true);
            }
            catch (Exception)
            {
            }
            if (mainAppExe != string.Empty)
            {
                //启动程序
                System.Diagnostics.Process.Start(Environment.CurrentDirectory + mainAppExe);
            }
            else
            {
                MessageBox.Show("更新成功，请重新打开程序！", "提示");
            }
            this.Close();

        }
        /// <summary>
        /// 把一个文件夹下所有文件复制到另一个文件夹下
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="destPath"></param>
        public static void CopyDirectory(string srcPath, string destPath)
        {
            //获取目录下（不包含子目录）的文件和子目录
            DirectoryInfo dir = new DirectoryInfo(srcPath); FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
            foreach (FileSystemInfo i in fileinfo)
            {
                //判断是否文件夹
                if (i is DirectoryInfo)
                {
                    if (!Directory.Exists(destPath + "\\" + i.Name))
                    {
                        //目标目录下不存在此文件夹即创建子文件夹
                        Directory.CreateDirectory(destPath + "\\" + i.Name);
                    }
                    //递归调用复制子文件夹
                    CopyDirectory(i.FullName, destPath + "\\" + i.Name);
                }
                else
                {
                    //不是文件夹即复制文件，true表示可以覆盖同名文件
                    File.Copy(i.FullName, destPath + "\\" + i.Name, true);
                }
            }
        }

        //重新绘制窗体部分控件属性
        private void InvalidateControl()
        {
            panel2.Location = panel1.Location;
            panel2.Size = panel1.Size;
            panel1.Visible = false;
            panel2.Visible = true;

            btnNext.Visible = false;
            btnCancel.Visible = false;
            btnFinish.Location = btnCancel.Location;
            btnFinish.Visible = true;
        }
        //判断主应用程序是否正在运行
        private bool IsMainAppRun()
        {
            string mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
            bool isRun = false;
            Process[] allProcess = Process.GetProcesses();
            foreach (Process p in allProcess)
            {
                if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower())
                {
                    isRun = true;
                }
            }
            return isRun;
        }

        private PictureBox pictureBox2;
    }
}
