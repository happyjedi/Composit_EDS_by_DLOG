namespace CEGSA_Server
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
          this.lstClients = new System.Windows.Forms.ListBox();
          this.toolStrip1 = new System.Windows.Forms.ToolStrip();
          this.tbtnAdd = new System.Windows.Forms.ToolStripButton();
          this.tbtnEdit = new System.Windows.Forms.ToolStripButton();
          this.tbtnDel = new System.Windows.Forms.ToolStripButton();
          this.tbtnChangeAdminPass = new System.Windows.Forms.ToolStripButton();
          this.label1 = new System.Windows.Forms.Label();
          this.btnAddClient = new System.Windows.Forms.Button();
          this.btnAddAllClients = new System.Windows.Forms.Button();
          this.btnDelClient = new System.Windows.Forms.Button();
          this.btnDelAllClients = new System.Windows.Forms.Button();
          this.btnStart = new System.Windows.Forms.Button();
          this.progressBar1 = new System.Windows.Forms.ProgressBar();
          this.lstCurrentClients = new System.Windows.Forms.CheckedListBox();
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
          this.cmbServerAddress = new System.Windows.Forms.ComboBox();
          this.label2 = new System.Windows.Forms.Label();
          this.toolStrip1.SuspendLayout();
          this.menuStrip1.SuspendLayout();
          this.statusStrip1.SuspendLayout();
          this.SuspendLayout();
          // 
          // lstClients
          // 
          this.lstClients.FormattingEnabled = true;
          this.lstClients.Location = new System.Drawing.Point(9, 65);
          this.lstClients.Name = "lstClients";
          this.lstClients.Size = new System.Drawing.Size(120, 225);
          this.lstClients.TabIndex = 0;
          this.lstClients.SelectedIndexChanged += new System.EventHandler(this.lstClients_SelectedIndexChanged);
          this.lstClients.DoubleClick += new System.EventHandler(this.lstClients_DoubleClick);
          // 
          // toolStrip1
          // 
          this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
          this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnAdd,
            this.tbtnEdit,
            this.tbtnDel,
            this.tbtnChangeAdminPass});
          this.toolStrip1.Location = new System.Drawing.Point(9, 37);
          this.toolStrip1.Name = "toolStrip1";
          this.toolStrip1.Size = new System.Drawing.Size(104, 25);
          this.toolStrip1.TabIndex = 1;
          this.toolStrip1.Text = "toolStrip1";
          // 
          // tbtnAdd
          // 
          this.tbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.tbtnAdd.Image = global::CEGSA_Server.Properties.Resources.add_48;
          this.tbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.tbtnAdd.Name = "tbtnAdd";
          this.tbtnAdd.Size = new System.Drawing.Size(23, 22);
          this.tbtnAdd.Text = "Добавить";
          this.tbtnAdd.Click += new System.EventHandler(this.tbtnAdd_Click);
          // 
          // tbtnEdit
          // 
          this.tbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.tbtnEdit.Image = global::CEGSA_Server.Properties.Resources.paper_content_pencil_48;
          this.tbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.tbtnEdit.Name = "tbtnEdit";
          this.tbtnEdit.Size = new System.Drawing.Size(23, 22);
          this.tbtnEdit.Text = "Редактировать";
          this.tbtnEdit.Click += new System.EventHandler(this.tbtnEdit_Click);
          // 
          // tbtnDel
          // 
          this.tbtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.tbtnDel.Image = global::CEGSA_Server.Properties.Resources.cross_48;
          this.tbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.tbtnDel.Name = "tbtnDel";
          this.tbtnDel.Size = new System.Drawing.Size(23, 22);
          this.tbtnDel.Text = "Удалить";
          this.tbtnDel.Click += new System.EventHandler(this.tbtnDel_Click);
          // 
          // tbtnChangeAdminPass
          // 
          this.tbtnChangeAdminPass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.tbtnChangeAdminPass.Image = global::CEGSA_Server.Properties.Resources.lock_open_48;
          this.tbtnChangeAdminPass.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.tbtnChangeAdminPass.Name = "tbtnChangeAdminPass";
          this.tbtnChangeAdminPass.Size = new System.Drawing.Size(23, 22);
          this.tbtnChangeAdminPass.Text = "Изменить пароль Администратора";
          this.tbtnChangeAdminPass.Click += new System.EventHandler(this.toolStripButton1_Click);
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(191, 37);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(106, 13);
          this.label1.TabIndex = 3;
          this.label1.Text = "Текущие участники";
          // 
          // btnAddClient
          // 
          this.btnAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.btnAddClient.Location = new System.Drawing.Point(135, 89);
          this.btnAddClient.Name = "btnAddClient";
          this.btnAddClient.Size = new System.Drawing.Size(53, 23);
          this.btnAddClient.TabIndex = 4;
          this.btnAddClient.Text = ">";
          this.btnAddClient.UseVisualStyleBackColor = true;
          this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
          // 
          // btnAddAllClients
          // 
          this.btnAddAllClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.btnAddAllClients.Location = new System.Drawing.Point(135, 118);
          this.btnAddAllClients.Name = "btnAddAllClients";
          this.btnAddAllClients.Size = new System.Drawing.Size(53, 23);
          this.btnAddAllClients.TabIndex = 4;
          this.btnAddAllClients.Text = ">>";
          this.btnAddAllClients.UseVisualStyleBackColor = true;
          this.btnAddAllClients.Click += new System.EventHandler(this.btnAddAllClients_Click);
          // 
          // btnDelClient
          // 
          this.btnDelClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.btnDelClient.Location = new System.Drawing.Point(135, 169);
          this.btnDelClient.Name = "btnDelClient";
          this.btnDelClient.Size = new System.Drawing.Size(53, 23);
          this.btnDelClient.TabIndex = 4;
          this.btnDelClient.Text = "<";
          this.btnDelClient.UseVisualStyleBackColor = true;
          this.btnDelClient.Click += new System.EventHandler(this.btnDelClient_Click);
          // 
          // btnDelAllClients
          // 
          this.btnDelAllClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.btnDelAllClients.Location = new System.Drawing.Point(135, 198);
          this.btnDelAllClients.Name = "btnDelAllClients";
          this.btnDelAllClients.Size = new System.Drawing.Size(53, 23);
          this.btnDelAllClients.TabIndex = 4;
          this.btnDelAllClients.Text = "<<";
          this.btnDelAllClients.UseVisualStyleBackColor = true;
          this.btnDelAllClients.Click += new System.EventHandler(this.btnDelAllClients_Click);
          // 
          // btnStart
          // 
          this.btnStart.Location = new System.Drawing.Point(98, 340);
          this.btnStart.Name = "btnStart";
          this.btnStart.Size = new System.Drawing.Size(120, 23);
          this.btnStart.TabIndex = 5;
          this.btnStart.Text = "Запустить сервер";
          this.btnStart.UseVisualStyleBackColor = true;
          this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
          // 
          // progressBar1
          // 
          this.progressBar1.Location = new System.Drawing.Point(9, 369);
          this.progressBar1.Name = "progressBar1";
          this.progressBar1.Size = new System.Drawing.Size(311, 23);
          this.progressBar1.TabIndex = 6;
          // 
          // lstCurrentClients
          // 
          this.lstCurrentClients.FormattingEnabled = true;
          this.lstCurrentClients.Location = new System.Drawing.Point(194, 65);
          this.lstCurrentClients.Name = "lstCurrentClients";
          this.lstCurrentClients.Size = new System.Drawing.Size(120, 229);
          this.lstCurrentClients.TabIndex = 7;
          this.lstCurrentClients.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstCurrentClients_ItemCheck);
          // 
          // menuStrip1
          // 
          this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
          this.menuStrip1.Location = new System.Drawing.Point(0, 0);
          this.menuStrip1.Name = "menuStrip1";
          this.menuStrip1.Size = new System.Drawing.Size(327, 24);
          this.menuStrip1.TabIndex = 14;
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
          this.statusStrip1.Location = new System.Drawing.Point(0, 398);
          this.statusStrip1.Name = "statusStrip1";
          this.statusStrip1.Size = new System.Drawing.Size(327, 22);
          this.statusStrip1.TabIndex = 15;
          this.statusStrip1.Text = "statusStrip1";
          // 
          // lblStatus
          // 
          this.lblStatus.Name = "lblStatus";
          this.lblStatus.Size = new System.Drawing.Size(0, 17);
          // 
          // cmbServerAddress
          // 
          this.cmbServerAddress.FormattingEnabled = true;
          this.cmbServerAddress.Location = new System.Drawing.Point(114, 307);
          this.cmbServerAddress.Name = "cmbServerAddress";
          this.cmbServerAddress.Size = new System.Drawing.Size(200, 21);
          this.cmbServerAddress.TabIndex = 16;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(12, 310);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(83, 13);
          this.label2.TabIndex = 17;
          this.label2.Text = "Адрес сервера";
          // 
          // frmBase
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(327, 420);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.cmbServerAddress);
          this.Controls.Add(this.statusStrip1);
          this.Controls.Add(this.menuStrip1);
          this.Controls.Add(this.lstCurrentClients);
          this.Controls.Add(this.progressBar1);
          this.Controls.Add(this.btnStart);
          this.Controls.Add(this.btnDelAllClients);
          this.Controls.Add(this.btnDelClient);
          this.Controls.Add(this.btnAddAllClients);
          this.Controls.Add(this.btnAddClient);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.toolStrip1);
          this.Controls.Add(this.lstClients);
          this.Name = "frmBase";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Композиционная ЭЦП - Сервер";
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBase_FormClosing);
          this.Load += new System.EventHandler(this.frmBase_Load);
          this.Shown += new System.EventHandler(this.frmBase_Shown);
          this.toolStrip1.ResumeLayout(false);
          this.toolStrip1.PerformLayout();
          this.menuStrip1.ResumeLayout(false);
          this.menuStrip1.PerformLayout();
          this.statusStrip1.ResumeLayout(false);
          this.statusStrip1.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnAdd;
        private System.Windows.Forms.ToolStripButton tbtnEdit;
        private System.Windows.Forms.ToolStripButton tbtnDel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnAddAllClients;
        private System.Windows.Forms.Button btnDelClient;
        private System.Windows.Forms.Button btnDelAllClients;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripButton tbtnChangeAdminPass;
        private System.Windows.Forms.CheckedListBox lstCurrentClients;
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
        private System.Windows.Forms.ComboBox cmbServerAddress;
        private System.Windows.Forms.Label label2;
    }
}