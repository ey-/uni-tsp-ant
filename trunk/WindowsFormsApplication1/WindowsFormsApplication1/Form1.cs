﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private float heuristicPheromonUpdateValue = 0.001f;
        private float pheromonValue = 0.001f;
        private float initialPheromonValue = 0.001f;
        private float humidificationValue = 0.001f;
        private float heuristicValue = 0.001f;
        public Form1()
        {
            InitializeComponent();
            postInitialize();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.cStoppLoesung, "Diese Option ist nur verfügbar, wenn eine *.opt.tour-Datei für die *.tsp-Datei vorhanden ist. Diese Datei sollte sich in dem selben Ordner befinden.");
            //toolTip1.SetToolTip(this.chec, "My checkBox1");

        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(('0' <= e.KeyValue && e.KeyValue <= '9') || e.KeyCode < Keys.Help) || e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void trackBarPheremon_Scroll(object sender, EventArgs e)
        {
            pheromonValue = ((float)trackBarPheromon.Value / 1000);
            labelPheremon.Text = pheromonValue.ToString();
        }

        private void trackBarheuristic_Scroll(object sender, EventArgs e)
        {
            heuristicValue = ((float)trackBarheuristic.Value / 1000);
            labelHeuristic.Text = heuristicValue.ToString();
        }

        private void trackBarHumidification_Scroll(object sender, EventArgs e)
        {
            humidificationValue = ((float)trackBarHumidification.Value / 1000);
            labelHumidification.Text = humidificationValue.ToString();
        }

        private void trackBarinitialPheromon_Scroll(object sender, EventArgs e)
        {
            initialPheromonValue = ((float)trackBarinitialPheromon.Value / 1000);
            labelinitialPheromon.Text = initialPheromonValue.ToString();
        }

        private void trackBarheuristicPheromonUpdate_Scroll(object sender, EventArgs e)
        {
            heuristicPheromonUpdateValue = ((float)trackBarheuristicPheromonUpdate.Value / 1000);
            labelheuristicPheromonUpdate.Text = heuristicPheromonUpdateValue.ToString();
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openTspFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                Thread openFileThread = new Thread(new ThreadStart(this.openTSPFile));
                openFileThread.Start();
                
            }
        }

        private void openTSPFile()
        {
            // Open the selected file to read.
            System.IO.Stream myResult = openTspFileDialog1.OpenFile();

            CTSPLibFileParser fileParser = new CTSPLibFileParser(myResult);
            try
            {
                fileParser.fillTSPPointList();
            }
            catch (CInsufficientMemoryException exception)
            {
                if (exception.getType() == CInsufficientMemoryException.E_EXCEPTION_TYPE.E_32_BIT_ERROR)
                {
                    MessageBox.Show("Um dieses Projekt laden zu können werden ca. " + exception.getMemoryNeeded()
                        + " MByte benötigt. 32-Bit-Anwendungen können aber maximal " + exception.getMemoryAvailable() + " MByte verwalten. "
                        + "Bitte verwenden sie die 64-Bit Version oder öffnen Sie ein kleineres Projekt.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Auf ihrem System stehen noch " + exception.getMemoryAvailable() + " MByte zur Verfügung. Es werden aber ca. "
                        + exception.getMemoryNeeded() + " MByte benötigt. "
                        + "Wenn Sie dieses Projekt laden möchten stellen Sie Bitte mehr RAM zur Verfügung.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //MessageBox.Show(CTSPPointList.getInstance().ToString());
            myResult.Close();
            mRenderWindow.Invoke(new Action(delegate()
            {
                mRenderWindow.initViewPort();
                mRenderWindow.Refresh();
            }));
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            CAntAlgorithmParameters.getInstance().numberAnts = Convert.ToInt32(uAntsQuantity.Value);
            CAntAlgorithmParameters.getInstance().numberMaxIterations = Convert.ToInt32(uQuantityIterations.Value);
            CAntAlgorithmParameters.getInstance().pheromoneParameter = pheromonValue;
            CAntAlgorithmParameters.getInstance().pheromoneUpdate = heuristicPheromonUpdateValue;
            CAntAlgorithmParameters.getInstance().initialPheromone = initialPheromonValue;
            CAntAlgorithmParameters.getInstance().localInformation = heuristicValue;
            CAntAlgorithmParameters.getInstance().evaporationFactor = humidificationValue;
            //MessageBox.Show("Ants: " + CAntAlgorithmParameters.getInstance().numberAnts + "\n" + CAntAlgorithmParameters.getInstance().numberMaxIterations + "\n" + CAntAlgorithmParameters.getInstance().pheromoneParameter + " \n" + "usw usw");
            var antAlgorithm = new CAntAlgorithm();
            antAlgorithm.NewIteration();
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cStopSchwellenwert.Checked)
            {
                tThreshold.Visible = true;
                labelThreshold.Visible = true;
            }
            else
            {
                tThreshold.Visible = false;
                labelThreshold.Visible = false;
            }

        }



        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            mRenderWindow.InitializeContexts();
            mRenderWindow.initViewPort();
            mRenderWindow.Refresh();                  
        }

        private void bRandomCreate_Click(object sender, EventArgs e)
        {
            if (!((tRandomKnoten.Text == null) || (tRandomKnoten.Text == "")))
            {
                CRandomPointGenerator.mNumPoints = Int32.Parse(tRandomKnoten.Text);
            }

            if (!((tRandomXKoordinate.Text == null) || (tRandomXKoordinate.Text == "")))
            {
                CRandomPointGenerator.mSizeX = Int32.Parse(tRandomXKoordinate.Text);
            }

            if (!((tRandomYKoordinate.Text == null) || (tRandomYKoordinate.Text == "")))
            {
                CRandomPointGenerator.mSizeY = Int32.Parse(tRandomYKoordinate.Text);
            }

            CRandomPointGenerator.generateTSP();
            mRenderWindow.InitializeContexts();
            mRenderWindow.initViewPort();
            mRenderWindow.Refresh();  

        }

        private void tRandomKnoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(('0' <= e.KeyValue && e.KeyValue <= '9') || e.KeyCode < Keys.Help) || e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void tRandomXKoordinate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(('0' <= e.KeyValue && e.KeyValue <= '9') || e.KeyCode < Keys.Help) || e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void tRandomYKoordinate_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (!(('0' <= e.KeyValue && e.KeyValue <= '9') || e.KeyCode < Keys.Help) || e.KeyCode == Keys.Space)
            {                
                e.SuppressKeyPress = true;
            }
        }


    }
}