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
  public partial class frmClient : Form
  {
    string connection = "";
    DB_CEGSA db;
    int IDUser = 0;
    bool NEW = true;
    public frmClient(string con)
    {
      InitializeComponent();
      connection = con;
      db = new DB_CEGSA(con);
    }

    public frmClient(string con, int id)
    {
      InitializeComponent();
      connection = con;
      db = new DB_CEGSA(con);
      IDUser = id;
      NEW = false;
      var clients = from U in db.User
                    where U.ID_user == IDUser
                    select U;
      foreach (User user in clients)
      {
        txtLogin.Text = user.Login;
        txtPassword.Text = user.Password;
        txtFIO.Text = user.Fio;
      }


    }

    private void frmClient_Load(object sender, EventArgs e)
    {

    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (txtLogin.Text == "" || txtPassword.Text == "" || txtFIO.Text == "")
      {
        MessageBox.Show("Все поля должны быть заполнены");
        return;
      }
      if (NEW)
      {
        string login = txtLogin.Text;
        var clients = from U in db.User
                      where U.Login == login
                      select U;
        foreach (User user in clients)
        {
          MessageBox.Show("Пользователь с таким логином уже существует");
          txtLogin.Select();
          return;
        }
        User client = new User();
        client.Fio = txtFIO.Text;
        client.Login = txtLogin.Text;
        client.Password = txtPassword.Text;
        client.Admin = false;
        try
        {
          db.User.InsertOnSubmit(client);
          db.SubmitChanges();
        }
        catch
        {
          MessageBox.Show("Не удалось добавить запись");
          return;
        }
      }
      else
      {
        var clients = from U in db.User
                      where U.ID_user == IDUser
                      select U;
        foreach (User user in clients)
        {
          user.Login = txtLogin.Text;
          user.Password = txtPassword.Text;
          user.Fio = txtFIO.Text;
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
      }
      this.Close();

    }
  }
}
