using System;
using System.Timers;

namespace PacManGame
{
    public class GameTimer : ITimer
    {
        private readonly Timer timer;
        public GameTimer(int millis)
        {
            timer = new Timer(millis);
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var evt = Elapsed;
            if (evt != null)
            {
                evt(this, EventArgs.Empty);
            }
        }

        public event EventHandler Elapsed;

        public void Start()
        {
            timer.Start();
        }
    }
}