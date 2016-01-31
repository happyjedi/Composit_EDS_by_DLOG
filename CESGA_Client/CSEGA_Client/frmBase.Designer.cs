namespace CESGA_Client
{
    partial class frmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.btnConnect = new System.Windows.Forms.Button();
          this.txtIP = new System.Windows.Forms.TextBox();
          this.label1 = new System.Windows.Forms.Label();
          this.btnEnter = new System.Windows.Forms.Button();
          this.txtPassword = new System.Windows.Forms.TextBox();
          this.txtLogin = new System.Windows.Forms.TextBox();
          this.label2 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.btnSign = new System.Windows.Forms.Button();
          this.txtFileName = new System.Windows.Forms.TextBox();
          this.btnChooseFile = new System.Windows.Forms.Button();
          this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
          this.grpAutorize = new System.Windows.Forms.GroupBox();
          this.tabControl1 = new System.Windows.Forms.TabControl();
          this.tabPage1 = new System.Windows.Forms.TabPage();
          this.tabPage2 = new System.Windows.Forms.TabPage();
          this.progressBar1 = new System.Windows.Forms.ProgressBar();
          this.menuStrip1 = new System.Windows.Forms.MenuStrip();
          this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuNewSession = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuHelpItem = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
          this.statusStrip1 = new System.Windows.Forms.StatusStrip();
          this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
          this.grpAutorize.SuspendLayout();
          this.tabControl1.SuspendLayout();
          this.tabPage1.SuspendLayout();
          this.tabPage2.SuspendLayout();
          this.menuStrip1.SuspendLayout();
          this.statusStrip1.SuspendLayout();
          this.SuspendLayout();
          // 
          // btnConnect
          // 
          this.btnConnect.Location = new System.Drawing.Point(377, 12);
          this.btnConnect.Name = "btnConnect";
          this.btnConnect.Size = new System.Drawing.Size(91, 23);
          this.btnConnect.TabIndex = 5;
          this.btnConnect.Text = "Подключиться";
          this.btnConnect.UseVisualStyleBackColor = true;
          this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
          // 
          // txtIP
          // 
          this.txtIP.Location = new System.Drawing.Point(117, 15);
          this.txtIP.Name = "txtIP";
          this.txtIP.Size = new System.Drawing.Size(254, 20);
          this.txtIP.TabIndex = 4;
          this.txtIP.Text = "192.168.1.2";
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(16, 18);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(95, 13);
          this.label1.TabIndex = 3;
          this.label1.Text = "IP адрес сервера";
          // 
          // btnEnter
          // 
          this.btnEnter.Location = new System.Drawing.Point(387, 108);
          this.btnEnter.Name = "btnEnter";
          this.btnEnter.Size = new System.Drawing.Size(75, 23);
          this.btnEnter.TabIndex = 8;
          this.btnEnter.Text = "Войти";
          this.btnEnter.UseVisualStyleBackColor = true;
          this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
          // 
          // txtPassword
          // 
          this.txtPassword.Location = new System.Drawing.Point(98, 65);
          this.txtPassword.Name = "txtPassword";
          this.txtPassword.PasswordChar = '*';
          this.txtPassword.Size = new System.Drawing.Size(270, 20);
          this.txtPassword.TabIndex = 7;
          // 
          // txtLogin
          // 
          this.txtLogin.Location = new System.Drawing.Point(98, 27);
          this.txtLogin.Name = "txtLogin";
          this.txtLogin.Size = new System.Drawing.Size(270, 20);
          this.txtLogin.TabIndex = 6;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.label2.Location = new System.Drawing.Point(21, 72);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(45, 13);
          this.label2.TabIndex = 5;
          this.label2.Text = "Пароль";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.label3.Location = new System.Drawing.Point(21, 27);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(38, 13);
          this.label3.TabIndex = 4;
          this.label3.Text = "Логин";
          // 
          // btnSign
          // 
          this.btnSign.Enabled = false;
          this.btnSign.Location = new System.Drawing.Point(370, 80);
          this.btnSign.Name = "btnSign";
          this.btnSign.Size = new System.Drawing.Size(107, 23);
          this.btnSign.TabIndex = 2;
          this.btnSign.Text = "Подписать файл";
          this.btnSign.UseVisualStyleBackColor = true;
          this.btnSign.Click += new System.EventHandler(this.btnNext1_Click);
          // 
          // txtFileName
          // 
          this.txtFileName.Enabled = false;
          this.txtFileName.Location = new System.Drawing.Point(98, 19);
          this.txtFileName.Name = "txtFileName";
          this.txtFileName.Size = new System.Drawing.Size(379, 20);
          this.txtFileName.TabIndex = 1;
          // 
          // btnChooseFile
          // 
          this.btnChooseFile.Enabled = false;
          this.btnChooseFile.Location = new System.Drawing.Point(6, 17);
          this.btnChooseFile.Name = "btnChooseFile";
          this.btnChooseFile.Size = new System.Drawing.Size(75, 23);
          this.btnChooseFile.TabIndex = 0;
          this.btnChooseFile.Text = "Выбрать файл";
          this.btnChooseFile.UseVisualStyleBackColor = true;
          this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
          // 
          // grpAutorize
          // 
          this.grpAutorize.Controls.Add(this.btnEnter);
          this.grpAutorize.Controls.Add(this.label3);
          this.grpAutorize.Controls.Add(this.label2);
          this.grpAutorize.Controls.Add(this.txtLogin);
          this.grpAutorize.Controls.Add(this.txtPassword);
          this.grpAutorize.Enabled = false;
          this.grpAutorize.Location = new System.Drawing.Point(6, 53);
          this.grpAutorize.Name = "grpAutorize";
          this.grpAutorize.Size = new System.Drawing.Size(468, 142);
          this.grpAutorize.TabIndex = 11;
          this.grpAutorize.TabStop = false;
          this.grpAutorize.Text = "Авторизация";
          // 
          // tabControl1
          // 
          this.tabControl1.Controls.Add(this.tabPage1);
          this.tabControl1.Controls.Add(this.tabPage2);
          this.tabControl1.Location = new System.Drawing.Point(0, 27);
          this.tabControl1.Name = "tabControl1";
          this.tabControl1.SelectedIndex = 0;
          this.tabControl1.Size = new System.Drawing.Size(491, 228);
          this.tabControl1.TabIndex = 12;
          // 
          // tabPage1
          // 
          this.tabPage1.Controls.Add(this.btnConnect);
          this.tabPage1.Controls.Add(this.grpAutorize);
          this.tabPage1.Controls.Add(this.label1);
          this.tabPage1.Controls.Add(this.txtIP);
          this.tabPage1.Location = new System.Drawing.Point(4, 22);
          this.tabPage1.Name = "tabPage1";
          this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
          this.tabPage1.Size = new System.Drawing.Size(483, 202);
          this.tabPage1.TabIndex = 0;
          this.tabPage1.Text = "Подключение и авторизация";
          this.tabPage1.UseVisualStyleBackColor = true;
          // 
          // tabPage2
          // 
          this.tabPage2.Controls.Add(this.progressBar1);
          this.tabPage2.Controls.Add(this.btnChooseFile);
          this.tabPage2.Controls.Add(this.btnSign);
          this.tabPage2.Controls.Add(this.txtFileName);
          this.tabPage2.Location = new System.Drawing.Point(4, 22);
          this.tabPage2.Name = "tabPage2";
          this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
          this.tabPage2.Size = new System.Drawing.Size(483, 202);
          this.tabPage2.TabIndex = 1;
          this.tabPage2.Text = "Выбор файла";
          this.tabPage2.UseVisualStyleBackColor = true;
          // 
          // progressBar1
          // 
          this.progressBar1.Location = new System.Drawing.Point(6, 173);
          this.progressBar1.Name = "progressBar1";
          this.progressBar1.Size = new System.Drawing.Size(471, 23);
          this.progressBar1.TabIndex = 11;
          // 
          // menuStrip1
          // 
          this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
          this.menuStrip1.Location = new System.Drawing.Point(0, 0);
          this.menuStrip1.Name = "menuStrip1";
          this.menuStrip1.Size = new System.Drawing.Size(499, 24);
          this.menuStrip1.TabIndex = 13;
          this.menuStrip1.Text = "menuStrip1";
          // 
          // mnuFile
          // 
          this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewSession,
            this.toolStripSeparator1,
            this.mnuExit});
          this.mnuFile.Name = "mnuFile";
          this.mnuFile.Size = new System.Drawing.Size(48, 20);
          this.mnuFile.Text = "Файл";
          // 
          // mnuNewSession
          // 
          this.mnuNewSession.Name = "mnuNewSession";
          this.mnuNewSession.Size = new System.Drawing.Size(148, 22);
          this.mnuNewSession.Text = "Новая сессия";
          this.mnuNewSession.Click += new System.EventHandler(this.mnuNewSession_Click);
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
          // 
          // mnuExit
          // 
          this.mnuExit.Name = "mnuExit";
          this.mnuExit.Size = new System.Drawing.Size(148, 22);
          this.mnuExit.Text = "Выход";
          this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
          // 
          // mnuHelp
          // 
          this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpItem,
            this.mnuAbout});
          this.mnuHelp.Name = "mnuHelp";
          this.mnuHelp.Size = new System.Drawing.Size(65, 20);
          this.mnuHelp.Text = "Справка";
          // 
          // mnuHelpItem
          // 
          this.mnuHelpItem.Name = "mnuHelpItem";
          this.mnuHelpItem.Size = new System.Drawing.Size(152, 22);
          this.mnuHelpItem.Text = "Справка";
          this.mnuHelpItem.Click += new System.EventHandler(this.mnuHelpItem_Click);
          // 
          // mnuAbout
          // 
          this.mnuAbout.Name = "mnuAbout";
          this.mnuAbout.Size = new System.Drawing.Size(152, 22);
          this.mnuAbout.Text = "О программе";
          this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
          // 
          // statusStrip1
          // 
          this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
          this.statusStrip1.Location = new System.Drawing.Point(0, 264);
          this.statusStrip1.Name = "statusStrip1";
          this.statusStrip1.Size = new System.Drawing.Size(499, 22);
          this.statusStrip1.TabIndex = 14;
          this.statusStrip1.Text = "statusStrip1";
          // 
          // lblStatus
          // 
          this.lblStatus.Name = "lblStatus";
          this.lblStatus.Size = new System.Drawing.Size(141, 17);
          this.lblStatus.Text = "Подключение к серверу";
          // 
          // frmBase
          // 
          this.AcceptButton = this.btnConnect;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(499, 286);
          this.Controls.Add(this.statusStrip1);
          this.Controls.Add(this.tabControl1);
          this.Controls.Add(this.menuStrip1);
          this.MainMenuStrip = this.menuStrip1;
          this.Name = "frmBase";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Композиционная ЭЦП - Клиент";
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBase_FormClosing);
          this.Load += new System.EventHandler(this.frmBase_Load);
          this.grpAutorize.ResumeLayout(false);
          this.grpAutorize.PerformLayout();
          this.tabControl1.ResumeLayout(false);
          this.tabPage1.ResumeLayout(false);
          this.tabPage1.PerformLayout();
          this.tabPage2.ResumeLayout(false);
          this.tabPage2.PerformLayout();
          this.menuStrip1.ResumeLayout(false);
          this.menuStrip1.PerformLayout();
          this.statusStrip1.ResumeLayout(false);
          this.statusStrip1.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox grpAutorize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNewSession;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}