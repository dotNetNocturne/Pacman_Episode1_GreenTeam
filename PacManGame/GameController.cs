namespace PacManGame
{
    public class GameController
    {
        private readonly ITickable board;
        private readonly ITimer timer;

        public GameController(ITickable board, ITimer timer)
        {
            this.board = board;
            this.timer = timer;
            this.timer.Elapsed += (sender, args) => board.Tick();
        }

    }
}