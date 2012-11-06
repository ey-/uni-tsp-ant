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
            
            // Startwerte für die Komponenten setzen
            trackBarPheromon.Value = (int)(CAntAlgorithmParameters.START_PHEROMONE_PARAMETER * 1000);
            trackBarheuristic.Value = (int)(CAntAlgorithmParameters.START_LOCAL_INFORMATION_PARAMETER * 1000);
            trackBarEvaporation.Value = (int)(CAntAlgorithmParameters.START_EVAPORATION * 1000);
            numericUpDownInitialPheromone.Value = (decimal)CAntAlgorithmParameters.START_INITIAL_PHEROMONE;
            numericUpDownPheromoneUpdate.Value = (decimal)CAntAlgorithmParameters.START_PHEROMONE_UPDATE;

            // noch die Labels korrekt setzen
            labelPheremon.Text = CAntAlgorithmParameters.START_PHEROMONE_PARAMETER.ToString();
            labelHeuristic.Text = CAntAlgorithmParameters.START_LOCAL_INFORMATION_PARAMETER.ToString();
            labelEvaporation.Text = CAntAlgorithmParameters.START_EVAPORATION.ToString();
        }

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
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
            this.tBestGlobal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tØGlobal = new System.Windows.Forms.TextBox();
            this.tBestIteration = new System.Windows.Forms.TextBox();
            this.pIterationProgressBar = new System.Windows.Forms.ProgressBar();
            this.tTimeDisplay = new System.Windows.Forms.TextBox();
            this.tNumberOfIteration = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lOptimalerPfad = new System.Windows.Forms.Label();
            this.cBallConnection = new System.Windows.Forms.CheckBox();
            this.cBoptPath = new System.Windows.Forms.CheckBox();
            this.cBbestPathOfIteration = new System.Windows.Forms.CheckBox();
            this.cBbestPathOfAllIteration = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cStopSchwellenwert = new System.Windows.Forms.CheckBox();
            this.cStoppLoesung = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tOptimalerPfad = new System.Windows.Forms.TextBox();
            this.mRenderWindow = new WindowsFormsApplication1.RenderWindow();
            this.tabVisibility = new System.Windows.Forms.TabPage();
            this.drawingOptions = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabEditieren = new System.Windows.Forms.TabPage();
            this.gBRandomTSP = new System.Windows.Forms.GroupBox();
            this.bRandomCreate = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.tRandomYKoordinate = new System.Windows.Forms.TextBox();
            this.tRandomXKoordinate = new System.Windows.Forms.TextBox();
            this.tRandomKnoten = new System.Windows.Forms.TextBox();
            this.gBCursorAction = new System.Windows.Forms.GroupBox();
            this.rCursorShift = new System.Windows.Forms.RadioButton();
            this.rCursorDelete = new System.Windows.Forms.RadioButton();
            this.rCursorAdd = new System.Windows.Forms.RadioButton();
            this.rCursorNothing = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.tabParameter = new System.Windows.Forms.TabPage();
            this.tThreshold = new System.Windows.Forms.TextBox();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.groupBoxAntsAlgorithym = new System.Windows.Forms.GroupBox();
            this.numericUpDownPheromoneUpdate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInitialPheromone = new System.Windows.Forms.NumericUpDown();
            this.labelEvaporation = new System.Windows.Forms.Label();
            this.trackBarEvaporation = new System.Windows.Forms.TrackBar();
            this.labelHeuristic = new System.Windows.Forms.Label();
            this.trackBarheuristic = new System.Windows.Forms.TrackBar();
            this.labelPheremon = new System.Windows.Forms.Label();
            this.trackBarPheromon = new System.Windows.Forms.TrackBar();
            this.uQuantityIterations = new System.Windows.Forms.NumericUpDown();
            this.uAntsQuantity = new System.Windows.Forms.NumericUpDown();
            this.tabController = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabVisibility.SuspendLayout();
            this.drawingOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabEditieren.SuspendLayout();
            this.gBRandomTSP.SuspendLayout();
            this.gBCursorAction.SuspendLayout();
            this.tabParameter.SuspendLayout();
            this.groupBoxAntsAlgorithym.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPheromoneUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialPheromone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEvaporation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarheuristic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPheromon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uQuantityIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAntsQuantity)).BeginInit();
            this.tabController.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
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
            this.f1ManualToolStripMenuItem.Click += new System.EventHandler(this.openManual);
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
            this.tableLayoutPanel1.Controls.Add(this.tBestGlobal, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tØGlobal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tBestIteration, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(804, 610);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(201, 85);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tØIteration
            // 
            this.tØIteration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tØIteration.Location = new System.Drawing.Point(50, 33);
            this.tØIteration.Name = "tØIteration";
            this.tØIteration.ReadOnly = true;
            this.tØIteration.Size = new System.Drawing.Size(70, 20);
            this.tØIteration.TabIndex = 0;
            this.tØIteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBestGlobal
            // 
            this.tBestGlobal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBestGlobal.Location = new System.Drawing.Point(126, 59);
            this.tBestGlobal.Name = "tBestGlobal";
            this.tBestGlobal.ReadOnly = true;
            this.tBestGlobal.Size = new System.Drawing.Size(72, 20);
            this.tBestGlobal.TabIndex = 3;
            this.tBestGlobal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.toolTip1.SetToolTip(this.label2, "Wenn einmal alle Ameisen das TSP abgelaufen sind");
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
            this.toolTip1.SetToolTip(this.label5, "Übergreifend über alle Iterationen");
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 24);
            this.label11.TabIndex = 6;
            this.label11.Text = "Ø-Wert";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.label11, "Durchschnittliche Streckenlänge");
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 31);
            this.label12.TabIndex = 7;
            this.label12.Text = "Beste";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.label12, "Kürzeste gefundene Strecke");
            // 
            // tØGlobal
            // 
            this.tØGlobal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tØGlobal.Location = new System.Drawing.Point(126, 33);
            this.tØGlobal.Name = "tØGlobal";
            this.tØGlobal.ReadOnly = true;
            this.tØGlobal.Size = new System.Drawing.Size(72, 20);
            this.tØGlobal.TabIndex = 1;
            this.tØGlobal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBestIteration
            // 
            this.tBestIteration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBestIteration.Location = new System.Drawing.Point(50, 59);
            this.tBestIteration.Name = "tBestIteration";
            this.tBestIteration.ReadOnly = true;
            this.tBestIteration.Size = new System.Drawing.Size(70, 20);
            this.tBestIteration.TabIndex = 2;
            this.tBestIteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pIterationProgressBar
            // 
            this.pIterationProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pIterationProgressBar.Location = new System.Drawing.Point(119, 472);
            this.pIterationProgressBar.Name = "pIterationProgressBar";
            this.pIterationProgressBar.Size = new System.Drawing.Size(794, 20);
            this.pIterationProgressBar.TabIndex = 5;
            // 
            // tTimeDisplay
            // 
            this.tTimeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tTimeDisplay.Location = new System.Drawing.Point(10, 472);
            this.tTimeDisplay.Name = "tTimeDisplay";
            this.tTimeDisplay.ReadOnly = true;
            this.tTimeDisplay.Size = new System.Drawing.Size(103, 20);
            this.tTimeDisplay.TabIndex = 6;
            this.tTimeDisplay.Text = "00:00:00:000";
            this.tTimeDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tNumberOfIteration
            // 
            this.tNumberOfIteration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tNumberOfIteration.Location = new System.Drawing.Point(919, 472);
            this.tNumberOfIteration.Name = "tNumberOfIteration";
            this.tNumberOfIteration.ReadOnly = true;
            this.tNumberOfIteration.Size = new System.Drawing.Size(83, 20);
            this.tNumberOfIteration.TabIndex = 7;
            this.tNumberOfIteration.Text = "0/100";
            this.tNumberOfIteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.BackColor = System.Drawing.Color.Khaki;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // lOptimalerPfad
            // 
            this.lOptimalerPfad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lOptimalerPfad.AutoSize = true;
            this.lOptimalerPfad.Location = new System.Drawing.Point(40, 5);
            this.lOptimalerPfad.Name = "lOptimalerPfad";
            this.lOptimalerPfad.Size = new System.Drawing.Size(76, 13);
            this.lOptimalerPfad.TabIndex = 0;
            this.lOptimalerPfad.Text = "Optimaler Pfad";
            this.lOptimalerPfad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.lOptimalerPfad, "Nicht bei allen TSP\'s vorhanden");
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
            this.toolTip1.SetToolTip(this.cBallConnection, "Zeigt in Abhänigkeit der Menge an Pheromon die Strecken zwischen den Knoten");
            this.cBallConnection.UseVisualStyleBackColor = true;
            this.cBallConnection.CheckedChanged += new System.EventHandler(this.drawSettings_CheckedChanged);
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
            this.toolTip1.SetToolTip(this.cBoptPath, "Zeigt den optimalen Pfad an, falls dieser vorhanden ist");
            this.cBoptPath.UseVisualStyleBackColor = true;
            this.cBoptPath.CheckedChanged += new System.EventHandler(this.drawSettings_CheckedChanged);
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
            this.toolTip1.SetToolTip(this.cBbestPathOfIteration, "Zeigt den besten Pfad der momentanen Iteration an");
            this.cBbestPathOfIteration.UseVisualStyleBackColor = true;
            this.cBbestPathOfIteration.CheckedChanged += new System.EventHandler(this.drawSettings_CheckedChanged);
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
            this.toolTip1.SetToolTip(this.cBbestPathOfAllIteration, "Zeigt den bis jetzt besten gefundenen Pfad an");
            this.cBbestPathOfAllIteration.UseVisualStyleBackColor = true;
            this.cBbestPathOfAllIteration.CheckedChanged += new System.EventHandler(this.drawSettings_CheckedChanged);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Verdunstungsfaktor ρ :";
            this.toolTip1.SetToolTip(this.label8, "Gibt an wie viel Prozent Pheromon auf jeder Strecke nach \r\neiner Iteration verdun" +
        "stet, z.B. 0,005 bedeutet 0,5%");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(492, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "initiale Pheromon-Werte τ :";
            this.toolTip1.SetToolTip(this.label9, "Gibt an wie viel Pheromon initial pro Strecke verteilt wird,\r\n initial bedeutet h" +
        "ier vor der ersten Iteration");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(494, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 26);
            this.label10.TabIndex = 15;
            this.label10.Text = "heuristischer Parameter\r\nfür Pheromon-Update Q :";
            this.toolTip1.SetToolTip(this.label10, "Gibt an wie viel Pheromon von der Ameisen hinterlassen wird wenn sie eine\r\nStreck" +
        "e abgelaufen ist, Werte sind absolut min. 0 max. 100");
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tOptimalerPfad, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lOptimalerPfad, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(848, 560);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(157, 48);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // tOptimalerPfad
            // 
            this.tOptimalerPfad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tOptimalerPfad.Location = new System.Drawing.Point(4, 27);
            this.tOptimalerPfad.Name = "tOptimalerPfad";
            this.tOptimalerPfad.ReadOnly = true;
            this.tOptimalerPfad.Size = new System.Drawing.Size(148, 20);
            this.tOptimalerPfad.TabIndex = 8;
            this.tOptimalerPfad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // tabVisibility
            // 
            this.tabVisibility.Controls.Add(this.drawingOptions);
            this.tabVisibility.Location = new System.Drawing.Point(4, 22);
            this.tabVisibility.Name = "tabVisibility";
            this.tabVisibility.Size = new System.Drawing.Size(788, 173);
            this.tabVisibility.TabIndex = 5;
            this.tabVisibility.Text = "Anzeige";
            this.tabVisibility.UseVisualStyleBackColor = true;
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
            // tRandomYKoordinate
            // 
            this.tRandomYKoordinate.Location = new System.Drawing.Point(117, 99);
            this.tRandomYKoordinate.Name = "tRandomYKoordinate";
            this.tRandomYKoordinate.Size = new System.Drawing.Size(122, 20);
            this.tRandomYKoordinate.TabIndex = 7;
            this.tRandomYKoordinate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberOnlyChangeHandler);
            // 
            // tRandomXKoordinate
            // 
            this.tRandomXKoordinate.Location = new System.Drawing.Point(117, 74);
            this.tRandomXKoordinate.Name = "tRandomXKoordinate";
            this.tRandomXKoordinate.Size = new System.Drawing.Size(122, 20);
            this.tRandomXKoordinate.TabIndex = 6;
            this.tRandomXKoordinate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberOnlyChangeHandler);
            // 
            // tRandomKnoten
            // 
            this.tRandomKnoten.Location = new System.Drawing.Point(117, 49);
            this.tRandomKnoten.MaxLength = 5;
            this.tRandomKnoten.Name = "tRandomKnoten";
            this.tRandomKnoten.Size = new System.Drawing.Size(122, 20);
            this.tRandomKnoten.TabIndex = 5;
            this.tRandomKnoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberOnlyChangeHandler);
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
            // groupBoxAntsAlgorithym
            // 
            this.groupBoxAntsAlgorithym.Controls.Add(this.numericUpDownPheromoneUpdate);
            this.groupBoxAntsAlgorithym.Controls.Add(this.numericUpDownInitialPheromone);
            this.groupBoxAntsAlgorithym.Controls.Add(this.label10);
            this.groupBoxAntsAlgorithym.Controls.Add(this.label9);
            this.groupBoxAntsAlgorithym.Controls.Add(this.labelEvaporation);
            this.groupBoxAntsAlgorithym.Controls.Add(this.trackBarEvaporation);
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
            // numericUpDownPheromoneUpdate
            // 
            this.numericUpDownPheromoneUpdate.DecimalPlaces = 3;
            this.numericUpDownPheromoneUpdate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownPheromoneUpdate.Location = new System.Drawing.Point(649, 57);
            this.numericUpDownPheromoneUpdate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPheromoneUpdate.Name = "numericUpDownPheromoneUpdate";
            this.numericUpDownPheromoneUpdate.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownPheromoneUpdate.TabIndex = 18;
            this.numericUpDownPheromoneUpdate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownPheromoneUpdate.ValueChanged += new System.EventHandler(this.algorithmParameterChanged);
            // 
            // numericUpDownInitialPheromone
            // 
            this.numericUpDownInitialPheromone.DecimalPlaces = 3;
            this.numericUpDownInitialPheromone.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownInitialPheromone.Location = new System.Drawing.Point(649, 18);
            this.numericUpDownInitialPheromone.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownInitialPheromone.Name = "numericUpDownInitialPheromone";
            this.numericUpDownInitialPheromone.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownInitialPheromone.TabIndex = 17;
            this.numericUpDownInitialPheromone.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelEvaporation
            // 
            this.labelEvaporation.AutoSize = true;
            this.labelEvaporation.Location = new System.Drawing.Point(172, 101);
            this.labelEvaporation.Name = "labelEvaporation";
            this.labelEvaporation.Size = new System.Drawing.Size(13, 13);
            this.labelEvaporation.TabIndex = 11;
            this.labelEvaporation.Text = "0";
            // 
            // trackBarEvaporation
            // 
            this.trackBarEvaporation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarEvaporation.Location = new System.Drawing.Point(205, 89);
            this.trackBarEvaporation.Maximum = 1000;
            this.trackBarEvaporation.Name = "trackBarEvaporation";
            this.trackBarEvaporation.Size = new System.Drawing.Size(238, 45);
            this.trackBarEvaporation.TabIndex = 10;
            this.trackBarEvaporation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarEvaporation.Scroll += new System.EventHandler(this.algorithmParameterChanged);
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
            this.trackBarheuristic.Maximum = 1000;
            this.trackBarheuristic.Name = "trackBarheuristic";
            this.trackBarheuristic.Size = new System.Drawing.Size(238, 45);
            this.trackBarheuristic.TabIndex = 7;
            this.trackBarheuristic.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarheuristic.Scroll += new System.EventHandler(this.algorithmParameterChanged);
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
            this.trackBarPheromon.Size = new System.Drawing.Size(238, 45);
            this.trackBarPheromon.TabIndex = 4;
            this.trackBarPheromon.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarPheromon.Scroll += new System.EventHandler(this.algorithmParameterChanged);
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
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabController.Controls.Add(this.tabParameter);
            this.tabController.Controls.Add(this.tabEditieren);
            this.tabController.Controls.Add(this.tabVisibility);
            this.tabController.Location = new System.Drawing.Point(7, 495);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(796, 199);
            this.tabController.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 702);
            this.Controls.Add(this.tNumberOfIteration);
            this.Controls.Add(this.tTimeDisplay);
            this.Controls.Add(this.pIterationProgressBar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.mRenderWindow);
            this.Controls.Add(this.tabController);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "Form1";
            this.Text = "TSP SAD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.beendenToolStripMenuItem_Click);
            this.ClientSizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabVisibility.ResumeLayout(false);
            this.drawingOptions.ResumeLayout(false);
            this.drawingOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabEditieren.ResumeLayout(false);
            this.gBRandomTSP.ResumeLayout(false);
            this.gBRandomTSP.PerformLayout();
            this.gBCursorAction.ResumeLayout(false);
            this.gBCursorAction.PerformLayout();
            this.tabParameter.ResumeLayout(false);
            this.tabParameter.PerformLayout();
            this.groupBoxAntsAlgorithym.ResumeLayout(false);
            this.groupBoxAntsAlgorithym.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPheromoneUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialPheromone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEvaporation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarheuristic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPheromon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uQuantityIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAntsQuantity)).EndInit();
            this.tabController.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openTspFileDialog1;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TextBox tØIteration;
        public System.Windows.Forms.TextBox tØGlobal;
        public System.Windows.Forms.TextBox tBestIteration;
        public System.Windows.Forms.TextBox tBestGlobal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar pIterationProgressBar;
        private System.Windows.Forms.TextBox tTimeDisplay;
        private System.Windows.Forms.TextBox tNumberOfIteration;
        private System.Windows.Forms.ToolStripMenuItem f1ManualToolStripMenuItem;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TextBox tOptimalerPfad;
        private System.Windows.Forms.Label lOptimalerPfad;
        private System.Windows.Forms.TabPage tabVisibility;
        private System.Windows.Forms.GroupBox drawingOptions;
        private System.Windows.Forms.CheckBox cBbestPathOfAllIteration;
        private System.Windows.Forms.CheckBox cBbestPathOfIteration;
        private System.Windows.Forms.CheckBox cBoptPath;
        private System.Windows.Forms.CheckBox cBallConnection;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabEditieren;
        private System.Windows.Forms.GroupBox gBRandomTSP;
        private System.Windows.Forms.Button bRandomCreate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tRandomYKoordinate;
        private System.Windows.Forms.TextBox tRandomXKoordinate;
        private System.Windows.Forms.TextBox tRandomKnoten;
        private System.Windows.Forms.GroupBox gBCursorAction;
        public System.Windows.Forms.RadioButton rCursorShift;
        public System.Windows.Forms.RadioButton rCursorDelete;
        public System.Windows.Forms.RadioButton rCursorAdd;
        private System.Windows.Forms.RadioButton rCursorNothing;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabParameter;
        private System.Windows.Forms.CheckBox cStoppLoesung;
        private System.Windows.Forms.CheckBox cStopSchwellenwert;
        private System.Windows.Forms.TextBox tThreshold;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxAntsAlgorithym;
        private System.Windows.Forms.NumericUpDown numericUpDownPheromoneUpdate;
        private System.Windows.Forms.NumericUpDown numericUpDownInitialPheromone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelEvaporation;
        private System.Windows.Forms.TrackBar trackBarEvaporation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelHeuristic;
        private System.Windows.Forms.TrackBar trackBarheuristic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPheremon;
        private System.Windows.Forms.TrackBar trackBarPheromon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown uQuantityIterations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown uAntsQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabController;
    }
}

