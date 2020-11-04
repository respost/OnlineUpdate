namespace 在线更新
{
    partial class Form1
    {
        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvUpdateList = new System.Windows.Forms.ListView();
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pbDownFile = new System.Windows.Forms.ProgressBar();
            this.lbState = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 240);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labTitle);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.lvUpdateList);
            this.panel1.Controls.Add(this.pbDownFile);
            this.panel1.Controls.Add(this.lbState);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(120, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 240);
            this.panel1.TabIndex = 2;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.ForeColor = System.Drawing.Color.Brown;
            this.labTitle.Location = new System.Drawing.Point(7, 16);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(191, 12);
            this.labTitle.TabIndex = 9;
            this.labTitle.Text = "正在检查更新文件，请耐心等待...";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 2);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // lvUpdateList
            // 
            this.lvUpdateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chVersion,
            this.chProgress});
            this.lvUpdateList.Location = new System.Drawing.Point(3, 48);
            this.lvUpdateList.Name = "lvUpdateList";
            this.lvUpdateList.Size = new System.Drawing.Size(272, 120);
            this.lvUpdateList.TabIndex = 6;
            this.lvUpdateList.UseCompatibleStateImageBehavior = false;
            this.lvUpdateList.View = System.Windows.Forms.View.Details;
            // 
            // chFileName
            // 
            this.chFileName.Text = "文件名";
            this.chFileName.Width = 123;
            // 
            // chVersion
            // 
            this.chVersion.Text = "版本号";
            this.chVersion.Width = 98;
            // 
            // chProgress
            // 
            this.chProgress.Text = "进度";
            this.chProgress.Width = 47;
            // 
            // pbDownFile
            // 
            this.pbDownFile.Location = new System.Drawing.Point(3, 200);
            this.pbDownFile.Name = "pbDownFile";
            this.pbDownFile.Size = new System.Drawing.Size(274, 17);
            this.pbDownFile.TabIndex = 5;
            // 
            // lbState
            // 
            this.lbState.Location = new System.Drawing.Point(3, 176);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(240, 16);
            this.lbState.TabIndex = 4;
            this.lbState.Text = "点击“下一步”开始更新文件";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 8);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(224, 264);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 24);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一步(&N)>";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Location = new System.Drawing.Point(8, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(112, 24);
            this.panel2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(144, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "资源驿站";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(136, 208);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(128, 16);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.zy13.net";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "欢迎以后继续关注我们的产品。";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 48);
            this.label2.TabIndex = 10;
            this.label2.Text = "     程序更新完成,如果程序更新期间被关闭,点击\"完成\"自动更新程序会自动重新启动系统。";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(16, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "感谢使用在线升级";
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(112, 2);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox2";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(0, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 8);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(136, 264);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(80, 24);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "完成(&F)";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(96, 240);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(424, 301);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动更新";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}

