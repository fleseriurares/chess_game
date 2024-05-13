using System.Collections.Generic;
using System.Drawing;

namespace ChessModel
{
    public class Board
    {

        public Pieces[,] mat;

        public Board()
        {
            InitializeBoard();
        }

        public Board(Board b)
        {
            InitializeBoard();
            for (int i = 0;i<8; i++)
            {
                for(int j = 0;j<8; j++)
                {
                    if(b.mat[i, j] == null)
                    {
                        mat[i, j] = null;
                    }
                    else
                    {
                        mat[i, j] = b.mat[i, j].Duplicate();
                    }
                    
                }
            }
        }

        public Pieces this[int i, int j]
        {
            get { return mat[i, j]; }
            set { mat[i, j] = value; }
        }

        public void InitializeBoard()
        {
            this.mat = new Pieces[8, 8];

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    mat[j, i] = null;
                }
            }
        }

        public List<Pieces> GetPieces(Side col)
        {

            List<Pieces> list = new List<Pieces>();
           
            for(int i = 0; i < 8;i++)
            {
                for(int j = 0;j < 8;j++)
                {
                    if (mat[i, j] != null)
                    {
                        if (mat[i, j].Side == col)
                        {
                            list.Add(mat[i, j]);
                        }
                    }
                }
            }
            return list; 
        }

        public Position GetKingPosition(Side s)
        {
         

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (mat[i, j] != null)
                    {
                        if (mat[i, j].PieceType == Type.King && mat[i, j].Side == s)
                        {
                            return new Position(new Position(i,j));
                        }
                    }
                }
            }
            return null;
        }

    }
}
                