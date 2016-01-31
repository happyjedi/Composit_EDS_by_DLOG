using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace CEGSA_Server
{
  public partial class frmBase : Form
  {
    string connection = "";
    DB_CEGSA db;

    #region Private Members

    // Structure to store the client information
    class CLIENT
    {
      public User user;
      public EndPoint ep;
    }
    List<CLIENT> CLientsList = new List<CLIENT>();

    // Listing of clients
    private ArrayList clientList;

    // Server socket
    private Socket serverSocket;

    BigInteger var_P;
    BigInteger var_G;
    BigInteger var_Q;
    BigInteger var_Y;
    BigInteger var_E;
    BigInteger var_S;
    BigInteger var_R;
    BigInteger var_NewE;
    BigInteger var_NewR;
    BigInteger[] var_Si;
    BigInteger[] var_Hi;
    BigInteger[] var_Ri;
    BigInteger[] var_Yi;
    int var_Ri_Count;
    int var_Yi_Count;
    int var_Si_Count;
    int var_Hi_Count;
    String SignFileName;
    // Data stream
    private byte[] dataStream = new byte[1028];

    #endregion
    delegate void Progress();  

    void RaiseProgress()
    {
      progressBar1.Value += 10;
    }
    void MaxProgress()
    {
      progressBar1.Value = 100;
    }

    delegate void CloseForm();
    void CloseProgram()
    {
      Close();
    }

    delegate void SetlblStatus(string text);
    void SetlblStatusText(string text)
    {
      lblStatus.Text = text;
    }
    public frmBase()
    {
      InitializeComponent();
      frmAutorization frmA = new frmAutorization();
      frmA.ShowDialog();

      connection = frmA.connection;
      db = new DB_CEGSA(connection);
    }
    List<User> listClients = new List<User>();
    void ReadListClients()
    {
        try
        {
            var clients = from U in db.User
                          where U.Admin != true
                          select U;
            listClients = new List<User>();
            lstClients.Items.Clear();
            foreach (User user in clients)
            {
                if (lstCurrentClients.Items.IndexOf(user.Login) == -1)
                    lstClients.Items.Add(user.Login);
                listClients.Add(user);
            }
        }
        catch
        {
        }

    }

    private void frmBase_Load(object sender, EventArgs e)
    {
      ReadListClients();
      IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
      string ip = "";
      cmbServerAddress.Items.Clear();
      for (int i = 0; i < host.AddressList.Length; i++)
      {
        ip = host.AddressList[i].ToString();
        string pattern = @"\d\d?\d?\.\d\d?\d?\.\d\d?\d?\.\d\d?\d?";
        Regex regex = new Regex(pattern);
        Match match = regex.Match(ip);
        if (match.Success)
          cmbServerAddress.Items.Add(ip);
      }
      if (cmbServerAddress.Items.Count > 0)
        cmbServerAddress.Text = cmbServerAddress.Items[0].ToString();
    }

    private void tbtnAdd_Click(object sender, EventArgs e)
    {
      frmClient frmC = new frmClient(connection);
      frmC.ShowDialog();
      ReadListClients();
    }
    void EditClient()
    {
      int id = 0;
      string login = "";
      try
      {
        login = lstClients.SelectedItem.ToString();
      }
      catch { return; }
      var clients = from U in db.User
                    where U.Login == login
                    select U;
      foreach (User U in clients)
        id = U.ID_user;
      frmClient frmC = new frmClient(connection, id);
      frmC.ShowDialog();
      db = new DB_CEGSA(connection);
      ReadListClients();
    }
    private void tbtnEdit_Click(object sender, EventArgs e)
    {
      EditClient();
    }

    private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void lstClients_DoubleClick(object sender, EventArgs e)
    {
      EditClient();
    }

    private void tbtnDel_Click(object sender, EventArgs e)
    {
      int id = 0;
      string login = "";
      try
      {
        login = lstClients.SelectedItem.ToString();
        if (MessageBox.Show("Вы действительно хотите удалить выбранного клиента", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
        {
          var clients = from U in db.User
                        where U.Login == login
                        select U;
          try
          {
            foreach (User U in clients)
              db.User.DeleteOnSubmit(U);
            db.SubmitChanges();
            ReadListClients();
          }
          catch
          {
            MessageBox.Show("Не удалось удалить клиента");
            return;
          }
        }

      }
      catch { return; }

    }

    private void btnAddClient_Click(object sender, EventArgs e)
    {
      try
      {
        string login = lstClients.SelectedItem.ToString();
        lstCurrentClients.Items.Add(login);
        lstClients.Items.Remove(lstClients.SelectedItem);
      }
      catch { return; }


    }

    private void btnAddAllClients_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < lstClients.Items.Count; i++)
        lstCurrentClients.Items.Add(lstClients.Items[i]);
      lstClients.Items.Clear();
    }

    private void btnDelClient_Click(object sender, EventArgs e)
    {
      try
      {
        string login = lstCurrentClients.SelectedItem.ToString();
        lstClients.Items.Add(login);
        lstCurrentClients.Items.Remove(lstCurrentClients.SelectedItem);
      }
      catch { return; }
    }

    private void btnDelAllClients_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < lstCurrentClients.Items.Count; i++)
        lstClients.Items.Add(lstCurrentClients.Items[i]);
      lstCurrentClients.Items.Clear();
    }

    void EditAdmin()
    {
      int id = 0;
      string login = "Admin";

      var Admin = from U in db.User
                  where U.Login == login
                  select U;
      foreach (User U in Admin)
        id = U.ID_user;
      frmChangeAdminPass frmC = new frmChangeAdminPass(connection, id);
      frmC.ShowDialog();
      db = new DB_CEGSA(connection);
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      EditAdmin();
    }


    private void btnStart_Click(object sender, EventArgs e)
    {
      if (lstCurrentClients.Items.Count < 1)
      {
        MessageBox.Show("Добавьте клиентов в список");
        return;
      }
      cmbServerAddress.Enabled = false;
      lstCurrentClients.SelectionMode = SelectionMode.None;
      lblStatus.Text = "Ожидание подключения всех клиентов";
      for (int i = 0; i < lstCurrentClients.Items.Count; i++)
        lstCurrentClients.SetItemChecked(i, false);
      btnAddAllClients.Enabled = false;
      btnAddClient.Enabled = false;
      btnDelAllClients.Enabled = false;
      btnDelClient.Enabled = false;
      tbtnAdd.Enabled = false;
      tbtnDel.Enabled = false;
      tbtnEdit.Enabled = false;
      tbtnChangeAdminPass.Enabled = false;
      lstClients.Enabled = false;
      listClients = new List<User>();
      for (int i = 0; i < lstCurrentClients.Items.Count; i++)
      {
        var query = from U in db.User
                    where U.Login == lstCurrentClients.Items[i].ToString()
                    select U;
        foreach (User U in query)
          listClients.Add(U);

      }

      btnStart.Enabled = false;
      try
      {

        /////////// Поиск ip сервера из DNS таблицы хоста                         


        // Initialise the ArrayList of connected clients
        this.clientList = new ArrayList();


        // Initialise the socket
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPEndPoint server;
        if (cmbServerAddress.Text != "")
          server = new IPEndPoint(IPAddress.Parse(cmbServerAddress.Text), 30000);
        else
        {
          MessageBox.Show("Не удалось настроить ip адрес Сервера");
          return;
        }
        //txtIPAddress.Text = ip;

        serverSocket.Bind(server);
        // Initialise the IPEndPoint for the clients
        IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);

        // Initialise the EndPoint for the clients
        EndPoint epSender = (EndPoint)clients;

        // Start listening for incoming data
        serverSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveData), epSender);

      }
      catch (ObjectDisposedException) { }
      catch (ArgumentException) { }
      catch (Exception ex)
      {

        MessageBox.Show("Load Error: " + ex.Message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }
    #region Send And Receive

    public void SendData(IAsyncResult asyncResult)
    {
      try
      {
        serverSocket.EndSend(asyncResult);
      }
      catch (ObjectDisposedException) { }
      catch (ArgumentException) { }
      catch (Exception ex)
      {
        MessageBox.Show("SendData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    delegate void SetText(string text);
    delegate void BeginNewSes();
    void BeginNewSession()
    {
        NewSession();
    }
    int kol_clients = 0;
    bool AllowAutorize = true;
    delegate void SetChecked(int i);
    void Checked(int i)
    {
      lstCurrentClients.SetItemChecked(i, true);
    }
    private void ReceiveData(IAsyncResult asyncResult)
    {
      try
      {
        byte[] data;

        // Initialise a packet object to store the received data
        Packet receivedData = new Packet(this.dataStream);

        // Initialise a packet object to store the data to be sent
        Packet sendData = new Packet();

        // Initialise the IPEndPoint for the clients
        IPEndPoint clients = new IPEndPoint(IPAddress.Any, 8080);

        // Initialise the EndPoint for the clients
        EndPoint epSender = (EndPoint)clients;
        IPEndPoint broadcast = new IPEndPoint(IPAddress.Broadcast, 0);
        EndPoint epBroadcast = (EndPoint)broadcast;
        // Receive all data
        serverSocket.EndReceiveFrom(asyncResult, ref epSender);

        // Start populating the packet to be sent
        sendData.ChatDataIdentifier = receivedData.ChatDataIdentifier;

        switch (receivedData.ChatDataIdentifier)
        {
          case DataIdentifier.Message:
            {
              if (receivedData.ChatMessage[0] == '~')
              {
                bool find = false;
                bool OutSession = true;
                if (AllowAutorize)
                {
                  string[] temp = receivedData.ChatMessage.Split('|');
                  var query = from U in db.User
                              where U.Login == temp[1] && U.Password == temp[2]
                              select U;

                  foreach (User U in query)
                  {
                    for (int i = 0; i < listClients.Count; i++)
                    {
                      if (U.Login == listClients[i].Login)
                      {

                        CLIENT NewClient = new CLIENT();
                        NewClient.ep = epSender;
                        NewClient.user = U;
                        bool exist = false;
                        for (int j = 0; j < CLientsList.Count; j++)
                          if (CLientsList[j].user.Login == U.Login)
                          {
                            exist = true;
                            break;
                          }
                        if (!exist)
                        {
                          CLientsList.Add(NewClient);
                          find = true;
                          kol_clients++;
                          OutSession = false;

                        }

                      }

                      if (lstCurrentClients.Items[i].ToString() == U.Login)
                        if (lstCurrentClients.InvokeRequired)
                          lstCurrentClients.Invoke(new SetChecked(Checked), i);

                    }

                  }
                }


                sendData.ChatMessage = "!";
                if (find)
                  sendData.ChatMessage += "|True";
                else
                  sendData.ChatMessage += "|False";
                //sendData.ChatMessage = "True";
                if (OutSession)
                  sendData.ChatMessage += "|Out";
                data = sendData.GetDataStream();
                serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epSender, new AsyncCallback(this.SendData), epSender);
                //  serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epSender, new AsyncCallback(this.SendData), epSender);
                if (kol_clients == listClients.Count)
                {
                  if (lstClients.InvokeRequired)
                  {
                    lstClients.Invoke(new Progress(RaiseProgress), null);
                    lstClients.Invoke(new SetText(SetlblStatusText), "Идет генерация ключей");
                  }

                  serverSocket.EnableBroadcast = true;
                  sendData.ChatMessage = "AllClOK";
                  data = sendData.GetDataStream();
                  AllowAutorize = false;

                  var_Ri = new BigInteger[kol_clients];
                  var_Si = new BigInteger[kol_clients];
                  var_Hi = new BigInteger[kol_clients];
                  var_Yi = new BigInteger[kol_clients];
                  var_Ri_Count = 0;
                  var_Si_Count = 0;
                  var_Hi_Count = 0;
                  var_Yi_Count = 0;
                  ////serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.Broadcast, epBroadcast, new AsyncCallback(this.SendData), broadcast);
                  for (int i = 0; i < CLientsList.Count; i++)
                    serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
                  ///P
                  var_P = Sign.BI_Generate_P();
                  if (lstClients.InvokeRequired)
                    lstClients.Invoke(new Progress(RaiseProgress), null);
                  sendData.ChatMessage = "P|" + var_P.ToString();

                  //if (textBox1.InvokeRequired)
                  //    textBox1.Invoke(new SetText(PrintText), sendData.ChatMessage);

                  data = sendData.GetDataStream();
                  for (int i = 0; i < CLientsList.Count; i++)
                    serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
                  //MessageBox.Show(sendData.ChatMessage);
                  /////Q
                  var_Q = Sign.BI_Generate_Q(var_P);
                  if (lstClients.InvokeRequired)
                    lstClients.Invoke(new Progress(RaiseProgress), null);
                  sendData.ChatMessage = "Q|" + var_Q.ToString();
                  data = sendData.GetDataStream();
                  for (int i = 0; i < CLientsList.Count; i++)
                    serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
                  //MessageBox.Show(sendData.ChatMessage);

                  /////G
                  var_G = Sign.BI_Generate_G(var_P, var_Q);
                  if (lstClients.InvokeRequired)
                    lstClients.Invoke(new Progress(RaiseProgress), null);
                  sendData.ChatMessage = "G|" + var_Q.ToString();
                  data = sendData.GetDataStream();
                  for (int i = 0; i < CLientsList.Count; i++)
                    serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
                  //MessageBox.Show(sendData.ChatMessage);


                }

              }
              else
                if (receivedData.ChatMessage[0] == 'R')
                {
                  if (var_Ri_Count < kol_clients)
                  {
                    string[] temp = receivedData.ChatMessage.Split('|');
                    var_Ri[var_Ri_Count] = new BigInteger(temp[1], 10);
                    //MessageBox.Show("Ri[" + var_Ri_Count.ToString() + "]= "+ var_Ri[var_Ri_Count].ToString());
                    var_Ri_Count++;
                    if (var_Ri_Count == kol_clients)
                    {
                      var_R = Sign.Calculate_R(var_Ri, var_P);
                      if (lstClients.InvokeRequired)
                        lstClients.Invoke(new Progress(RaiseProgress), null);
                      //MessageBox.Show(var_R.ToString());
                      var_E = Sign.Calculate_E(var_R, var_Q);
                      if (lstClients.InvokeRequired)
                        lstClients.Invoke(new Progress(RaiseProgress), null);
                      sendData.ChatMessage = "E|" + var_E.ToString();
                      data = sendData.GetDataStream();
                      for (int i = 0; i < CLientsList.Count; i++)
                        serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
                      if (lstClients.InvokeRequired)
                        lstClients.Invoke(new SetText(SetlblStatusText), "Ожидание ответа от клиентов...");
                    }

                  }

                }
                else
                  if (receivedData.ChatMessage[0] == 'S')
                  {
                    if (var_Si_Count < kol_clients)
                    {
                      if (lstClients.InvokeRequired)
                        lstClients.Invoke(new SetText(SetlblStatusText), "Идет генерация ЭЦП...");
                      string[] temp = receivedData.ChatMessage.Split('|');
                      var_Si[var_Si_Count] = new BigInteger(temp[1], 10);
                      //MessageBox.Show("Si[" + var_Si_Count.ToString() + "]= " + var_Si[var_Si_Count].ToString());
                      var_Si_Count++;
                      if (var_Si_Count == kol_clients)
                      {
                        var_S = Sign.Calculate_S(var_Si, var_Q);
                        if (lstClients.InvokeRequired)
                          lstClients.Invoke(new Progress(RaiseProgress), null);
                        // MessageBox.Show(var_S.ToString());

                        sendData.ChatMessage = "S|" + var_S.ToString();
                        data = sendData.GetDataStream();
                        for (int i = 0; i < CLientsList.Count; i++)
                          serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
                      }

                    }

                  }
                  else
                    if (receivedData.ChatMessage[0] == 'Y')
                    {
                      if (var_Yi_Count < kol_clients)
                      {
                        string[] temp = receivedData.ChatMessage.Split('|');
                        var_Yi[var_Yi_Count] = new BigInteger(temp[1], 10);
                        //MessageBox.Show("Yi[" + var_Yi_Count.ToString() + "]= " + var_Yi[var_Yi_Count].ToString());
                        var_Yi_Count++;
                        if (var_Yi_Count == kol_clients)
                        {
                          sendData.ChatMessage = "Need_Hi";
                          data = sendData.GetDataStream();
                          for (int i = 0; i < CLientsList.Count; i++)
                            serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
                        }

                      }

                    }
                    else
                      if (receivedData.ChatMessage[0] == 'H')
                      {
                        if (var_Hi_Count < kol_clients)
                        {
                          string[] temp = receivedData.ChatMessage.Split('|');
                          var_Hi[var_Hi_Count] = new BigInteger(temp[1], 10);
                          //MessageBox.Show("Hi[" + var_Hi_Count.ToString() + "]= " + var_Hi[var_Hi_Count].ToString());
                          var_Hi_Count++;
                          if (var_Hi_Count == kol_clients)
                          {
                            var_Y = Sign.Calculate_Y(var_Yi, var_Hi, var_P);
                            if (lstClients.InvokeRequired)
                              lstClients.Invoke(new Progress(RaiseProgress), null);
                            //MessageBox.Show("Y= " + var_Y.ToString());
                            Session session = new Session();
                            session.E = var_E.ToString();
                            session.G = var_G.ToString();
                            session.P = var_P.ToString();
                            session.S = var_S.ToString();
                            session.Y = var_Y.ToString();
                            session.Q = var_Q.ToString();
                            try
                            {
                              db.Session.InsertOnSubmit(session);
                              db.SubmitChanges();
                            }
                            catch (Exception ex)
                            {
                              MessageBox.Show("Не удалось добавить данные в базу по причине:\n" + ex.ToString());
                            }

                            sendData.ChatMessage = "OK";
                            if (lstClients.InvokeRequired)
                            {
                              lstClients.Invoke(new Progress(MaxProgress), null);
                              lstClients.Invoke(new SetText(SetlblStatusText), "Документ подписан");
                            }
                            bool VerifyResult = Sign.Verify_Sign(var_Y, var_E, var_S, var_P, var_Q, var_G);                           
                           
                            data = sendData.GetDataStream();
                            for (int i = 0; i < CLientsList.Count; i++)
                              serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
                            DateTime CurrDate = DateTime.Now;
                            SignFileName = "Sign_" + CurrDate.Day.ToString() + "." + CurrDate.Month.ToString() + "." + CurrDate.Year.ToString() + "_" + CurrDate.Hour.ToString() + "." + CurrDate.Minute.ToString() + "." + CurrDate.Second.ToString() + ".CEGSA";
                            FileStream FS = new FileStream(SignFileName, FileMode.Create);
                            StreamWriter sw = new StreamWriter(FS);
                            sw.WriteLine(var_S.ToString());
                            sw.WriteLine(var_E.ToString());
                            sw.Close();
                            /*
                            if (VerifyResult)
                              MessageBox.Show("Подпись верна", "Сервер");
                            else
                              MessageBox.Show("Подпись НЕ верна", "Сервер");
                             * */
                            frmFinalMsg frmFinMsg = new frmFinalMsg();
                            frmFinMsg.ChangePrompt("Композиционная ЭЦП успешно сформирована и сохранена\nв " + SignFileName);
                            frmFinMsg.ShowDialog();
                            if (frmFinMsg.flagNewSession)
                                if (lstClients.InvokeRequired)
                                {
                                    lstClients.Invoke(new BeginNewSes(BeginNewSession), null);
                                    while (true) ;
                                }
                          }

                        }

                      }
                      else
                        if (receivedData.ChatMessage[0] == 'V')
                        {
                          string[] temp = receivedData.ChatMessage.Split('|');
                          var_S = new BigInteger(temp[1], 10);
                        }
                        else
                          if (receivedData.ChatMessage[0] == 'B')
                          {
                            string[] temp = receivedData.ChatMessage.Split('|');
                            var_E = new BigInteger(temp[1], 10);
                            bool VerifyResult = false;
                            if (var_S != 0)
                            {
                              if (lstClients.InvokeRequired)
                                lstClients.Invoke(new Progress(MaxProgress), null);
                              var sessions = from S in db.Session
                                             where S.S == var_S.ToString() && S.E == var_E.ToString()
                                             select S;
                              foreach (Session session in sessions)
                              {
                                var_Y = new BigInteger(session.Y, 10);
                                var_G = new BigInteger(session.G, 10);
                                var_P = new BigInteger(session.P, 10);
                                var_Q = new BigInteger(session.Q, 10);
                                VerifyResult = Sign.Verify_Sign(var_Y, var_E, var_S, var_P, var_Q, var_G);
                              }


                            }

                            if (VerifyResult)
                              sendData.ChatMessage = "VerifyTrue";
                            else
                              sendData.ChatMessage = "VerifyFalse";

                            data = sendData.GetDataStream();

                            serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epSender, new AsyncCallback(this.SendData), epSender);
                          }
              //else
              //if (receivedData.ChatMessage == "LogOut")
              //{
              //    if (!AllowAutorize)
              //    {
              //        sendData.ChatMessage = "LogOut";
              //        sendData.ChatDataIdentifier = DataIdentifier.Message;
              //        data = sendData.GetDataStream();
              //        for (int i = 0; i < CLientsList.Count; i++)
              //            serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
              //        MessageBox.Show("Сессия завершена одним из клиентов");

              //        if (lstClients.InvokeRequired)
              //            lstClients.Invoke(new Progress(NewSession), null);
              //        listClients.Clear();
              //        CLientsList.Clear();
              //    }

              //}
            }
            break;

          case DataIdentifier.LogIn:
            // Разрешаем авторизацию пользователей  
            sendData.ChatMessage = "#";
            data = sendData.GetDataStream();
            serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epSender, new AsyncCallback(this.SendData), epSender);
            break;

        }


        // Get packet as byte array
        data = sendData.GetDataStream();

        // Listen for more connections again...
        serverSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(this.ReceiveData), epSender);


      }

      catch (ObjectDisposedException) { }
      catch (ArgumentException) { }
      catch (Exception ex)
      {

        if (ex.Message != "Удаленный хост принудительно разорвал существующее подключение") ;
        MessageBox.Show("ReceiveData Error: " + ex.Message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion
    int kol_kl = 0;//кол-во клиентов
    private void lstCurrentClients_ItemCheck(object sender, ItemCheckEventArgs e)
    {

    }

    private void frmBase_FormClosing(object sender, FormClosingEventArgs e)
    {

        try
        {
            if (serverSocket != null)
            //if (serverSocket.Connected)
            {
                Packet sendData = new Packet();
                sendData.ChatMessage = "LogOut";
                sendData.ChatDataIdentifier = DataIdentifier.Message;
                byte[] data = sendData.GetDataStream();
                for (int i = 0; i < CLientsList.Count; i++)
                    serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
            }
        }
        catch { }
    }

    private void mnuExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void mnuAbout_Click(object sender, EventArgs e)
    {
      frmAbout frmAbout = new frmAbout();
      frmAbout.ShowDialog();
    }
    void NewSession()
    {
      Packet sendData = new Packet();
      sendData.ChatMessage = "LogOut";
      sendData.ChatDataIdentifier = DataIdentifier.Message;
      byte[] data = sendData.GetDataStream();
      for (int i = 0; i < CLientsList.Count; i++)
        serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, CLientsList[i].ep, new AsyncCallback(this.SendData), CLientsList[i].ep);
      if (serverSocket != null)
      {
        //serverSocket.Disconnect(true);
        serverSocket.Dispose();
        //serverSocket.Close();
      }
      Hide();
      frmAutorization frmA = new frmAutorization();
      frmA.ShowDialog();

      connection = frmA.connection;
      db = new DB_CEGSA(connection);
      var_G = new BigInteger(0);
      var_Q = new BigInteger(0);
      var_Y = new BigInteger(0);
      var_E = new BigInteger(0);
      var_S = new BigInteger(0);
      var_R = new BigInteger(0);
      var_NewE = new BigInteger(0);
      var_NewR = new BigInteger(0);
      var_Si = new BigInteger[1];
      var_Hi = new BigInteger[1];
      var_Ri = new BigInteger[1];
      var_Yi = new BigInteger[1];
      int var_Ri_Count = 0;
      int var_Yi_Count = 0;
      int var_Si_Count = 0;
      int var_Hi_Count = 0;
      this.AcceptButton = btnStart;

      kol_clients = 0;
      AllowAutorize = true;
      try
      {
        clientList.Clear();
      }
      catch { }
      try
      {

        listClients.Clear();
      }
      catch { }
      try
      {
        lstClients.Items.Clear();
      }
      catch { }
      try
      {
        CLientsList.Clear();
      }
      catch { }

      lstCurrentClients.Items.Clear();
      progressBar1.Value = 0;
      toolStrip1.Enabled = true;
      tbtnAdd.Enabled = true;
      tbtnDel.Enabled = true;
      tbtnEdit.Enabled = true;
      tbtnChangeAdminPass.Enabled = true;
      btnStart.Enabled = true;
      lstClients.Enabled = true;
      lstCurrentClients.Enabled = true;




      lstCurrentClients.Visible = true;
      btnAddClient.Visible = true;
      btnAddAllClients.Visible = true;
      btnDelAllClients.Visible = true;
      btnDelClient.Visible = true;
      label1.Visible = true;
      lstCurrentClients.Enabled = true;
      btnAddClient.Enabled = true;
      btnAddAllClients.Enabled = true;
      btnDelAllClients.Enabled = true;
      btnDelClient.Enabled = true;
      label1.Enabled = true;
      cmbServerAddress.Enabled = true;


      ReadListClients();

      Show();

    }
    private void mnuNewSession_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Вы уверены, что хотите завершить текущую сессию?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
        NewSession();

    }

    private void frmBase_Shown(object sender, EventArgs e)
    {

    }

    private void mnuHelpItem_Click(object sender, EventArgs e)
    {
      Process.Start("HELP_Server.chm");
    }
  }
}


