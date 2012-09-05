using System.Collections.Generic;
namespace WindowsFormsApplication1
{
    partial class Form1
    {
        private RenderWindow mRenderWindow;
        private List<CTSPPoint> mCityList;

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
            mRenderWindow.initViewPort();
        }

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tThreshold = new System.Windows.Forms.TextBox();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.uCityQuantity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.uAntsQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.uCityQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAntsQuantity)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(9, 367);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(973, 199);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(965, 189);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Statistiken";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage1.Controls.Add(this.tThreshold);
            this.tabPage1.Controls.Add(this.labelThreshold);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBoxAntsAlgorithym);
            this.tabPage1.Controls.Add(this.uQuantityIterations);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.uCityQuantity);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.uAntsQuantity);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(965, 173);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Parameter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tThreshold
            // 
            this.tThreshold.Location = new System.Drawing.Point(698, 10);
            this.tThreshold.Name = "tThreshold";
            this.tThreshold.Size = new System.Drawing.Size(55, 20);
            this.tThreshold.TabIndex = 11;
            this.tThreshold.Visible = false;
            this.tThreshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Location = new System.Drawing.Point(614, 15);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(79, 13);
            this.labelThreshold.TabIndex = 10;
            this.labelThreshold.Text = "Schwellenwert:";
            this.labelThreshold.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Anzahl Iterationen erreicht";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Anzahl Iterationen erreicht",
            "Schwellenwert für Tourlänge",
            "Lösung gefunden"});
            this.comboBox1.Location = new System.Drawing.Point(450, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "Anzahl Iterationen erreicht";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 14);
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
            this.groupBoxAntsAlgorithym.Size = new System.Drawing.Size(944, 126);
            this.groupBoxAntsAlgorithym.TabIndex = 7;
            this.groupBoxAntsAlgorithym.TabStop = false;
            this.groupBoxAntsAlgorithym.Text = "Ameisenalgorithmus";
            // 
            // labelheuristicPheromonUpdate
            // 
            this.labelheuristicPheromonUpdate.AutoSize = true;
            this.labelheuristicPheromonUpdate.Location = new System.Drawing.Point(601, 60);
            this.labelheuristicPheromonUpdate.Name = "labelheuristicPheromonUpdate";
            this.labelheuristicPheromonUpdate.Size = new System.Drawing.Size(34, 13);
            this.labelheuristicPheromonUpdate.TabIndex = 17;
            this.labelheuristicPheromonUpdate.Text = "0,001";
            // 
            // trackBarheuristicPheromonUpdate
            // 
            this.trackBarheuristicPheromonUpdate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarheuristicPheromonUpdate.Location = new System.Drawing.Point(634, 48);
            this.trackBarheuristicPheromonUpdate.Maximum = 10000;
            this.trackBarheuristicPheromonUpdate.Minimum = 1;
            this.trackBarheuristicPheromonUpdate.Name = "trackBarheuristicPheromonUpdate";
            this.trackBarheuristicPheromonUpdate.Size = new System.Drawing.Size(171, 45);
            this.trackBarheuristicPheromonUpdate.TabIndex = 16;
            this.trackBarheuristicPheromonUpdate.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarheuristicPheromonUpdate.Value = 1;
            this.trackBarheuristicPheromonUpdate.Scroll += new System.EventHandler(this.trackBarheuristicPheromonUpdate_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(438, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 26);
            this.label10.TabIndex = 15;
            this.label10.Text = "heuristischer Parameter\r\nfür Pheremon-Update:";
            // 
            // labelinitialPheromon
            // 
            this.labelinitialPheromon.AutoSize = true;
            this.labelinitialPheromon.Location = new System.Drawing.Point(601, 21);
            this.labelinitialPheromon.Name = "labelinitialPheromon";
            this.labelinitialPheromon.Size = new System.Drawing.Size(34, 13);
            this.labelinitialPheromon.TabIndex = 14;
            this.labelinitialPheromon.Text = "0,001";
            // 
            // trackBarinitialPheromon
            // 
            this.trackBarinitialPheromon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarinitialPheromon.Location = new System.Drawing.Point(634, 9);
            this.trackBarinitialPheromon.Maximum = 10000;
            this.trackBarinitialPheromon.Minimum = 1;
            this.trackBarinitialPheromon.Name = "trackBarinitialPheromon";
            this.trackBarinitialPheromon.Size = new System.Drawing.Size(171, 45);
            this.trackBarinitialPheromon.TabIndex = 13;
            this.trackBarinitialPheromon.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarinitialPheromon.Value = 1;
            this.trackBarinitialPheromon.Scroll += new System.EventHandler(this.trackBarinitialPheromon_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(436, 21);
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
            this.trackBarHumidification.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
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
            this.trackBarheuristic.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
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
            this.trackBarPheromon.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
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
            this.uQuantityIterations.Location = new System.Drawing.Point(290, 9);
            this.uQuantityIterations.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uQuantityIterations.Name = "uQuantityIterations";
            this.uQuantityIterations.Size = new System.Drawing.Size(54, 20);
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
            this.label3.Location = new System.Drawing.Point(231, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Iterationen:";
            // 
            // uCityQuantity
            // 
            this.uCityQuantity.Location = new System.Drawing.Point(163, 9);
            this.uCityQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uCityQuantity.Name = "uCityQuantity";
            this.uCityQuantity.Size = new System.Drawing.Size(54, 20);
            this.uCityQuantity.TabIndex = 4;
            this.uCityQuantity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Städte:";
            // 
            // uAntsQuantity
            // 
            this.uAntsQuantity.Location = new System.Drawing.Point(58, 9);
            this.uAntsQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uAntsQuantity.Name = "uAntsQuantity";
            this.uAntsQuantity.Size = new System.Drawing.Size(54, 20);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem,
            this.startToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 24);
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
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // mRenderWindow
            // 
            this.mRenderWindow.AccumBits = ((byte)(0));
            this.mRenderWindow.AutoCheckErrors = false;
            this.mRenderWindow.AutoFinish = false;
            this.mRenderWindow.AutoMakeCurrent = true;
            this.mRenderWindow.AutoSwapBuffers = true;
            this.mRenderWindow.BackColor = System.Drawing.Color.Black;
            this.mRenderWindow.ColorBits = ((byte)(32));
            this.mRenderWindow.DepthBits = ((byte)(16));
            this.mRenderWindow.Location = new System.Drawing.Point(9, 27);
            this.mRenderWindow.Name = "mRenderWindow";
            this.mRenderWindow.Size = new System.Drawing.Size(898, 311);
            this.mRenderWindow.StencilBits = ((byte)(0));
            this.mRenderWindow.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 571);
            this.Controls.Add(this.mRenderWindow);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.uCityQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uAntsQuantity)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown uAntsQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown uQuantityIterations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown uCityQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxAntsAlgorithym;
        private System.Windows.Forms.ComboBox comboBox1;
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
    }
}

