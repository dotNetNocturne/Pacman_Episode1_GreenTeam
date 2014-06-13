using System;

namespace PacManGame
{ 
    public class Position
    {
        public int Row { get; set; }

        public int Column { get; set; } 

        public Position(int col, int row)
        {
            Column = col;
            Row = row;
        }
               
        public override bool Equals(Object position)
        {
            return ((Position)position).Column == Column && ((Position)position).Row == Row;
        }
    }
}
