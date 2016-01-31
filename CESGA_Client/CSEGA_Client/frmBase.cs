using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;


namespace CESGA_Client
{
  public partial class frmBase : Form
  {
    public frmBase()
    {
      InitializeComponent();
    }

    #region Private Members

    // Client socket
    private Socket clientSocket;


    // Server End Point
    private EndPoint epServer;

    // Data stream
    private byte[] dataStream = new byte[1024];

    BigInteger var_P;
    BigInteger var_G;
    BigInteger var_Q;
    BigInteger var_Ti;
    BigInteger var_Ri;
    BigInteger var_Hi;
    BigInteger var_Si;
    BigInteger var_Ki;
    BigInteger var_Yi;
    BigInteger var_E;
    BigInteger var_S;



    // Display message delegate
    private delegate void DisplayMessageDelegate(string message);


    #endregion
    private void frmBase_Load(object sender, EventArgs e)
    {


      btnSign.Visible = false;
      try
      {
        if (this.clientSocket != null)
        {
          // Initialise a packet object to store the data to be sent
          Packet sendData = new Packet();
          sendData.ChatDataIdentifier = DataIdentifier.LogOut;
          sendData.ChatMessage = null;

          // Get packet as byte array
          byte[] byteData = sendData.GetDataStream();

          // Send packet to the server
          this.clientSocket.SendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer);

          // Close the socket
          this.clientSocket.Close();
        }
      }
      catch (ObjectDisposedException) { }
      catch (ArgumentException) { }
      catch (Exception ex)
      {
        MessageBox.Show("Closing Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
      if (txtPassword.Text == "" || txtLogin.Text == "")
      {
        MessageBox.Show("Заполните все поля");
        return;
      }
      string login = txtLogin.Text;
      string password = txtPassword.Text;

      string mes = "~|" + login + "|" + password;
      Packet sendData = new Packet();
      sendData.ChatMessage = mes;
      sendData.ChatDataIdentifier = DataIdentifier.Message;
      byte[] data = sendData.GetDataStream();
      // Initialise socket
      //// Get packet as byte array


      // Send data to server
      clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epServer, new AsyncCallback(this.SendData), null);
      lblStatus.Text = "Процесс авторизации";


    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      /////////// Поиск ip клиента из DNS таблицы хоста
      IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
      string ip = "";
      for (int i = 0; i < host.AddressList.Length; i++)
      {
        ip = host.AddressList[i].ToString();
        string pattern = @"\d\d?\d?\.\d\d?\d?\.\d\d?\d?\.\d\d?\d?";
        Regex regex = new Regex(pattern);
        Match match = regex.Match(ip);
        if (match.Success)
        {
          break;
        }
      }

      try
      {

        // Initialise a packet object to store the data to be sent
        Packet sendData = new Packet();
        sendData.ChatMessage = null;
        sendData.ChatDataIdentifier = DataIdentifier.LogIn;

        // Initialise socket
        if (clientSocket != null)
        {
          try
          {
            clientSocket.Close();
          }
          catch { }
        }
        this.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint ClientIPE;
        if (ip != "")
          ClientIPE = new IPEndPoint(IPAddress.Parse(ip), 8080);
        else
        {
          MessageBox.Show("Не удалось настроить ip адрес Клиента");
          return;
        }

        clientSocket.Bind(ClientIPE);
        IPAddress serverIP;
        // Initialise server IP
        if (txtIP.Text.Trim() != "")
          serverIP = IPAddress.Parse(txtIP.Text.Trim());
        else
        {
          MessageBox.Show("Введите ip адрес Сервера");
          return;
        }

        // Initialise the IPEndPoint for the server and use port 30000
        IPEndPoint server = new IPEndPoint(serverIP, 30000);

        // Initialise the EndPoint for the server
        epServer = (EndPoint)server;

        // Get packet as byte array
        byte[] data = sendData.GetDataStream();

        // Send data to server
        clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epServer, new AsyncCallback(this.SendData), null);

        // Initialise data stream
        this.dataStream = new byte[1024];

        // Begin listening for broadcasts
        clientSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epServer, new AsyncCallback(this.ReceiveData), null);
      }
      catch (ObjectDisposedException)
      {
        MessageBox.Show("Не удалось подключиться к указанному серверу");
      }
      catch (ArgumentException) { }
      catch (Exception ex)
      {
        try
        {
          clientSocket.Close();
        }
        catch { }
        if (ex.Message == "Удаленный хост принудительно разорвал существующее подключение")
          MessageBox.Show("Не удалось подключиться к серверу", "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
        else
          MessageBox.Show("Connection Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }




    }

    #region Send And Receive

    private void SendData(IAsyncResult ar)
    {
      try
      {
        clientSocket.EndSend(ar);
      }
      catch (ObjectDisposedException) { }
      catch (ArgumentException) { }
      catch (Exception ex)
      {
        MessageBox.Show("Send Data: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    delegate void SetInvisiblePanel();
    delegate void SetInvisibleAutorize();
    delegate void SetEnabledChoose();
    delegate void SetlblStatus(string text);
    delegate void Progress();
    delegate void LogOut();
    delegate void Tab(int i);
    void ChooseTabPage(int i)
    {
      tabControl1.SelectedIndex = i;
    }
    void UnEnabledAll()
    {
      progressBar1.Value = 0;

      txtIP.Enabled = true;
      btnConnect.Enabled = true;
      btnSign.Visible = false;
      grpAutorize.Enabled = false;
      txtFileName.Enabled = false;
      btnChooseFile.Enabled = false;
      txtLogin.Text = "";
      txtPassword.Text = "";
      txtFileName.Text = "";
      var_P = new BigInteger(0);
      var_G = new BigInteger(0);
      var_Q = new BigInteger(0);
      var_Ti = new BigInteger(0);
      var_Ri = new BigInteger(0);
      var_Hi = new BigInteger(0);
      var_Si = new BigInteger(0);
      var_Ki = new BigInteger(0);
      var_Yi = new BigInteger(0);
      var_E = new BigInteger(0);
      var_S = new BigInteger(0);

    }
    void RaiseProgress()
    {
      if (progressBar1.Value < 93)
        progressBar1.Value += 7;
    }
    void MaxProgress()
    {
      progressBar1.Value = 100;
    }
    void SetlblStatusText(string text)
    {
      lblStatus.Text = text;
    }
    void HideConnect()
    {
      txtIP.Enabled = false;
      btnConnect.Enabled = false;
      grpAutorize.Enabled = true;

      txtLogin.Select();
      this.AcceptButton = btnEnter;
      lblStatus.Text = "Авторизация";
    }
    void HideAutorize()
    {
      grpAutorize.Enabled = false;
      btnSign.Visible = true;
      MessageBox.Show("Вы успешно авторизованы");
      this.AcceptButton = btnChooseFile;
      tabControl1.TabPages[1].Select();
      lblStatus.Text = "Выбор файла";

    }
    void ServerStartGeneration()
    {
      lblStatus.Text = "Ожидаем завершения генерации ключей на сервере...";
    }
    void EnabledChoose()
    {
      btnChooseFile.Enabled = true;
      txtFileName.Enabled = true;
      btnSign.Enabled = true;
      this.AcceptButton = btnChooseFile;
      lblStatus.Text = "Выбор файла";
    }


    private void ReceiveData(IAsyncResult ar)
    {
      try
      {
        // Receive all data
        this.clientSocket.EndReceiveFrom(ar, ref epServer);

        // Initialise a packet object to store the received data
        Packet receivedData = new Packet(this.dataStream);

        // Update display through a delegate
        if (receivedData.ChatMessage != null)
        {
          ///////// Разрешение на авторизацию после успешного подключения к серверу
          if (receivedData.ChatMessage == "#")
          {
            if (grpAutorize.InvokeRequired)
              grpAutorize.Invoke(new SetInvisiblePanel(HideConnect), null);


          }
          else
            if (receivedData.ChatMessage[0] == '!')
            {
              string[] temp = receivedData.ChatMessage.Split('|');
              if (temp[1] == "True")
              {
                if (grpAutorize.InvokeRequired)
                {
                  grpAutorize.Invoke(new SetInvisibleAutorize(HideAutorize), null);
                  grpAutorize.Invoke(new Tab(ChooseTabPage), 1);
                }

              }
              else
                if (temp[1] == "False")
                  MessageBox.Show("Неверные логин или пароль");
                else
                  MessageBox.Show("Сервер занят! Повторите попытку позднее.");
            }
            else
              if (receivedData.ChatMessage == "AllClOK")
              {
                if (grpAutorize.InvokeRequired)
                {
                  grpAutorize.Invoke(new SetlblStatus(SetlblStatusText), "Все клиенты подключены");
                  grpAutorize.Invoke(new SetEnabledChoose(ServerStartGeneration), null);
                  grpAutorize.Invoke(new Progress(RaiseProgress), null);

                }



              }
              else
                if (receivedData.ChatMessage[0] == 'P')
                {
                  /////СОХРАНЕНИЕ P  
                  if (grpAutorize.InvokeRequired)
                    grpAutorize.Invoke(new Progress(RaiseProgress), null);


                  string[] temp = receivedData.ChatMessage.Split('|');
                  var_P = new BigInteger(temp[1], 10);
                  //MessageBox.Show(var_P.ToString());                        
                }
                else
                  if (receivedData.ChatMessage[0] == 'Q')
                  {
                    /////СОХРАНЕНИЕ Q   
                    if (grpAutorize.InvokeRequired)
                      grpAutorize.Invoke(new Progress(RaiseProgress), null);
                    string[] temp = receivedData.ChatMessage.Split('|');
                    var_Q = new BigInteger(temp[1], 10);
                    // MessageBox.Show(var_Q.ToString());
                  }
                  else
                    if (receivedData.ChatMessage[0] == 'G')
                    {
                      /////СОХРАНЕНИЕ G  
                      if (grpAutorize.InvokeRequired)
                        grpAutorize.Invoke(new Progress(RaiseProgress), null);
                      string[] temp = receivedData.ChatMessage.Split('|');
                      var_G = new BigInteger(temp[1], 10);
                      //MessageBox.Show(var_G.ToString());

                      ///////Генерируем Ti вычисляем Ri и отсылаем его серверу
                      var_Ti = Sign.BI_Generate_Ti(var_Q);
                      if (grpAutorize.InvokeRequired)
                        grpAutorize.Invoke(new Progress(RaiseProgress), null);
                      var_Ri = Sign.Calculate_Ri(var_G, var_P, var_Ti);
                      if (grpAutorize.InvokeRequired)
                        grpAutorize.Invoke(new Progress(RaiseProgress), null);
                      Packet sendData = new Packet();
                      sendData.ChatMessage = "R|" + var_Ri.ToString();
                      sendData.ChatDataIdentifier = DataIdentifier.Message;
                      byte[] data = sendData.GetDataStream();

                      // Send data to server
                      clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epServer, new AsyncCallback(this.SendData), null);
                    }
                    else
                      if (receivedData.ChatMessage[0] == 'E')
                      {
                        if (grpAutorize.InvokeRequired)
                          grpAutorize.Invoke(new Progress(RaiseProgress), null);
                        string[] temp = receivedData.ChatMessage.Split('|');
                        var_E = new BigInteger(temp[1], 10);
                        //MessageBox.Show("E= "+var_E.ToString());
                        if (grpAutorize.InvokeRequired)
                          grpAutorize.Invoke(new SetEnabledChoose(EnabledChoose), null);

                      }
                      else
                        if (receivedData.ChatMessage[0] == 'S')
                        {
                          /////СОХРАНЕНИЕ S   
                          if (grpAutorize.InvokeRequired)
                            grpAutorize.Invoke(new Progress(RaiseProgress), null);
                          string[] temp = receivedData.ChatMessage.Split('|');
                          var_S = new BigInteger(temp[1], 10);
                          //MessageBox.Show(var_S.ToString());
                          Packet sendData = new Packet();
                          sendData.ChatMessage = "Y|" + var_Yi.ToString();
                          sendData.ChatDataIdentifier = DataIdentifier.Message;
                          byte[] data = sendData.GetDataStream();

                          // Send data to server
                          clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epServer, new AsyncCallback(this.SendData), null);
                        }

                        else
                          if (receivedData.ChatMessage == "Need_Hi")
                          {
                            if (grpAutorize.InvokeRequired)
                              grpAutorize.Invoke(new Progress(RaiseProgress), null);
                            Packet sendData = new Packet();
                            sendData.ChatMessage = "H|" + var_Hi.ToString();
                            sendData.ChatDataIdentifier = DataIdentifier.Message;
                            byte[] data = sendData.GetDataStream();
                            // Send data to server
                            clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epServer, new AsyncCallback(this.SendData), null);
                          }
                          else
                            if (receivedData.ChatMessage == "OK")
                            {                            
                              
                              if (grpAutorize.InvokeRequired)
                              {
                                grpAutorize.Invoke(new Progress(MaxProgress), null);
                                grpAutorize.Invoke(new SetlblStatus(SetlblStatusText), "Документ подписан");
                                MessageBox.Show("Операция подписания успешно завершена", "Клиент");
                              }

                            }
                            else
                              if (receivedData.ChatMessage == "VerifyFalse")
                              {
                                if (grpAutorize.InvokeRequired)
                                {
                                  grpAutorize.Invoke(new Progress(MaxProgress), null);
                                  grpAutorize.Invoke(new SetlblStatus(SetlblStatusText), "Проверка завершена");
                                }
                                MessageBox.Show("Подпись неверна!!!", "Клиент");

                              }
                              else
                                if (receivedData.ChatMessage == "VerifyTrue")
                                {
                                  if (grpAutorize.InvokeRequired)
                                  {
                                    grpAutorize.Invoke(new Progress(MaxProgress), null);
                                    grpAutorize.Invoke(new SetlblStatus(SetlblStatusText), "Проверка завершена");
                                  }
                                  MessageBox.Show("Подпись Верна!!!", "Клиент");
                                }
                                else
                                  if (receivedData.ChatMessage == "LogOut")
                                  {
                                    if (grpAutorize.InvokeRequired)
                                    {
                                      grpAutorize.Invoke(new SetlblStatus(SetlblStatusText), "Подключение с сервером");
                                      grpAutorize.Invoke(new LogOut(UnEnabledAll), null);
                                      grpAutorize.Invoke(new Tab(ChooseTabPage), 0);
                                    }
                                    MessageBox.Show("Соединение с сервером разорвано!!!", "Клиент");
                                  }
        }

        // Reset data stream
        this.dataStream = new byte[1024];

        // Continue listening for broadcasts
        clientSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epServer, new AsyncCallback(this.ReceiveData), null);

      }
      catch (ObjectDisposedException)
      { }
      catch (ArgumentException) { }
      catch (Exception ex)
      {
        if (ex.Message == "Удаленный хост принудительно разорвал существующее подключение")
          MessageBox.Show("Не удалось подключиться к серверу", "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
        else
          MessageBox.Show("Receive Data: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);

      }
    }

    #endregion

    private void btnChooseFile_Click(object sender, EventArgs e)
    {


      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        txtFileName.Text = openFileDialog1.FileName;

      }
    }

    private void panChooseFile_Paint(object sender, PaintEventArgs e)
    {

    }
    public class Hash_Dll
    {
      [DllImport("HASH_DLL.dll", EntryPoint = "GostHashFile", CharSet = CharSet.Ansi)]
      [return: MarshalAs(UnmanagedType.AnsiBStr)]
      public static extern String GostHashFile(String Filename);
    }
    private void frmBase_FormClosing(object sender, FormClosingEventArgs e)
    {
      //ClientLogOut();
      try
      {
        clientSocket.Dispose();
      }
      catch
      { }

    }

    private void btnNext1_Click(object sender, EventArgs e)
    {

      if (txtFileName.Text == "")
      {
        MessageBox.Show("Выберите файл", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      ////////////////////////////////////////////////////////////////Получение ki
      frmChooseKey frmKey = new frmChooseKey();
      frmKey.ShowDialog();
      
      if (frmKey.find)
        var_Ki = frmKey.Ki;
      else
      {
        return;
      }      
      txtFileName.Enabled = false;
      btnChooseFile.Enabled = false;
      btnSign.Enabled = false;     
      String hash = Hash_Dll.GostHashFile(txtFileName.Text);
      var_Hi = new BigInteger(hash, 16);
      if (grpAutorize.InvokeRequired)
        grpAutorize.Invoke(new Progress(RaiseProgress), null);
      
   
      if (grpAutorize.InvokeRequired)
        grpAutorize.Invoke(new Progress(RaiseProgress), null);
   

      lblStatus.Text = "Идет генерация ЭЦП...";
      var_Si = Sign.Calculate_Si(var_Ti, var_Hi, var_Ki, var_E, var_Q);
      if (grpAutorize.InvokeRequired)
        grpAutorize.Invoke(new Progress(RaiseProgress), null);      
      var_Yi = Sign.BI_Generate_Yi(var_P, var_G, var_Ki);
      if (grpAutorize.InvokeRequired)
        grpAutorize.Invoke(new Progress(RaiseProgress), null);
      //MessageBox.Show("Yi= " + var_Yi.ToString());
      Packet sendData = new Packet();
      sendData.ChatMessage = "S|" + var_Si.ToString();
      sendData.ChatDataIdentifier = DataIdentifier.Message;
      byte[] data = sendData.GetDataStream();
      // Send data to server
      clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epServer, new AsyncCallback(this.SendData), null);



    }



    private void mnuNewSession_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Вы уверены, что хотите завершить текущую сессию?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
      {
        UnEnabledAll();
        tabControl1.SelectedIndex = 0;
        ClientLogOut();
      }
    }

    private void mnuExit_Click(object sender, EventArgs e)
    {
      this.Close();

    }

    private void mnuAbout_Click(object sender, EventArgs e)
    {
      frmAbout frmAbout = new frmAbout();
      frmAbout.ShowDialog();
    }
    void ClientLogOut()
    {
      Packet sendData = new Packet();
      sendData.ChatMessage = "LogOut";
      sendData.ChatDataIdentifier = DataIdentifier.Message;
      byte[] data = sendData.GetDataStream();
      clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epServer, new AsyncCallback(this.SendData), null);
    }

    private void mnuHelpItem_Click(object sender, EventArgs e)
    {
      Process.Start("HELP_Client.chm");
    }
  }
}
