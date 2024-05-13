
using Microsoft.AspNetCore.Http.HttpResults;
using System.Drawing;

namespace ChessModel
{
    public class Pawn : Pieces
    {
        public Boolean enPassantCond;
        public Boolean[] enPassantCondDir;
        public Pawn(Side player)
        {
            this.type = Type.Pawn;
            this.side = player;
            this.selected = false; 
            this.hasMoved = false;
            this.active = true;
            this.direction = new Position[1];
            this.limit = 2;
            this.enPassantCond = false;
            this.enPassantCondDir = new Boolean[2];
            ConfigDirections();
        }

        public Boolean[] EnPassantCondDir
        {
            get { return enPassantCondDir; }
        }

        public override void ConfigDirections()
        {
            enPassantCondDir[0] = false;
            enPassantCondDir[1] = false;
            if (this.Side == Side.White)
            {
                this.direction[0] = new Position(0, -1);
            }
            else
            {
                this.direction[0] = new Position(0, 1);
            }
        }

        public int IsValidEnPassant(int newX,int newY)
        {

            if (this.side == Side.White)
            {
                if (enPassantCondDir[0] == true && this.position.X - 1== newX && newY - 1 == this.position.Y )
                {
                    return 1;
                }

                if (enPassantCondDir[1] == true && this.position.X + 1 == newX && newY - 1== this.position.Y )
                {
                    return 2;
                }

            }

            return 0;
        }

        public override bool IsValidMove(int newX, int newY)
        {

            if(this.side == Side.White)
            {
                if(newX == this.position.X && newY == this.position.Y - 2 && hasMoved == false)
                {
                    enPassantCond = true;
                    hasMoved = true;
                    limit = 1;
                    return true;
                }

                if (newX == this.position.X && newY == this.position.Y -1 )
                {
                    enPassantCond = false;
                    hasMoved = true;
                    limit = 1;
                    return true; 
                }
                
            }
            else
            {
                if (newX == this.position.X && newY == this.position.Y + 2 && hasMoved == false)
                {
                    enPassantCond = true;
                    hasMoved = true;
                    limit = 1;
                    return true;
                }

                if (newX == this.position.X && newY == this.position.Y + 1)
                {
                    enPassantCond = false;
                    hasMoved = true;
                    limit = 1;
                    return true;
                }
            }
            return false;
        }

        public override Pieces Duplicate()
        {
            Pawn p = new Pawn(this.Side);
            p.Position = new Position(this.Position.X, this.Position.Y);
            p.hasMoved = hasMoved;
            p.enPassantCond = enPassantCond;
            p.enPassantCondDir = enPassantCondDir;
            return p;

        }

    }
}
