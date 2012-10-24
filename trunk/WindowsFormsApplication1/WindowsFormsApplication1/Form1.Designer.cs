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
            button_Start.Text = BUTTON_START_TEXT_START;
            
        }

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabController = new System.Windows.Forms.TabControl();
            this.tabParameter = new System.Windows.Forms.TabPage();
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
            this.tabEditieren = new System.Windows.Forms.TabPage();
            this.gBRandomTSP = new System.Windows.Forms.GroupBox();
            this.bRandomCreate = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tRandomYKoordinate = new System.Windows.Forms.TextBox();
            this.tRandomXKoordinate = new System.Windows.Forms.TextBox();
            this.tRandomKnoten = new System.Windows.Forms.TextBox();
            this.gBCursorAction = new System.Windows.Forms.GroupBox();
            this.rCursorShift = new System.Windows.Forms.RadioButton();
            this.rCursorDelete = new System.Windows.Forms.RadioButton();
            this.rCursorAdd = new System.Windows.Forms.RadioButton();
            this.rCursorNothing = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.tabStatistiken = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.labelStreckePheromon = new System.Windows.Forms.Label();
            this.tStreckeLocalInfo = new System.Windows.Forms.TextBox();
            this.tStreckePheromon = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.drawingOptions = new System.Windows.Forms.GroupBox();
            this.cBbestPathOfAllIteration = new System.Windows.Forms.CheckBox();
            this.cBbestPathOfIteration = new System.Windows.Forms.CheckBox();
            this.cBoptPath = new System.Windows.Forms.CheckBox();
            this.cBallConnection = new System.Windows.Forms.CheckBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f1ManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mRenderWindow = new WindowsFormsApplication1.RenderWindow();
            this.tabController.SuspendLayout();
            this.tabParameter.SuspendLayout();
            this.groupBoxAntsAlgorithym.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarheuristicPheromonUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarinitialPheromon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHumidification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarheuristic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPheromon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uQuantityIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAntsQuantity)).BeginInit();
            this.tabEditieren.SuspendLayout();
            this.gBRandomTSP.SuspendLayout();
            this.gBCursorAction.SuspendLayout();
            this.tabStatistiken.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.drawingOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabController.Controls.Add(this.tabParameter);
            this.tabController.Controls.Add(this.tabEditieren);
            this.tabController.Controls.Add(this.tabStatistiken);
            this.tabController.Controls.Add(this.tabPage1);
            this.tabController.Location = new System.Drawing.Point(7, 495);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(796, 199);
            this.tabController.TabIndex = 1;
            // 
            // tabParameter
            // 
            this.tabParameter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabParameter.Controls.Add(this.cStoppLoesung);
            this.tabParameter.Controls.Add(this.cStopSchwellenwert);
            this.tabParameter.Controls.Add(this.tThreshold);
            this.tabParameter.Controls.Add(this.labelThreshold);
            this.tabParameter.Controls.Add(this.label4);
            this.tabParameter.Controls.Add(this.groupBoxAntsAlgorithym);
            this.tabParameter.Controls.Add(this.uQuantityIterations);
            this.tabParameter.Controls.Add(this.label3);
            this.tabParameter.Controls.Add(this.uAntsQuantity);
            this.tabParameter.Controls.Add(this.label1);
            this.tabParameter.Location = new System.Drawing.Point(4, 22);
            this.tabParameter.Name = "tabParameter";
            this.tabParameter.Padding = new System.Windows.Forms.Padding(3);
            this.tabParameter.Size = new System.Drawing.Size(788, 173);
            this.tabParameter.TabIndex = 2;
            this.tabParameter.Text = "Parameter";
            this.tabParameter.UseVisualStyleBackColor = true;
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
            this.toolTip1.SetToolTip(this.cStoppLoesung, "Bei setzen des Hakens\r\nin das Kontrollkästchen stoppt der\r\nAlgorithmus sobald die" +
                    " optimale Lösung \r\ngefunden wurde");
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
            this.toolTip1.SetToolTip(this.cStopSchwellenwert, "Mit diesem Stoppkriterium kann man\r\neinen Schwellenwert definieren bei dem\r\nder A" +
                    "lgorithmus aufhört zu laufen sobald\r\ndieser Wert unterschritten wurde");
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
            this.toolTip1.SetToolTip(this.label4, "Alle Stoppkriterien sind logisch ODER verknüpft,\r\ndas bedeutet sobald einer der\r\n" +
                    "Kriterien erreicht wurde wird das\r\nProgramm gestoppt");
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
            this.groupBoxAntsAlgorithym.Size = new System.Drawing.Size(771, 126);
            this.groupBoxAntsAlgorithym.TabIndex = 7;
            this.groupBoxAntsAlgorithym.TabStop = false;
            this.groupBoxAntsAlgorithym.Text = "Ameisenalgorithmus";
            // 
            // labelheuristicPheromonUpdate
            // 
            this.labelheuristicPheromonUpdate.AutoSize = true;
            this.labelheuristicPheromonUpdate.Location = new System.Drawing.Point(562, 60);
            this.labelheuristicPheromonUpdate.Name = "labelheuristicPheromonUpdate";
            this.labelheuristicPheromonUpdate.Size = new System.Drawing.Size(34, 13);
            this.labelheuristicPheromonUpdate.TabIndex = 17;
            this.labelheuristicPheromonUpdate.Text = "0,001";
            // 
            // trackBarheuristicPheromonUpdate
            // 
            this.trackBarheuristicPheromonUpdate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarheuristicPheromonUpdate.Location = new System.Drawing.Point(595, 48);
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
            this.label10.Location = new System.Drawing.Point(399, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 26);
            this.label10.TabIndex = 15;
            this.label10.Text = "heuristischer Parameter\r\nfür Pheromon-Update Q :";
            this.toolTip1.SetToolTip(this.label10, "Gibt an wie viel Pheromon von der Ameisen hinterlassen wird wenn sie eine\r\nStreck" +
                    "e abgelaufen ist, Werte sind absolut min. 0 max. 10");
            // 
            // labelinitialPheromon
            // 
            this.labelinitialPheromon.AutoSize = true;
            this.labelinitialPheromon.Location = new System.Drawing.Point(562, 21);
            this.labelinitialPheromon.Name = "labelinitialPheromon";
            this.labelinitialPheromon.Size = new System.Drawing.Size(34, 13);
            this.labelinitialPheromon.TabIndex = 14;
            this.labelinitialPheromon.Text = "0,001";
            // 
            // trackBarinitialPheromon
            // 
            this.trackBarinitialPheromon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarinitialPheromon.Location = new System.Drawing.Point(595, 9);
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
            this.label9.Location = new System.Drawing.Point(397, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "initiale Pheromon-Werte τ :";
            this.toolTip1.SetToolTip(this.label9, "Gibt an wie viel Pheromon initial pro Strecke verteilt wird,\r\n initial bedeutet h" +
                    "ier vor der ersten Iteration");
            // 
            // labelHumidification
            // 
            this.labelHumidification.AutoSize = true;
            this.labelHumidification.Location = new System.Drawing.Point(172, 101);
            this.labelHumidification.Name = "labelHumidification";
            this.labelHumidification.Size = new System.Drawing.Size(13, 13);
            this.labelHumidification.TabIndex = 11;
            this.labelHumidification.Text = "0";
            // 
            // trackBarHumidification
            // 
            this.trackBarHumidification.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarHumidification.Location = new System.Drawing.Point(205, 89);
            this.trackBarHumidification.Maximum = 1000;
            this.trackBarHumidification.Name = "trackBarHumidification";
            this.trackBarHumidification.Size = new System.Drawing.Size(171, 45);
            this.trackBarHumidification.TabIndex = 10;
            this.trackBarHumidification.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarHumidification.Scroll += new System.EventHandler(this.trackBarHumidification_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Verdunstungsfaktor ρ :";
            this.toolTip1.SetToolTip(this.label8, "Gibt an in Prozent wie viel Pheromon auf jeder Strecke nach \r\neiner Iteration ver" +
                    "dunstes, z.B. 0,005 bedeutet 0,5%");
            // 
            // labelHeuristic
            // 
            this.labelHeuristic.AutoSize = true;
            this.labelHeuristic.Location = new System.Drawing.Point(171, 60);
            this.labelHeuristic.Name = "labelHeuristic";
            this.labelHeuristic.Size = new System.Drawing.Size(13, 13);
            this.labelHeuristic.TabIndex = 8;
            this.labelHeuristic.Text = "0";
            // 
            // trackBarheuristic
            // 
            this.trackBarheuristic.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarheuristic.Location = new System.Drawing.Point(204, 48);
            this.trackBarheuristic.Maximum = 5000;
            this.trackBarheuristic.Name = "trackBarheuristic";
            this.trackBarheuristic.Size = new System.Drawing.Size(171, 45);
            this.trackBarheuristic.TabIndex = 7;
            this.trackBarheuristic.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarheuristic.Scroll += new System.EventHandler(this.trackBarheuristic_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "heuristischer Parameter\r\nfür die lokale Information β :";
            this.toolTip1.SetToolTip(this.label7, "Gibt an zu wie vielen Teilen die Ameise beim Entscheidungsprozess die\r\nStreckenlä" +
                    "nge für alle möglichen Strecken berücksichtigt");
            // 
            // labelPheremon
            // 
            this.labelPheremon.AutoSize = true;
            this.labelPheremon.Location = new System.Drawing.Point(171, 21);
            this.labelPheremon.Name = "labelPheremon";
            this.labelPheremon.Size = new System.Drawing.Size(13, 13);
            this.labelPheremon.TabIndex = 5;
            this.labelPheremon.Text = "0";
            // 
            // trackBarPheromon
            // 
            this.trackBarPheromon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarPheromon.Location = new System.Drawing.Point(204, 9);
            this.trackBarPheromon.Maximum = 1000;
            this.trackBarPheromon.Name = "trackBarPheromon";
            this.trackBarPheromon.Size = new System.Drawing.Size(171, 45);
            this.trackBarPheromon.TabIndex = 4;
            this.trackBarPheromon.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarPheromon.Scroll += new System.EventHandler(this.trackBarPheremon_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Pheromon Parameter α :";
            this.toolTip1.SetToolTip(this.label6, "Gibt an zu wie vielen Teilen die Ameise beim Entscheidungsprozess die\r\nPheromon W" +
                    "erte auf den möglichen Strecken berücksichtigt");
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
            this.toolTip1.SetToolTip(this.label3, "Wenn die angegebene Anzahl von Iterationen\r\ndurchgelaufen ist, wird der Algorithm" +
                    "us gestoppt");
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
            this.toolTip1.SetToolTip(this.label1, "Anzahl der Ameisen die pro Iteration über das TSP-Problem laufen");
            // 
            // tabEditieren
            // 
            this.tabEditieren.Controls.Add(this.gBRandomTSP);
            this.tabEditieren.Controls.Add(this.gBCursorAction);
            this.tabEditieren.Location = new System.Drawing.Point(4, 22);
            this.tabEditieren.Name = "tabEditieren";
            this.tabEditieren.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditieren.Size = new System.Drawing.Size(788, 173);
            this.tabEditieren.TabIndex = 3;
            this.tabEditieren.Text = "Editieren";
            this.tabEditieren.UseVisualStyleBackColor = true;
            // 
            // gBRandomTSP
            // 
            this.gBRandomTSP.Controls.Add(this.bRandomCreate);
            this.gBRandomTSP.Controls.Add(this.label17);
            this.gBRandomTSP.Controls.Add(this.label16);
            this.gBRandomTSP.Controls.Add(this.label15);
            this.gBRandomTSP.Controls.Add(this.label14);
            this.gBRandomTSP.Controls.Add(this.tRandomYKoordinate);
            this.gBRandomTSP.Controls.Add(this.tRandomXKoordinate);
            this.gBRandomTSP.Controls.Add(this.tRandomKnoten);
            this.gBRandomTSP.Location = new System.Drawing.Point(200, 15);
            this.gBRandomTSP.Name = "gBRandomTSP";
            this.gBRandomTSP.Size = new System.Drawing.Size(264, 152);
            this.gBRandomTSP.TabIndex = 14;
            this.gBRandomTSP.TabStop = false;
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
            this.bRandomCreate.Click += new System.EventHandler(this.bRandomCreate_Click);
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
            this.toolTip1.SetToolTip(this.label16, "Gibt die Längeneinheiten der vertikalen Achse an");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Max. X Koordinate";
            this.toolTip1.SetToolTip(this.label15, "Gibt die Längeneinheiten der horizontalen Achse an");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Anzahl der Knoten";
            this.toolTip1.SetToolTip(this.label14, "Anzahl der Städte die das neue TSP haben soll");
            // 
            // tRandomYKoordinate
            // 
            this.tRandomYKoordinate.Location = new System.Drawing.Point(117, 99);
            this.tRandomYKoordinate.Name = "tRandomYKoordinate";
            this.tRandomYKoordinate.Size = new System.Drawing.Size(122, 20);
            this.tRandomYKoordinate.TabIndex = 7;
            this.tRandomYKoordinate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tRandomYKoordinate_KeyDown);
            // 
            // tRandomXKoordinate
            // 
            this.tRandomXKoordinate.Location = new System.Drawing.Point(117, 74);
            this.tRandomXKoordinate.Name = "tRandomXKoordinate";
            this.tRandomXKoordinate.Size = new System.Drawing.Size(122, 20);
            this.tRandomXKoordinate.TabIndex = 6;
            this.tRandomXKoordinate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tRandomXKoordinate_KeyDown);
            // 
            // tRandomKnoten
            // 
            this.tRandomKnoten.Location = new System.Drawing.Point(117, 49);
            this.tRandomKnoten.MaxLength = 5;
            this.tRandomKnoten.Name = "tRandomKnoten";
            this.tRandomKnoten.Size = new System.Drawing.Size(122, 20);
            this.tRandomKnoten.TabIndex = 5;
            this.tRandomKnoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tRandomKnoten_KeyDown);
            // 
            // gBCursorAction
            // 
            this.gBCursorAction.Controls.Add(this.rCursorShift);
            this.gBCursorAction.Controls.Add(this.rCursorDelete);
            this.gBCursorAction.Controls.Add(this.rCursorAdd);
            this.gBCursorAction.Controls.Add(this.rCursorNothing);
            this.gBCursorAction.Controls.Add(this.label13);
            this.gBCursorAction.Location = new System.Drawing.Point(15, 15);
            this.gBCursorAction.Name = "gBCursorAction";
            this.gBCursorAction.Size = new System.Drawing.Size(173, 152);
            this.gBCursorAction.TabIndex = 13;
            this.gBCursorAction.TabStop = false;
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
            this.rCursorShift.CheckedChanged += new System.EventHandler(this.rCursor_CheckedChanged);
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
            this.rCursorDelete.CheckedChanged += new System.EventHandler(this.rCursor_CheckedChanged);
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
            this.rCursorAdd.CheckedChanged += new System.EventHandler(this.rCursor_CheckedChanged);
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
            this.rCursorNothing.CheckedChanged += new System.EventHandler(this.rCursor_CheckedChanged);
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
            // tabStatistiken
            // 
            this.tabStatistiken.Controls.Add(this.listBox1);
            this.tabStatistiken.Controls.Add(this.groupBox3);
            this.tabStatistiken.Location = new System.Drawing.Point(4, 22);
            this.tabStatistiken.Name = "tabStatistiken";
            this.tabStatistiken.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatistiken.Size = new System.Drawing.Size(788, 173);
            this.tabStatistiken.TabIndex = 4;
            this.tabStatistiken.Text = "Statistiken";
            this.tabStatistiken.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(19, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(559, 134);
            this.listBox1.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.labelStreckePheromon);
            this.groupBox3.Controls.Add(this.tStreckeLocalInfo);
            this.groupBox3.Controls.Add(this.tStreckePheromon);
            this.groupBox3.Location = new System.Drawing.Point(595, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 155);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Referenzwerte";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(48, 92);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Strecke Local Info";
            this.toolTip1.SetToolTip(this.label18, "Zeigt die Länge an für einen Durchlauf des TSP bei sehr \r\nstarker Berücksichtigun" +
                    "g der lokalen Information\r\n");
            // 
            // labelStreckePheromon
            // 
            this.labelStreckePheromon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStreckePheromon.AutoSize = true;
            this.labelStreckePheromon.Location = new System.Drawing.Point(45, 35);
            this.labelStreckePheromon.Name = "labelStreckePheromon";
            this.labelStreckePheromon.Size = new System.Drawing.Size(95, 13);
            this.labelStreckePheromon.TabIndex = 4;
            this.labelStreckePheromon.Text = "Strecke Pheromon";
            this.toolTip1.SetToolTip(this.labelStreckePheromon, "Zeigt die Länge an für einen Durchlauf des TSP bei \r\nsehr starker Pheromon Berück" +
                    "sichtigung");
            // 
            // tStreckeLocalInfo
            // 
            this.tStreckeLocalInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tStreckeLocalInfo.Location = new System.Drawing.Point(11, 112);
            this.tStreckeLocalInfo.Name = "tStreckeLocalInfo";
            this.tStreckeLocalInfo.ReadOnly = true;
            this.tStreckeLocalInfo.Size = new System.Drawing.Size(165, 20);
            this.tStreckeLocalInfo.TabIndex = 3;
            this.tStreckeLocalInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tStreckePheromon
            // 
            this.tStreckePheromon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tStreckePheromon.Location = new System.Drawing.Point(11, 55);
            this.tStreckePheromon.Name = "tStreckePheromon";
            this.tStreckePheromon.ReadOnly = true;
            this.tStreckePheromon.Size = new System.Drawing.Size(165, 20);
            this.tStreckePheromon.TabIndex = 1;
            this.tStreckePheromon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.drawingOptions);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(788, 173);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Anzeige";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // drawingOptions
            // 
            this.drawingOptions.Controls.Add(this.cBbestPathOfAllIteration);
            this.drawingOptions.Controls.Add(this.cBbestPathOfIteration);
            this.drawingOptions.Controls.Add(this.cBoptPath);
            this.drawingOptions.Controls.Add(this.cBallConnection);
            this.drawingOptions.Controls.Add(this.pictureBox4);
            this.drawingOptions.Controls.Add(this.pictureBox3);
            this.drawingOptions.Controls.Add(this.pictureBox2);
            this.drawingOptions.Controls.Add(this.pictureBox1);
            this.drawingOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingOptions.Location = new System.Drawing.Point(31, 20);
            this.drawingOptions.Name = "drawingOptions";
            this.drawingOptions.Size = new System.Drawing.Size(273, 144);
            this.drawingOptions.TabIndex = 1;
            this.drawingOptions.TabStop = false;
            this.drawingOptions.Text = "Anzeigeoptionen";
            // 
            // cBbestPathOfAllIteration
            // 
            this.cBbestPathOfAllIteration.AutoSize = true;
            this.cBbestPathOfAllIteration.Checked = true;
            this.cBbestPathOfAllIteration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBbestPathOfAllIteration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBbestPathOfAllIteration.Location = new System.Drawing.Point(24, 105);
            this.cBbestPathOfAllIteration.Name = "cBbestPathOfAllIteration";
            this.cBbestPathOfAllIteration.Size = new System.Drawing.Size(178, 17);
            this.cBbestPathOfAllIteration.TabIndex = 8;
            this.cBbestPathOfAllIteration.Text = "Bester Pfad aus alles Iterationen";
            this.cBbestPathOfAllIteration.UseVisualStyleBackColor = true;
            this.cBbestPathOfAllIteration.CheckedChanged += new System.EventHandler(this.drawSettings_CheckedChanged);
            // 
            // cBbestPathOfIteration
            // 
            this.cBbestPathOfIteration.AutoSize = true;
            this.cBbestPathOfIteration.Checked = true;
            this.cBbestPathOfIteration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBbestPathOfIteration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBbestPathOfIteration.Location = new System.Drawing.Point(24, 88);
            this.cBbestPathOfIteration.Name = "cBbestPathOfIteration";
            this.cBbestPathOfIteration.Size = new System.Drawing.Size(140, 17);
            this.cBbestPathOfIteration.TabIndex = 7;
            this.cBbestPathOfIteration.Text = "Bester Pfad der Iteration";
            this.cBbestPathOfIteration.UseVisualStyleBackColor = true;
            this.cBbestPathOfIteration.CheckedChanged += new System.EventHandler(this.drawSettings_CheckedChanged);
            // 
            // cBoptPath
            // 
            this.cBoptPath.AutoSize = true;
            this.cBoptPath.Checked = true;
            this.cBoptPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoptPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoptPath.Location = new System.Drawing.Point(24, 73);
            this.cBoptPath.Name = "cBoptPath";
            this.cBoptPath.Size = new System.Drawing.Size(95, 17);
            this.cBoptPath.TabIndex = 6;
            this.cBoptPath.Text = "Optimaler Pfad";
            this.cBoptPath.UseVisualStyleBackColor = true;
            this.cBoptPath.CheckedChanged += new System.EventHandler(this.drawSettings_CheckedChanged);
            // 
            // cBallConnection
            // 
            this.cBallConnection.AutoSize = true;
            this.cBallConnection.Checked = true;
            this.cBallConnection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBallConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBallConnection.Location = new System.Drawing.Point(24, 56);
            this.cBallConnection.Name = "cBallConnection";
            this.cBallConnection.Size = new System.Drawing.Size(191, 17);
            this.cBallConnection.TabIndex = 5;
            this.cBallConnection.Text = "Verbindung zwischen den Punkten";
            this.cBallConnection.UseVisualStyleBackColor = true;
            this.cBallConnection.CheckedChanged += new System.EventHandler(this.drawSettings_CheckedChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Red;
            this.pictureBox4.Location = new System.Drawing.Point(7, 107);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(12, 12);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Lime;
            this.pictureBox3.Location = new System.Drawing.Point(7, 91);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(12, 12);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Blue;
            this.pictureBox2.Location = new System.Drawing.Point(7, 75);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(12, 12);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(7, 59);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(12, 12);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.f1ManualToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.ShortcutKeyDisplayString = "Manual";
            this.hilfeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // f1ManualToolStripMenuItem
            // 
            this.f1ManualToolStripMenuItem.AutoToolTip = true;
            this.f1ManualToolStripMenuItem.Name = "f1ManualToolStripMenuItem";
            this.f1ManualToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            this.f1ManualToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.f1ManualToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.f1ManualToolStripMenuItem.Text = "Manual";
            this.f1ManualToolStripMenuItem.ToolTipText = "HelpFile";
            // 
            // openTspFileDialog1
            // 
            this.openTspFileDialog1.Filter = "TSP-Dateien|*.tsp";
            // 
            // button_Start
            // 
            this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Start.Location = new System.Drawing.Point(803, 515);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(807, 565);
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
            this.tØIteration.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.pIterationProgressBar.Size = new System.Drawing.Size(817, 20);
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
            this.tNumberOfIteration.Location = new System.Drawing.Point(942, 472);
            this.tNumberOfIteration.Name = "tNumberOfIteration";
            this.tNumberOfIteration.ReadOnly = true;
            this.tNumberOfIteration.Size = new System.Drawing.Size(60, 20);
            this.tNumberOfIteration.TabIndex = 7;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.BackColor = System.Drawing.Color.Khaki;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
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
            this.mRenderWindow.Size = new System.Drawing.Size(986, 445);
            this.mRenderWindow.StencilBits = ((byte)(0));
            this.mRenderWindow.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 702);
            this.Controls.Add(this.tNumberOfIteration);
            this.Controls.Add(this.tTimeDisplay);
            this.Controls.Add(this.pIterationProgressBar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.mRenderWindow);
            this.Controls.Add(this.tabController);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "Form1";
            this.Text = "TSPD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.beendenToolStripMenuItem_Click);
            this.ClientSizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabController.ResumeLayout(false);
            this.tabParameter.ResumeLayout(false);
            this.tabParameter.PerformLayout();
            this.groupBoxAntsAlgorithym.ResumeLayout(false);
            this.groupBoxAntsAlgorithym.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarheuristicPheromonUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarinitialPheromon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHumidification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarheuristic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPheromon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uQuantityIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAntsQuantity)).EndInit();
            this.tabEditieren.ResumeLayout(false);
            this.gBRandomTSP.ResumeLayout(false);
            this.gBRandomTSP.PerformLayout();
            this.gBCursorAction.ResumeLayout(false);
            this.gBCursorAction.PerformLayout();
            this.tabStatistiken.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.drawingOptions.ResumeLayout(false);
            this.drawingOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TabControl tabController;
        private System.Windows.Forms.TabPage tabParameter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
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
        private System.Windows.Forms.TabPage tabEditieren;
        private System.Windows.Forms.TabPage tabStatistiken;
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
        private System.Windows.Forms.Button bRandomCreate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tRandomYKoordinate;
        private System.Windows.Forms.TextBox tRandomXKoordinate;
        private System.Windows.Forms.TextBox tRandomKnoten;
        private System.Windows.Forms.GroupBox gBCursorAction;
        private System.Windows.Forms.GroupBox gBRandomTSP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tStreckeLocalInfo;
        private System.Windows.Forms.TextBox tStreckePheromon;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label labelStreckePheromon;
        public System.Windows.Forms.RadioButton rCursorShift;
        public System.Windows.Forms.RadioButton rCursorDelete;
        public System.Windows.Forms.RadioButton rCursorAdd;
        private System.Windows.Forms.ToolStripMenuItem f1ManualToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox drawingOptions;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cBbestPathOfAllIteration;
        private System.Windows.Forms.CheckBox cBbestPathOfIteration;
        private System.Windows.Forms.CheckBox cBoptPath;
        private System.Windows.Forms.CheckBox cBallConnection;
    }
}

