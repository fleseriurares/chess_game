using System.Drawing;
using System.Runtime.CompilerServices;

namespace ChessModel
{

    public enum Type{
        Pawn,
        Knight,
        Rook,
        Bishop,
        Queen,
        King
    }

    public enum Side
    {
        White,
        Black
    }

    public abstract class Pieces
    {

        protected Type type;
        protected Side side;
        protected Position position;
        protected Boolean selected;
        protected Boolean hasMoved;
        protected Boolean active;
        protected int limit;
        protected Position[] direction;


        public Type PieceType
        {
            get { return type; }
            set { type = value; }
        }

        public Side Side
        {
            get { return side; }
            set { side = value; }
        }

        public int Limit
        {
            get { return limit; }
            set { limit = value; }
        }

        public Position Position
        {
            get { return position; }
            set { position = value; }  
        }

        public Position[] Direction
        {
            get { return direction; }
        }

        public Boolean Selected
        {
            get { return selected; }
            set{selected = value;}
        }

        public Boolean Active
        {
            get { return active; }
            set { active = value; }
        }

        public Boolean HasMoved
        {
            get { return hasMoved; }
            set { hasMoved = value; }
        }

        public abstract Boolean IsValidMove(int newX, int newY);

        public abstract void ConfigDirections();

        public abstract Pieces Duplicate();


    }
}
