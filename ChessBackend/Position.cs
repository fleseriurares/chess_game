namespace ChessModel
{
    public class Position
    {
        public int x;
        public int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position(Position a)
        {
            this.x = a.X;
            this.y = a.Y;
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public static Boolean operator ==(Position a, Position b)
        {
            if(a.X == b.X && a.Y == b.Y)
                {
                return true;
            }
            return false;
        }

        public static Boolean operator !=(Position a, Position b)
        {
            if (a.X == b.X && a.Y == b.Y)
            {
                return false;
            }
            return true;
        }

        public static Position operator *(Position a, int b)
        {
            return new Position(a.X * b, a.Y * b);
        }

        public Boolean isValid()
        {
            if((x >= 0 && x < 8) && (y >= 0 && y < 8))
            {
                return true;        
            }
            return false; 
        }

        public String toString()
        {
            return this.x.ToString() + ' ' + this.y.ToString() ;
        }

    }

   

}
