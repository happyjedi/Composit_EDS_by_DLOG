using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CEGSA_Server
{
  public partial class frmAutorization : Form
  {
    public string connection;
    DB_CEGSA db;

    public frmAutorization()
    {
      InitializeComponent();

    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
      if (txtLogin.Text == "" || txtPassword.Text == "")
      {
        MessageBox.Show("Все поля должны быть заполнены");
        return;
      }



      SqlConnection connect = new SqlConnection(connection);
      try
      {
        connect.Open();
        connect.Close();
      }
      catch
      {
        MessageBox.Show("Не удалось подключиться к БД. Проверьте параметры подключения к БД");
        return;
      }
      db = new DB_CEGSA(connection);
      var query = from U in db.User
                  where U.Login == txtLogin.Text && U.Password == txtPassword.Text
                  select U;
      bool flag = false;
      bool admin = false;
      foreach (User U in query)
      {
        flag = true;
        if ((bool)U.Admin) admin = true;
      }
      if (!flag)
      {
        MessageBox.Show("Неверные имя или пароль");
        return;
      }
      if (!admin)
      {
        MessageBox.Show("Для дальнейших действий необходимы права администратора");
        return;
      }
      enter = true;
      this.Close();
    }
    bool enter = false;
    private void frmAutorization_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (!enter)
        Application.Exit();
    }

    private void label3_Click(object sender, EventArgs e)
    {
      frmConnection frmConnect = new frmConnection();
        //frmCon frmConnect = new frmCon();
      frmConnect.ShowDialog();
      connection = frmConnect.connection;
    }

    private void frmAutorization_Load(object sender, EventArgs e)
    {
      try
      {

        FileStream f = new FileStream("Settings.txt", FileMode.Open);
        StreamReader str = new StreamReader(f);
        string server = str.ReadLine();
        string name = str.ReadLine();
        str.Close();
        connection = @"Data Source=" + server + ";Initial Catalog=" + name + ";Integrated Security=True";
        SqlConnection con = new SqlConnection(connection);
        try
        {
          con.Open();
          con.Close();
        }
        catch
        {
          //  connection = @"Data Source=" + Environment.UserDomainName + ";Initial Catalog=Anketirovanie;Integrated Security=True";
        }
      }
      catch
      {
        MessageBox.Show("Не удалось подключиться к базе данных. Проверьте параметры подключения");
      }

    }

    private void frmAutorization_Activated(object sender, EventArgs e)
    {


    }
  }
}
