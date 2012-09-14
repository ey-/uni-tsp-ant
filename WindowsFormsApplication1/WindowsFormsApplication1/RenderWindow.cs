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

    class RenderWindow : SimpleOpenGlControl
    {
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

        protected T_BOUNDS mBounds = new T_BOUNDS();

        public RenderWindow()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.render);
            this.Click += new EventHandler(this.click);
            
            initTestData();
        }

        private void initTestData()
        {
            // TEMPORÄR - muss woanders realisiert werden
            /////////////////////////////////////////////
            Random rand = new Random();
            
            for (int cityIndex = 0; cityIndex < NUM_RANDOM_CITYS; cityIndex++)
            {

                CTSPPointList.getInstance().addPoint(new CTSPPoint(rand.Next(1000), rand.Next(1000), ""));
                //mCityList.Add(new CTSPPoint(rand.Next(1000), rand.Next(1000), ""));
            }

            CConnectionList.getInstance().generateFromPointList();
        }
        
        public void setBestLocalPath(List<CTSPPoint> bestLocalPath)
        {
            mBestLocalPath = bestLocalPath;
        }

        public void setBestGlobalPath(List<CTSPPoint> bestGlobalPath)
        {
            mBestGlobalPath = bestGlobalPath;
        }

        protected void render(object sender, EventArgs args)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            drawAllConnections();

            //drawBestPaths();

            drawCitys();

            Gl.glFlush();
        }

        private void drawAllConnections()
        {
            Gl.glColor3f(0.8f, 0.8f, 0.8f);

            CConnectionList connList = CConnectionList.getInstance();

            for (int connectionIndex = 0; connectionIndex < connList.length(); connectionIndex++)
            {
                // Verbindung holen
                CConnection connection = connList.getConnection(connectionIndex);
                
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

        private void drawCitys()
        {
            Gl.glPointSize(5);
            Gl.glColor3f(0.0f, 0.0f, 0.0f);

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
            InitializeContexts();

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

        public void click(object sender, EventArgs args)
        {
            System.Windows.Forms.MouseEventArgs mouseArgs = (System.Windows.Forms.MouseEventArgs)args;

            if (mouseArgs.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Debug.Write("Click - X: " + mouseArgs.X + " Y: " + mouseArgs.Y + "\n");
                // da die Y-Koordinate von Oben ausgeht aber unser ViewPort von unten ausgeht muss
                // die Y-Koordiante umgekehrt werden, damit die Stadt an der korrekten Position 
                // eingefügt werden kann
                CVector2f mouseClickPos = new CVector2f(mouseArgs.X, this.Height - mouseArgs.Y);

                CTSPPoint position = new CTSPPoint("");
                position.x = (int)(mouseClickPos.x / (float)this.Width * (mBounds.right - mBounds.left));
                position.y = (int)(mouseClickPos.y / (float)this.Height * (mBounds.top - mBounds.bottom));

                CTSPPointList.getInstance().addPoint(position);
                CConnectionList.getInstance().generateFromPointList();
                this.Refresh();
            }

        }
    }
}
