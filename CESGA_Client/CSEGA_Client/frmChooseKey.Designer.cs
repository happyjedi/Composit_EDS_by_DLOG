namespace CESGA_Client
{
    partial class frmChooseKey
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
          this.txtPrivateKey = new System.Windows.Forms.TextBox();
          this.btnOpen = new System.Windows.Forms.Button();
          this.btnOK = new System.Windows.Forms.Button();
          this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
          this.SuspendLayout();
          // 
          // txtPrivateKey
          // 
          this.txtPrivateKey.Location = new System.Drawing.Point(114, 22);
          this.txtPrivateKey.Name = "txtPrivateKey";
          this.txtPrivateKey.Size = new System.Drawing.Size(257, 20);
          this.txtPrivateKey.TabIndex = 1;
          // 
          // btnOpen
          // 
          this.btnOpen.Location = new System.Drawing.Point(12, 20);
          this.btnOpen.Name = "btnOpen";
          this.btnOpen.Size = new System.Drawing.Size(96, 23);
          this.btnOpen.TabIndex = 2;
          this.btnOpen.Text = "Генерировать";
          this.btnOpen.UseVisualStyleBackColor = true;
          this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
          // 
          // btnOK
          // 
          this.btnOK.Location = new System.Drawing.Point(296, 60);
          this.btnOK.Name = "btnOK";
          this.btnOK.Size = new System.Drawing.Size(75, 23);
          this.btnOK.TabIndex = 3;
          this.btnOK.Text = "OK";
          this.btnOK.UseVisualStyleBackColor = true;
          this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          // 
          // frmChooseKey
          // 
          this.AcceptButton = this.btnOpen;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(375, 104);
          this.Controls.Add(this.btnOK);
          this.Controls.Add(this.btnOpen);
          this.Controls.Add(this.txtPrivateKey);
          this.Name = "frmChooseKey";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Секретный ключ";
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}