using System.Collections.Generic;
namespace WindowsFormsApplication1
{
    partial class Form1
    {
        private RenderWindow mRenderWindow;

        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            mRenderWindow.DestroyContexts();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            
        }

        /// <summary>
        ///     Methode zum nachinitialisieren des Viewports. Damit wir
        ///     in einem Fenster Render können
        /// </summary>
        protected void postInitialize()
        {
            mRenderWindow.InitializeContexts();
            mRenderWindow.initViewPort();
        }

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cStoppLoesung = new System.Windows.Forms.CheckBox();
            this.cStopSchwellenwert = new System.Windows.Forms.CheckBox();
            this.tThreshold = new System.Windows.Forms.TextBox();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxAntsAlgorithym = new System.Windows.Forms.GroupBox();
            this.labelheuristicPheromonUpdate = new System.Windows.Forms.Label();
            this.trackBarheuristicPheromonUpdate = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.labelinitialPheromon = new System.Windows.Forms.Label();
            this.trackBarinitialPheromon = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.labelHumidification = new System.Windows.Forms.Label();
            this.trackBarHumidification = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.labelHeuristic = new System.Windows.Forms.Label();
            this.trackBarheuristic = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.labelPheremon = new System.Windows.Forms.Label();
            this.trackBarPheromon = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.uQuantityIterations = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.uAntsQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bRandomCreate = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tRandomYKoordinate = new System.Windows.Forms.TextBox();
            this.tRandomXKoordinate = new System.Windows.Forms.TextBox();
            this.tRandomKnoten = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rCursorShift = new System.Windows.Forms.RadioButton();
            this.rCursorDelete = new System.Windows.Forms.RadioButton();
            this.rCursorAdd = new System.Windows.Forms.RadioButton();
            this.rCursorNothing = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTspFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_Start = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tØIteration = new System.Windows.Forms.TextBox();
            this.tØGlobal = new System.Windows.Forms.TextBox();
            this.tBestIteration = new System.Windows.Forms.TextBox();
            this.tBestGlobal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pIterationProgressBar = new System.Windows.Forms.ProgressBar();
            this.tTimeDisplay = new System.Windows.Forms.TextBox();
            this.tNumberOfIteration = new System.Windows.Forms.TextBox();
            this.mRenderWindow = new WindowsFormsApplication1.RenderWindow();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxAntsAlgorithym.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarheuristicPheromonUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarinitialPheromon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHumidification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarheuristic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPheromon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uQuantityIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAntsQuantity)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(7, 495);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(832, 199);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage1.Controls.Add(this.cStoppLoesung);
            this.tabPage1.Controls.Add(this.cStopSchwellenwert);
            this.tabPage1.Controls.Add(this.tThreshold);
            this.tabPage1.Controls.Add(this.labelThreshold);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBoxAntsAlgorithym);
            this.tabPage1.Controls.Add(this.uQuantityIterations);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.uAntsQuantity);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(824, 173);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Parameter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cStoppLoesung
            // 
            this.cStoppLoesung.AutoSize = true;
            this.cStoppLoesung.Enabled = false;
            this.cStoppLoesung.Location = new System.Drawing.Point(309, 12);
            this.cStoppLoesung.Name = "cStoppLoesung";
            this.cStoppLoesung.Size = new System.Drawing.Size(109, 17);
            this.cStoppLoesung.TabIndex = 16;
            this.cStoppLoesung.Text = "Lösung gefunden";
            this.cStoppLoesung.UseVisualStyleBackColor = true;
            // 
            // cStopSchwellenwert
            // 
            this.cStopSchwellenwert.AutoSize = true;
            this.cStopSchwellenwert.Location = new System.Drawing.Point(419, 5);
            this.cStopSchwellenwert.Name = "cStopSchwellenwert";
            this.cStopSchwellenwert.Size = new System.Drawing.Size(152, 30);
            this.cStopSchwellenwert.TabIndex = 15;
            this.cStopSchwellenwert.Text = "Schwellenwert für die\r\nLänge der Strecke erreicht";
            this.cStopSchwellenwert.UseVisualStyleBackColor = true;
            this.cStopSchwellenwert.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // tThreshold
            // 
            this.tThreshold.Location = new System.Drawing.Point(647, 12);
            this.tThreshold.Name = "tThreshold";
            this.tThreshold.Size = new System.Drawing.Size(55, 20);
            this.tThreshold.TabIndex = 11;
            this.tThreshold.Visible = false;
            this.tThreshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Location = new System.Drawing.Point(568, 16);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(79, 13);
            this.labelThreshold.TabIndex = 10;
            this.labelThreshold.Text = "Schwellenwert:";
            this.labelThreshold.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stopkriterium:";
            // 
            // groupBoxAntsAlgorithym
            // 
            this.groupBoxAntsAlgorithym.Controls.Add(this.labelheuristicPheromonUpdate);
            this.groupBoxAntsAlgorithym.Controls.Add(this.trackBarheuristicPheromonUpdate);
            this.groupBoxAntsAlgorithym.Controls.Add(this.label10);
            this.groupBoxAntsAlgorithym.Controls.Add(this.labelinitialPheromon);
            this.groupBoxAntsAlgorithym.Controls.Add(this.trackBarinitialPheromon);
            this.groupBoxAntsAlgorithym.Controls.Add(this.label9);
            this.groupBoxAntsAlgorithym.Controls.Add(this.labelHumidification);
            this.groupBoxAntsAlgorithym.Controls.Add(this.trackBarHumidification);
            this.groupBoxAntsAlgorithym.Controls.Add(this.label8);
            this.groupBoxAntsAlgorithym.Controls.Add(this.labelHeuristic);
            this.groupBoxAntsAlgorithym.Controls.Add(this.trackBarheuristic);
            this.groupBoxAntsAlgorithym.Controls.Add(this.label7);
            this.groupBoxAntsAlgorithym.Controls.Add(this.labelPheremon);
            this.groupBoxAntsAlgorithym.Controls.Add(this.trackBarPheromon);
            this.groupBoxAntsAlgorithym.Controls.Add(this.label6);
            this.groupBoxAntsAlgorithym.Location = new System.Drawing.Point(9, 40);
            this.groupBoxAntsAlgorithym.Name = "groupBoxAntsAlgorithym";
            this.groupBoxAntsAlgorithym.Size = new System.Drawing.Size(804, 126);
            this.groupBoxAntsAlgorithym.TabIndex = 7;
            this.groupBoxAntsAlgorithym.TabStop = false;
            this.groupBoxAntsAlgorithym.Text = "Ameisenalgorithmus";
            // 
            // labelheuristicPheromonUpdate
            // 
            this.labelheuristicPheromonUpdate.AutoSize = true;
            this.labelheuristicPheromonUpdate.Location = new System.Drawing.Point(566, 60);
            this.labelheuristicPheromonUpdate.Name = "labelheuristicPheromonUpdate";
            this.labelheuristicPheromonUpdate.Size = new System.Drawing.Size(34, 13);
            this.labelheuristicPheromonUpdate.TabIndex = 17;
            this.labelheuristicPheromonUpdate.Text = "0,001";
            // 
            // trackBarheuristicPheromonUpdate
            // 
            this.trackBarheuristicPheromonUpdate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarheuristicPheromonUpdate.Location = new System.Drawing.Point(599, 48);
            this.trackBarheuristicPheromonUpdate.Maximum = 10000;
            this.trackBarheuristicPheromonUpdate.Minimum = 1;
            this.trackBarheuristicPheromonUpdate.Name = "trackBarheuristicPheromonUpdate";
            this.trackBarheuristicPheromonUpdate.Size = new System.Drawing.Size(171, 45);
            this.trackBarheuristicPheromonUpdate.TabIndex = 16;
            this.trackBarheuristicPheromonUpdate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarheuristicPheromonUpdate.Value = 1;
            this.trackBarheuristicPheromonUpdate.Scroll += new System.EventHandler(this.trackBarheuristicPheromonUpdate_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(403, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 26);
            this.label10.TabIndex = 15;
            this.label10.Text = "heuristischer Parameter\r\nfür Pheremon-Update:";
            // 
            // labelinitialPheromon
            // 
            this.labelinitialPheromon.AutoSize = true;
            this.labelinitialPheromon.Location = new System.Drawing.Point(566, 21);
            this.labelinitialPheromon.Name = "labelinitialPheromon";
            this.labelinitialPheromon.Size = new System.Drawing.Size(34, 13);
            this.labelinitialPheromon.TabIndex = 14;
            this.labelinitialPheromon.Text = "0,001";
            // 
            // trackBarinitialPheromon
            // 
            this.trackBarinitialPheromon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarinitialPheromon.Location = new System.Drawing.Point(599, 9);
            this.trackBarinitialPheromon.Maximum = 10000;
            this.trackBarinitialPheromon.Minimum = 1;
            this.trackBarinitialPheromon.Name = "trackBarinitialPheromon";
            this.trackBarinitialPheromon.Size = new System.Drawing.Size(171, 45);
            this.trackBarinitialPheromon.TabIndex = 13;
            this.trackBarinitialPheromon.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarinitialPheromon.Value = 1;
            this.trackBarinitialPheromon.Scroll += new System.EventHandler(this.trackBarinitialPheromon_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(401, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "initiale Pheromon-Werte";
            // 
            // labelHumidification
            // 
            this.labelHumidification.AutoSize = true;
            this.labelHumidification.Location = new System.Drawing.Point(172, 101);
            this.labelHumidification.Name = "labelHumidification";
            this.labelHumidification.Size = new System.Drawing.Size(34, 13);
            this.labelHumidification.TabIndex = 11;
            this.labelHumidification.Text = "0,001";
            // 
            // trackBarHumidification
            // 
            this.trackBarHumidification.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarHumidification.Location = new System.Drawing.Point(205, 89);
            this.trackBarHumidification.Maximum = 1000;
            this.trackBarHumidification.Minimum = 1;
            this.trackBarHumidification.Name = "trackBarHumidification";
            this.trackBarHumidification.Size = new System.Drawing.Size(171, 45);
            this.trackBarHumidification.TabIndex = 10;
            this.trackBarHumidification.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarHumidification.Value = 1;
            this.trackBarHumidification.Scroll += new System.EventHandler(this.trackBarHumidification_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Verdunstungsfaktor:";
            // 
            // labelHeuristic
            // 
            this.labelHeuristic.AutoSize = true;
            this.labelHeuristic.Location = new System.Drawing.Point(171, 60);
            this.labelHeuristic.Name = "labelHeuristic";
            this.labelHeuristic.Size = new System.Drawing.Size(34, 13);
            this.labelHeuristic.TabIndex = 8;
            this.labelHeuristic.Text = "0,001";
            // 
            // trackBarheuristic
            // 
            this.trackBarheuristic.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarheuristic.Location = new System.Drawing.Point(204, 48);
            this.trackBarheuristic.Maximum = 10000;
            this.trackBarheuristic.Minimum = 1;
            this.trackBarheuristic.Name = "trackBarheuristic";
            this.trackBarheuristic.Size = new System.Drawing.Size(171, 45);
            this.trackBarheuristic.TabIndex = 7;
            this.trackBarheuristic.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarheuristic.Value = 1;
            this.trackBarheuristic.Scroll += new System.EventHandler(this.trackBarheuristic_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "heuristischer Parameter\r\nfür die lokale Information:";
            // 
            // labelPheremon
            // 
            this.labelPheremon.AutoSize = true;
            this.labelPheremon.Location = new System.Drawing.Point(171, 21);
            this.labelPheremon.Name = "labelPheremon";
            this.labelPheremon.Size = new System.Drawing.Size(34, 13);
            this.labelPheremon.TabIndex = 5;
            this.labelPheremon.Text = "0,001";
            // 
            // trackBarPheromon
            // 
            this.trackBarPheromon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarPheromon.Location = new System.Drawing.Point(204, 9);
            this.trackBarPheromon.Maximum = 10000;
            this.trackBarPheromon.Minimum = 1;
            this.trackBarPheromon.Name = "trackBarPheromon";
            this.trackBarPheromon.Size = new System.Drawing.Size(171, 45);
            this.trackBarPheromon.TabIndex = 4;
            this.trackBarPheromon.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarPheromon.Value = 1;
            this.trackBarPheromon.Scroll += new System.EventHandler(this.trackBarPheremon_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Pheromon Parameter:";
            // 
            // uQuantityIterations
            // 
            this.uQuantityIterations.Location = new System.Drawing.Point(171, 12);
            this.uQuantityIterations.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uQuantityIterations.Name = "uQuantityIterations";
            this.uQuantityIterations.Size = new System.Drawing.Size(43, 20);
            this.uQuantityIterations.TabIndex = 6;
            this.uQuantityIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Iterationen:";
            // 
            // uAntsQuantity
            // 
            this.uAntsQuantity.Location = new System.Drawing.Point(58, 12);
            this.uAntsQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uAntsQuantity.Name = "uAntsQuantity";
            this.uAntsQuantity.Size = new System.Drawing.Size(44, 20);
            this.uAntsQuantity.TabIndex = 2;
            this.uAntsQuantity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ameisen:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(824, 173);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Editieren";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bRandomCreate);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tRandomYKoordinate);
            this.groupBox2.Controls.Add(this.tRandomXKoordinate);
            this.groupBox2.Controls.Add(this.tRandomKnoten);
            this.groupBox2.Location = new System.Drawing.Point(200, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 152);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // bRandomCreate
            // 
            this.bRandomCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRandomCreate.Location = new System.Drawing.Point(17, 124);
            this.bRandomCreate.Name = "bRandomCreate";
            this.bRandomCreate.Size = new System.Drawing.Size(224, 20);
            this.bRandomCreate.TabIndex = 12;
            this.bRandomCreate.Text = "TSP erstellen";
            this.bRandomCreate.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(17, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(174, 16);
            this.label17.TabIndex = 11;
            this.label17.Text = "Zufälliges TSP erstellen";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 102);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Max. Y Koordinate";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Max. X Koordinate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Anzahl der Knoten";
            // 
            // tRandomYKoordinate
            // 
            this.tRandomYKoordinate.Location = new System.Drawing.Point(117, 99);
            this.tRandomYKoordinate.Name = "tRandomYKoordinate";
            this.tRandomYKoordinate.Size = new System.Drawing.Size(122, 20);
            this.tRandomYKoordinate.TabIndex = 7;
            // 
            // tRandomXKoordinate
            // 
            this.tRandomXKoordinate.Location = new System.Drawing.Point(117, 74);
            this.tRandomXKoordinate.Name = "tRandomXKoordinate";
            this.tRandomXKoordinate.Size = new System.Drawing.Size(122, 20);
            this.tRandomXKoordinate.TabIndex = 6;
            // 
            // tRandomKnoten
            // 
            this.tRandomKnoten.Location = new System.Drawing.Point(117, 49);
            this.tRandomKnoten.Name = "tRandomKnoten";
            this.tRandomKnoten.Size = new System.Drawing.Size(122, 20);
            this.tRandomKnoten.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rCursorShift);
            this.groupBox1.Controls.Add(this.rCursorDelete);
            this.groupBox1.Controls.Add(this.rCursorAdd);
            this.groupBox1.Controls.Add(this.rCursorNothing);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 152);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // rCursorShift
            // 
            this.rCursorShift.AutoSize = true;
            this.rCursorShift.Location = new System.Drawing.Point(22, 121);
            this.rCursorShift.Name = "rCursorShift";
            this.rCursorShift.Size = new System.Drawing.Size(120, 17);
            this.rCursorShift.TabIndex = 3;
            this.rCursorShift.Text = "Knoten verschieben";
            this.rCursorShift.UseVisualStyleBackColor = true;
            // 
            // rCursorDelete
            // 
            this.rCursorDelete.AutoSize = true;
            this.rCursorDelete.Location = new System.Drawing.Point(22, 96);
            this.rCursorDelete.Name = "rCursorDelete";
            this.rCursorDelete.Size = new System.Drawing.Size(99, 17);
            this.rCursorDelete.TabIndex = 2;
            this.rCursorDelete.Text = "Knoten löschen";
            this.rCursorDelete.UseVisualStyleBackColor = true;
            // 
            // rCursorAdd
            // 
            this.rCursorAdd.AutoSize = true;
            this.rCursorAdd.Location = new System.Drawing.Point(22, 71);
            this.rCursorAdd.Name = "rCursorAdd";
            this.rCursorAdd.Size = new System.Drawing.Size(114, 17);
            this.rCursorAdd.TabIndex = 1;
            this.rCursorAdd.Text = "Knoten hinzufügen";
            this.rCursorAdd.UseVisualStyleBackColor = true;
            // 
            // rCursorNothing
            // 
            this.rCursorNothing.AutoSize = true;
            this.rCursorNothing.Checked = true;
            this.rCursorNothing.Location = new System.Drawing.Point(22, 46);
            this.rCursorNothing.Name = "rCursorNothing";
            this.rCursorNothing.Size = new System.Drawing.Size(53, 17);
            this.rCursorNothing.TabIndex = 0;
            this.rCursorNothing.TabStop = true;
            this.rCursorNothing.Text = "nichts";
            this.rCursorNothing.UseMnemonic = false;
            this.rCursorNothing.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(27, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Cursoraktion";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(824, 173);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Statistiken";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // openTspFileDialog1
            // 
            this.openTspFileDialog1.Filter = "TSP-Dateien|*.tsp";
            // 
            // button_Start
            // 
            this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Start.Location = new System.Drawing.Point(841, 517);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(200, 43);
            this.button_Start.TabIndex = 3;
            this.button_Start.Text = "Starten";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.Controls.Add(this.tØIteration, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tØGlobal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tBestIteration, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tBestGlobal, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(845, 565);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(201, 125);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tØIteration
            // 
            this.tØIteration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tØIteration.Location = new System.Drawing.Point(50, 33);
            this.tØIteration.Multiline = true;
            this.tØIteration.Name = "tØIteration";
            this.tØIteration.ReadOnly = true;
            this.tØIteration.Size = new System.Drawing.Size(70, 40);
            this.tØIteration.TabIndex = 0;
            // 
            // tØGlobal
            // 
            this.tØGlobal.Location = new System.Drawing.Point(126, 33);
            this.tØGlobal.Multiline = true;
            this.tØGlobal.Name = "tØGlobal";
            this.tØGlobal.ReadOnly = true;
            this.tØGlobal.Size = new System.Drawing.Size(72, 40);
            this.tØGlobal.TabIndex = 1;
            // 
            // tBestIteration
            // 
            this.tBestIteration.Location = new System.Drawing.Point(50, 79);
            this.tBestIteration.Multiline = true;
            this.tBestIteration.Name = "tBestIteration";
            this.tBestIteration.ReadOnly = true;
            this.tBestIteration.Size = new System.Drawing.Size(70, 43);
            this.tBestIteration.TabIndex = 2;
            // 
            // tBestGlobal
            // 
            this.tBestGlobal.Location = new System.Drawing.Point(126, 79);
            this.tBestGlobal.Multiline = true;
            this.tBestGlobal.Name = "tBestGlobal";
            this.tBestGlobal.ReadOnly = true;
            this.tBestGlobal.Size = new System.Drawing.Size(72, 43);
            this.tBestGlobal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Iteration";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 30);
            this.label5.TabIndex = 5;
            this.label5.Text = "Global";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 46);
            this.label11.TabIndex = 6;
            this.label11.Text = "Ø-Wert";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 49);
            this.label12.TabIndex = 7;
            this.label12.Text = "Beste";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pIterationProgressBar
            // 
            this.pIterationProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pIterationProgressBar.Location = new System.Drawing.Point(122, 472);
            this.pIterationProgressBar.Name = "pIterationProgressBar";
            this.pIterationProgressBar.Size = new System.Drawing.Size(855, 20);
            this.pIterationProgressBar.TabIndex = 5;
            // 
            // tTimeDisplay
            // 
            this.tTimeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tTimeDisplay.Location = new System.Drawing.Point(10, 472);
            this.tTimeDisplay.Name = "tTimeDisplay";
            this.tTimeDisplay.ReadOnly = true;
            this.tTimeDisplay.Size = new System.Drawing.Size(112, 20);
            this.tTimeDisplay.TabIndex = 6;
            // 
            // tNumberOfIteration
            // 
            this.tNumberOfIteration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tNumberOfIteration.Location = new System.Drawing.Point(980, 472);
            this.tNumberOfIteration.Name = "tNumberOfIteration";
            this.tNumberOfIteration.ReadOnly = true;
            this.tNumberOfIteration.Size = new System.Drawing.Size(60, 20);
            this.tNumberOfIteration.TabIndex = 7;
            // 
            // mRenderWindow
            // 
            this.mRenderWindow.AccumBits = ((byte)(0));
            this.mRenderWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mRenderWindow.AutoCheckErrors = false;
            this.mRenderWindow.AutoFinish = false;
            this.mRenderWindow.AutoMakeCurrent = true;
            this.mRenderWindow.AutoSwapBuffers = true;
            this.mRenderWindow.BackColor = System.Drawing.Color.Black;
            this.mRenderWindow.ColorBits = ((byte)(32));
            this.mRenderWindow.DepthBits = ((byte)(16));
            this.mRenderWindow.Location = new System.Drawing.Point(7, 27);
            this.mRenderWindow.Name = "mRenderWindow";
            this.mRenderWindow.Size = new System.Drawing.Size(1025, 445);
            this.mRenderWindow.StencilBits = ((byte)(0));
            this.mRenderWindow.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 702);
            this.Controls.Add(this.tNumberOfIteration);
            this.Controls.Add(this.tTimeDisplay);
            this.Controls.Add(this.pIterationProgressBar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.mRenderWindow);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1062, 726);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBoxAntsAlgorithym.ResumeLayout(false);
            this.groupBoxAntsAlgorithym.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarheuristicPheromonUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarinitialPheromon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHumidification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarheuristic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPheromon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uQuantityIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAntsQuantity)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown uAntsQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown uQuantityIterations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxAntsAlgorithym;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tThreshold;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBarPheromon;
        private System.Windows.Forms.Label labelPheremon;
        private System.Windows.Forms.Label labelHeuristic;
        private System.Windows.Forms.TrackBar trackBarheuristic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelHumidification;
        private System.Windows.Forms.TrackBar trackBarHumidification;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelinitialPheromon;
        private System.Windows.Forms.TrackBar trackBarinitialPheromon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelheuristicPheromonUpdate;
        private System.Windows.Forms.TrackBar trackBarheuristicPheromonUpdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog openTspFileDialog1;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.CheckBox cStoppLoesung;
        private System.Windows.Forms.CheckBox cStopSchwellenwert;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tØIteration;
        private System.Windows.Forms.TextBox tØGlobal;
        private System.Windows.Forms.TextBox tBestIteration;
        private System.Windows.Forms.TextBox tBestGlobal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar pIterationProgressBar;
        private System.Windows.Forms.TextBox tTimeDisplay;
        private System.Windows.Forms.TextBox tNumberOfIteration;
        private System.Windows.Forms.RadioButton rCursorNothing;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rCursorShift;
        private System.Windows.Forms.RadioButton rCursorDelete;
        private System.Windows.Forms.RadioButton rCursorAdd;
        private System.Windows.Forms.Button bRandomCreate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tRandomYKoordinate;
        private System.Windows.Forms.TextBox tRandomXKoordinate;
        private System.Windows.Forms.TextBox tRandomKnoten;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

