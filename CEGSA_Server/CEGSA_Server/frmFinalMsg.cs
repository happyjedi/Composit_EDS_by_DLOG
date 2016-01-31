using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CEGSA_Server
{
  public partial class frmFinalMsg : Form
  {
    public bool flagNewSession = true;
    public void ChangePrompt(String Prompt)
    {
      lblPrompt.Text = Prompt;
    }
    public frmFinalMsg()
    {
      InitializeComponent();
    }    

    private void btnNewSession_Click(object sender, EventArgs e)
    {
      flagNewSession = true;
      this.Close();
    }

    private void frmFinalMsg_Load(object sender, EventArgs e)
    {

    }

    private void frmFinalMsg_FormClosing(object sender, FormClosingEventArgs e)
    {
      flagNewSession = true;
    }
  }
}
