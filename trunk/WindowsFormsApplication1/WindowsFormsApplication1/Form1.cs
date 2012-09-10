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
        public Form1()
        {
            InitializeComponent();
            postInitialize();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            { 
                tThreshold.Visible = true;
                labelThreshold.Visible = true;
            }
            else {
                tThreshold.Visible = false;
                labelThreshold.Visible = false;
            }
                
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
            double pheromonValue = ((double)trackBarPheromon.Value / 1000);
            labelPheremon.Text = pheromonValue.ToString();
        }

        private void trackBarheuristic_Scroll(object sender, EventArgs e)
        {
            double heuristicValue = ((double)trackBarheuristic.Value / 1000);
            labelHeuristic.Text = heuristicValue.ToString();
        }

        private void trackBarHumidification_Scroll(object sender, EventArgs e)
        {
            double humidificationValue = ((double)trackBarHumidification.Value / 1000);
            labelHumidification.Text = humidificationValue.ToString();
        }

        private void trackBarinitialPheromon_Scroll(object sender, EventArgs e)
        {
            double initialPheromonValue = ((double)trackBarinitialPheromon.Value / 1000);
            labelinitialPheromon.Text = initialPheromonValue.ToString();
        }

        private void trackBarheuristicPheromonUpdate_Scroll(object sender, EventArgs e)
        {
            double heuristicPheromonUpdateValue = ((double)trackBarheuristicPheromonUpdate.Value / 1000);
            labelheuristicPheromonUpdate.Text = heuristicPheromonUpdateValue.ToString();
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (openTspFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Open the selected file to read.
                System.IO.Stream myResult = openTspFileDialog1.OpenFile();

                using (System.IO.StreamReader reader = new System.IO.StreamReader(myResult))
                {
                    String actualLine;
                    CTSPPointList loadedCtsPointList = new CTSPPointList();
                    while (!(reader.ReadLine() == "NODE_COORD_SECTION"))
                    { }
                    while (!(reader.EndOfStream))
                    {              
                        actualLine = reader.ReadLine();
    
                        if (!(actualLine == "EOF"))
                        {
                            string[] actualLineSplit = actualLine.Split(new Char[] { ' ' });

                          //  for (int i=0; i < actualLineSplit.Length; i++)
                           // {
                            double pointX = (double)double.Parse(actualLineSplit[1],System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                            double pointY = (double)double.Parse(actualLineSplit[2], System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                            string index = actualLineSplit[0];
                            MessageBox.Show("Punkt mit dem Index" + index + "mit den Punkten X=" + pointX + " und Y=" + pointY);                             
                           // loadedCtsPointList.addPoint(new CTSPPoint(pointX,pointY,index);
                          //  }
                        }
                    }

                }
                myResult.Close();

            }
        }

    }
}
