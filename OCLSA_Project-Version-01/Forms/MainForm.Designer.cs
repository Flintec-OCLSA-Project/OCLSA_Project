namespace OCLSA_Project_Version_01.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.initialTimer = new System.Windows.Forms.Timer(this.components);
            this.serialPortVT400 = new System.IO.Ports.SerialPort(this.components);
            this.horizontalPanel1 = new WindowsFormsAero.HorizontalPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbD2Reading = new System.Windows.Forms.TextBox();
            this.tbD1Reading = new System.Windows.Forms.TextBox();
            this.tbInitialD2Reading = new System.Windows.Forms.TextBox();
            this.tbD3Reading = new System.Windows.Forms.TextBox();
            this.aeroLinkLabel10 = new AeroSuite.Controls.AeroLinkLabel();
            this.tbInitialD1Reading = new System.Windows.Forms.TextBox();
            this.tbInitialD3Reading = new System.Windows.Forms.TextBox();
            this.aeroLinkLabel9 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel8 = new AeroSuite.Controls.AeroLinkLabel();
            this.tbD4Reading = new System.Windows.Forms.TextBox();
            this.tbInitialD4Reading = new System.Windows.Forms.TextBox();
            this.aeroLinkLabel7 = new AeroSuite.Controls.AeroLinkLabel();
            this.tbRightCorner = new System.Windows.Forms.TextBox();
            this.tbInitialRightCornerReading = new System.Windows.Forms.TextBox();
            this.tbLeftCorner = new System.Windows.Forms.TextBox();
            this.tbInitialLeftCornerReading = new System.Windows.Forms.TextBox();
            this.tbBackCorner = new System.Windows.Forms.TextBox();
            this.tbInitialBackCornerReading = new System.Windows.Forms.TextBox();
            this.tbFrontCorner = new System.Windows.Forms.TextBox();
            this.tbInitialFrontCornerReading = new System.Windows.Forms.TextBox();
            this.tbCenter = new System.Windows.Forms.TextBox();
            this.tbInitialCenterReading = new System.Windows.Forms.TextBox();
            this.aeroLinkLabel6 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel5 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel4 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel3 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel2 = new AeroSuite.Controls.AeroLinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbNoOfCycles = new System.Windows.Forms.PictureBox();
            this.pbTotalTime = new System.Windows.Forms.PictureBox();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.pbCalculatedFso = new System.Windows.Forms.PictureBox();
            this.pbInitialFso = new System.Windows.Forms.PictureBox();
            this.pbBridgeUnbalance = new System.Windows.Forms.PictureBox();
            this.trimDataGridView = new System.Windows.Forms.DataGridView();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.aeroLinkLabel16 = new AeroSuite.Controls.AeroLinkLabel();
            this.tbTotalTime = new System.Windows.Forms.TextBox();
            this.aeroLinkLabel15 = new AeroSuite.Controls.AeroLinkLabel();
            this.tbTrimmedCyclesCount = new System.Windows.Forms.TextBox();
            this.aeroLinkLabel14 = new AeroSuite.Controls.AeroLinkLabel();
            this.tbCalculatedFso = new System.Windows.Forms.TextBox();
            this.aeroLinkLabel13 = new AeroSuite.Controls.AeroLinkLabel();
            this.tbInitialFSO = new System.Windows.Forms.TextBox();
            this.aeroLinkLabel12 = new AeroSuite.Controls.AeroLinkLabel();
            this.tbBridgeUnbalance = new System.Windows.Forms.TextBox();
            this.aeroLinkLabel11 = new AeroSuite.Controls.AeroLinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbPositions = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblMinimumFSOFinal = new System.Windows.Forms.Label();
            this.lblMinimumFSO = new System.Windows.Forms.Label();
            this.lblMinimumUnbalance = new System.Windows.Forms.Label();
            this.lblMaximumFSOFinal = new System.Windows.Forms.Label();
            this.lblMaximumFSO = new System.Windows.Forms.Label();
            this.lblMaximumUnbalance = new System.Windows.Forms.Label();
            this.aeroLinkLabel29 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel30 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel37 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel36 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel35 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel34 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel33 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel18 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel17 = new AeroSuite.Controls.AeroLinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblFrontCorner = new System.Windows.Forms.Label();
            this.lblBackCorner = new System.Windows.Forms.Label();
            this.lblLeftCorner = new System.Windows.Forms.Label();
            this.lblRightCorner = new System.Windows.Forms.Label();
            this.lblMaximumCenter = new System.Windows.Forms.Label();
            this.aeroLinkLabel28 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel27 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel26 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel25 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel24 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel23 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel22 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel21 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel20 = new AeroSuite.Controls.AeroLinkLabel();
            this.aeroLinkLabel19 = new AeroSuite.Controls.AeroLinkLabel();
            this.btnStop = new WindowsFormsAero.Button();
            this.btnStart = new WindowsFormsAero.Button();
            this.tbSerialNumber = new WindowsFormsAero.TextBox();
            this.aeroLinkLabel1 = new AeroSuite.Controls.AeroLinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOperatorName = new System.Windows.Forms.Label();
            this.lblOperatorId = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblStation = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lblReading = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStable = new System.Windows.Forms.Label();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNoOfTestRuns = new System.Windows.Forms.Label();
            this.lblDisplayMessage = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TenSecondsCounter = new System.Windows.Forms.Timer(this.components);
            this.FiveSecondsCounter = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.horizontalPanel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoOfCycles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTotalTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCalculatedFso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInitialFso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBridgeUnbalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trimDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPositions)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // initialTimer
            // 
            this.initialTimer.Interval = 200;
            this.initialTimer.Tick += new System.EventHandler(this.initialTimer_Tick);
            // 
            // serialPortVT400
            // 
            this.serialPortVT400.BaudRate = 2400;
            this.serialPortVT400.DtrEnable = true;
            this.serialPortVT400.PortName = "COM8";
            // 
            // horizontalPanel1
            // 
            this.horizontalPanel1.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel1.Controls.Add(this.groupBox6);
            this.horizontalPanel1.Controls.Add(this.groupBox3);
            this.horizontalPanel1.Controls.Add(this.groupBox2);
            this.horizontalPanel1.Controls.Add(this.groupBox1);
            this.horizontalPanel1.Controls.Add(this.menuStrip1);
            this.horizontalPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel1.Location = new System.Drawing.Point(0, 0);
            this.horizontalPanel1.Name = "horizontalPanel1";
            this.horizontalPanel1.Size = new System.Drawing.Size(1352, 701);
            this.horizontalPanel1.TabIndex = 5;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbD2Reading);
            this.groupBox6.Controls.Add(this.tbD1Reading);
            this.groupBox6.Controls.Add(this.tbInitialD2Reading);
            this.groupBox6.Controls.Add(this.tbD3Reading);
            this.groupBox6.Controls.Add(this.aeroLinkLabel10);
            this.groupBox6.Controls.Add(this.tbInitialD1Reading);
            this.groupBox6.Controls.Add(this.tbInitialD3Reading);
            this.groupBox6.Controls.Add(this.aeroLinkLabel9);
            this.groupBox6.Controls.Add(this.aeroLinkLabel8);
            this.groupBox6.Controls.Add(this.tbD4Reading);
            this.groupBox6.Controls.Add(this.tbInitialD4Reading);
            this.groupBox6.Controls.Add(this.aeroLinkLabel7);
            this.groupBox6.Controls.Add(this.tbRightCorner);
            this.groupBox6.Controls.Add(this.tbInitialRightCornerReading);
            this.groupBox6.Controls.Add(this.tbLeftCorner);
            this.groupBox6.Controls.Add(this.tbInitialLeftCornerReading);
            this.groupBox6.Controls.Add(this.tbBackCorner);
            this.groupBox6.Controls.Add(this.tbInitialBackCornerReading);
            this.groupBox6.Controls.Add(this.tbFrontCorner);
            this.groupBox6.Controls.Add(this.tbInitialFrontCornerReading);
            this.groupBox6.Controls.Add(this.tbCenter);
            this.groupBox6.Controls.Add(this.tbInitialCenterReading);
            this.groupBox6.Controls.Add(this.aeroLinkLabel6);
            this.groupBox6.Controls.Add(this.aeroLinkLabel5);
            this.groupBox6.Controls.Add(this.aeroLinkLabel4);
            this.groupBox6.Controls.Add(this.aeroLinkLabel3);
            this.groupBox6.Controls.Add(this.aeroLinkLabel2);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(774, 182);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(578, 268);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Corners and Center Readings ";
            // 
            // tbD2Reading
            // 
            this.tbD2Reading.BackColor = System.Drawing.Color.White;
            this.tbD2Reading.Location = new System.Drawing.Point(423, 68);
            this.tbD2Reading.Name = "tbD2Reading";
            this.tbD2Reading.Size = new System.Drawing.Size(120, 25);
            this.tbD2Reading.TabIndex = 21;
            // 
            // tbD1Reading
            // 
            this.tbD1Reading.BackColor = System.Drawing.Color.White;
            this.tbD1Reading.Location = new System.Drawing.Point(38, 68);
            this.tbD1Reading.Name = "tbD1Reading";
            this.tbD1Reading.Size = new System.Drawing.Size(120, 25);
            this.tbD1Reading.TabIndex = 21;
            // 
            // tbInitialD2Reading
            // 
            this.tbInitialD2Reading.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbInitialD2Reading.Location = new System.Drawing.Point(423, 37);
            this.tbInitialD2Reading.Name = "tbInitialD2Reading";
            this.tbInitialD2Reading.Size = new System.Drawing.Size(120, 25);
            this.tbInitialD2Reading.TabIndex = 20;
            // 
            // tbD3Reading
            // 
            this.tbD3Reading.BackColor = System.Drawing.Color.White;
            this.tbD3Reading.Location = new System.Drawing.Point(423, 234);
            this.tbD3Reading.Name = "tbD3Reading";
            this.tbD3Reading.Size = new System.Drawing.Size(120, 25);
            this.tbD3Reading.TabIndex = 30;
            // 
            // aeroLinkLabel10
            // 
            this.aeroLinkLabel10.AutoSize = true;
            this.aeroLinkLabel10.Location = new System.Drawing.Point(475, 17);
            this.aeroLinkLabel10.Name = "aeroLinkLabel10";
            this.aeroLinkLabel10.Size = new System.Drawing.Size(24, 17);
            this.aeroLinkLabel10.TabIndex = 19;
            this.aeroLinkLabel10.TabStop = true;
            this.aeroLinkLabel10.Text = "D2";
            // 
            // tbInitialD1Reading
            // 
            this.tbInitialD1Reading.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbInitialD1Reading.Location = new System.Drawing.Point(38, 37);
            this.tbInitialD1Reading.Name = "tbInitialD1Reading";
            this.tbInitialD1Reading.Size = new System.Drawing.Size(120, 25);
            this.tbInitialD1Reading.TabIndex = 20;
            // 
            // tbInitialD3Reading
            // 
            this.tbInitialD3Reading.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbInitialD3Reading.Location = new System.Drawing.Point(423, 203);
            this.tbInitialD3Reading.Name = "tbInitialD3Reading";
            this.tbInitialD3Reading.Size = new System.Drawing.Size(120, 25);
            this.tbInitialD3Reading.TabIndex = 29;
            // 
            // aeroLinkLabel9
            // 
            this.aeroLinkLabel9.AutoSize = true;
            this.aeroLinkLabel9.Location = new System.Drawing.Point(84, 17);
            this.aeroLinkLabel9.Name = "aeroLinkLabel9";
            this.aeroLinkLabel9.Size = new System.Drawing.Size(22, 17);
            this.aeroLinkLabel9.TabIndex = 19;
            this.aeroLinkLabel9.TabStop = true;
            this.aeroLinkLabel9.Text = "D1";
            // 
            // aeroLinkLabel8
            // 
            this.aeroLinkLabel8.AutoSize = true;
            this.aeroLinkLabel8.Location = new System.Drawing.Point(475, 183);
            this.aeroLinkLabel8.Name = "aeroLinkLabel8";
            this.aeroLinkLabel8.Size = new System.Drawing.Size(24, 17);
            this.aeroLinkLabel8.TabIndex = 28;
            this.aeroLinkLabel8.TabStop = true;
            this.aeroLinkLabel8.Text = "D3";
            // 
            // tbD4Reading
            // 
            this.tbD4Reading.BackColor = System.Drawing.Color.White;
            this.tbD4Reading.Location = new System.Drawing.Point(40, 234);
            this.tbD4Reading.Name = "tbD4Reading";
            this.tbD4Reading.Size = new System.Drawing.Size(120, 25);
            this.tbD4Reading.TabIndex = 27;
            // 
            // tbInitialD4Reading
            // 
            this.tbInitialD4Reading.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbInitialD4Reading.Location = new System.Drawing.Point(40, 203);
            this.tbInitialD4Reading.Name = "tbInitialD4Reading";
            this.tbInitialD4Reading.Size = new System.Drawing.Size(120, 25);
            this.tbInitialD4Reading.TabIndex = 26;
            // 
            // aeroLinkLabel7
            // 
            this.aeroLinkLabel7.AutoSize = true;
            this.aeroLinkLabel7.Location = new System.Drawing.Point(84, 181);
            this.aeroLinkLabel7.Name = "aeroLinkLabel7";
            this.aeroLinkLabel7.Size = new System.Drawing.Size(24, 17);
            this.aeroLinkLabel7.TabIndex = 25;
            this.aeroLinkLabel7.TabStop = true;
            this.aeroLinkLabel7.Text = "D4";
            // 
            // tbRightCorner
            // 
            this.tbRightCorner.BackColor = System.Drawing.Color.White;
            this.tbRightCorner.Location = new System.Drawing.Point(423, 150);
            this.tbRightCorner.Name = "tbRightCorner";
            this.tbRightCorner.Size = new System.Drawing.Size(120, 25);
            this.tbRightCorner.TabIndex = 24;
            // 
            // tbInitialRightCornerReading
            // 
            this.tbInitialRightCornerReading.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbInitialRightCornerReading.Location = new System.Drawing.Point(423, 119);
            this.tbInitialRightCornerReading.Name = "tbInitialRightCornerReading";
            this.tbInitialRightCornerReading.Size = new System.Drawing.Size(120, 25);
            this.tbInitialRightCornerReading.TabIndex = 23;
            // 
            // tbLeftCorner
            // 
            this.tbLeftCorner.BackColor = System.Drawing.Color.White;
            this.tbLeftCorner.Location = new System.Drawing.Point(40, 150);
            this.tbLeftCorner.Name = "tbLeftCorner";
            this.tbLeftCorner.Size = new System.Drawing.Size(120, 25);
            this.tbLeftCorner.TabIndex = 22;
            // 
            // tbInitialLeftCornerReading
            // 
            this.tbInitialLeftCornerReading.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbInitialLeftCornerReading.Location = new System.Drawing.Point(40, 119);
            this.tbInitialLeftCornerReading.Name = "tbInitialLeftCornerReading";
            this.tbInitialLeftCornerReading.Size = new System.Drawing.Size(120, 25);
            this.tbInitialLeftCornerReading.TabIndex = 21;
            // 
            // tbBackCorner
            // 
            this.tbBackCorner.BackColor = System.Drawing.Color.White;
            this.tbBackCorner.Location = new System.Drawing.Point(232, 66);
            this.tbBackCorner.Name = "tbBackCorner";
            this.tbBackCorner.Size = new System.Drawing.Size(120, 25);
            this.tbBackCorner.TabIndex = 20;
            // 
            // tbInitialBackCornerReading
            // 
            this.tbInitialBackCornerReading.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbInitialBackCornerReading.Location = new System.Drawing.Point(232, 35);
            this.tbInitialBackCornerReading.Name = "tbInitialBackCornerReading";
            this.tbInitialBackCornerReading.Size = new System.Drawing.Size(120, 25);
            this.tbInitialBackCornerReading.TabIndex = 19;
            // 
            // tbFrontCorner
            // 
            this.tbFrontCorner.BackColor = System.Drawing.Color.White;
            this.tbFrontCorner.Location = new System.Drawing.Point(232, 234);
            this.tbFrontCorner.Name = "tbFrontCorner";
            this.tbFrontCorner.Size = new System.Drawing.Size(120, 25);
            this.tbFrontCorner.TabIndex = 18;
            // 
            // tbInitialFrontCornerReading
            // 
            this.tbInitialFrontCornerReading.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbInitialFrontCornerReading.Location = new System.Drawing.Point(232, 203);
            this.tbInitialFrontCornerReading.Name = "tbInitialFrontCornerReading";
            this.tbInitialFrontCornerReading.Size = new System.Drawing.Size(120, 25);
            this.tbInitialFrontCornerReading.TabIndex = 17;
            // 
            // tbCenter
            // 
            this.tbCenter.BackColor = System.Drawing.Color.White;
            this.tbCenter.Location = new System.Drawing.Point(232, 150);
            this.tbCenter.Name = "tbCenter";
            this.tbCenter.Size = new System.Drawing.Size(120, 25);
            this.tbCenter.TabIndex = 16;
            // 
            // tbInitialCenterReading
            // 
            this.tbInitialCenterReading.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbInitialCenterReading.Location = new System.Drawing.Point(232, 119);
            this.tbInitialCenterReading.Name = "tbInitialCenterReading";
            this.tbInitialCenterReading.Size = new System.Drawing.Size(120, 25);
            this.tbInitialCenterReading.TabIndex = 15;
            // 
            // aeroLinkLabel6
            // 
            this.aeroLinkLabel6.AutoSize = true;
            this.aeroLinkLabel6.Location = new System.Drawing.Point(267, 15);
            this.aeroLinkLabel6.Name = "aeroLinkLabel6";
            this.aeroLinkLabel6.Size = new System.Drawing.Size(36, 17);
            this.aeroLinkLabel6.TabIndex = 12;
            this.aeroLinkLabel6.TabStop = true;
            this.aeroLinkLabel6.Text = "Back";
            // 
            // aeroLinkLabel5
            // 
            this.aeroLinkLabel5.AutoSize = true;
            this.aeroLinkLabel5.Location = new System.Drawing.Point(466, 99);
            this.aeroLinkLabel5.Name = "aeroLinkLabel5";
            this.aeroLinkLabel5.Size = new System.Drawing.Size(40, 17);
            this.aeroLinkLabel5.TabIndex = 9;
            this.aeroLinkLabel5.TabStop = true;
            this.aeroLinkLabel5.Text = "Right";
            // 
            // aeroLinkLabel4
            // 
            this.aeroLinkLabel4.AutoSize = true;
            this.aeroLinkLabel4.Location = new System.Drawing.Point(267, 181);
            this.aeroLinkLabel4.Name = "aeroLinkLabel4";
            this.aeroLinkLabel4.Size = new System.Drawing.Size(41, 17);
            this.aeroLinkLabel4.TabIndex = 6;
            this.aeroLinkLabel4.TabStop = true;
            this.aeroLinkLabel4.Text = "Front";
            // 
            // aeroLinkLabel3
            // 
            this.aeroLinkLabel3.AutoSize = true;
            this.aeroLinkLabel3.Location = new System.Drawing.Point(84, 99);
            this.aeroLinkLabel3.Name = "aeroLinkLabel3";
            this.aeroLinkLabel3.Size = new System.Drawing.Size(30, 17);
            this.aeroLinkLabel3.TabIndex = 3;
            this.aeroLinkLabel3.TabStop = true;
            this.aeroLinkLabel3.Text = "Left";
            // 
            // aeroLinkLabel2
            // 
            this.aeroLinkLabel2.AutoSize = true;
            this.aeroLinkLabel2.Location = new System.Drawing.Point(267, 99);
            this.aeroLinkLabel2.Name = "aeroLinkLabel2";
            this.aeroLinkLabel2.Size = new System.Drawing.Size(48, 17);
            this.aeroLinkLabel2.TabIndex = 0;
            this.aeroLinkLabel2.TabStop = true;
            this.aeroLinkLabel2.Text = "Center";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbNoOfCycles);
            this.groupBox3.Controls.Add(this.pbTotalTime);
            this.groupBox3.Controls.Add(this.pbStatus);
            this.groupBox3.Controls.Add(this.pbCalculatedFso);
            this.groupBox3.Controls.Add(this.pbInitialFso);
            this.groupBox3.Controls.Add(this.pbBridgeUnbalance);
            this.groupBox3.Controls.Add(this.trimDataGridView);
            this.groupBox3.Controls.Add(this.tbStatus);
            this.groupBox3.Controls.Add(this.aeroLinkLabel16);
            this.groupBox3.Controls.Add(this.tbTotalTime);
            this.groupBox3.Controls.Add(this.aeroLinkLabel15);
            this.groupBox3.Controls.Add(this.tbTrimmedCyclesCount);
            this.groupBox3.Controls.Add(this.aeroLinkLabel14);
            this.groupBox3.Controls.Add(this.tbCalculatedFso);
            this.groupBox3.Controls.Add(this.aeroLinkLabel13);
            this.groupBox3.Controls.Add(this.tbInitialFSO);
            this.groupBox3.Controls.Add(this.aeroLinkLabel12);
            this.groupBox3.Controls.Add(this.tbBridgeUnbalance);
            this.groupBox3.Controls.Add(this.aeroLinkLabel11);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(352, 456);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1000, 242);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Summary";
            // 
            // pbNoOfCycles
            // 
            this.pbNoOfCycles.Location = new System.Drawing.Point(268, 130);
            this.pbNoOfCycles.Name = "pbNoOfCycles";
            this.pbNoOfCycles.Size = new System.Drawing.Size(28, 35);
            this.pbNoOfCycles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNoOfCycles.TabIndex = 49;
            this.pbNoOfCycles.TabStop = false;
            // 
            // pbTotalTime
            // 
            this.pbTotalTime.Location = new System.Drawing.Point(268, 166);
            this.pbTotalTime.Name = "pbTotalTime";
            this.pbTotalTime.Size = new System.Drawing.Size(28, 35);
            this.pbTotalTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTotalTime.TabIndex = 48;
            this.pbTotalTime.TabStop = false;
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(268, 202);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(28, 35);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatus.TabIndex = 47;
            this.pbStatus.TabStop = false;
            // 
            // pbCalculatedFso
            // 
            this.pbCalculatedFso.Location = new System.Drawing.Point(268, 95);
            this.pbCalculatedFso.Name = "pbCalculatedFso";
            this.pbCalculatedFso.Size = new System.Drawing.Size(28, 35);
            this.pbCalculatedFso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCalculatedFso.TabIndex = 45;
            this.pbCalculatedFso.TabStop = false;
            // 
            // pbInitialFso
            // 
            this.pbInitialFso.Location = new System.Drawing.Point(268, 58);
            this.pbInitialFso.Name = "pbInitialFso";
            this.pbInitialFso.Size = new System.Drawing.Size(28, 35);
            this.pbInitialFso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInitialFso.TabIndex = 44;
            this.pbInitialFso.TabStop = false;
            // 
            // pbBridgeUnbalance
            // 
            this.pbBridgeUnbalance.Location = new System.Drawing.Point(268, 22);
            this.pbBridgeUnbalance.Name = "pbBridgeUnbalance";
            this.pbBridgeUnbalance.Size = new System.Drawing.Size(28, 35);
            this.pbBridgeUnbalance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBridgeUnbalance.TabIndex = 43;
            this.pbBridgeUnbalance.TabStop = false;
            // 
            // trimDataGridView
            // 
            this.trimDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trimDataGridView.Location = new System.Drawing.Point(302, 24);
            this.trimDataGridView.Name = "trimDataGridView";
            this.trimDataGridView.Size = new System.Drawing.Size(693, 212);
            this.trimDataGridView.TabIndex = 42;
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(146, 208);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(117, 25);
            this.tbStatus.TabIndex = 41;
            // 
            // aeroLinkLabel16
            // 
            this.aeroLinkLabel16.AutoSize = true;
            this.aeroLinkLabel16.Location = new System.Drawing.Point(7, 211);
            this.aeroLinkLabel16.Name = "aeroLinkLabel16";
            this.aeroLinkLabel16.Size = new System.Drawing.Size(46, 17);
            this.aeroLinkLabel16.TabIndex = 40;
            this.aeroLinkLabel16.TabStop = true;
            this.aeroLinkLabel16.Text = "Status";
            // 
            // tbTotalTime
            // 
            this.tbTotalTime.Location = new System.Drawing.Point(146, 173);
            this.tbTotalTime.Name = "tbTotalTime";
            this.tbTotalTime.Size = new System.Drawing.Size(117, 25);
            this.tbTotalTime.TabIndex = 39;
            // 
            // aeroLinkLabel15
            // 
            this.aeroLinkLabel15.AutoSize = true;
            this.aeroLinkLabel15.Location = new System.Drawing.Point(7, 177);
            this.aeroLinkLabel15.Name = "aeroLinkLabel15";
            this.aeroLinkLabel15.Size = new System.Drawing.Size(70, 17);
            this.aeroLinkLabel15.TabIndex = 38;
            this.aeroLinkLabel15.TabStop = true;
            this.aeroLinkLabel15.Text = "Total Time";
            // 
            // tbTrimmedCyclesCount
            // 
            this.tbTrimmedCyclesCount.Location = new System.Drawing.Point(146, 137);
            this.tbTrimmedCyclesCount.Name = "tbTrimmedCyclesCount";
            this.tbTrimmedCyclesCount.Size = new System.Drawing.Size(117, 25);
            this.tbTrimmedCyclesCount.TabIndex = 37;
            // 
            // aeroLinkLabel14
            // 
            this.aeroLinkLabel14.AutoSize = true;
            this.aeroLinkLabel14.Location = new System.Drawing.Point(7, 140);
            this.aeroLinkLabel14.Name = "aeroLinkLabel14";
            this.aeroLinkLabel14.Size = new System.Drawing.Size(140, 17);
            this.aeroLinkLabel14.TabIndex = 36;
            this.aeroLinkLabel14.TabStop = true;
            this.aeroLinkLabel14.Text = "No of Trimmed Cycles";
            // 
            // tbCalculatedFso
            // 
            this.tbCalculatedFso.Location = new System.Drawing.Point(146, 100);
            this.tbCalculatedFso.Name = "tbCalculatedFso";
            this.tbCalculatedFso.Size = new System.Drawing.Size(117, 25);
            this.tbCalculatedFso.TabIndex = 35;
            // 
            // aeroLinkLabel13
            // 
            this.aeroLinkLabel13.AutoSize = true;
            this.aeroLinkLabel13.Location = new System.Drawing.Point(7, 103);
            this.aeroLinkLabel13.Name = "aeroLinkLabel13";
            this.aeroLinkLabel13.Size = new System.Drawing.Size(98, 17);
            this.aeroLinkLabel13.TabIndex = 34;
            this.aeroLinkLabel13.TabStop = true;
            this.aeroLinkLabel13.Text = "Calculated FSO";
            // 
            // tbInitialFSO
            // 
            this.tbInitialFSO.Location = new System.Drawing.Point(146, 64);
            this.tbInitialFSO.Name = "tbInitialFSO";
            this.tbInitialFSO.Size = new System.Drawing.Size(117, 25);
            this.tbInitialFSO.TabIndex = 33;
            // 
            // aeroLinkLabel12
            // 
            this.aeroLinkLabel12.AutoSize = true;
            this.aeroLinkLabel12.Location = new System.Drawing.Point(7, 67);
            this.aeroLinkLabel12.Name = "aeroLinkLabel12";
            this.aeroLinkLabel12.Size = new System.Drawing.Size(69, 17);
            this.aeroLinkLabel12.TabIndex = 32;
            this.aeroLinkLabel12.TabStop = true;
            this.aeroLinkLabel12.Text = "Initial FSO";
            // 
            // tbBridgeUnbalance
            // 
            this.tbBridgeUnbalance.Location = new System.Drawing.Point(146, 27);
            this.tbBridgeUnbalance.Name = "tbBridgeUnbalance";
            this.tbBridgeUnbalance.Size = new System.Drawing.Size(117, 25);
            this.tbBridgeUnbalance.TabIndex = 31;
            // 
            // aeroLinkLabel11
            // 
            this.aeroLinkLabel11.AutoSize = true;
            this.aeroLinkLabel11.Location = new System.Drawing.Point(7, 30);
            this.aeroLinkLabel11.Name = "aeroLinkLabel11";
            this.aeroLinkLabel11.Size = new System.Drawing.Size(114, 17);
            this.aeroLinkLabel11.TabIndex = 4;
            this.aeroLinkLabel11.TabStop = true;
            this.aeroLinkLabel11.Text = "Bridge Unbalance";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbPositions);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(352, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 268);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graphical Display";
            // 
            // pbPositions
            // 
            this.pbPositions.Location = new System.Drawing.Point(6, 18);
            this.pbPositions.Name = "pbPositions";
            this.pbPositions.Size = new System.Drawing.Size(401, 245);
            this.pbPositions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPositions.TabIndex = 0;
            this.pbPositions.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.tbSerialNumber);
            this.groupBox1.Controls.Add(this.aeroLinkLabel1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 516);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Cell Information";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblMinimumFSOFinal);
            this.groupBox5.Controls.Add(this.lblMinimumFSO);
            this.groupBox5.Controls.Add(this.lblMinimumUnbalance);
            this.groupBox5.Controls.Add(this.lblMaximumFSOFinal);
            this.groupBox5.Controls.Add(this.lblMaximumFSO);
            this.groupBox5.Controls.Add(this.lblMaximumUnbalance);
            this.groupBox5.Controls.Add(this.aeroLinkLabel29);
            this.groupBox5.Controls.Add(this.aeroLinkLabel30);
            this.groupBox5.Controls.Add(this.aeroLinkLabel37);
            this.groupBox5.Controls.Add(this.aeroLinkLabel36);
            this.groupBox5.Controls.Add(this.aeroLinkLabel35);
            this.groupBox5.Controls.Add(this.aeroLinkLabel34);
            this.groupBox5.Controls.Add(this.aeroLinkLabel33);
            this.groupBox5.Controls.Add(this.aeroLinkLabel18);
            this.groupBox5.Controls.Add(this.aeroLinkLabel17);
            this.groupBox5.Location = new System.Drawing.Point(8, 386);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(317, 124);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Pass Fail Range";
            // 
            // lblMinimumFSOFinal
            // 
            this.lblMinimumFSOFinal.AutoSize = true;
            this.lblMinimumFSOFinal.ForeColor = System.Drawing.Color.Red;
            this.lblMinimumFSOFinal.Location = new System.Drawing.Point(13, 96);
            this.lblMinimumFSOFinal.Name = "lblMinimumFSOFinal";
            this.lblMinimumFSOFinal.Size = new System.Drawing.Size(15, 17);
            this.lblMinimumFSOFinal.TabIndex = 34;
            this.lblMinimumFSOFinal.Text = "0";
            // 
            // lblMinimumFSO
            // 
            this.lblMinimumFSO.AutoSize = true;
            this.lblMinimumFSO.ForeColor = System.Drawing.Color.Red;
            this.lblMinimumFSO.Location = new System.Drawing.Point(13, 65);
            this.lblMinimumFSO.Name = "lblMinimumFSO";
            this.lblMinimumFSO.Size = new System.Drawing.Size(15, 17);
            this.lblMinimumFSO.TabIndex = 35;
            this.lblMinimumFSO.Text = "0";
            // 
            // lblMinimumUnbalance
            // 
            this.lblMinimumUnbalance.AutoSize = true;
            this.lblMinimumUnbalance.ForeColor = System.Drawing.Color.Red;
            this.lblMinimumUnbalance.Location = new System.Drawing.Point(13, 34);
            this.lblMinimumUnbalance.Name = "lblMinimumUnbalance";
            this.lblMinimumUnbalance.Size = new System.Drawing.Size(15, 17);
            this.lblMinimumUnbalance.TabIndex = 36;
            this.lblMinimumUnbalance.Text = "0";
            // 
            // lblMaximumFSOFinal
            // 
            this.lblMaximumFSOFinal.AutoSize = true;
            this.lblMaximumFSOFinal.ForeColor = System.Drawing.Color.Red;
            this.lblMaximumFSOFinal.Location = new System.Drawing.Point(238, 96);
            this.lblMaximumFSOFinal.Name = "lblMaximumFSOFinal";
            this.lblMaximumFSOFinal.Size = new System.Drawing.Size(15, 17);
            this.lblMaximumFSOFinal.TabIndex = 37;
            this.lblMaximumFSOFinal.Text = "0";
            // 
            // lblMaximumFSO
            // 
            this.lblMaximumFSO.AutoSize = true;
            this.lblMaximumFSO.ForeColor = System.Drawing.Color.Red;
            this.lblMaximumFSO.Location = new System.Drawing.Point(238, 65);
            this.lblMaximumFSO.Name = "lblMaximumFSO";
            this.lblMaximumFSO.Size = new System.Drawing.Size(15, 17);
            this.lblMaximumFSO.TabIndex = 38;
            this.lblMaximumFSO.Text = "0";
            // 
            // lblMaximumUnbalance
            // 
            this.lblMaximumUnbalance.AutoSize = true;
            this.lblMaximumUnbalance.ForeColor = System.Drawing.Color.Red;
            this.lblMaximumUnbalance.Location = new System.Drawing.Point(238, 34);
            this.lblMaximumUnbalance.Name = "lblMaximumUnbalance";
            this.lblMaximumUnbalance.Size = new System.Drawing.Size(15, 17);
            this.lblMaximumUnbalance.TabIndex = 39;
            this.lblMaximumUnbalance.Text = "0";
            // 
            // aeroLinkLabel29
            // 
            this.aeroLinkLabel29.AutoSize = true;
            this.aeroLinkLabel29.Location = new System.Drawing.Point(68, 96);
            this.aeroLinkLabel29.Name = "aeroLinkLabel29";
            this.aeroLinkLabel29.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel29.TabIndex = 31;
            this.aeroLinkLabel29.TabStop = true;
            this.aeroLinkLabel29.Text = "<=";
            // 
            // aeroLinkLabel30
            // 
            this.aeroLinkLabel30.AutoSize = true;
            this.aeroLinkLabel30.Location = new System.Drawing.Point(205, 96);
            this.aeroLinkLabel30.Name = "aeroLinkLabel30";
            this.aeroLinkLabel30.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel30.TabIndex = 30;
            this.aeroLinkLabel30.TabStop = true;
            this.aeroLinkLabel30.Text = "<=";
            // 
            // aeroLinkLabel37
            // 
            this.aeroLinkLabel37.AutoSize = true;
            this.aeroLinkLabel37.Location = new System.Drawing.Point(119, 96);
            this.aeroLinkLabel37.Name = "aeroLinkLabel37";
            this.aeroLinkLabel37.Size = new System.Drawing.Size(56, 17);
            this.aeroLinkLabel37.TabIndex = 27;
            this.aeroLinkLabel37.TabStop = true;
            this.aeroLinkLabel37.Text = "FSO      ";
            // 
            // aeroLinkLabel36
            // 
            this.aeroLinkLabel36.AutoSize = true;
            this.aeroLinkLabel36.Location = new System.Drawing.Point(69, 65);
            this.aeroLinkLabel36.Name = "aeroLinkLabel36";
            this.aeroLinkLabel36.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel36.TabIndex = 26;
            this.aeroLinkLabel36.TabStop = true;
            this.aeroLinkLabel36.Text = "<=";
            // 
            // aeroLinkLabel35
            // 
            this.aeroLinkLabel35.AutoSize = true;
            this.aeroLinkLabel35.Location = new System.Drawing.Point(69, 34);
            this.aeroLinkLabel35.Name = "aeroLinkLabel35";
            this.aeroLinkLabel35.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel35.TabIndex = 24;
            this.aeroLinkLabel35.TabStop = true;
            this.aeroLinkLabel35.Text = "<=";
            // 
            // aeroLinkLabel34
            // 
            this.aeroLinkLabel34.AutoSize = true;
            this.aeroLinkLabel34.Location = new System.Drawing.Point(206, 65);
            this.aeroLinkLabel34.Name = "aeroLinkLabel34";
            this.aeroLinkLabel34.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel34.TabIndex = 25;
            this.aeroLinkLabel34.TabStop = true;
            this.aeroLinkLabel34.Text = "<=";
            // 
            // aeroLinkLabel33
            // 
            this.aeroLinkLabel33.AutoSize = true;
            this.aeroLinkLabel33.Location = new System.Drawing.Point(206, 34);
            this.aeroLinkLabel33.Name = "aeroLinkLabel33";
            this.aeroLinkLabel33.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel33.TabIndex = 24;
            this.aeroLinkLabel33.TabStop = true;
            this.aeroLinkLabel33.Text = "<=";
            // 
            // aeroLinkLabel18
            // 
            this.aeroLinkLabel18.AutoSize = true;
            this.aeroLinkLabel18.Location = new System.Drawing.Point(108, 65);
            this.aeroLinkLabel18.Name = "aeroLinkLabel18";
            this.aeroLinkLabel18.Size = new System.Drawing.Size(88, 17);
            this.aeroLinkLabel18.TabIndex = 8;
            this.aeroLinkLabel18.TabStop = true;
            this.aeroLinkLabel18.Text = "Final FSO      ";
            // 
            // aeroLinkLabel17
            // 
            this.aeroLinkLabel17.AutoSize = true;
            this.aeroLinkLabel17.Location = new System.Drawing.Point(96, 34);
            this.aeroLinkLabel17.Name = "aeroLinkLabel17";
            this.aeroLinkLabel17.Size = new System.Drawing.Size(118, 17);
            this.aeroLinkLabel17.TabIndex = 5;
            this.aeroLinkLabel17.TabStop = true;
            this.aeroLinkLabel17.Text = "Bridge Unbalance ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblFrontCorner);
            this.groupBox4.Controls.Add(this.lblBackCorner);
            this.groupBox4.Controls.Add(this.lblLeftCorner);
            this.groupBox4.Controls.Add(this.lblRightCorner);
            this.groupBox4.Controls.Add(this.lblMaximumCenter);
            this.groupBox4.Controls.Add(this.aeroLinkLabel28);
            this.groupBox4.Controls.Add(this.aeroLinkLabel27);
            this.groupBox4.Controls.Add(this.aeroLinkLabel26);
            this.groupBox4.Controls.Add(this.aeroLinkLabel25);
            this.groupBox4.Controls.Add(this.aeroLinkLabel24);
            this.groupBox4.Controls.Add(this.aeroLinkLabel23);
            this.groupBox4.Controls.Add(this.aeroLinkLabel22);
            this.groupBox4.Controls.Add(this.aeroLinkLabel21);
            this.groupBox4.Controls.Add(this.aeroLinkLabel20);
            this.groupBox4.Controls.Add(this.aeroLinkLabel19);
            this.groupBox4.Location = new System.Drawing.Point(8, 173);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 207);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Corner and Center Trim Range";
            // 
            // lblFrontCorner
            // 
            this.lblFrontCorner.AutoSize = true;
            this.lblFrontCorner.ForeColor = System.Drawing.Color.Red;
            this.lblFrontCorner.Location = new System.Drawing.Point(213, 76);
            this.lblFrontCorner.Name = "lblFrontCorner";
            this.lblFrontCorner.Size = new System.Drawing.Size(15, 17);
            this.lblFrontCorner.TabIndex = 33;
            this.lblFrontCorner.Text = "0";
            // 
            // lblBackCorner
            // 
            this.lblBackCorner.AutoSize = true;
            this.lblBackCorner.ForeColor = System.Drawing.Color.Red;
            this.lblBackCorner.Location = new System.Drawing.Point(213, 103);
            this.lblBackCorner.Name = "lblBackCorner";
            this.lblBackCorner.Size = new System.Drawing.Size(15, 17);
            this.lblBackCorner.TabIndex = 32;
            this.lblBackCorner.Text = "0";
            // 
            // lblLeftCorner
            // 
            this.lblLeftCorner.AutoSize = true;
            this.lblLeftCorner.ForeColor = System.Drawing.Color.Red;
            this.lblLeftCorner.Location = new System.Drawing.Point(213, 130);
            this.lblLeftCorner.Name = "lblLeftCorner";
            this.lblLeftCorner.Size = new System.Drawing.Size(15, 17);
            this.lblLeftCorner.TabIndex = 31;
            this.lblLeftCorner.Text = "0";
            // 
            // lblRightCorner
            // 
            this.lblRightCorner.AutoSize = true;
            this.lblRightCorner.ForeColor = System.Drawing.Color.Red;
            this.lblRightCorner.Location = new System.Drawing.Point(213, 158);
            this.lblRightCorner.Name = "lblRightCorner";
            this.lblRightCorner.Size = new System.Drawing.Size(15, 17);
            this.lblRightCorner.TabIndex = 30;
            this.lblRightCorner.Text = "0";
            // 
            // lblMaximumCenter
            // 
            this.lblMaximumCenter.AutoSize = true;
            this.lblMaximumCenter.ForeColor = System.Drawing.Color.Red;
            this.lblMaximumCenter.Location = new System.Drawing.Point(213, 38);
            this.lblMaximumCenter.Name = "lblMaximumCenter";
            this.lblMaximumCenter.Size = new System.Drawing.Size(15, 17);
            this.lblMaximumCenter.TabIndex = 29;
            this.lblMaximumCenter.Text = "0";
            // 
            // aeroLinkLabel28
            // 
            this.aeroLinkLabel28.AutoSize = true;
            this.aeroLinkLabel28.Location = new System.Drawing.Point(177, 103);
            this.aeroLinkLabel28.Name = "aeroLinkLabel28";
            this.aeroLinkLabel28.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel28.TabIndex = 19;
            this.aeroLinkLabel28.TabStop = true;
            this.aeroLinkLabel28.Text = "<=";
            // 
            // aeroLinkLabel27
            // 
            this.aeroLinkLabel27.AutoSize = true;
            this.aeroLinkLabel27.Location = new System.Drawing.Point(177, 130);
            this.aeroLinkLabel27.Name = "aeroLinkLabel27";
            this.aeroLinkLabel27.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel27.TabIndex = 18;
            this.aeroLinkLabel27.TabStop = true;
            this.aeroLinkLabel27.Text = "<=";
            // 
            // aeroLinkLabel26
            // 
            this.aeroLinkLabel26.AutoSize = true;
            this.aeroLinkLabel26.Location = new System.Drawing.Point(177, 158);
            this.aeroLinkLabel26.Name = "aeroLinkLabel26";
            this.aeroLinkLabel26.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel26.TabIndex = 17;
            this.aeroLinkLabel26.TabStop = true;
            this.aeroLinkLabel26.Text = "<=";
            // 
            // aeroLinkLabel25
            // 
            this.aeroLinkLabel25.AutoSize = true;
            this.aeroLinkLabel25.Location = new System.Drawing.Point(177, 76);
            this.aeroLinkLabel25.Name = "aeroLinkLabel25";
            this.aeroLinkLabel25.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel25.TabIndex = 16;
            this.aeroLinkLabel25.TabStop = true;
            this.aeroLinkLabel25.Text = "<=";
            // 
            // aeroLinkLabel24
            // 
            this.aeroLinkLabel24.AutoSize = true;
            this.aeroLinkLabel24.Location = new System.Drawing.Point(176, 38);
            this.aeroLinkLabel24.Name = "aeroLinkLabel24";
            this.aeroLinkLabel24.Size = new System.Drawing.Size(26, 17);
            this.aeroLinkLabel24.TabIndex = 15;
            this.aeroLinkLabel24.TabStop = true;
            this.aeroLinkLabel24.Text = "<=";
            // 
            // aeroLinkLabel23
            // 
            this.aeroLinkLabel23.AutoSize = true;
            this.aeroLinkLabel23.Location = new System.Drawing.Point(89, 158);
            this.aeroLinkLabel23.Name = "aeroLinkLabel23";
            this.aeroLinkLabel23.Size = new System.Drawing.Size(89, 17);
            this.aeroLinkLabel23.TabIndex = 14;
            this.aeroLinkLabel23.TabStop = true;
            this.aeroLinkLabel23.Text = "Right-Corner ";
            // 
            // aeroLinkLabel22
            // 
            this.aeroLinkLabel22.AutoSize = true;
            this.aeroLinkLabel22.Location = new System.Drawing.Point(89, 130);
            this.aeroLinkLabel22.Name = "aeroLinkLabel22";
            this.aeroLinkLabel22.Size = new System.Drawing.Size(83, 17);
            this.aeroLinkLabel22.TabIndex = 13;
            this.aeroLinkLabel22.TabStop = true;
            this.aeroLinkLabel22.Text = "Left-Corner  ";
            // 
            // aeroLinkLabel21
            // 
            this.aeroLinkLabel21.AutoSize = true;
            this.aeroLinkLabel21.Location = new System.Drawing.Point(88, 103);
            this.aeroLinkLabel21.Name = "aeroLinkLabel21";
            this.aeroLinkLabel21.Size = new System.Drawing.Size(89, 17);
            this.aeroLinkLabel21.TabIndex = 12;
            this.aeroLinkLabel21.TabStop = true;
            this.aeroLinkLabel21.Text = "Back-Corner  ";
            // 
            // aeroLinkLabel20
            // 
            this.aeroLinkLabel20.AutoSize = true;
            this.aeroLinkLabel20.Location = new System.Drawing.Point(89, 76);
            this.aeroLinkLabel20.Name = "aeroLinkLabel20";
            this.aeroLinkLabel20.Size = new System.Drawing.Size(90, 17);
            this.aeroLinkLabel20.TabIndex = 11;
            this.aeroLinkLabel20.TabStop = true;
            this.aeroLinkLabel20.Text = "Front-Corner ";
            // 
            // aeroLinkLabel19
            // 
            this.aeroLinkLabel19.AutoSize = true;
            this.aeroLinkLabel19.Location = new System.Drawing.Point(88, 38);
            this.aeroLinkLabel19.Name = "aeroLinkLabel19";
            this.aeroLinkLabel19.Size = new System.Drawing.Size(84, 17);
            this.aeroLinkLabel19.TabIndex = 11;
            this.aeroLinkLabel19.TabStop = true;
            this.aeroLinkLabel19.Text = "Final Center ";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStop.Location = new System.Drawing.Point(175, 113);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 49);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStart.Location = new System.Drawing.Point(8, 113);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 49);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSerialNumber.Location = new System.Drawing.Point(8, 63);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(317, 36);
            this.tbSerialNumber.TabIndex = 1;
            this.tbSerialNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSerialNumber_KeyPress);
            // 
            // aeroLinkLabel1
            // 
            this.aeroLinkLabel1.AutoSize = true;
            this.aeroLinkLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aeroLinkLabel1.Location = new System.Drawing.Point(6, 28);
            this.aeroLinkLabel1.Name = "aeroLinkLabel1";
            this.aeroLinkLabel1.Size = new System.Drawing.Size(140, 25);
            this.aeroLinkLabel1.TabIndex = 0;
            this.aeroLinkLabel1.TabStop = true;
            this.aeroLinkLabel1.Text = "Serial Number";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1352, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // lblOperatorName
            // 
            this.lblOperatorName.AutoSize = true;
            this.lblOperatorName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorName.Location = new System.Drawing.Point(26, 6);
            this.lblOperatorName.Name = "lblOperatorName";
            this.lblOperatorName.Size = new System.Drawing.Size(124, 21);
            this.lblOperatorName.TabIndex = 1;
            this.lblOperatorName.Text = "Opeartor Name";
            // 
            // lblOperatorId
            // 
            this.lblOperatorId.AutoSize = true;
            this.lblOperatorId.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorId.Location = new System.Drawing.Point(26, 28);
            this.lblOperatorId.Name = "lblOperatorId";
            this.lblOperatorId.Size = new System.Drawing.Size(97, 21);
            this.lblOperatorId.TabIndex = 2;
            this.lblOperatorId.Text = "Opeartor ID";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(26, 51);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(73, 21);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "Location";
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation.Location = new System.Drawing.Point(26, 74);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(62, 21);
            this.lblStation.TabIndex = 4;
            this.lblStation.Text = "Station";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.lblStation);
            this.panel2.Controls.Add(this.lblLocation);
            this.panel2.Controls.Add(this.lblOperatorId);
            this.panel2.Controls.Add(this.lblOperatorName);
            this.panel2.Controls.Add(this.pbImage);
            this.panel2.Location = new System.Drawing.Point(1088, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 100);
            this.panel2.TabIndex = 3;
            // 
            // pbImage
            // 
            this.pbImage.Image = ((System.Drawing.Image)(resources.GetObject("pbImage.Image")));
            this.pbImage.Location = new System.Drawing.Point(166, 0);
            this.pbImage.MaximumSize = new System.Drawing.Size(98, 100);
            this.pbImage.MinimumSize = new System.Drawing.Size(98, 100);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(98, 100);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // lblReading
            // 
            this.lblReading.AutoSize = true;
            this.lblReading.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReading.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblReading.Location = new System.Drawing.Point(21, 4);
            this.lblReading.Name = "lblReading";
            this.lblReading.Size = new System.Drawing.Size(209, 65);
            this.lblReading.TabIndex = 0;
            this.lblReading.Text = "0.00000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(267, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 65);
            this.label7.TabIndex = 1;
            this.label7.Text = "mV/ V";
            // 
            // lblStable
            // 
            this.lblStable.AutoSize = true;
            this.lblStable.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStable.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStable.Location = new System.Drawing.Point(35, 63);
            this.lblStable.Name = "lblStable";
            this.lblStable.Size = new System.Drawing.Size(0, 28);
            this.lblStable.TabIndex = 3;
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiting.ForeColor = System.Drawing.Color.Gold;
            this.lblWaiting.Location = new System.Drawing.Point(890, 19);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(0, 32);
            this.lblWaiting.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.lblNoOfTestRuns);
            this.panel1.Controls.Add(this.lblDisplayMessage);
            this.panel1.Controls.Add(this.lblWaiting);
            this.panel1.Controls.Add(this.lblStable);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblReading);
            this.panel1.Location = new System.Drawing.Point(12, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 100);
            this.panel1.TabIndex = 2;
            // 
            // lblNoOfTestRuns
            // 
            this.lblNoOfTestRuns.AutoSize = true;
            this.lblNoOfTestRuns.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfTestRuns.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblNoOfTestRuns.Location = new System.Drawing.Point(938, 61);
            this.lblNoOfTestRuns.Name = "lblNoOfTestRuns";
            this.lblNoOfTestRuns.Size = new System.Drawing.Size(0, 30);
            this.lblNoOfTestRuns.TabIndex = 6;
            // 
            // lblDisplayMessage
            // 
            this.lblDisplayMessage.AutoSize = true;
            this.lblDisplayMessage.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayMessage.ForeColor = System.Drawing.Color.Aqua;
            this.lblDisplayMessage.Location = new System.Drawing.Point(470, 63);
            this.lblDisplayMessage.Name = "lblDisplayMessage";
            this.lblDisplayMessage.Size = new System.Drawing.Size(0, 28);
            this.lblDisplayMessage.TabIndex = 5;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TenSecondsCounter
            // 
            this.TenSecondsCounter.Interval = 1000;
            this.TenSecondsCounter.Tick += new System.EventHandler(this.TenSecondsCounter_Tick);
            // 
            // FiveSecondsCounter
            // 
            this.FiveSecondsCounter.Interval = 1000;
            this.FiveSecondsCounter.Tick += new System.EventHandler(this.FiveSecondsCounter_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(409, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "OCLSA Automation System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(12, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1340, 50);
            this.panel3.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 701);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.horizontalPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "OCLSA Automation System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.horizontalPanel1.ResumeLayout(false);
            this.horizontalPanel1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoOfCycles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTotalTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCalculatedFso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInitialFso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBridgeUnbalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trimDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPositions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer initialTimer;
        private System.IO.Ports.SerialPort serialPortVT400;
        private WindowsFormsAero.HorizontalPanel horizontalPanel1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbD2Reading;
        private System.Windows.Forms.TextBox tbD1Reading;
        private System.Windows.Forms.TextBox tbInitialD2Reading;
        private System.Windows.Forms.TextBox tbD3Reading;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel10;
        private System.Windows.Forms.TextBox tbInitialD1Reading;
        private System.Windows.Forms.TextBox tbInitialD3Reading;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel9;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel8;
        private System.Windows.Forms.TextBox tbD4Reading;
        private System.Windows.Forms.TextBox tbInitialD4Reading;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel7;
        private System.Windows.Forms.TextBox tbRightCorner;
        private System.Windows.Forms.TextBox tbInitialRightCornerReading;
        private System.Windows.Forms.TextBox tbLeftCorner;
        private System.Windows.Forms.TextBox tbInitialLeftCornerReading;
        private System.Windows.Forms.TextBox tbBackCorner;
        private System.Windows.Forms.TextBox tbInitialBackCornerReading;
        private System.Windows.Forms.TextBox tbFrontCorner;
        private System.Windows.Forms.TextBox tbInitialFrontCornerReading;
        private System.Windows.Forms.TextBox tbCenter;
        private System.Windows.Forms.TextBox tbInitialCenterReading;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel6;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel5;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel4;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel3;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView trimDataGridView;
        private System.Windows.Forms.TextBox tbStatus;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel16;
        private System.Windows.Forms.TextBox tbTotalTime;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel15;
        private System.Windows.Forms.TextBox tbTrimmedCyclesCount;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel14;
        private System.Windows.Forms.TextBox tbCalculatedFso;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel13;
        private System.Windows.Forms.TextBox tbInitialFSO;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel12;
        private System.Windows.Forms.TextBox tbBridgeUnbalance;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private WindowsFormsAero.Button btnStop;
        private WindowsFormsAero.Button btnStart;
        private WindowsFormsAero.TextBox tbSerialNumber;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel1;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblOperatorName;
        private System.Windows.Forms.Label lblOperatorId;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblReading;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblStable;
        private System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel17;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel18;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel28;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel27;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel26;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel25;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel24;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel23;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel22;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel21;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel20;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel19;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel36;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel35;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel34;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel33;
        private System.Windows.Forms.Timer TenSecondsCounter;
        private System.Windows.Forms.Timer FiveSecondsCounter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label lblDisplayMessage;
        private System.Windows.Forms.PictureBox pbPositions;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel29;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel30;
        private AeroSuite.Controls.AeroLinkLabel aeroLinkLabel37;
        private System.Windows.Forms.Label lblNoOfTestRuns;
        private System.Windows.Forms.Label lblMinimumFSOFinal;
        private System.Windows.Forms.Label lblMinimumFSO;
        private System.Windows.Forms.Label lblMinimumUnbalance;
        private System.Windows.Forms.Label lblMaximumFSOFinal;
        private System.Windows.Forms.Label lblMaximumFSO;
        private System.Windows.Forms.Label lblMaximumUnbalance;
        private System.Windows.Forms.Label lblFrontCorner;
        private System.Windows.Forms.Label lblBackCorner;
        private System.Windows.Forms.Label lblLeftCorner;
        private System.Windows.Forms.Label lblRightCorner;
        private System.Windows.Forms.Label lblMaximumCenter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbBridgeUnbalance;
        private System.Windows.Forms.PictureBox pbInitialFso;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.PictureBox pbCalculatedFso;
        private System.Windows.Forms.PictureBox pbNoOfCycles;
        private System.Windows.Forms.PictureBox pbTotalTime;
    }
}

