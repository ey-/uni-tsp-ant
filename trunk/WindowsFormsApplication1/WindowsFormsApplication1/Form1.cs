using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public delegate void delegateRefreshStatistic();
        public delegateRefreshStatistic refreshDelegateStatistic;

        private const string BUTTON_START_TEXT_START = "Starten";
        private const string BUTTON_START_TEXT_STOP = "STOP";

        private float heuristicPheromonUpdateValue = 0.001f;
        private float pheromonValue = 0.001f;
        private float initialPheromonValue = 0.001f;
        private float evaporationValue = 0.001f;
        private float heuristicValue = 0.001f;

        protected Thread mLastFileOpenerThread = null;
        protected Thread mAntAlgorithmThread = null;
        

        public Form1()
        {
            InitializeComponent();
            postInitialize();
            Application.Idle += new EventHandler(Application_Idle);
            CProgressManager.setProgressBar(pIterationProgressBar);
            CIterationList.setForm(this);
            refreshDelegateStatistic = new delegateRefreshStatistic(refreshStatisticNumbers);
        }


        public void refreshStatisticNumbers()
        {
            CIterationList iterationList = CIterationList.getInstance();
            if (iterationList.Last() != null)
                tØIteration.Text = String.Format("{0:f}", iterationList.Last().AverageTourLength);
            if (iterationList.GlobalAverageTourLength() != 0)
                tØGlobal.Text = String.Format("{0:f}", iterationList.GlobalAverageTourLength());
            if (iterationList.getBestLastIterationTour() != null)
                tBestIteration.Text = String.Format("{0:f}", iterationList.getBestLastIterationTour().getTourLength());
            if (iterationList.getBestGlobalTour() != null)
                tBestGlobal.Text = String.Format("{0:f}", iterationList.getBestGlobalTour().getTourLength());

        }

        private void Application_Idle(Object sender, EventArgs e)
        {

            if (((mLastFileOpenerThread != null) && (mLastFileOpenerThread.IsAlive)) || ((mAntAlgorithmThread != null) && (mAntAlgorithmThread.IsAlive)))
            {
                setEditFunctions(false);
            }
            else
            {
                setEditFunctions(true);
                button_Start.Text = BUTTON_START_TEXT_START;
            }

                       
        }

        private void setEditFunctions(bool all)
        {
            if (button_Start.Text==BUTTON_START_TEXT_START)
                button_Start.Enabled = all;
            groupBoxAntsAlgorithym.Enabled = all;
            uAntsQuantity.Enabled = all;
            uQuantityIterations.Enabled = all;
            gBCursorAction.Enabled = all;
            gBRandomTSP.Enabled = all;
            öffnenToolStripMenuItem.Enabled = all;
        }


        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // wenn das Programm beendet werden soll müssen wir noch eventuell 
            // laufenden Thread beenden.
            if ((mAntAlgorithmThread != null) && (mAntAlgorithmThread.IsAlive == true))
            {
                //mAntAlgorithmThread.Suspend();
                mAntAlgorithmThread.Abort();
            }

            if ((mLastFileOpenerThread != null) && (mLastFileOpenerThread.IsAlive == true))
            {
                //mLastFileOpenerThread.Suspend();
                mLastFileOpenerThread.Abort();
            }

            Application.Exit();
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(('0' <= e.KeyValue && e.KeyValue <= '9') || e.KeyCode < Keys.Help) || e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void algorithmParameterChanged(object sender ,EventArgs e)
        {
            if (sender == numericUpDownInitialPheromone)
            {
                initialPheromonValue = (float)numericUpDownInitialPheromone.Value;
            }
            else if (sender == numericUpDownPheromoneUpdate)
            {
                heuristicPheromonUpdateValue = (float)numericUpDownPheromoneUpdate.Value;
            }
            else if (sender == trackBarPheromon)
            {
                pheromonValue = ((float)trackBarPheromon.Value / 1000);
                labelPheremon.Text = pheromonValue.ToString();
            }
            else if (sender == trackBarheuristic)
            {
                heuristicValue = ((float)trackBarheuristic.Value / 1000);
                labelHeuristic.Text = heuristicValue.ToString();
            }
            else if (sender == trackBarEvaporation)
            {
                evaporationValue = ((float)trackBarEvaporation.Value / 1000);
                labelEvaporation.Text = evaporationValue.ToString();
            }
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // wenn noch ein Fileopener Thred läuft dann beenden wir diesen zunächst
            // damit wird verhindert das die Daten durcheinander gewürfelt werden
            if ((mLastFileOpenerThread != null) && (mLastFileOpenerThread.IsAlive == true))
            {
                mLastFileOpenerThread.Abort();
            }

            if (openTspFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mLastFileOpenerThread = new Thread(this.openTSPFile);
                mLastFileOpenerThread.Priority = ThreadPriority.Highest;
                mLastFileOpenerThread.Name = "TSP-LoadingThread";
                mLastFileOpenerThread.Start();
            }
        }

        private void openTSPFile()
        {
            CIterationList.getInstance().Clear();

            // Open the selected file to read.
            System.IO.Stream myResult = openTspFileDialog1.OpenFile();

            string tspFilePath = openTspFileDialog1.FileName;
            string tourFilePath = tspFilePath.Substring(0, tspFilePath.LastIndexOf('.')) + ".opt.tour";

            try
            {
                // zuerst mal das TSPfile parsen
                CTSPLibFileParser tspParser = new CTSPLibFileParser(myResult);
                tspParser.fillTSPPointList();

                // prüfen ob eine Datei mit der optimalen Tour existiert
                if (File.Exists(tourFilePath) == true)
                {
                    // Dann die Optimale Tour parsen
                    FileStream optTourFile = File.Open(tourFilePath, FileMode.Open);
                    CTSPLibFileParser tourParser = new CTSPLibFileParser(optTourFile);
                    tourParser.getOptTour();
                }
                else
                {
                    CAntAlgorithmParameters.getInstance().optTour = null;
                }
            }
            catch (ThreadAbortException )
            { 
                // wir machen nichts .. das ist nur zum verhindern das eine Meldung angezeigt wird
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
                CAntAlgorithmParameters.getInstance().optTour = null;
            }

            // Schaltfläche der Stoppkriterien, Lösung gefunden, (de)aktivieren
            this.Invoke(new Action(setStopCriteriaSolutionFound));

            myResult.Close();
            mRenderWindow.Invoke(new Action(delegate()
            {
                mRenderWindow.initViewPort();
                mRenderWindow.Refresh();
            }));

            CProgressManager.setFinished();
        }

        private void setStopCriteriaSolutionFound()
        {
            if (CAntAlgorithmParameters.getInstance().optTour == null)
            {
                cStoppLoesung.Checked = false;
                cStoppLoesung.Enabled = false;
            }
            else 
            {
                cStoppLoesung.Enabled = true;
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
            CAntAlgorithmParameters.getInstance().evaporationFactor = evaporationValue;
            //MessageBox.Show("Ants: " + CAntAlgorithmParameters.getInstance().numberAnts + "\n" + CAntAlgorithmParameters.getInstance().numberMaxIterations + "\n" + CAntAlgorithmParameters.getInstance().pheromoneParameter + " \n" + "usw usw");

            if (!(mAntAlgorithmThread == null) && (mAntAlgorithmThread.IsAlive == true) && (button_Start.Text == BUTTON_START_TEXT_STOP))
            {
                mAntAlgorithmThread.Abort();
                CIterationList.getInstance().Clear();
                GC.Collect();
            }
            if (CTSPPointList.getInstance().length() < 2)
            {
                MessageBox.Show("Anzahl der Städte beträgt weniger als 2.");
                return;
            }

            if (((mAntAlgorithmThread == null) || (mAntAlgorithmThread.IsAlive == false)) && (button_Start.Text == BUTTON_START_TEXT_START))
            {
                CAntAlgorithm antAlgorithm = new CAntAlgorithm(mRenderWindow);
                mAntAlgorithmThread = new Thread(antAlgorithm.startAlgorithm);
                mAntAlgorithmThread.Name = "AntAlgorithmThread";
                mAntAlgorithmThread.Priority = ThreadPriority.Normal;
                mAntAlgorithmThread.Start();
            }
            
            if (button_Start.Text == BUTTON_START_TEXT_START)
            {
                button_Start.Text = BUTTON_START_TEXT_STOP;
            }
            else
            {
                button_Start.Text = BUTTON_START_TEXT_START;
            }

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

        private void rCursor_CheckedChanged(object sender, EventArgs e)
        {
            mRenderWindow.setCursorAction(rCursorAdd.Checked, rCursorDelete.Checked, rCursorShift.Checked);
        }

        private void drawSettings_CheckedChanged(object sender, EventArgs e)
        {
            mRenderWindow.setDrawSettings(cBallConnection.Checked, cBoptPath.Checked, cBbestPathOfIteration.Checked, cBbestPathOfAllIteration.Checked);
            mRenderWindow.Refresh();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openManual(object sender, EventArgs e)
        {
#if DEBUG
            System.Diagnostics.Process.Start(@"../../../../Manual.pdf");
#else
            System.Diagnostics.Process.Start(@"Manual.pdf");
#endif
        }

    }
}
