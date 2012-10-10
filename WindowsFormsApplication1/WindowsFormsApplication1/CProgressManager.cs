using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class CProgressManager
    {
        protected static ProgressBar mManagedProgressbar = null;
        protected static int mIncrementPerSteps = 1;
        protected static long mStepsCounted = 0;

        public static void setProgressBar(ProgressBar progressBar)
        {
            mManagedProgressbar = progressBar;
            mManagedProgressbar.Minimum = 0;
        }

        public static void setStepsPointsAndConnections(int numberPoints)
        {
            int steps = numberPoints; // erstellen der Punkte
            steps += numberPoints * (numberPoints - 1) / 2; // erstellen der Verbindungen

            calculcateIncrementPerSteps(steps);
            mStepsCounted = 0;

            if (mManagedProgressbar != null)
            {
                mManagedProgressbar.Invoke(new Action(delegate()
                    {
                        mManagedProgressbar.Maximum = steps;
                        mManagedProgressbar.Value = 0;
                    }));
            }
        }

        public static void setStepsConnections(int numberPoints)
        {
            calculcateIncrementPerSteps(numberPoints);
            mStepsCounted = 0;

            if (mManagedProgressbar != null)
            {
                mManagedProgressbar.Invoke(new Action(delegate()
                {
                    mManagedProgressbar.Maximum = numberPoints * (numberPoints - 1) / 2;
                    mManagedProgressbar.Value = 0;
                }));
            }
        }

        public static void setStepsIteration(int numberIterations)
        {
            calculcateIncrementPerSteps(numberIterations);
            mStepsCounted = 0;

            if (mManagedProgressbar != null)
            {
                mManagedProgressbar.Invoke(new Action(delegate()
                {
                    mManagedProgressbar.Maximum = numberIterations;
                    mManagedProgressbar.Value = 0;
                }));
            }
        }

        protected static void calculcateIncrementPerSteps(int steps)
        {
            mIncrementPerSteps = steps / 100;
            if (mIncrementPerSteps == 0)
            {
                mIncrementPerSteps = 1;
            }
        }

        public static void stepDone()
        {

            if (mStepsCounted % mIncrementPerSteps == 0)
            {
                if (mManagedProgressbar != null)
                {
                    mManagedProgressbar.Invoke(new Action(delegate()
                        {
                            mManagedProgressbar.Increment(mIncrementPerSteps);
                        }));
                }
            }
            mStepsCounted++;
        }

        public static void setFinished()
        {
            if (mManagedProgressbar != null)
            {
                mManagedProgressbar.Invoke(new Action(delegate()
                {
                    mManagedProgressbar.Value = mManagedProgressbar.Maximum;
                }));
            }
        }

    }// class
} // namespace
