using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballMatch
{
    public delegate void SayComment(object sender, EventArgs args);
    public delegate void PrintScore(object sender, EventArgs args);

    public static class GameTimer
    {
        public const int TIME = 90;
        static Timer timer;
        static Timer commentTimer;
        public static int currentTime;

        public static event SayComment SayComment;
        public static event PrintScore PrintScore;

        public static void Count(object state)
        {
            currentTime ++;
            if (currentTime == TIME)
            {
                timer.Dispose();
                commentTimer.Dispose();
                SayComment = null;
                if (PrintScore != null)
                {
                    PrintScore(null, null);
                }
            }
        }

        public static void StartGame()
        {
            int num = 0;
            TimerCallback callback1 = new TimerCallback(Count);
            timer = new Timer(callback1, num, 0, 1000);
            currentTime = 1;

            TimerCallback callback2 = new TimerCallback(NewComment);
            commentTimer = new Timer(callback2, num, 0, 3000);
        }

        private static void NewComment(object state)
        {
            if (SayComment != null)
            {
                SayComment(null, null);
            }
        }


    }
}
