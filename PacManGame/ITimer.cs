using System;

namespace PacManGame
{
    public interface ITimer
    {
        event EventHandler Elapsed;
        void Start();
    }
}