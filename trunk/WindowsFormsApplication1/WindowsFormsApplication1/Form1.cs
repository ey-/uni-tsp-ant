using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private double heuristicPheromonUpdateValue =0.001;
        private double pheromonValue=0.001;
        private double initialPheromonValue=0.001;
        private double humidificationValue=0.001;
        private double heuristicValue=0.001;
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
            toolTip1.SetToolTip(this.checkBox3, "Diese Option ist nur verfügbar, wenn eine *.opt.tour-Datei für die *.tsp-Datei vorhanden ist. Diese Datei sollte sich in dem selben Ordner befinden.");
            //toolTip1.SetToolTip(this.chec, "My checkBox1");

        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(('0' <= e.KeyValue && e.KeyValue <= '9') || e.KeyCode < Keys.Help))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void trackBarPheremon_Scroll(object sender, EventArgs e)
        {
            pheromonValue = ((double)trackBarPheromon.Value / 1000);
            labelPheremon.Text = pheromonValue.ToString();
        }

        private void trackBarheuristic_Scroll(object sender, EventArgs e)
        {
            heuristicValue = ((double)trackBarheuristic.Value / 1000);
            labelHeuristic.Text = heuristicValue.ToString();
        }

        private void trackBarHumidification_Scroll(object sender, EventArgs e)
        {
            humidificationValue = ((double)trackBarHumidification.Value / 1000);
            labelHumidification.Text = humidificationValue.ToString();
        }

        private void trackBarinitialPheromon_Scroll(object sender, EventArgs e)
        {
            initialPheromonValue = ((double)trackBarinitialPheromon.Value / 1000);
            labelinitialPheromon.Text = initialPheromonValue.ToString();
        }

        private void trackBarheuristicPheromonUpdate_Scroll(object sender, EventArgs e)
        {
            heuristicPheromonUpdateValue = ((double)trackBarheuristicPheromonUpdate.Value / 1000);
            labelheuristicPheromonUpdate.Text = heuristicPheromonUpdateValue.ToString();
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (openTspFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Open the selected file to read.
                System.IO.Stream myResult = openTspFileDialog1.OpenFile();

                CTSPLibFileParser fileParser = new CTSPLibFileParser(myResult);
                try
                {
                    fileParser.fillTSPPointList();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //MessageBox.Show(CTSPPointList.getInstance().ToString());
                myResult.Close();
                mRenderWindow.initViewPort();
                mRenderWindow.Refresh();

            }
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
            MessageBox.Show("Ants: " + CAntAlgorithmParameters.getInstance().numberAnts + "\n" + CAntAlgorithmParameters.getInstance().numberMaxIterations + "\n" + CAntAlgorithmParameters.getInstance().pheromoneParameter + " \n" + "usw usw");
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
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

    }
}
