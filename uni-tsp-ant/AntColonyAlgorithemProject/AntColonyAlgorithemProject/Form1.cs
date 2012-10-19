using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AntColonyAlgorithemProject
{
     
    public partial class Form1 : Form
    {

        #region Field
        List<Point> PointList;
        List<Points> ListofPoints;
        List<Point> ToDoPoints;
        List<Point> Bestwayjet;
        double bestroute;
        Point actuelpoint;

        #endregion


        public Form1()
        {
            InitializeComponent();
            PointList = new List<Point>();
            ListofPoints = new List<Points>();
            ToDoPoints = new List<Point>();
            Bestwayjet = new List<Point>();
            bestroute = 0;

        }
        
        public struct Points
        {
            int X;
            int Y;
            string Name;

        }

        public  double distance(Point A , Point B)
        {
            double distance;
            distance = Math.Sqrt(((A.X - B.X) * (A.X - B.X)) + ((A.Y - B.Y) * (A.Y - B.Y)));
            return distance;

            
        }

       

        public Point decision(Point A)
        {
            double actuelbest = 0;
            Point Bestpoint = Point.Empty;
            ToDoPoints.Remove(A);
            Bestwayjet.Add(A);

            double dChanceValue;
            double dPheromone = 1;
            //double dDistance;
            double dSumChanceValue = 0;
            double dBetha = 10;
            double dAlpha =  0;
            




            

            foreach (Point i in ToDoPoints)
            {


                dSumChanceValue = Math.Pow((1 / distance(A, i)), dAlpha);

            }


            foreach (Point i in ToDoPoints)
            {
                dChanceValue = ((Math.Pow(dPheromone, dAlpha)) * (Math.Pow( (1 / distance(i,A)),dBetha)));
                if (  ((dChanceValue / dSumChanceValue)  > actuelbest)  )
                {


                    actuelbest = distance(A, i);
                    Bestpoint = i;
                    
                }

            }

            bestroute = bestroute + distance(A, Bestpoint);
            return Bestpoint;
        }

        public void bestway(Point A)
        {
            actuelpoint = A;
            while (ToDoPoints.Count != 0)
            {
                actuelpoint =  decision(actuelpoint);
            }
            
        }


        public void addPoint(int A, int B )
        {
            Point C = new Point();
            C.X = A;
            C.Y = B;
            PointList.Add(C);
            ToDoPoints.Add(C);    
        }


        private void button1_Click(object sender, EventArgs e)
        {

            
            addPoint(0,0);
            addPoint(2,0);
            addPoint(3,2);
            addPoint(0, 3);
            addPoint(4, 2);
            addPoint(6, 4);
            bestway(PointList[0]);

            foreach (Point i in Bestwayjet)
            {
                AusgabePunktkoordinaten(i);
            }
            MessageBox.Show(bestroute.ToString());
            

        }


        public void entfernungsausgabe(Point A, Point B)
        {
            MessageBox.Show(" Punkt A ist von Punkt B " + distance(A, B).ToString() + " Einheiten entfernt.");

        }
        public void AusgabePunktkoordinaten(Point A)
        {
            MessageBox.Show(A.X.ToString() + "/" + A.Y.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
