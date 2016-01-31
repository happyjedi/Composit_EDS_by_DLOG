using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace CEGSA_Server
{
    public partial class frmConnection : Form
    {
        public string connection = @"Data Source=" + Environment.UserDomainName + ";Initial Catalog=DB_CESGSA;Integrated Security=True";
        
        public frmConnection()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text;
            string name = txtName.Text;

            connection = @"Data Source=" + server + ";Initial Catalog=" + name + ";Integrated Security=True";

            SqlConnection con = new SqlConnection(connection);
            try
            {
                con.Open();
                con.Close();
                FileStream f = new FileStream("Settings.txt", FileMode.Create);
                StreamWriter str = new StreamWriter(f);
                str.WriteLine(server);
                str.WriteLine(name);
                str.Close();
                this.Close();

            }
            catch
            {

                connection = @"Data Source=" + server + ";Initial Catalog=master;Integrated Security=True";

                con = new SqlConnection(connection);
                try
                {
                    con.Open();
                    con.Close();
                    if (MessageBox.Show("Базы с таким именем не существует. Хотите ее создать?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        string NameServer, strDBName;
                        NameServer = txtServer.Text;
                        strDBName = txtName.Text;
                        string ConnectionString = @"Data Source=" + NameServer + ";Initial Catalog=master;Integrated Security=True";//формируем строку подключения к БД
                        SqlConnection conn = new SqlConnection(ConnectionString);
                        SqlCommand command = new SqlCommand("CREATE DATABASE " + strDBName, conn);
                        command.Connection.Open();
                        command.Connection.ChangeDatabase("master");
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message,"master mistake");
                            return;
                        }

                        finally
                        {
                            command.Connection.Close();
                        }
                        conn = new SqlConnection(ConnectionString);
                        string sql = "CREATE TABLE [dbo].[User]([ID_user] [int] IDENTITY(1,1) NOT NULL,	[Login] [varchar](20) COLLATE Cyrillic_General_CI_AS NULL,	[Password] [varchar](64) COLLATE Cyrillic_General_CI_AS NULL,	[Fio] [varchar](60) COLLATE Cyrillic_General_CI_AS NULL,	[Admin] [bit] NULL, CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED (	[ID_user] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]";

                        command = new SqlCommand(sql, conn);
                        command.Connection.Open();
                        command.Connection.ChangeDatabase(strDBName);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        finally
                        {
                            command.Connection.Close();
                        }
                        sql = "Insert into [dbo].[User] (Login, Password,FIO,Admin) values ('Admin','Admin','Admin','true')";

                        command = new SqlCommand(sql, conn);
                        command.Connection.Open();
                        command.Connection.ChangeDatabase(strDBName);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        //finally
                        //{
                        //    command.Connection.Close();
                        //}





                        ConnectionString = @"Data Source=" + NameServer + ";Initial Catalog=" + strDBName + ";Integrated Security=True";//формируем строку подключения к БД
                        conn = new SqlConnection(ConnectionString);
                        sql = "CREATE TABLE [dbo].[Session](	[ID] [int] IDENTITY(1,1) NOT NULL,	[S] [varchar](256) COLLATE Cyrillic_General_CI_AS NULL,	[E] [varchar](256) COLLATE Cyrillic_General_CI_AS NULL,	[g] [varchar](1024) COLLATE Cyrillic_General_CI_AS NULL,	[p] [varchar](1024) COLLATE Cyrillic_General_CI_AS NULL,	[y] [varchar](1024) COLLATE Cyrillic_General_CI_AS NULL,	[q] [varchar](256) COLLATE Cyrillic_General_CI_AS NULL, CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED (	[ID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]";
                        command.CommandText = sql;
                        //command = new SqlCommand(sql, conn);
                        //command.Connection.Open();
                        //command.Connection.ChangeDatabase(strDBName);
                        try
                        {



                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Miasatke Session");
                            return;
                        }
                        finally
                        {
                            command.Connection.Close();
                        }

                        
                        MessageBox.Show("База создана!!!");
                        


                    }
                }
                catch (Exception ex)
                {

                    //MessageBox.Show("Не удалось подключиться к БД. Проверьте параметры подключения");
                    MessageBox.Show(ex.Message);
                }

            }
            

        }

        private void frmConnection_Load(object sender, EventArgs e)
        {
            try
            {

                FileStream f = new FileStream("Settings.txt", FileMode.Open);
                StreamReader str = new StreamReader(f);
                string server = str.ReadLine();
                string name = str.ReadLine();
                str.Close();
                connection = @"Data Source=" + server + ";Initial Catalog=" + name + ";Integrated Security=True";
                txtName.Text = name;
                txtServer.Text = server;
                SqlConnection con = new SqlConnection(connection);
                try
                {
                    con.Open();
                    con.Close();
                }
                catch
                {
                }

            }

            catch
            {
                txtServer.Text = Environment.UserDomainName;
                txtName.Text = "DB_CEGSA";
            }

        
        }
    }
}
