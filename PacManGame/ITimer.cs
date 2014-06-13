using System;

namespace PacManGame
{
    public interface ITimer
    {
        event EventHandler Elapsed;
    }
}