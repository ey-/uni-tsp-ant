using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1 
{
    using Tao.Platform.Windows;
    using Tao.OpenGl;
    using System.Threading;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Drawing;

    class RenderWindow : SimpleOpenGlControl
    {
        // je höher desto eher wir sie gesehen
        protected const float CONNECTION_DRAW_LAYER = 0f;
        protected const float TOUR_DRAW_LAYER = 1f;
        protected const float POINT_DRAW_LAYER = 2f;
        
        protected struct T_CURSORACTION
        {
            public bool add;
            public bool del;
            public bool change;
        }

        protected struct T_POINTTOMOVE
        {
            public CTSPPoint pointToMove;
            public bool movePoint;
        }


        protected struct T_BOUNDS
        {
            public double left;
            public double right;
            public double top;
            public double bottom;
        }

        protected const int NUM_RANDOM_CITYS = 3;

        protected T_CURSORACTION mCursorAction = new T_CURSORACTION();
        protected T_POINTTOMOVE pointToMove = new T_POINTTOMOVE();
        protected T_BOUNDS mBounds = new T_BOUNDS();

        public RenderWindow()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.render);
            this.MouseUp += new MouseEventHandler(this.click);
            this.MouseDown += new MouseEventHandler(this.mMouseDown);
            this.MouseMove += new MouseEventHandler(this.mMouseMove);

        }

        public void setCursorAction(bool addP,bool deleteP,bool changeP)
        {
            mCursorAction.add = addP;
            mCursorAction.del = deleteP;
            mCursorAction.change = changeP;
        }

        protected void render(object sender, EventArgs args)
        {
            DateTime start = DateTime.Now;

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            drawAllConnections();

            drawBestPaths();

            drawPoints();

            Gl.glFlush();

            DateTime finished = DateTime.Now;
            Debug.WriteLine("Render took: " + (finished - start).TotalSeconds + " sek.");
        }

        private void drawBestPaths()
        {
            CIterationList iterationList = CIterationList.getInstance();

            CTour bestGlobalTour = iterationList.getBestGlobalTour();
            drawTour(bestGlobalTour, 1f, 0f, 0f);

            CTour bestIterationTour = iterationList.getBestLastIterationTour();
            drawTour(bestIterationTour, 0f, 1f, 0f);

            CTour optimumTour = CAntAlgorithmParameters.getInstance().optTour;
            drawTour(optimumTour, 0f, 0f, 1f);
        }

        private void drawTour(CTour tour, float red, float green, float blue)
        {
            if (tour == null)
            {
                return;
            }

            Gl.glLineWidth(3f);
            Gl.glColor3f(red, green, blue);

            // wir verwenden einen GL_LINE_LOOP. Dieser zeichnet von punkt 1 zu 2 zu 3 und 
            // zum Schluss wieder zu 1. Es ist also ein Kreis.
            Gl.glBegin(Gl.GL_LINE_LOOP);

            for (int pointIndex = 0; pointIndex < tour.getListLength(); pointIndex++)
            {
                CTSPPoint point = tour.GetPoint(pointIndex);
                Gl.glVertex3f(point.x, point.y, TOUR_DRAW_LAYER);
            }

            Gl.glEnd();
        }

        private void drawAllConnections()
        {
            Debug.WriteLine("render");

            CConnectionList connList = CConnectionList.getInstance();

            // zuerst bestimmen wie hoch der höchste Pheromonwert aller Verbindungen ist
            // damit wir beim zeichnen der Verbindungen diese Abhängig von ihrem Wert, dunkler 
            // oder heller zeichnen können
            double highestPhermone = 0;
            foreach (CConnection connection in connList)
            {
                if (connection.getPheromone() > highestPhermone)
                {
                    highestPhermone = connection.getPheromone();
                }
                if (highestPhermone == 0.0)
                {
                    highestPhermone = 1.0;
                }
            }

            Gl.glLineWidth(1f);

            // Verbindungen Zeichnen
            foreach (CConnection connection in connList)
            {                
                // Farbe abhängig vom Pheromonwert der Verbindung setzen
                // => hohe Werte werden dunkel dagestellt
                // => niedrige hell
                double pheromonLevel = connection.getPheromone() / highestPhermone;
                double color = 1 - pheromonLevel;
                // Die Verbindungen sollen immer sichtbar bleiben auch wenn sie sehr geringe Pheromonwerte haben
                if (color > 0.95) color = 0.95;

                // 0.0 == schwarz // 1.0 == weiß
                Gl.glColor3d(1.0 - color, 1.0 - color, 1.0 - color);

                // Eckpunkte bestimmen
                CTSPPoint sourcePoint = null;
                CTSPPoint destinationPoint = null;
                connection.getPoints(out sourcePoint, out destinationPoint);

                // Linien Zeichnen
                Gl.glBegin(Gl.GL_LINES);
                    Gl.glVertex3d(sourcePoint.x, sourcePoint.y, CONNECTION_DRAW_LAYER);
                    Gl.glVertex3d(destinationPoint.x, destinationPoint.y, CONNECTION_DRAW_LAYER);
                Gl.glEnd();
            }
        }

        private void drawPoints()
        {
            Gl.glPointSize(5);
            Gl.glColor3f(1.0f, 0f, 0f);

            // Städte Zeichnen
            CTSPPointList pointList = CTSPPointList.getInstance();

            for (int pointIndex = 0; pointIndex < pointList.length(); pointIndex++)
            {
                CTSPPoint point = pointList.getPoint(pointIndex);

                Gl.glBegin(Gl.GL_POINTS);
                  Gl.glVertex3d(point.x, point.y, POINT_DRAW_LAYER);
                Gl.glEnd();
            }
        }

        public void initViewPort()
        {
            //InitializeContexts();

            Gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            mBounds = getBounds(CTSPPointList.getInstance());

            mBounds.left -= 5;
            mBounds.right += 5;
            mBounds.bottom -= 5;
            mBounds.top += 5;
            
            // hier müssen wir bestimmen wie groß die Renderfläche sein soll
            // wenn z.b. die äußerste Stadt bei 345, 239 liegt, sollte der 
            // Viewport ein wenig größer sein
            Gl.glOrtho(mBounds.left, mBounds.right, mBounds.bottom, mBounds.top, -100.0f, 100.0f);
        }

        protected T_BOUNDS getBounds(CTSPPointList citys)
        {
            T_BOUNDS ret = new T_BOUNDS();
            ret.left = double.MaxValue;
            ret.bottom = double.MaxValue;

            for (int cityIndex = 0; cityIndex < citys.length(); cityIndex++)
            {
                CTSPPoint city = citys.getPoint(cityIndex);

                if (city.x < ret.left)
                {
                    ret.left = city.x;
                }

                if (city.y < ret.bottom)
                {
                    ret.bottom = city.y;
                }

                if (city.x > ret.right)
                {
                    ret.right = city.x;
                }

                if (city.y > ret.top)
                {
                    ret.top = city.y;
                }
            }

            return ret;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RenderWindow
            // 
            this.Name = "RenderWindow";
            this.ResumeLayout(false);
        }

        public void mMouseMove(object sender, EventArgs args)
        {
            System.Windows.Forms.MouseEventArgs mouseArgs = (System.Windows.Forms.MouseEventArgs)args;

            CVector2f position = getPositionFromMouseClick(mouseArgs);

            if (!mCursorAction.change)
            {
                return;
            }

            if (pointToMove.movePoint)
            {
                if (mouseArgs.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pointToMove.pointToMove.x = position.x;
                    pointToMove.pointToMove.y = position.y;
                }
            }
            
        }

        private CVector2f getPositionFromMouseClick(System.Windows.Forms.MouseEventArgs mouseArgs)
        {
            //Debug.Write("Click - X: " + mouseArgs.X + " Y: " + mouseArgs.Y + "\n");
            // da die Y-Koordinate von Oben ausgeht aber unser ViewPort von unten ausgeht muss
            // die Y-Koordiante umgekehrt werden, damit die Stadt an der korrekten Position 
            // eingefügt werden kann
            float mouseX = mouseArgs.X;
            float mouseY = this.Height - mouseArgs.Y;

            CVector2f position = new CVector2f();
            position.x = (float)(mBounds.left + ((mouseX * (mBounds.right - mBounds.left)) / (float)this.Width));
            position.y = (float)(mBounds.bottom + ((mouseY * (mBounds.top - mBounds.bottom)) / (float)this.Height));
            return position;
        }

        public void mMouseDown(object sender, EventArgs args)
        {
            if (mCursorAction.change)
            {
                System.Windows.Forms.MouseEventArgs mouseArgs = (System.Windows.Forms.MouseEventArgs)args;

                if (mouseArgs.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    CVector2f position = getPositionFromMouseClick(mouseArgs);

                    float precision = (float)((mBounds.right - mBounds.left)/100);
                    CTSPPoint Point = CTSPPointList.getInstance().getPointsbyCoordinates(position.x, position.y,precision);
                    if (!(Point == null))
                    {
                        pointToMove.movePoint=true;
                        pointToMove.pointToMove= Point;
                    }
                }
            }

        }

        public void click(object sender, EventArgs args)
        {
            if (mCursorAction.change || mCursorAction.add || mCursorAction.del)
            {
                System.Windows.Forms.MouseEventArgs mouseArgs = (System.Windows.Forms.MouseEventArgs)args;

                if (mouseArgs.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    CVector2f position = getPositionFromMouseClick(mouseArgs);

                    //Debug.Write("pos - X: " + position.x + " Y: " + position.y + "\n");
                    handleCursorAction(position);
                    CConnectionList.getInstance().generateFromPointList(CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EUC_2D);
                    this.Refresh();
                }
            }
        }

        private void handleCursorAction(CVector2f position)
        {
            if (mCursorAction.add)
            {
                CTSPPointList.getInstance().addPoint(new CTSPPoint(position.x, position.y));
            }
            
            if (mCursorAction.del)
            {
                float precision = (float)((mBounds.right - mBounds.left) / 100);
                CTSPPoint Point = CTSPPointList.getInstance().getPointsbyCoordinates(position.x, position.y, precision);
                if (!(Point == null))
                {
                    CTSPPointList.getInstance().remove(Point);
                }
            }

            if (mCursorAction.change)
            {
                pointToMove.movePoint=false;
            }

        }
    }// class
} // namespace
