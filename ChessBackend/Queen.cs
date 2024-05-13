namespace ChessModel
{
    public class Queen : Pieces
    {

        public Queen(Side player)
        {
            this.type = Type.Queen;
            this.side = player;
            this.selected = false;
            this.hasMoved = false;
            this.active = true;
            this.direction = new Position[8];
            this.limit = 64;
            ConfigDirections();
        }

        public override void ConfigDirections()
        {
            this.direction[0] = new Position(0, 1); // sus
            this.direction[1] = new Position(0, -1); // jos

            this.direction[2] = new Position(1, 0); // stanga
            this.direction[3] = new Position(-1, 0); // dreapta

            this.direction[4] = new Position(-1, -1); //sus stanga
            this.direction[5] = new Position(1, -1); //sus dreapta

            this.direction[6] = new Position(1, 1); //jos dreapta
            this.direction[7] = new Position(-1, 1); //jos stanga
        }

        public override bool IsValidMove(int newX, int newY)
        {
            return true;
        }

        public override Pieces Duplicate()
        {
            Queen p = new Queen(this.Side);
            p.Position = new Position(this.Position.X, this.Position.Y);
            p.hasMoved = hasMoved;
            return p;

        }

    }
}
