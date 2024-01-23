namespace SocketSP
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radUdp = new System.Windows.Forms.RadioButton();
            this.radTcp = new System.Windows.Forms.RadioButton();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnListen = new System.Windows.Forms.Button();
            this.txtPortServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPortClient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIPClient = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radServer = new System.Windows.Forms.RadioButton();
            this.radClient = new System.Windows.Forms.RadioButton();
            this.grpRx = new System.Windows.Forms.GroupBox();
            this.chkTraces = new System.Windows.Forms.CheckBox();
            this.butClear = new System.Windows.Forms.Button();
            this.chkHaut = new System.Windows.Forms.CheckBox();
            this.txt = new System.Windows.Forms.TextBox();
            this.grpTx = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.butFic = new System.Windows.Forms.Button();
            this.chkEnter = new System.Windows.Forms.CheckBox();
            this.chkBin = new System.Windows.Forms.CheckBox();
            this.chkStxEtx = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdConnectCsat = new System.Windows.Forms.Button();
            this.txtDelaiCSat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.txtSend2 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtSendRepeat = new System.Windows.Forms.TextBox();
            this.cmdStartConnect = new System.Windows.Forms.Button();
            this.txtCnxRepete = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocalEndPoint = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkCodeAscii = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.butAppel = new System.Windows.Forms.Button();
            this.txtFaisceau = new System.Windows.Forms.TextBox();
            this.lblFais = new System.Windows.Forms.Label();
            this.txtMonNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textNumTel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPoste = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNbCar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkRepAuto = new System.Windows.Forms.CheckBox();
            this.chkGipSwissPhone = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.grpRx.SuspendLayout();
            this.grpTx.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.chkAuto);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.btnListen);
            this.groupBox1.Controls.Add(this.txtPortServer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPortClient);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIPClient);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radServer);
            this.groupBox1.Controls.Add(this.radClient);
            this.groupBox1.Location = new System.Drawing.Point(15, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connexion";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.radUdp);
            this.groupBox8.Controls.Add(this.radTcp);
            this.groupBox8.Location = new System.Drawing.Point(77, 7);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(53, 51);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            // 
            // radUdp
            // 
            this.radUdp.AutoSize = true;
            this.radUdp.Location = new System.Drawing.Point(7, 31);
            this.radUdp.Name = "radUdp";
            this.radUdp.Size = new System.Drawing.Size(45, 17);
            this.radUdp.TabIndex = 20;
            this.radUdp.Text = "Udp";
            this.radUdp.UseVisualStyleBackColor = true;
            // 
            // radTcp
            // 
            this.radTcp.AutoSize = true;
            this.radTcp.Checked = true;
            this.radTcp.Location = new System.Drawing.Point(7, 11);
            this.radTcp.Name = "radTcp";
            this.radTcp.Size = new System.Drawing.Size(44, 17);
            this.radTcp.TabIndex = 19;
            this.radTcp.TabStop = true;
            this.radTcp.Text = "Tcp";
            this.radTcp.UseVisualStyleBackColor = true;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(214, 40);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(48, 17);
            this.chkAuto.TabIndex = 16;
            this.chkAuto.Text = "Auto";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(348, 15);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(71, 19);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(348, 39);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(71, 19);
            this.btnListen.TabIndex = 13;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // txtPortServer
            // 
            this.txtPortServer.Location = new System.Drawing.Point(305, 38);
            this.txtPortServer.Name = "txtPortServer";
            this.txtPortServer.Size = new System.Drawing.Size(37, 20);
            this.txtPortServer.TabIndex = 12;
            this.txtPortServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Port";
            // 
            // txtPortClient
            // 
            this.txtPortClient.Location = new System.Drawing.Point(305, 16);
            this.txtPortClient.Name = "txtPortClient";
            this.txtPortClient.Size = new System.Drawing.Size(37, 20);
            this.txtPortClient.TabIndex = 8;
            this.txtPortClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // txtIPClient
            // 
            this.txtIPClient.Location = new System.Drawing.Point(176, 16);
            this.txtIPClient.Name = "txtIPClient";
            this.txtIPClient.Size = new System.Drawing.Size(91, 20);
            this.txtIPClient.TabIndex = 6;
            this.txtIPClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP";
            // 
            // radServer
            // 
            this.radServer.AutoSize = true;
            this.radServer.Location = new System.Drawing.Point(15, 39);
            this.radServer.Name = "radServer";
            this.radServer.Size = new System.Drawing.Size(56, 17);
            this.radServer.TabIndex = 4;
            this.radServer.Text = "Server";
            this.radServer.UseVisualStyleBackColor = true;
            this.radServer.CheckedChanged += new System.EventHandler(this.radServer_CheckedChanged);
            // 
            // radClient
            // 
            this.radClient.AutoSize = true;
            this.radClient.Checked = true;
            this.radClient.Location = new System.Drawing.Point(15, 18);
            this.radClient.Name = "radClient";
            this.radClient.Size = new System.Drawing.Size(51, 17);
            this.radClient.TabIndex = 3;
            this.radClient.TabStop = true;
            this.radClient.Text = "Client";
            this.radClient.UseVisualStyleBackColor = true;
            this.radClient.CheckedChanged += new System.EventHandler(this.radClient_CheckedChanged);
            // 
            // grpRx
            // 
            this.grpRx.Controls.Add(this.chkTraces);
            this.grpRx.Controls.Add(this.butClear);
            this.grpRx.Controls.Add(this.chkHaut);
            this.grpRx.Controls.Add(this.txt);
            this.grpRx.Location = new System.Drawing.Point(15, 65);
            this.grpRx.Name = "grpRx";
            this.grpRx.Size = new System.Drawing.Size(443, 211);
            this.grpRx.TabIndex = 2;
            this.grpRx.TabStop = false;
            // 
            // chkTraces
            // 
            this.chkTraces.AutoSize = true;
            this.chkTraces.Location = new System.Drawing.Point(192, 9);
            this.chkTraces.Name = "chkTraces";
            this.chkTraces.Size = new System.Drawing.Size(76, 17);
            this.chkTraces.TabIndex = 19;
            this.chkTraces.Text = "Traces log";
            this.chkTraces.UseVisualStyleBackColor = true;
            this.chkTraces.CheckedChanged += new System.EventHandler(this.chkTrim_CheckedChanged);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(389, 7);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(45, 19);
            this.butClear.TabIndex = 18;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // chkHaut
            // 
            this.chkHaut.AutoSize = true;
            this.chkHaut.Checked = true;
            this.chkHaut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHaut.Location = new System.Drawing.Point(6, 7);
            this.chkHaut.Name = "chkHaut";
            this.chkHaut.Size = new System.Drawing.Size(175, 17);
            this.chkHaut.TabIndex = 17;
            this.chkHaut.Text = "Ecritures les + récentes en haut";
            this.chkHaut.UseVisualStyleBackColor = true;
            // 
            // txt
            // 
            this.txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.Location = new System.Drawing.Point(6, 30);
            this.txt.MaxLength = 90000;
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt.Size = new System.Drawing.Size(428, 176);
            this.txt.TabIndex = 6;
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // grpTx
            // 
            this.grpTx.Controls.Add(this.button1);
            this.grpTx.Controls.Add(this.butFic);
            this.grpTx.Controls.Add(this.chkEnter);
            this.grpTx.Controls.Add(this.chkBin);
            this.grpTx.Controls.Add(this.chkStxEtx);
            this.grpTx.Controls.Add(this.btnSend);
            this.grpTx.Controls.Add(this.txtSend);
            this.grpTx.Location = new System.Drawing.Point(12, 277);
            this.grpTx.Name = "grpTx";
            this.grpTx.Size = new System.Drawing.Size(446, 216);
            this.grpTx.TabIndex = 3;
            this.grpTx.TabStop = false;
            this.grpTx.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 19);
            this.button1.TabIndex = 20;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butFic
            // 
            this.butFic.Image = ((System.Drawing.Image)(resources.GetObject("butFic.Image")));
            this.butFic.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.butFic.Location = new System.Drawing.Point(287, 10);
            this.butFic.Name = "butFic";
            this.butFic.Size = new System.Drawing.Size(27, 19);
            this.butFic.TabIndex = 19;
            this.butFic.UseVisualStyleBackColor = true;
            this.butFic.Click += new System.EventHandler(this.butFic_Click);
            // 
            // chkEnter
            // 
            this.chkEnter.AutoSize = true;
            this.chkEnter.Location = new System.Drawing.Point(195, 10);
            this.chkEnter.Name = "chkEnter";
            this.chkEnter.Size = new System.Drawing.Size(96, 17);
            this.chkEnter.TabIndex = 17;
            this.chkEnter.Text = "Send sur Enter";
            this.chkEnter.UseVisualStyleBackColor = true;
            // 
            // chkBin
            // 
            this.chkBin.AutoSize = true;
            this.chkBin.Location = new System.Drawing.Point(111, 10);
            this.chkBin.Name = "chkBin";
            this.chkBin.Size = new System.Drawing.Size(78, 17);
            this.chkBin.TabIndex = 16;
            this.chkBin.Text = "Bin apres \\";
            this.chkBin.UseVisualStyleBackColor = true;
            // 
            // chkStxEtx
            // 
            this.chkStxEtx.AutoSize = true;
            this.chkStxEtx.Location = new System.Drawing.Point(9, 10);
            this.chkStxEtx.Name = "chkStxEtx";
            this.chkStxEtx.Size = new System.Drawing.Size(99, 17);
            this.chkStxEtx.TabIndex = 15;
            this.chkStxEtx.Text = "Entre STX ETX";
            this.chkStxEtx.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(392, 8);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(45, 19);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(6, 33);
            this.txtSend.MaxLength = 90000;
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSend.Size = new System.Drawing.Size(431, 176);
            this.txtSend.TabIndex = 6;
            this.txtSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSend_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmdConnectCsat);
            this.groupBox4.Controls.Add(this.txtDelaiCSat);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtCS);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(473, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(168, 63);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CSAT";
            // 
            // cmdConnectCsat
            // 
            this.cmdConnectCsat.Location = new System.Drawing.Point(80, 14);
            this.cmdConnectCsat.Name = "cmdConnectCsat";
            this.cmdConnectCsat.Size = new System.Drawing.Size(83, 19);
            this.cmdConnectCsat.TabIndex = 14;
            this.cmdConnectCsat.Text = "Connect";
            this.cmdConnectCsat.UseVisualStyleBackColor = true;
            this.cmdConnectCsat.Click += new System.EventHandler(this.cmdConnectCsat_Click);
            // 
            // txtDelaiCSat
            // 
            this.txtDelaiCSat.Location = new System.Drawing.Point(86, 38);
            this.txtDelaiCSat.Name = "txtDelaiCSat";
            this.txtDelaiCSat.Size = new System.Drawing.Size(37, 20);
            this.txtDelaiCSat.TabIndex = 12;
            this.txtDelaiCSat.Text = "100";
            this.txtDelaiCSat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Delai Cnx (ms)";
            // 
            // txtCS
            // 
            this.txtCS.Location = new System.Drawing.Point(33, 14);
            this.txtCS.Name = "txtCS";
            this.txtCS.Size = new System.Drawing.Size(41, 20);
            this.txtCS.TabIndex = 6;
            this.txtCS.Text = "FOR";
            this.txtCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "CS";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtTimer);
            this.groupBox5.Location = new System.Drawing.Point(489, 387);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(93, 38);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Send Every (ms)";
            // 
            // txtTimer
            // 
            this.txtTimer.Location = new System.Drawing.Point(29, 12);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.Size = new System.Drawing.Size(58, 20);
            this.txtTimer.TabIndex = 6;
            this.txtTimer.Text = "0";
            this.txtTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSend2
            // 
            this.txtSend2.Location = new System.Drawing.Point(483, 350);
            this.txtSend2.Multiline = true;
            this.txtSend2.Name = "txtSend2";
            this.txtSend2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSend2.Size = new System.Drawing.Size(295, 33);
            this.txtSend2.TabIndex = 9;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtSendRepeat);
            this.groupBox6.Controls.Add(this.cmdStartConnect);
            this.groupBox6.Controls.Add(this.txtCnxRepete);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Location = new System.Drawing.Point(473, 100);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(234, 61);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Connections répétées";
            // 
            // txtSendRepeat
            // 
            this.txtSendRepeat.Location = new System.Drawing.Point(9, 38);
            this.txtSendRepeat.Multiline = true;
            this.txtSendRepeat.Name = "txtSendRepeat";
            this.txtSendRepeat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendRepeat.Size = new System.Drawing.Size(218, 20);
            this.txtSendRepeat.TabIndex = 11;
            // 
            // cmdStartConnect
            // 
            this.cmdStartConnect.Location = new System.Drawing.Point(10, 13);
            this.cmdStartConnect.Name = "cmdStartConnect";
            this.cmdStartConnect.Size = new System.Drawing.Size(83, 19);
            this.cmdStartConnect.TabIndex = 14;
            this.cmdStartConnect.Text = "Start";
            this.cmdStartConnect.UseVisualStyleBackColor = true;
            this.cmdStartConnect.Click += new System.EventHandler(this.cmdStartConnect_Click);
            // 
            // txtCnxRepete
            // 
            this.txtCnxRepete.Location = new System.Drawing.Point(181, 13);
            this.txtCnxRepete.Name = "txtCnxRepete";
            this.txtCnxRepete.Size = new System.Drawing.Size(37, 20);
            this.txtCnxRepete.TabIndex = 12;
            this.txtCnxRepete.Text = "1000";
            this.txtCnxRepete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Delai Cnx (ms)";
            // 
            // txtLocalEndPoint
            // 
            this.txtLocalEndPoint.Location = new System.Drawing.Point(482, 180);
            this.txtLocalEndPoint.Name = "txtLocalEndPoint";
            this.txtLocalEndPoint.Size = new System.Drawing.Size(91, 20);
            this.txtLocalEndPoint.TabIndex = 12;
            this.txtLocalEndPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(478, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "LocalIp EndPoint";
            // 
            // chkCodeAscii
            // 
            this.chkCodeAscii.AutoSize = true;
            this.chkCodeAscii.Location = new System.Drawing.Point(615, 180);
            this.chkCodeAscii.Name = "chkCodeAscii";
            this.chkCodeAscii.Size = new System.Drawing.Size(76, 17);
            this.chkCodeAscii.TabIndex = 17;
            this.chkCodeAscii.Text = "Code Ascii";
            this.chkCodeAscii.UseVisualStyleBackColor = true;
            this.chkCodeAscii.CheckedChanged += new System.EventHandler(this.chkCodeAscii_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button7);
            this.groupBox7.Controls.Add(this.button6);
            this.groupBox7.Controls.Add(this.button5);
            this.groupBox7.Controls.Add(this.button4);
            this.groupBox7.Controls.Add(this.button3);
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Controls.Add(this.butAppel);
            this.groupBox7.Controls.Add(this.txtFaisceau);
            this.groupBox7.Controls.Add(this.lblFais);
            this.groupBox7.Controls.Add(this.txtMonNum);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.textNumTel);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.txtPoste);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Location = new System.Drawing.Point(473, 217);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(342, 127);
            this.groupBox7.TabIndex = 26;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "TELEPHONIE";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(73, 38);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(51, 25);
            this.button7.TabIndex = 41;
            this.button7.Text = "202.55";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(16, 38);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(51, 25);
            this.button6.TabIndex = 40;
            this.button6.Text = "202.52";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(233, 37);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 19);
            this.button5.TabIndex = 39;
            this.button5.Text = "Raccrocher";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(233, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 19);
            this.button4.TabIndex = 37;
            this.button4.Text = "Décrocher";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(73, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 25);
            this.button3.TabIndex = 38;
            this.button3.Text = "202.54";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 25);
            this.button2.TabIndex = 37;
            this.button2.Text = "202.51";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // butAppel
            // 
            this.butAppel.Location = new System.Drawing.Point(176, 15);
            this.butAppel.Name = "butAppel";
            this.butAppel.Size = new System.Drawing.Size(51, 19);
            this.butAppel.TabIndex = 36;
            this.butAppel.Text = "Appel";
            this.butAppel.UseVisualStyleBackColor = true;
            this.butAppel.Click += new System.EventHandler(this.butAppel_Click);
            // 
            // txtFaisceau
            // 
            this.txtFaisceau.Location = new System.Drawing.Point(186, 96);
            this.txtFaisceau.Name = "txtFaisceau";
            this.txtFaisceau.Size = new System.Drawing.Size(75, 20);
            this.txtFaisceau.TabIndex = 35;
            this.txtFaisceau.Text = "18";
            this.txtFaisceau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFais
            // 
            this.lblFais.AutoSize = true;
            this.lblFais.Location = new System.Drawing.Point(130, 99);
            this.lblFais.Name = "lblFais";
            this.lblFais.Size = new System.Drawing.Size(50, 13);
            this.lblFais.TabIndex = 34;
            this.lblFais.Text = "Faisceau";
            // 
            // txtMonNum
            // 
            this.txtMonNum.Location = new System.Drawing.Point(62, 93);
            this.txtMonNum.Name = "txtMonNum";
            this.txtMonNum.Size = new System.Drawing.Size(55, 20);
            this.txtMonNum.TabIndex = 33;
            this.txtMonNum.Text = "2222";
            this.txtMonNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Mon num";
            // 
            // textNumTel
            // 
            this.textNumTel.Location = new System.Drawing.Point(186, 74);
            this.textNumTel.Name = "textNumTel";
            this.textNumTel.Size = new System.Drawing.Size(75, 20);
            this.textNumTel.TabIndex = 31;
            this.textNumTel.Text = "0558062323";
            this.textNumTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(130, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Appelant";
            // 
            // txtPoste
            // 
            this.txtPoste.Location = new System.Drawing.Point(62, 75);
            this.txtPoste.Name = "txtPoste";
            this.txtPoste.Size = new System.Drawing.Size(55, 20);
            this.txtPoste.TabIndex = 29;
            this.txtPoste.Text = "POSTE1";
            this.txtPoste.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Poste";
            // 
            // txtNbCar
            // 
            this.txtNbCar.Location = new System.Drawing.Point(679, 399);
            this.txtNbCar.Name = "txtNbCar";
            this.txtNbCar.Size = new System.Drawing.Size(55, 20);
            this.txtNbCar.TabIndex = 31;
            this.txtNbCar.Text = "20000";
            this.txtNbCar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(620, 402);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "nb Caract";
            // 
            // chkRepAuto
            // 
            this.chkRepAuto.AutoSize = true;
            this.chkRepAuto.Location = new System.Drawing.Point(490, 431);
            this.chkRepAuto.Name = "chkRepAuto";
            this.chkRepAuto.Size = new System.Drawing.Size(130, 17);
            this.chkRepAuto.TabIndex = 32;
            this.chkRepAuto.Text = "Reponse automatique";
            this.chkRepAuto.UseVisualStyleBackColor = true;
            this.chkRepAuto.CheckedChanged += new System.EventHandler(this.chkRepAuto_CheckedChanged);
            // 
            // chkGipSwissPhone
            // 
            this.chkGipSwissPhone.AutoSize = true;
            this.chkGipSwissPhone.Location = new System.Drawing.Point(697, 180);
            this.chkGipSwissPhone.Name = "chkGipSwissPhone";
            this.chkGipSwissPhone.Size = new System.Drawing.Size(101, 17);
            this.chkGipSwissPhone.TabIndex = 33;
            this.chkGipSwissPhone.Text = "gip_swissphone";
            this.chkGipSwissPhone.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 498);
            this.Controls.Add(this.chkGipSwissPhone);
            this.Controls.Add(this.chkRepAuto);
            this.Controls.Add(this.txtNbCar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.chkCodeAscii);
            this.Controls.Add(this.txtLocalEndPoint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.txtSend2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grpTx);
            this.Controls.Add(this.grpRx);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Socket";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.Resize += new System.EventHandler(this.OnResize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.grpRx.ResumeLayout(false);
            this.grpRx.PerformLayout();
            this.grpTx.ResumeLayout(false);
            this.grpTx.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIPClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radServer;
        private System.Windows.Forms.RadioButton radClient;
        private System.Windows.Forms.TextBox txtPortClient;
        private System.Windows.Forms.TextBox txtPortServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpRx;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.GroupBox grpTx;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.CheckBox chkStxEtx;
        private System.Windows.Forms.CheckBox chkBin;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.CheckBox chkEnter;
        private System.Windows.Forms.CheckBox chkHaut;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Button butFic;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdConnectCsat;
        private System.Windows.Forms.TextBox txtDelaiCSat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.TextBox txtSend2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button cmdStartConnect;
        private System.Windows.Forms.TextBox txtCnxRepete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSendRepeat;
        private System.Windows.Forms.TextBox txtLocalEndPoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkCodeAscii;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtMonNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textNumTel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPoste;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton radUdp;
        private System.Windows.Forms.RadioButton radTcp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFaisceau;
        private System.Windows.Forms.Label lblFais;
        private System.Windows.Forms.TextBox txtNbCar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkTraces;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button butAppel;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox chkRepAuto;
        private System.Windows.Forms.CheckBox chkGipSwissPhone;
    }
}

