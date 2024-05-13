namespace ChessModel
{
    public class Knight : Pieces
    {
        public Knight(Side player)
        {
            this.type = Type.Knight;
            this.side = player;
            this.selected = false;
            this.hasMoved = false;
            this.active = true;
            this.direction = new Position[8];
            this.limit = 1;
            ConfigDirections();
        }

        public override void ConfigDirections()
        {
            this.direction[0] = new Position(1, -2); //  L sus dreapta (latura mare in sus)
            this.direction[1] = new Position(-1, -2); // L sus stanga

            this.direction[2] = new Position(2, -1); // L dreapta sus (latura mare in dreapta)
            this.direction[3] = new Position(-2, -1); // L stanga sus

            this.direction[4] = new Position(1, 2); //L jos dreapta
            this.direction[5] = new Position(-1, 2); //L jos stanga

            this.direction[6] = new Position(2, 1); //L dreapta jos
            this.direction[7] = new Position(-2, 1); //L stanga jos
        }

        public override bool IsValidMove(int newX, int newY)
        {
            return true;
        }

        public override Pieces Duplicate()
        {
            Knight p = new Knight(this.Side);
            p.Position = new Position(this.Position.X, this.Position.Y);
            p.hasMoved = hasMoved;
            return p;

        }

    }
}
