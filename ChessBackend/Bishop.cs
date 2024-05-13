
using Microsoft.AspNetCore.Http.HttpResults;
using System.Drawing;

namespace ChessModel
{
    public class Bishop : Pieces
    {
        public Bishop(Side player)
        {
            this.type = Type.Bishop;
            this.side = player;
            this.selected = false;
            this.hasMoved = false;
            this.active = true;
            this.direction = new Position[4];
            this.limit = 64;
            ConfigDirections();
        }




        public override void ConfigDirections()
        {
            this.direction[0] = new Position(-1, -1); //sus stanga
            this.direction[1] = new Position(1, -1); //sus dreapta

            this.direction[2] = new Position(1, 1); //jos dreapta
            this.direction[3] = new Position(-1, 1); //jos stanga
        }

        public override bool IsValidMove(int newX, int newY)
        {
            return true;
        }

        public override Pieces Duplicate()
        {
            Bishop p = new Bishop(this.Side);
            p.Position = new Position(this.Position.X, this.Position.Y);
            p.hasMoved = hasMoved;
            return p;

        }

    }
}
