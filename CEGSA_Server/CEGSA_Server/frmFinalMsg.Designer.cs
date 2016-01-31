namespace CEGSA_Server
{
  partial class frmFinalMsg
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
      this.lblPrompt = new System.Windows.Forms.Label();
      this.btnNewSession = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblPrompt
      // 
      this.lblPrompt.AutoSize = true;
      this.lblPrompt.Location = new System.Drawing.Point(12, 25);
      this.lblPrompt.Name = "lblPrompt";
      this.lblPrompt.Size = new System.Drawing.Size(319, 13);
      this.lblPrompt.TabIndex = 0;
      this.lblPrompt.Text = "Композиционная ЭЦП успешно сформирована и сохранена в";
      // 
      // btnNewSession
      // 
      this.btnNewSession.Location = new System.Drawing.Point(123, 76);
      this.btnNewSession.Name = "btnNewSession";
      this.btnNewSession.Size = new System.Drawing.Size(89, 23);
      this.btnNewSession.TabIndex = 2;
      this.btnNewSession.Text = "Новая сессия";
      this.btnNewSession.UseVisualStyleBackColor = true;
      this.btnNewSession.Click += new System.EventHandler(this.btnNewSession_Click);
      // 
      // frmFinalMsg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(334, 111);
      this.Controls.Add(this.btnNewSession);
      this.Controls.Add(this.lblPrompt);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmFinalMsg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Генерация завершена";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFinalMsg_FormClosing);
      this.Load += new System.EventHandler(this.frmFinalMsg_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblPrompt;
    private System.Windows.Forms.Button btnNewSession;
  }
}