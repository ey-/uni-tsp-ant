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
            public float left;
            public float right;
            public float top;
            public float bottom;
        }

        protected const int NUM_RANDOM_CITYS = 10;

      //  protected CVector2f[] mTestCitys;

        protected List<CTSPPoint> mCityList = null;
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
            Random rand = new Random();

            //mCityList = new CTSPPoint[rand.Next(10)];
            mCityList = new List<CTSPPoint>();

            for (int cityIndex = 0; cityIndex < NUM_RANDOM_CITYS; cityIndex++)
            {
                mCityList.Add(new CTSPPoint(rand.Next(1000), rand.Next(1000), ""));
            }
        }

        public void setCityList(List<CTSPPoint> cityList)
        {
            mCityList = cityList;
        }

        public void setBestLocalPath(List<CTSPPoint> bestLocalPath)
        {
            mBestLocalPath = bestLocalPath;
        }

        public void setBestGlobalPath(List<CTSPPoint> bestGlobalPath)
        {
            mBestGlobalPath = bestGlobalPath;
        }

        public void render(object sender, EventArgs args)
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


            // Linien Zeichnen
            for (int cityIndex = 0; cityIndex < mCityList.Count; cityIndex++)
            {
                CTSPPoint fromCity = mCityList[cityIndex];
                for (int connectionToCityIndex = cityIndex + 1; connectionToCityIndex < mCityList.Count; connectionToCityIndex++)
                {
                    CTSPPoint toCity = mCityList[connectionToCityIndex];
                    Gl.glBegin(Gl.GL_LINES);
                    Gl.glVertex3f(fromCity.x, fromCity.y, 0.0f);
                    Gl.glVertex3f(toCity.x, toCity.y, 0.0f);
                    Gl.glEnd();
                }
            }
        }

        private void drawCitys()
        {
            Gl.glPointSize(5);
            Gl.glColor3f(0.0f, 0.0f, 0.0f);

            // Städte Zeichnen
            foreach (CTSPPoint city in mCityList)
            {
                Gl.glBegin(Gl.GL_POINTS);
                Gl.glVertex3f(city.x, city.y, 0.0f);
                Gl.glEnd();
            }
        }

        public void initViewPort()
        {
            InitializeContexts();

            Gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            mBounds = getBounds(mCityList);

            mBounds.left -= 5;
            mBounds.right += 5;
            mBounds.bottom -= 5;
            mBounds.top += 5;
            
            // hier müssen wir bestimmen wie groß die Renderfläche sein soll
            // wenn z.b. die äußerste Stadt bei 345, 239 liegt, sollte der 
            // Viewport ein wenig größer sein
            Gl.glOrtho(mBounds.left, mBounds.right, mBounds.bottom, mBounds.top, -100.0f, 100.0f);
        }

        protected T_BOUNDS getBounds(List<CTSPPoint> citys)
        {
            T_BOUNDS ret = new T_BOUNDS();
            ret.left = 0;
            ret.bottom = 0;

            foreach (CTSPPoint city in citys)
            {
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

            Debug.Write("Click - X: " + mouseArgs.X + " Y: " + mouseArgs.Y + "\n");
            // da die Y-Koordinate von Oben ausgeht aber unser ViewPort von unten ausgeht muss
            // die Y-Koordiante umgekehrt werden, damit die Stadt an der korrekten Position 
            // eingefügt werden kann
            CVector2f mouseClickPos = new CVector2f(mouseArgs.X, this.Height - mouseArgs.Y);

            CTSPPoint position = new CTSPPoint("");
            position.x = (int)(mouseClickPos.x / (float)this.Width * (mBounds.right - mBounds.left));
            position.y = (int)(mouseClickPos.y / (float)this.Height * (mBounds.top - mBounds.bottom));

            mCityList.Add(position);
            this.Refresh();
        }
    }
}
