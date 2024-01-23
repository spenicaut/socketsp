using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using ByteArray = Unigone.Asn1RT.Util.ByteArray;
using System.Media;
using System.Timers;

namespace SocketSP
{
    public partial class Form1 : Form
    {
        string path = Application.ExecutablePath;
        string iniFile = "";
        FileStream fs;
        TcpListener tcpListener;
        
        Socket sckClient;
        bool EnCours = false;
        Socket socket;
        Thread threadServeur;
        Thread threadClient;
        Thread threadRepeat;
        //public NetworkStream ns;
        SoundPlayer snd;
        bool CSATConnecte = false;
        bool Connecte = false;
        System.Timers.Timer timerSend;
        int txtToSend = 1;
        bool CODE_ASCII = false;
        bool TELEPHONE = false;
        Socket sockUdp;
        int NB_CAR = 20000;
        bool TRACE_LOG = false;

        int xGrpRxIni, yGrpRxIni, xGrpTxIni, yGrpTxIni;
        int wGrpRxIni, hGrpRxIni, wGrpTxIni, hGrpTxIni;
        int hTxtRxIni, hTxtTxIni;
        int hFormIni;

        public Form1()
        {
            InitializeComponent();
        }


        public void Trace(string texte)
        {
            string trame = "";
            string typ = "   ";
            int tck = 0;
            string strFichierTraces = "";


            try
            {
                strFichierTraces = path + String.Format("socketSp-{0:yyyy-MM-dd}.log", DateTime.Now);

                trame = String.Format("{0:HH:mm:ss:fff} - {1}\r\n", DateTime.Now, texte);
                File.AppendAllText(strFichierTraces, trame, Encoding.GetEncoding("iso-8859-1"));
            }
            catch
            {
            }
        }


        private void OnResize(object sender, System.EventArgs e)
        {

            this.Text = "OnResize ...";
            try
            {

                this.Text = (String) this.Size.Height.ToString();

                // size form ini 546
                // location bas ini 21 317



                int delta = this.Height - hFormIni;

                if (delta<-200) return;

                // position grpSend
                this.grpTx.Location = new Point(xGrpTxIni, yGrpTxIni + (delta / 2));
                this.grpTx.Height = hGrpTxIni + (delta / 2);

                this.grpRx.Height = hGrpRxIni + (delta / 2);
                this.txt.Height = hTxtRxIni + (delta / 2);

                this.txtSend.Height = hTxtTxIni + (delta / 2); 
                /*

                int h = this.Size.Height;

                int xGr3 = 12;
                int yGr3 = 317 + (h - 546);

                this.grpTx.Location = new Point(xGr3, yGr3);
                */

            }
            catch
            {
            }

        }

        private void OnLoad(object sender, EventArgs e)
        {
            path = path.Substring(0, path.LastIndexOf("\\")+1);
            iniFile = path + "Socket.ini";

            try
            {
                TextReader txt = new StreamReader(iniFile);
                string getText = txt.ReadToEnd();
                txt.Close();
                
                string[] tab =  getText.Split(  new char[] { '-' });
                if (tab[0] == "True")
                    radClient.Checked = true;
                else
                    radServer.Checked = false;

                txtIPClient.Text = tab[1];
                txtPortClient.Text = tab[2];
                txtPortServer.Text = tab[3];

                if (tab[4] == "True")
                    chkAuto.Checked = true;
                else
                    chkAuto.Checked = false;

                if (chkAuto.Checked) StartListen();



                xGrpRxIni = this.grpRx.Location.X;
                yGrpRxIni = this.grpRx.Location.Y;
                wGrpRxIni = this.grpRx.Width;
                hGrpRxIni = this.grpRx.Height;

                xGrpTxIni = this.grpTx.Location.X;
                yGrpTxIni = this.grpTx.Location.Y;
                wGrpTxIni = this.grpTx.Width;
                hGrpTxIni = this.grpTx.Height;

                hTxtRxIni = this.txt.Height;
                hTxtTxIni = this.txtSend.Height;

                hFormIni = this.Height;

            }
            catch 
            {
            }

        }
        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            int iErr=100;
            try
            {
                File.Delete(iniFile);
                iErr=101;
                File.AppendAllText(iniFile, radClient.Checked.ToString() + "-");
                
                iErr=102;
                File.AppendAllText(iniFile, txtIPClient.Text.ToString() + "-");
                iErr=103;
                File.AppendAllText(iniFile, txtPortClient.Text.ToString() + "-");
                iErr=105;
                File.AppendAllText(iniFile, txtPortServer.Text.ToString() + "-");
                File.AppendAllText(iniFile, chkAuto.Checked.ToString() + "-");

                EnCours = false;

                try { threadRepeat.Abort(); }
                catch { }

                try { tcpListener.Stop(); }
                catch {}

                try { socket.Shutdown(SocketShutdown.Both); }
                catch   { }

                try { sockUdp.Close(); }
                catch { }

                try { tcpListener.Stop(); }
                catch { }

                try { threadServeur.Abort(); }
                catch { }

                try { sckClient.Close(); }
                catch { }

                try { threadClient.Abort(); }
                catch { }

                try { threadRepeat.Abort(); }
                catch { }

                try { sckClient.Close(); }
                catch { }




            }
            catch  (Exception ex)
            {
                MessageBox.Show("Err Closing iErr=" + iErr + " " + ex.Message);
            }
        }


        void ServeurUdp()
        {
            int iErr = 100;
            int size=0;
            IPEndPoint local_ep;
            IPEndPoint ipep;
            byte[] rcvBytes = new byte[8192];
            IPEndPoint rEp;
            byte[] data;
            string str = "";

            IPEndPoint receivePoint = new IPEndPoint(IPAddress.Any, 0);
            EndPoint tempReceivePoint = (EndPoint)receivePoint;
            try
            {

                 this.Text = "new Socket udp ...";
                 sockUdp = new Socket(AddressFamily.InterNetwork,
                              SocketType.Dgram,
                              ProtocolType.Udp);


                sockUdp.SetSocketOption(SocketOptionLevel.Socket,
                                     SocketOptionName.ReuseAddress, 1);

                  local_ep = new IPEndPoint(IPAddress.Any, int.Parse( txtPortServer.Text));
                    sockUdp.Bind(local_ep);

                  rEp = new IPEndPoint(IPAddress.Any, 0);

                  this.Text = "ecoute udp sur le port " +txtPortServer.Text + "  ...";

                   // ipep = new IPEndPoint(IPAddress.Parse(snifferHost), portInterco);
                    while (EnCours)
                    {
                        try
                        {
                            iErr = 100;

                            iErr = 102;
                            size = sockUdp.ReceiveFrom(rcvBytes, ref tempReceivePoint);
                            iErr = 103;
                            rEp = (IPEndPoint)tempReceivePoint;

                            data = new byte[size];
                            Array.Copy(rcvBytes, data, size);

                            str = String.Format("{0:HH:mm:ss} <- {1}/{2} {3}\r\n", DateTime.Now,rEp.Address,rEp.Port,
                                afficheStr(data));

                            log(str);

                            str = String.Format("<- {0} {1}", rEp.Address, afficheStr(data));
                            if (TRACE_LOG) Trace(str);


                        }
                catch
                {
                }
                    }
            }
                catch
                {
                }
        }



        void Serveur()
        {
            int iErr = 100;
            IPAddress localhost=null;

            try
            {

                this.Text = "Dns.GetHostEntry ...";
                IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
                iErr = 101;
                IPAddress ipAddress = ipHostEntry.AddressList[0];
                Thread threadClient = null; ;
                IPEndPoint ipLocalEndPoint;

                localhost = IPAddress.Any;

                iErr = 102;
                this.Text = "new TcpListener ...";
                //tcpListener = new TcpListener(ipAddress, int.Parse(txtPortServer.Text));
                tcpListener = new TcpListener(localhost, int.Parse(txtPortServer.Text));
                iErr = 103;
                this.Text = "tcpListener.Start ...";
                tcpListener.Start();

                while (EnCours)
                {

                    try
                    {

                        this.Text = "Listening " + ipAddress + " ...";
                        socket = tcpListener.AcceptSocket();
                        socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

                        ipLocalEndPoint = (IPEndPoint)socket.RemoteEndPoint;

                        threadClient = new Thread(new ThreadStart(ClientServeur));
                        threadClient.Start();

                      
                    }
                    catch (Exception ex)
                    {
                        this.Text = "Err Serveur " + ex.Message;
                    }
                }

                tcpListener.Stop();
                this.Text = "Stop Listening";
                try
                {
                    threadClient.Abort();
                    threadClient.Join();
                }
                catch 
                {
                }
                
            }
            catch (Exception ex2)
            {
                this.Text = "Err Serveur2 " + iErr+ " " + ex2.Message;
            }
            this.Text = "";
        }


        void ClientServeur()
        {
            try
            {

                Byte[] buffer = new Byte[2048];
                int nbBuffer;
                this.Text = "new Socket ...";
                Socket socketLocal = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipLocalEndPoint;
                string str;


                socketLocal = socket;
                ipLocalEndPoint = (IPEndPoint)socketLocal.RemoteEndPoint;
                this.Text = "Listening " + ipLocalEndPoint.ToString();

                str = String.Format("{0:HH:mm:ss} client connecte:{1}\r\n", DateTime.Now,
                    ipLocalEndPoint.ToString());

                this.WindowState = FormWindowState.Normal;
                log(str);


                while ((nbBuffer = socketLocal.Receive(buffer, 0, buffer.Length, SocketFlags.None)) != 0)
                {
                    byte[] data = new byte[nbBuffer];
                    byte[] rep = new byte[10];
                    Array.Copy(buffer, data, nbBuffer);
                    Array.Copy(buffer, rep, 10);
                    /*
                    str = String.Format("{0:HH:mm:ss} <-- {1}\r\n", DateTime.Now, 
                         ByteArray.ByteArrayToPrintableString(data));
                    */
                    str = String.Format("{0:HH:mm:ss} <- {1}\r\n", DateTime.Now,
                        afficheStr(data));

                    this.WindowState = FormWindowState.Normal;

                    log(str);


                    if (this.chkRepAuto.Checked) Send(txtSend.Text);

                    //log(afficheStr(data));

                    //log("srv tab ... \r\n");

                    string[] tab = null ;
                    if (afficheStr(data).Contains("@")) tab = afficheStr(data).Split(new char[] { '@' });

                   // log("TELEPHONE ... \r\n");
                    if (TELEPHONE)
                    {
                        if (str.Contains("A@"))
                        {
                            txtPoste.Text = tab[1];
                            Send("C@O@" + txtPoste.Text + "@00.00@" + txtMonNum.Text + "@" + tab[2] + "@");
                            Thread.Sleep(1500);
                            Send("C@E@00.00@" + tab[2] + "@" + txtMonNum.Text +"@");

                        }

                        if (str.Contains("D@"))
                        {
                            txtPoste.Text = tab[1];
                            Send("C@E@00.00@" + textNumTel.Text + "@" + txtMonNum.Text + "@");
                        }
                        if (str.Contains("R@"))
                        {
                            txtPoste.Text = tab[1];
                            Send("C@E@00.00@" + textNumTel.Text + "@" + txtMonNum.Text + "@");
                        }

                        if (str.Contains("C@C"))
                            Send("C@C@00.00@" + textNumTel.Text + "@" + txtMonNum.Text + "@");
                    }

                    if (this.chkGipSwissPhone.Checked)
                    {
                        rep[3] = 0x51;
                        rep[4] = 0x51;
                        rep[5] = 0x2B;
                        rep[6] = 0x30;
                        rep[7] = 0x30;
                        rep[8] = 0x0D;
                        rep[9] = 0x0A;

                        Send(rep,10);


                    }


                    /*
                    try
                    {
                        snd = new SoundPlayer(path + "call.wav");
                        snd.Play();
                    }
                    catch { }
                     * */
                }

                
                
                socketLocal.Shutdown(SocketShutdown.Both);

                str = String.Format("{0:HH:mm:ss} client deconnecte\r\n", DateTime.Now);

                this.WindowState = FormWindowState.Normal;
                log(str);

            }
            catch (Exception ex)
            {
               // log("Err srv " + ex.Message + "\r\n");
            }
            this.Text = "";



        }


        void Client()
        {
            byte[] buffer = new byte[2048];
            byte[] tmp = new byte[2048];
            int i = 0;
            int size;
            string str, strData;

            while (EnCours)
            {
                try
                {
                    Connecte = false;

                    
                    this.Text = "new socket ...";
                    
                    
                    // localendpoint
                    //IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
                    
                    //IPAddress ipAddress = ipHostEntry.AddressList[0];
                    //IPEndPoint ipLocalEndPoint;
                    
 
                     
                    sckClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    if (txtLocalEndPoint.Text.Length > 0)
                    {
                        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(txtLocalEndPoint.Text), 0);
                        sckClient.Bind(ep);
                    }

                    sckClient.Connect(txtIPClient.Text, int.Parse(txtPortClient.Text));
                    

                    
                    str = String.Format("{0:HH:mm:ss} client connecte au serveur\r\n", DateTime.Now);
                    this.WindowState = FormWindowState.Normal;
                    log(str);

                    Connecte = true;

                    try
                    {
                        // Lecture data
                        while (EnCours)
                        {
                            this.Text = "Connect OK";
                            //size = ns.Read(buffer, 0, buffer.Length);
                            size = sckClient.Receive(buffer, 0, buffer.Length, SocketFlags.None);

                            if (size <= 0)
                                break;

                            byte[] data = new byte[size];
                            Array.Copy(buffer, data, size);

                               
                            //Array.Copy(buffer, tmp, size);
                            /*
                            str = String.Format("{0:HH:mm:ss} <-- {1}\r\n", DateTime.Now, 
                                 ByteArray.ByteArrayToPrintableString(data));
                            */
                            str = String.Format("{0:HH:mm:ss} <- {1}\r\n", DateTime.Now,
                                afficheStr(data));
                            
                            this.WindowState = FormWindowState.Normal;

                            log(str);

                            str = String.Format("<- {0}", afficheStr(data));
                            if (TRACE_LOG) Trace(str);

                            
                            if (this.chkRepAuto.Checked) Send(txtSend.Text);

                            /*
                            try
                            {
                                snd = new SoundPlayer(path + "call.wav");
                                snd.Play();
                            }
                            catch   { }
                             * */
                           
                          
                        }
                    }
                    catch (Exception ex)
                    {
                        //log("err client " + ex.Message);
                    }

                    sckClient.Close();
                    
                    EnCours = false;

                    str = String.Format("{0:HH:mm:ss} client deconnecte\r\n", DateTime.Now);
                    this.WindowState = FormWindowState.Normal;
                    log(str);

                    Connecte = false;

                    btnConnect.Text = "Connect";
                    btnListen.Enabled = true;
                    btnConnect.Enabled = true;

                }
                catch (Exception excli)
                {
                    EnCours = false;
                    str = String.Format("{0:HH:mm:ss} Err {1}\r\n", DateTime.Now,excli.Message);
                    
                    log(str);
                }

                EnCours = false;

                btnConnect.Text = "Connect";
                btnListen.Enabled = true;
                btnConnect.Enabled = true;
                this.Text = "";

            }
            str = String.Format("{0:HH:mm:ss} client deconnecte\r\n", DateTime.Now);
            this.WindowState = FormWindowState.Normal;
            log(str);
        }


        void ClientCSat()
        {
            byte[] buffer = new byte[2048];
            byte[] tmp = new byte[2048];
            int i = 0;
            int size;
            string str, strData;
            string CS = txtCS.Text;
            string DelaiCs = txtDelaiCSat.Text;

            CSATConnecte = false;

            while (EnCours)
            {
                try
                {
                    while (!CSATConnecte && EnCours)
                    {
                        try 
                        {	        
                            this.Text = "sleep " + DelaiCs + " ...";
                            Thread.Sleep(int.Parse(DelaiCs));

                            this.Text = "new sckClient ...";
                            
                            sckClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            sckClient.Connect(txtIPClient.Text, int.Parse(txtPortClient.Text));

                            this.Text = "sckClient.GetStream ...";
                            
                            CSATConnecte=true;
                        }
                        catch  { }
                    }
                    if (!EnCours) break;

                    str = String.Format("{0:HH:mm:ss} client connecte au serveur\r\n", DateTime.Now);
                    this.WindowState = FormWindowState.Normal;
                    log(str);

                    SendTrameCfgCs(CS);

                    try
                    {
                        // Lecture data
                        while (EnCours)
                        {
                            this.Text = "Connect OK";
                            
                            size = sckClient.Receive(buffer, 0, buffer.Length, SocketFlags.None);

                            if (size <= 0)
                                break;

                            byte[] data = new byte[size];
                            Array.Copy(buffer, data, size);


                            //Array.Copy(buffer, tmp, size);
                            /*
                            str = String.Format("{0:HH:mm:ss} <-- {1}\r\n", DateTime.Now, 
                                 ByteArray.ByteArrayToPrintableString(data));
                            */
                            str = String.Format("{0:HH:mm:ss} <- {1}\r\n", DateTime.Now,
                                afficheStr(data));

                            this.WindowState = FormWindowState.Normal;

                            log(str);

                            try
                            {
                                snd = new SoundPlayer(path + "call.wav");
                                snd.Play();
                            }
                            catch { }


                        }
                    }
                    catch (Exception ex)
                    {
                        //log("Err Client CSAT " + ex.Message);
                    }


                    sckClient.Close();
                    EnCours = false;

                    str = String.Format("{0:HH:mm:ss} client deconnecte\r\n", DateTime.Now);
                    this.WindowState = FormWindowState.Normal;
                    log(str);

                    CSATConnecte = false;

                    cmdConnectCsat.Text = "Connect";
                    btnConnect.Text = "Connect";
                    btnListen.Enabled = true;
                    btnConnect.Enabled = true;

                }
                catch
                {
                }

                EnCours = false;

                btnConnect.Text = "Connect";
                btnListen.Enabled = true;
                btnConnect.Enabled = true;
                this.Text = "";

            }
        }

        private void StartListen()
        {
            try
            {
                NB_CAR = int.Parse(txtNbCar.Text);
                if (EnCours)
                {
                    EnCours = false;

                    try
                    {
                        if (radTcp.Checked)
                        {
                            tcpListener.Stop();
                            socket.Shutdown(SocketShutdown.Both);
                            threadServeur.Abort();
                            threadServeur.Join();
                        }
                        else
                        {
                            sockUdp.Close();
                            threadServeur.Abort();
                            this.Text = "";
                            //threadServeur.Join();
                        }
                    }
                    catch
                    {
                    }
                    btnListen.Text = "Listen";
                    btnListen.Enabled = true;
                    btnConnect.Enabled = true;
                    this.Text = "";
                }
                else
                {
                    EnCours = true;
                    btnListen.Text = "Stop Listening";
                    btnConnect.Enabled = false;
                    if (radTcp.Checked)
                    {
                        threadServeur = new Thread(new ThreadStart(Serveur));
                        threadServeur.Start();
                    }
                    if (radUdp.Checked)
                    {
                        threadServeur = new Thread(new ThreadStart(ServeurUdp));
                        threadServeur.Start();
                    }
                }
            }
            catch { }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            StartListen();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            cnx();
        }

        private void cnx()
        {
            try
            {
                NB_CAR = int.Parse(txtNbCar.Text);

                if (EnCours)
                {
                    EnCours = false;

                    try
                    {
                        //ns.Close();
                        sckClient.Close();
                        threadClient.Abort();
                        threadClient.Join();
                    }
                    catch
                    {
                    }
                    btnConnect.Text = "Connect";
                    btnListen.Enabled = true;
                    btnConnect.Enabled = true;
                    this.Text = "";
                    CSATConnecte = false;
                }
                else
                {
                    EnCours = true;
                    btnConnect.Text = "Disconnect";
                    btnListen.Enabled = false;
                    threadClient = new Thread(new ThreadStart(Client));
                    threadClient.Start();
                }
            }
            catch { }
        }



        private void btnSend_Click(object sender, EventArgs e)
        {

            if (radTcp.Checked)
            {
               // log("send ...\r\n");
                Send(txtSend.Text);
               // log("send ok\r\n");

                if (txtTimer.Text != "0")
                {
                    timerSend = new System.Timers.Timer();
                    timerSend.Interval = Convert.ToDouble(int.Parse(txtTimer.Text));
                    timerSend.Enabled = true;
                    timerSend.Elapsed += new ElapsedEventHandler(timerSendElapsed);

                    txtToSend = 2;
                }
            }
            else
                SendUdp(txtSend.Text);

            //log("sortie btnSend_Click\r\n");

        }

        private void timerSendElapsed(object source, ElapsedEventArgs e)
        {
            if (txtTimer.Text =="0" )
            {
                timerSend.Enabled=false;
                timerSend.Stop();
            }

            if (txtToSend == 1)
            {
                Send(txtSend.Text);
                txtToSend = 2;
            }
            else
            {
                Send(txtSend2.Text);
                txtToSend = 1;
            }
        }

        private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar == '\r') && (chkEnter.Checked))
                Send(txtSend.Text);

        }

        private string afficheStr(byte[] str)
        {
            int entier = 0, i;
            string ret = "";
            string ent = " ";
            try
            {

                for (i = 0; i < str.Length; i++)
                {

                    entier = Convert.ToInt32(str[i]);

                    if (CODE_ASCII)
                    {
                        ret += "<" + string.Format("{0:00}", entier) + ">";
                    }
                    else
                    {
                        if ((entier < 16) && (entier > -1) && (entier != 10) && (entier != 13))
                            ret += "<" + string.Format("{0:00}", entier) + ">";
                        else
                        {
                           ret += Convert.ToChar(str[i]);
                        }
                    }


                }
            }
            catch  { }

            //if (TRIM) ret = ret.Trim();

            return ret  ;
        }


        private void SendOld(string trm)
        {
            byte[] data;
            string tmp = "", str, sea, rep, entier;
            string c1 = "", c2 = "";
            int ent = 0;

            try
            {

                tmp = trm;
                if (tmp.Length == 0) return;

                if (chkBin.Checked)
                {
                    while (tmp.Contains("\\"))
                    {
                        sea = tmp.Substring(tmp.IndexOf("\\"), 3);

                        //entier = tmp.Substring(tmp.IndexOf("\\") + 1, 2);
                        c1 = tmp.Substring(tmp.IndexOf("\\") + 1, 1);
                        c2 = tmp.Substring(tmp.IndexOf("\\") + 2, 1);
                        ent = getEnt(c1, c2);

                        rep = Convert.ToString(Convert.ToChar(Convert.ToByte(ent)));
                        //rep = Convert.ToChar(Convert.ToByte(ent));
                        tmp = tmp.Replace(sea, rep);
                    }
                }
                else
                {

                }

                if (chkStxEtx.Checked)
                {
                    tmp = Convert.ToChar(Convert.ToByte(02)) +
                        tmp +
                        Convert.ToChar(Convert.ToByte(03));
                    data = ASCIIEncoding.ASCII.GetBytes(tmp);
                }
                else
                    data = ASCIIEncoding.ASCII.GetBytes(tmp);


                //ns.Write(data, 0, data.Length);
                if (btnConnect.Enabled)
                    sckClient.Send(data, 0, data.Length, SocketFlags.None);
                else
                    socket.Send(data, 0, data.Length, SocketFlags.None);
                /*
                str = String.Format("{0:HH:mm:ss} --> {1}\r\n", DateTime.Now, 
                    afficheStr( ByteArray.ByteArrayToPrintableString(data)));
                */
                str = String.Format("{0:HH:mm:ss} -> {1}\r\n", DateTime.Now,
                    afficheStr(data));

                log(str);
            }
            catch { }
        }


        private void Send(byte[] data, int len)
        {
            byte[] dataToSend;
            string str;
            string c1 = "", c2 = "";
            int ent = 0;
            int i = 0;

            try
            {
                dataToSend = new byte[len];
                Array.Copy(data, dataToSend, len);

                //ns.Write(data, 0, data.Length);
                if (btnConnect.Enabled)
                    sckClient.Send(dataToSend, 0, len, SocketFlags.None);
                else
                    socket.Send(dataToSend, 0, len, SocketFlags.None);
                /*
                str = String.Format("{0:HH:mm:ss} --> {1}\r\n", DateTime.Now, 
                    afficheStr( ByteArray.ByteArrayToPrintableString(data)));
                */
                str = String.Format("{0:HH:mm:ss} -> {1}\r\n", DateTime.Now,
                    afficheStr(dataToSend));

                log(str);
            }
            catch (Exception ex)
            {
                str = String.Format("{0:HH:mm:ss} Err send {1}\r\n", DateTime.Now,
                   ex.Message);

                log(str);
            }
        }

        private void Send(string trm)
        {
            byte[] data;
            byte[] dataToSend;
            string  str;
            string c1 = "", c2 = "";
            int ent = 0;
            int len = 0;
            int i=0;

            try
            {
                if (trm.Length == 0) return;

                data = new byte[trm.Length + 2];

                if (chkStxEtx.Checked) data[len++]=0x02;

                i = 0;
                while(i<trm.Length)
                {
                    if ((chkBin.Checked) && (trm[i] == '\\'))
                    {
                        c1 = trm.Substring(i + 1, 1);
                        c2 = trm.Substring(i + 2, 1);
                        ent = getEnt(c1, c2);
                        data[len++] = Convert.ToByte(ent);
                        i = i + 3;
                    }
                    else
                    {
                        data[len++] = Convert.ToByte(trm[i]);
                        i++;
                    }
                }


                if (chkStxEtx.Checked) data[len++]=0x03;

                dataToSend = new byte[len];
                Array.Copy(data, dataToSend, len);

                //ns.Write(data, 0, data.Length);
                if (btnConnect.Enabled)
                    sckClient.Send(dataToSend, 0, len, SocketFlags.None);
                else
                    socket.Send(dataToSend, 0, len, SocketFlags.None);
                /*
                str = String.Format("{0:HH:mm:ss} --> {1}\r\n", DateTime.Now, 
                    afficheStr( ByteArray.ByteArrayToPrintableString(data)));
                */
                str = String.Format("{0:HH:mm:ss} -> {1}\r\n", DateTime.Now,
                    afficheStr(dataToSend));

                log(str);
            }
            catch (Exception ex)  {
                str = String.Format("{0:HH:mm:ss} Err send {1}\r\n", DateTime.Now,
                   ex.Message);

                log(str);
            }
        }


        private void SendUdp(string trm)
        {
            byte[] data;
            byte[] dataToSend;
            string str;
            string c1 = "", c2 = "";
            int ent = 0;
            int len = 0;
            int i = 0;
            string strErr = "";
            try
            {
                if (trm.Length == 0) return;


                IPEndPoint ipep;
                strErr = "new Socket";
                sockUdp = new Socket(AddressFamily.InterNetwork,
                             SocketType.Dgram,
                             ProtocolType.Udp);

                strErr = "SetSocketOption reuse add";
                sockUdp.SetSocketOption(SocketOptionLevel.Socket,
                                     SocketOptionName.ReuseAddress, 1);


                strErr = "new IPEndPoint";
                ipep = new IPEndPoint(IPAddress.Parse(txtIPClient.Text), int.Parse(txtPortClient.Text));

                /*
                strErr = "SetSocketOption addmember";
                sockUdp.SetSocketOption(SocketOptionLevel.IP,
                                     SocketOptionName.AddMembership,
                                     new MulticastOption(IPAddress.Parse(txtIPClient.Text)
                                            , IPAddress.Any));
                */


                data = new byte[trm.Length + 2];

                if (chkStxEtx.Checked) data[len++] = 0x02;

                i = 0;
                while (i < trm.Length)
                {
                    if ((chkBin.Checked) && (trm[i] == '\\'))
                    {
                        c1 = trm.Substring(i + 1, 1);
                        c2 = trm.Substring(i + 2, 1);
                        ent = getEnt(c1, c2);
                        data[len++] = Convert.ToByte(ent);
                        i = i + 3;
                    }
                    else
                    {
                        data[len++] = Convert.ToByte(trm[i]);
                        i++;
                    }
                }


                if (chkStxEtx.Checked) data[len++] = 0x03;

                strErr = "new byte";
                dataToSend = new byte[len];
                Array.Copy(data, dataToSend, len);

                if (txtIPClient.Text.StartsWith("2"))
                {
                    sockUdp.SetSocketOption(SocketOptionLevel.IP,
                                         SocketOptionName.MulticastTimeToLive,
                                         8);
                }

                strErr = "sockUdp.SendTo";
                sockUdp.SendTo(dataToSend, 0, dataToSend.Length, SocketFlags.None, ipep);


                /*
                str = String.Format("{0:HH:mm:ss} --> {1}\r\n", DateTime.Now, 
                    afficheStr( ByteArray.ByteArrayToPrintableString(data)));
                */
                str = String.Format("{0:HH:mm:ss} -> udp {1}\r\n", DateTime.Now,
                    afficheStr(dataToSend));

                log(str);

                sockUdp.Close();


            }
            catch (Exception ex) { MessageBox.Show(strErr + " " + ex.Message); }
        }

        private int getEnt(string c1, string c2)
        {
            int i1 = 0, i2 = 0;

            if (c1 == "0") i1 = 0;
            if (c1 == "1") i1 = 1;
            if (c1 == "2") i1 = 2;
            if (c1 == "3") i1 = 3;
            if (c1 == "4") i1 = 4;
            if (c1 == "5") i1 = 5;
            if (c1 == "6") i1 = 6;
            if (c1 == "7") i1 = 7;
            if (c1 == "8") i1 = 8;
            if (c1 == "9") i1 = 9;
            if (c1 == "A") i1 = 10;
            if (c1 == "a") i1 = 10;
            if (c1 == "B") i1 = 11;
            if (c1 == "b") i1 = 11;
            if (c1 == "C") i1 = 12;
            if (c1 == "c") i1 = 12;
            if (c1 == "D") i1 = 13;
            if (c1 == "d") i1 = 13;
            if (c1 == "E") i1 = 14;
            if (c1 == "e") i1 = 14;
            if (c1 == "F") i1 = 15;
            if (c1 == "f") i1 = 15;

            if (c2 == "0") i2 = 0;
            if (c2 == "1") i2 = 1;
            if (c2 == "2") i2 = 2;
            if (c2 == "3") i2 = 3;
            if (c2 == "4") i2 = 4;
            if (c2 == "5") i2 = 5;
            if (c2 == "6") i2 = 6;
            if (c2 == "7") i2 = 7;
            if (c2 == "8") i2 = 8;
            if (c2 == "9") i2 = 9;
            if (c2 == "A") i2 = 10;
            if (c2 == "a") i2 = 10;
            if (c2 == "B") i2 = 11;
            if (c2 == "b") i2 = 11;
            if (c2 == "C") i2 = 12;
            if (c2 == "c") i2 = 12;
            if (c2 == "D") i2 = 13;
            if (c2 == "d") i2 = 13;
            if (c2 == "E") i2 = 14;
            if (c2 == "e") i2 = 14;
            if (c2 == "F") i2 = 15;
            if (c2 == "f") i2 = 15;

            return ((i1 * 16) + i2);

        }

        private void SendTrameCfgCs(string CS)
        {
            byte[] data;
            string  tmp="", str, sea, rep, entier;

            try
            {

                tmp = CS;

                tmp = Convert.ToChar(Convert.ToByte(02)) + "TrameCfgCS" + 
                    tmp +
                    Convert.ToChar(Convert.ToByte(03));
                data = ASCIIEncoding.ASCII.GetBytes(tmp);


                if (btnConnect.Enabled)
                    sckClient.Send(data, 0, data.Length, SocketFlags.None);
                else
                    socket.Send(data, 0, data.Length, SocketFlags.None);

                str = String.Format("{0:HH:mm:ss} -> {1}\r\n", DateTime.Now,
                    afficheStr(data));

                log(str);
            }
            catch { }
        }

        private void log(string data)
        {
            if (chkHaut.Checked)
            {
                txt.Text = data + txt.Text;
                if (txt.Text.Length > NB_CAR) txt.Text = txt.Text.Substring(0, NB_CAR);
            }
            else
                txt.Text = txt.Text + data;
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            txt.Text = "";
        }

        private void butFic_Click(object sender, EventArgs e)
        {
            int ierr = 0;
            try
            {
                ierr = 1;
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
                ierr = 2;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ierr = 3;
                    if (File.Exists(dlg.FileName))
                    {
                        ierr = 4;
                        
                        /*
                        BinaryReader sr = new BinaryReader(File.Open(dlg.FileName, FileMode.Open));

                        ierr = 5;
                        Byte[] tmp = sr.ReadBytes(524288);
                        ierr = 6;
                        int tmpLength = tmp.Length;
                        ierr = 7;
                        sr.Close();
                        ierr = 8;

                        if (btnConnect.Enabled)
                            sckClient.Send(tmp, 0, tmp.Length, SocketFlags.None);
                        else
                            socket.Send(tmp, 0, tmp.Length, SocketFlags.None);
                        */
                        byte[] contenu = File.ReadAllBytes(dlg.FileName);
                        if (btnConnect.Enabled)
                            sckClient.Send(contenu, 0, contenu.Length, SocketFlags.None);
                        else
                            socket.Send(contenu, 0, contenu.Length, SocketFlags.None);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur butFic:" + ierr + " " +  ex.Message);
            }
 
        }

        private void cmdConnectCsat_Click(object sender, EventArgs e)
        {
            string CS = txtCS.Text;
            string DELAI = txtDelaiCSat.Text;

            try
            {

                switch (cmdConnectCsat.Text)
                {
                    case "Connect":
                        EnCours = true;
                        cmdConnectCsat.Text = "Disconnect";
                        btnListen.Enabled = false;
                        threadClient = new Thread(new ThreadStart(ClientCSat));
                        threadClient.Start();

                        break;

                    case "Disconnect":


                        EnCours = false;
                        CSATConnecte = false;

                        try { sckClient.Close();}
                        catch  { }

                        try { threadClient.Abort(); }
                        catch { }

                        try { threadClient.Join();}
                        catch { }

                        cmdConnectCsat.Text = "Connect";
                        btnListen.Enabled = true;
                        btnConnect.Enabled = true;
                        this.Text = "";
                        break;

                    default:
                        break;
                }

                
            }
            catch { }
        }

        private void cmdStartConnect_Click(object sender, EventArgs e)
        {
            if (cmdStartConnect.Text == "Start")
            {
                threadRepeat = new Thread(new ThreadStart(RepeatCnx));
                threadRepeat.Start();
                cmdStartConnect.Text = "Stop";
            }
            else
            {
                cmdStartConnect.Text = "Start";
                if (EnCours) cnx();
                threadRepeat.Abort();
            }
        }

        private void RepeatCnx()
        {
            int delai=0;
            while (true)
            {
                cnx();
                Thread.Sleep(100);
                if (txtSendRepeat.Text.Length > 0)
                    if (Connecte) Send(txtSendRepeat.Text);

                delai = int.Parse(txtCnxRepete.Text);
                Thread.Sleep(delai);
            }
        }

        private void chkCodeAscii_CheckedChanged(object sender, EventArgs e)
        {
            CODE_ASCII = false;
            if (chkCodeAscii.Checked)
                CODE_ASCII = true;
        }



        private void butAppel_Click_1(object sender, EventArgs e)
        {

            // 0 1  2    3      4        5        6
            // C@I@SPE@01.16@calling@poste op@faisceau@

            Send("C@I@" + this.txtPoste.Text + "@00.00@" + this.textNumTel.Text + "@" + this.txtMonNum.Text + "@" + this.txtFaisceau.Text + "@");
        }

        private void chkTelephone_CheckedChanged_1(object sender, EventArgs e)
        {
            TELEPHONE = false;
            //if (chkTelephone.Checked) TELEPHONE = true;

            //if (chkTelephone.Checked) txtPortServer.Text = "2556";
        }

        private void radClient_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radServer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSend.Text = "";
        }

        private void chkTrim_CheckedChanged(object sender, EventArgs e)
        {
            TRACE_LOG = chkTraces.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtIPClient.Text = "192.168.202.51";
            this.txtPortClient.Text = "2556";
            this.radUdp.Checked = true;


        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.txtIPClient.Text = "192.168.202.54";
            this.txtPortClient.Text = "2556";
            this.radUdp.Checked = true;
        }

        private void butAppel_Click(object sender, EventArgs e)
        {
            SendUdp("C@I@" + this.txtPoste.Text + "@00.00@" + this.textNumTel.Text + "@" + this.txtMonNum.Text + "@" + this.txtFaisceau.Text + "@");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SendUdp("C@E@00.00@" + this.txtPoste.Text + this.textNumTel.Text + "@" + this.txtMonNum.Text + "@" + this.txtFaisceau.Text + "@");
            //C@E@bf.58@PTA5303@0644236895@5588@5303@
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SendUdp("C@C@" + this.txtPoste.Text + "@00.00" + "@");
            //C@C@PTA5303@bf.5f@
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.txtIPClient.Text = "192.168.202.52";
            this.txtPortClient.Text = "2556";
            this.radUdp.Checked = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.txtIPClient.Text = "192.168.202.55";
            this.txtPortClient.Text = "2556";
            this.radUdp.Checked = true;
        }

        private void chkRepAuto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }




    }
}