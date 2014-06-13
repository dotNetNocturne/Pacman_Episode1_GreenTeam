namespace PacManGame
{
    public class PacMan
    {
        public Position Position { get; set; }

        public Orientation Orientation { get; private set; }
        
        public void Turn(Orientation orientation)
        {
            this.Orientation = orientation;
        }
    }
}