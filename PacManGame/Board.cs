namespace PacManGame
{
    public class Board : ITickable
    {
        private readonly int cols;
        private readonly int rows;


        public Board(int cols, int rows)
        {
            this.cols = cols;
            this.rows = rows;
            PacMan = new PacMan { Position = new Position(cols / 2, rows / 2) };
            PacMan.Turn(Orientation.Up);
        }

        public PacMan PacMan { get; set; }

        public void Tick()
        {
            switch (PacMan.Orientation)
            {
                case Orientation.Up:
                    PacMan.Position.Row -= 1;
                    break;
                case Orientation.Left:
                    PacMan.Position.Column -= 1;
                    break;
                case Orientation.Down:
                    PacMan.Position.Row += 1;
                    break;
                case Orientation.Right:
                    PacMan.Position.Column += 1;
                    break;
            }
            PacMan.Position.Row += rows;
            PacMan.Position.Row %= rows;
            PacMan.Position.Column += cols;
            PacMan.Position.Column %= cols;

        }
    }
}