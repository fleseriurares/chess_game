namespace ChessModel
{
    public class Rook : Pieces
    {

        public Rook(Side player)
        {
            this.type = Type.Rook;
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
            this.direction[0] = new Position(0, 1); // sus
            this.direction[1] = new Position(0, -1); // jos

            this.direction[2] = new Position(1, 0); // stanga
            this.direction[3] = new Position(-1, 0); // dreapta
        }

        public override bool IsValidMove(int newX, int newY)
        {
            return true;
        }

        public override Pieces Duplicate()
        {
            Rook p = new Rook(this.Side);
            p.Position = new Position(this.Position.X, this.Position.Y);
            p.hasMoved = hasMoved;
            return p;

        }

    }
}
