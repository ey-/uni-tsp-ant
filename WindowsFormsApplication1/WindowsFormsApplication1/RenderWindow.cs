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

    class RenderWindow : SimpleOpenGlControl
    {

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

        protected List<CTSPPoint> mBestLocalPath = null;
        protected List<CTSPPoint> mBestGlobalPath = null;
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

        
        public void setBestLocalPath(List<CTSPPoint> bestLocalPath)
        {
            mBestLocalPath = bestLocalPath;
        }

        public void setBestGlobalPath(List<CTSPPoint> bestGlobalPath)
        {
            mBestGlobalPath = bestGlobalPath;
        }

        public void setCursorAction(bool addP,bool deleteP,bool changeP)
        {
            mCursorAction.add = addP;
            mCursorAction.del = deleteP;
            mCursorAction.change = changeP;
        }

        protected void render(object sender, EventArgs args)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            drawAllConnections();

            //drawBestPaths();

            drawPoints();

            Gl.glFlush();
        }

        private void drawAllConnections()
        {
            Gl.glColor3f(0.8f, 0.8f, 0.8f);

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

            // Verbindungen Zeichnen
            foreach (CConnection connection in connList)
            {                
                // Farbe abhängig vom Pheromonwert der Verbindung setzen
                // => hohe Werte werden dunkel dagestellt
                // => niedrige hell
                double color = connection.getPheromone() / highestPhermone;
                // Die Verbindungen sollen immer sichtbar bleiben auch wenn sie sehr geringe Pheromonwerte haben
                if (color < 0.1) color = 0.1;
                Gl.glColor3d(color, color, color);

                // Eckpunkte bestimmen
                CTSPPoint sourcePoint = null;
                CTSPPoint destinationPoint = null;
                connection.getPoints(out sourcePoint, out destinationPoint);

                // Linien Zeichnen
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(sourcePoint.x, sourcePoint.y, 0.0f);
                Gl.glVertex3d(destinationPoint.x, destinationPoint.y, 0.0f);
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
                Gl.glVertex3d(point.x, point.y, 0.0f);
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
            ret.left = 0;
            ret.bottom = 0;

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
          if (mCursorAction.change)
            {
             if (pointToMove.movePoint)
            {
                
                System.Windows.Forms.MouseEventArgs mouseArgs = (System.Windows.Forms.MouseEventArgs)args;

                if (mouseArgs.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //Debug.Write("Click - X: " + mouseArgs.X + " Y: " + mouseArgs.Y + "\n");
                    // da die Y-Koordinate von Oben ausgeht aber unser ViewPort von unten ausgeht muss
                    // die Y-Koordiante umgekehrt werden, damit die Stadt an der korrekten Position 
                    // eingefügt werden kann
                    float mouseX = mouseArgs.X;
                    float mouseY = this.Height - mouseArgs.Y;

                    CTSPPoint position = new CTSPPoint("");
                    position.x = (float)(mBounds.left + ((mouseX * (mBounds.right - mBounds.left)) / (float)this.Width));
                    position.y = (float)(mBounds.bottom + ((mouseY * (mBounds.top - mBounds.bottom)) / (float)this.Height));

                    pointToMove.pointToMove.changeX(position.x);
                    pointToMove.pointToMove.changeY(position.y);

                }
            }
                     }
          }

        public void mMouseDown(object sender, EventArgs args)
        {
            if (mCursorAction.change)
            {
                System.Windows.Forms.MouseEventArgs mouseArgs = (System.Windows.Forms.MouseEventArgs)args;

                if (mouseArgs.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //Debug.Write("Click - X: " + mouseArgs.X + " Y: " + mouseArgs.Y + "\n");
                    // da die Y-Koordinate von Oben ausgeht aber unser ViewPort von unten ausgeht muss
                    // die Y-Koordiante umgekehrt werden, damit die Stadt an der korrekten Position 
                    // eingefügt werden kann
                    float mouseX = mouseArgs.X;
                    float mouseY = this.Height - mouseArgs.Y;

                    CTSPPoint position = new CTSPPoint("");
                    position.x = (float)(mBounds.left + ((mouseX * (mBounds.right - mBounds.left)) / (float)this.Width));
                    position.y = (float)(mBounds.bottom + ((mouseY * (mBounds.top - mBounds.bottom)) / (float)this.Height));

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
                    //Debug.Write("Click - X: " + mouseArgs.X + " Y: " + mouseArgs.Y + "\n");
                    // da die Y-Koordinate von Oben ausgeht aber unser ViewPort von unten ausgeht muss
                    // die Y-Koordiante umgekehrt werden, damit die Stadt an der korrekten Position 
                    // eingefügt werden kann
                    float mouseX = mouseArgs.X;
                    float mouseY = this.Height - mouseArgs.Y;

                    CTSPPoint position = new CTSPPoint("");
                    position.x = (float)(mBounds.left + ((mouseX * (mBounds.right - mBounds.left)) / (float)this.Width));
                    position.y = (float)(mBounds.bottom + ((mouseY * (mBounds.top - mBounds.bottom)) / (float)this.Height));

                    //Debug.Write("pos - X: " + position.x + " Y: " + position.y + "\n");
                    handleCursorAction(position);
                    CConnectionList.getInstance().generateFromPointList(CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EUC_2D);
                    this.Refresh();
                }
            }
        }

        private void handleCursorAction(CTSPPoint position)
        {
            
            
            if (mCursorAction.add)
            {
                CTSPPointList.getInstance().addPoint(position);
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
    }
}
