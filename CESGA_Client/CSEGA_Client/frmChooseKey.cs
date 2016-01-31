using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CESGA_Client
{
    public partial class frmChooseKey : Form
    {
        public frmChooseKey()
        {
            InitializeComponent();
        }
        public BigInteger Ki;
        public bool find = false;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            string tempKi = "";
            Ki = Sign.BI_Generate_Ki();
            tempKi = Ki.ToString();            

            try
            {
                Ki = new BigInteger(tempKi, 10);
                find = true;
                txtPrivateKey.Text = Ki.ToString();
                
            }
            catch
            {
                MessageBox.Show("Неверный ключ");
            }            

        }

      
        private void btnOK_Click(object sender, EventArgs e)
        {
          if (find) 
            this.Close();
          else
            MessageBox.Show("Введите или сгенерируйте ключ");
        }
    }
}
