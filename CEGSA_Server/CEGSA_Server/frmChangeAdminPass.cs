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
    public partial class frmChangeAdminPass : Form
    {
        string connection = "";
        DB_CEGSA db;
        int IDUser = 0;
        string CurrPass = "";

        public frmChangeAdminPass(string con)
        {
            InitializeComponent();
            connection = con;
            db = new DB_CEGSA(con);
        }

        public frmChangeAdminPass(string con, int id)
        {
            InitializeComponent();
            connection = con;
            db = new DB_CEGSA(con);
            IDUser = id;
            
            var clients = from U in db.User
                         where U.ID_user==IDUser
                         select U;
            foreach (User user in clients)
              CurrPass = user.Password;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtCurrentPass.Text == "" || txtNewPass1.Text == "" || txtNewPass2.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены");                
                return;
            }

            if (txtCurrentPass.Text != CurrPass)
            {
                MessageBox.Show("Текущий пароль введен неверно");
                return;
            }

            if (txtNewPass1.Text != txtNewPass2.Text)
            {
                MessageBox.Show("Введенные пароли не совпадают");
                return;
            }

            if (txtNewPass1.Text.Length < 8)
            {
                MessageBox.Show("Введите пароль длиной не менее 8 символов");
                return;
            }


            var clients = from U in db.User
                          where U.ID_user == IDUser
                          select U;
            foreach (User user in clients)
            {
                //user.Login = "Admin";
                user.Password = txtNewPass1.Text;
                //user.Fio = txtFIO.Text;
            }
            try
            {

                db.SubmitChanges();
            }
            catch
            {
                MessageBox.Show("Не удалось изменить запись");
                return;
            }
            this.Close();

        }
    }
}
