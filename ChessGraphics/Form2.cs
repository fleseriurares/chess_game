using ChessModel;
using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGUI
{
    public partial class Form2 : Form
    {
        private int selectedPieceIndex;
        private int secondSelectedPieceIndex;
        private List<PictureBox> highlight;
        private Dictionary<Pieces, int> dictionary;
        private Logic logic;
        private int exchangePieceIndex;
        private Game game;
        private Form3 form3;


        public Form2(Form3 form3)
        {
            InitializeComponent();
            this.form3 = form3;

            this.Resize += Form2_Resize;
            selectedPieceIndex = -1;
            secondSelectedPieceIndex = -1;
            game = new Game();
            logic = game.GameLogic;
           
            highlight = new List<PictureBox>();
            this.dictionary = new Dictionary<Pieces, int>();

            InitializeContUpdateF3();
            InitializePieces();

        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            int pictureBoxSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height);

            this.pictureBox1.Size = new Size(pictureBoxSize, pictureBoxSize);
            this.pictureBox1.Location = new Point((this.ClientSize.Width - pictureBoxSize) / 2, (this.ClientSize.Height - pictureBoxSize) / 2);
            this.pictureBox1.SendToBack();

            pictureBoxExchange.Location = new Point((2) * this.pictureBox1.Width / 8 - 10, (3) * this.pictureBox1.Height / 8);
            pictureBoxExchange.Name = "pictureBoxExchange";
            pictureBoxExchange.Size = new Size(this.pictureBox1.Width / 2 + 25, this.pictureBox1.Width / 6);

            int center = (this.pictureBox1.Width / 6 - pictureBoxExchange.Width / 4) / 2;
            button1.Location = new Point((2) * this.pictureBox1.Width / 8, (3) * this.pictureBox1.Height / 8 + center);
            button1.Size = new Size(pictureBoxExchange.Width/4, pictureBoxExchange.Width / 4);

            button2.Location = new Point((3) * this.pictureBox1.Width / 8, (3) * this.pictureBox1.Height / 8 + center);
            button2.Size = new Size(pictureBoxExchange.Width / 4, pictureBoxExchange.Width / 4);

            button3.Location = new Point((4) * this.pictureBox1.Width / 8, (3) * this.pictureBox1.Height / 8 + center);            button3.Name = "button3";
            button3.Size = new Size(pictureBoxExchange.Width / 4, pictureBoxExchange.Width / 4);

            button4.Location = new Point((5) * this.pictureBox1.Width / 8, (3) * this.pictureBox1.Height / 8 + center);
            button4.Size = new Size(pictureBoxExchange.Width / 4, pictureBoxExchange.Width / 4);

            DisableExchangeBox();
        }

        public void Form2_Resize(object sender, EventArgs e)
        {
            int pictureBoxSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height);

            this.pictureBox1.Size = new Size(pictureBoxSize, pictureBoxSize);
            this.pictureBox1.Location = new Point((this.ClientSize.Width - pictureBoxSize) / 2, (this.ClientSize.Height - pictureBoxSize) / 2);
            this.pictureBox1.SendToBack();

            foreach (var piece in pieces)
            {
                piece.Item2.Location = GetPosition(piece.Item1.Position.X, piece.Item1.Position.Y);
                piece.Item2.Size = new Size(pictureBoxSize / 8, pictureBoxSize / 8);
            }

            foreach (var highlightVar in highlight)
            {
                highlightVar.Size = new Size(pictureBoxSize / 8, pictureBoxSize / 8);
                highlightVar.Location = new Point(highlightVar.Location.X * pictureBoxSize / this.pictureBox1.Width, highlightVar.Location.Y * pictureBoxSize / this.pictureBox1.Height);
            }
        }

        private void InitializePieces()
        {
            this.pieces = new Tuple<Pieces, PictureBox>[32];
            int pictureBoxSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height);
            
            for (int i = 0; i < 8; i++)
            {
                
                pieces[i] = new Tuple<Pieces, PictureBox>(new Pawn(Side.White), new PictureBox());
                pieces[i].Item2.Image = Properties.Resources.pawn_white;
                ConfigPieces(i,i,6);
                
            }
   
            pieces[8] = new Tuple<Pieces, PictureBox>(new Bishop(Side.White), new PictureBox());
            pieces[8].Item2.Image = Properties.Resources.bishop_white;
            ConfigPieces(8,2,7);
            pieces[9] = new Tuple<Pieces, PictureBox>(new Bishop(Side.White), new PictureBox());
            pieces[9].Item2.Image = Properties.Resources.bishop_white;
            ConfigPieces(9, 5, 7);

            pieces[10] = new Tuple<Pieces, PictureBox>(new Rook(Side.White), new PictureBox());
            pieces[10].Item2.Image = Properties.Resources.rook_white;
            ConfigPieces(10, 0, 7);
            pieces[11] = new Tuple<Pieces, PictureBox>(new Rook(Side.White), new PictureBox());
            pieces[11].Item2.Image = Properties.Resources.rook_white;
            ConfigPieces(11, 7, 7);

            pieces[12] = new Tuple<Pieces, PictureBox>(new Knight(Side.White), new PictureBox());
            pieces[12].Item2.Image = Properties.Resources.knight_white;
            ConfigPieces(12, 1, 7);
            pieces[13] = new Tuple<Pieces, PictureBox>(new Knight(Side.White), new PictureBox());
            pieces[13].Item2.Image = Properties.Resources.knight_white;
            ConfigPieces(13, 6, 7);

            pieces[14] = new Tuple<Pieces, PictureBox>(new Queen(Side.White), new PictureBox());

            pieces[14].Item2.Image = Properties.Resources.queen_white;
            ConfigPieces(14, 3, 7);
            pieces[15] = new Tuple<Pieces, PictureBox>(new King(Side.White), new PictureBox());
            pieces[15].Item2.Image = Properties.Resources.king_white;
            ConfigPieces(15, 4, 7);

            for (int i = 16; i < 24; i++)
            {
                pieces[i] = new Tuple<Pieces, PictureBox>(new Pawn(Side.Black), new PictureBox());
                pieces[i].Item2.Image = Properties.Resources.pawn_black;
                ConfigPieces(i,i%8,1);
            }

            pieces[24] = new Tuple<Pieces, PictureBox>(new Bishop(Side.Black), new PictureBox());
            pieces[24].Item2.Image = Properties.Resources.bishop_black;
            ConfigPieces(24, 2, 0);
            pieces[25] = new Tuple<Pieces, PictureBox>(new Bishop(Side.Black), new PictureBox());
            pieces[25].Item2.Image = Properties.Resources.bishop_black;
            ConfigPieces(25, 5, 0);

            pieces[26] = new Tuple<Pieces, PictureBox>(new Rook(Side.Black), new PictureBox());
            pieces[26].Item2.Image = Properties.Resources.rook_black;
            ConfigPieces(26, 0, 0);
            pieces[27] = new Tuple<Pieces, PictureBox>(new Rook(Side.Black), new PictureBox());
            pieces[27].Item2.Image = Properties.Resources.rook_black;
            ConfigPieces(27, 7, 0);

            pieces[28] = new Tuple<Pieces, PictureBox>(new Knight(Side.Black), new PictureBox());
            pieces[28].Item2.Image = Properties.Resources.knight_black;
            ConfigPieces(28, 1, 0);
            pieces[29] = new Tuple<Pieces, PictureBox>(new Knight(Side.Black), new PictureBox());
            pieces[29].Item2.Image = Properties.Resources.knight_black;
            ConfigPieces(29, 6, 0);


            pieces[30] = new Tuple<Pieces, PictureBox>(new Queen(Side.Black), new PictureBox());
            pieces[30].Item2.Image = Properties.Resources.queen_black;
            ConfigPieces(30, 3, 0);
            pieces[31] = new Tuple<Pieces, PictureBox>(new King(Side.Black), new PictureBox());
            pieces[31].Item2.Image = Properties.Resources.king_black;
            ConfigPieces(31, 4, 0);
        }
        public void InitializeContUpdateF3()
        {
            System.Timers.Timer form3UT = new System.Timers.Timer(1000);
            form3UT.Elapsed += Form3UpdateTimerElapsed;
            form3UT.Start();
        }

        public void ConfigPieces(int i,int x, int y)
         {
            int pictureBoxSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height);

            pieces[i].Item2.Name = "pictureBoxPiece" + i;
            pieces[i].Item2.BackColor = Color.Transparent;
            pieces[i].Item2.Name = "pictureBoxPiece" + i;
            pieces[i].Item2.Size = new Size(pictureBoxSize / 8, pictureBoxSize / 8);
            pieces[i].Item2.TabIndex = 1;
            pieces[i].Item2.TabStop = false;
            pieces[i].Item2.SizeMode = PictureBoxSizeMode.StretchImage;
            pieces[i].Item2.Parent = pictureBox1;
            int index = i;
            EventHandler clickEvent = (sender, e) =>
            {
                ChangeSelection(index);
                if (secondSelectedPieceIndex != -1)
                {
                    TryOvertakePiece();
                }
            };
            pieces[i].Item2.Click += clickEvent;

            pieces[i].Item1.Position = new Position(x, y); //col, linie
            logic.Board[x, y] = pieces[i].Item1;
            dictionary.Add(logic.Board[x, y], i);
            pieces[i].Item2.Location = GetPosition(pieces[i].Item1.Position.X, pieces[i].Item1.Position.Y);

         }

        public void ChangeSelection(int i) 
        {
            if (game.Over == false)
            {
                if (selectedPieceIndex != -1)
                {

                    if (pieces[selectedPieceIndex].Item1.Side == pieces[i].Item1.Side) //schimbam piesa de mutat
                    {
                        if (logic.CanCastle(pieces[selectedPieceIndex].Item1, pieces[i].Item1))
                        {
                            Castle(selectedPieceIndex, i);

                        }
                        else
                        {              
                            RemovePossibleHighlights();
                            pieces[selectedPieceIndex].Item2.BackColor = Color.Transparent;
                            pieces[selectedPieceIndex].Item1.Selected = false;
                            selectedPieceIndex = i;
                            pieces[selectedPieceIndex].Item1.Selected = true;
                            if ((pieces[selectedPieceIndex].Item1.Position.X + pieces[selectedPieceIndex].Item1.Position.X) % 2 == 1)
                            {
                                pieces[selectedPieceIndex].Item2.BackColor = Color.FromArgb(90, Color.YellowGreen);
                            }
                            else
                            {
                                pieces[selectedPieceIndex].Item2.BackColor = Color.FromArgb(160, Color.YellowGreen);
                            }
                            HighlightPossibleMoves();
                        }
                    }
                    else 
                    {
                        secondSelectedPieceIndex = i;
                    }
                }
                else
                {
                    if (pieces[i].Item1.Side == game.Turn)
                    {
                        selectedPieceIndex = i;
                        pieces[selectedPieceIndex].Item1.Selected = true;
                        RemovePossibleHighlights();
                        if ((pieces[selectedPieceIndex].Item1.Position.X + pieces[selectedPieceIndex].Item1.Position.X) % 2 == 1)
                        {
                            pieces[selectedPieceIndex].Item2.BackColor = Color.FromArgb(90, Color.YellowGreen);
                        }
                        else
                        {
                            pieces[selectedPieceIndex].Item2.BackColor = Color.FromArgb(160, Color.YellowGreen);
                        }
                        HighlightPossibleMoves();
                    }
                }
            }
        } 
        public void TryOvertakePiece()
        {
            if (pieces[secondSelectedPieceIndex].Item2.BackColor == Color.FromArgb(120,Color.DarkGreen))
            {              
                MovePiece(selectedPieceIndex, pieces[secondSelectedPieceIndex].Item1.Position.X, pieces[secondSelectedPieceIndex].Item1.Position.Y);
                RemovePiece(secondSelectedPieceIndex);
            }
            pieces[selectedPieceIndex].Item2.BackColor = Color.Transparent;
            selectedPieceIndex = -1;
            secondSelectedPieceIndex = -1;
        }


        public void DisableExchangeBox()
        {

            pictureBoxExchange.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();

        }

        public void EnableExchangeBox(int i)
        {
            exchangePieceIndex = i;
            pictureBoxExchange.Show();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();

        }

       
        public void Castle(int index1, int index2)
        {
            logic.Castle(pieces[index1].Item1, pieces[index2].Item1);
            pieces[index1].Item2.Location = new Point((pieces[index1].Item1.Position.X) * this.pictureBox1.Width / 8, (pieces[index1].Item1.Position.Y) * this.pictureBox1.Height / 8);
            pieces[index1].Item2.BackColor = Color.Transparent;

            pieces[index2].Item2.Location = new Point((pieces[index2].Item1.Position.X) * this.pictureBox1.Width / 8, (pieces[index2].Item1.Position.Y) * this.pictureBox1.Height / 8);
            pieces[index2].Item2.BackColor = Color.Transparent;

            selectedPieceIndex = -1;
            secondSelectedPieceIndex = -1;

        }

       

        public void HighlightPossibleMoves()
        {

            List<Position> possibleMoves = this.logic.GetPossibleMoves(pieces[selectedPieceIndex].Item1);
            
            foreach (Position pos in possibleMoves)
            {
                if (logic.Board[pos.X, pos.Y] != null && logic.Board[pos.X, pos.Y].PieceType != ChessModel.Type.King)
                {
                    int index = dictionary[logic.Board[pos.X, pos.Y]];
                    pieces[index].Item2.BackColor = Color.FromArgb(120,Color.DarkGreen);

                }
                HighlightSquare(pos);
            }
        }

        public void RemovePossibleHighlights()
        {
            foreach(PictureBox pictureBox in highlight)
            {
                pictureBox1.Controls.Remove(pictureBox);
            }
            highlight.Clear();
            ResetBackColor();
        }

        public void ResetBackColor()
        {
            for(int i = 0; i < pieces.Length; i++) 
            {

                if (pieces[i] != null)
                {
                    pieces[i].Item2.BackColor = Color.Transparent;
                }

            }
        }

        public void HighlightSquare(Position pos)
        {
            int pictureBoxSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height);

           PictureBox pic = new PictureBox();


            pic.Location = (GetPosition(pos.X, pos.Y));
            pic.Size = new Size(pictureBoxSize / 8, pictureBoxSize / 8);
            pic.BackColor = Color.FromArgb(90,Color.LightGreen);
            pic.Parent = pictureBox1;
            pic.Enabled = false;
            pictureBox1.Controls.Add(pic);

            highlight.Add(pic);

        }



        public Point GetPosition(int x,int y)
        {  
            int pictureBoxSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height);

            return new Point((x) * pictureBoxSize / 8  , (y) * pictureBoxSize / 8  );
        }

        public Point GetPositionPiece(int index)
        {
            return new Point(pieces[index].Item1.Position.X, pieces[index].Item1.Position.Y);
        }



        public void MovePiece(int index,int posX, int posY)
        {
            logic.MovePiece(logic.Board,pieces[index].Item1,  posX,  posY);
            Pieces exchangePiece = logic.ExchangePawn();
            if (exchangePiece != null)
            {
                int i = dictionary[exchangePiece];
                EnableExchangeBox(i);
            }
            pieces[index].Item2.Location = new Point((posX) * this.pictureBox1.Width / 8, (posY) * this.pictureBox1.Height / 8);
            pieces[index].Item2.BackColor = Color.Transparent;

            game.ChangeTurn();
            UpdateForm3();

            if (game.Checkmate == true)
            {
                game.Over = true;
            }
            else if(game.Stalemate == true) 
            {
                game.Over = true;
            }
            OverMessage();
            RemovePossibleHighlights(); 
        }

        public void RemovePiece(int index)
        {
            pieces[index].Item1.Active = false;
            pictureBox1.Controls.Remove(pieces[index].Item2);
        }

        public void UpdateForm3()
        {
            if (game.Turn == Side.White)
            {
                game.TimerW.Start();
                game.TimerB.Stop();
                if(game.Check == false) 
                {
                    form3.Label1.BackColor = Color.LightGreen;
                }
                else
                {
                    form3.Label1.BackColor = Color.Orange;

                }
                
                form3.Label2.BackColor = Color.Transparent;
                
            }
            else
            {
                game.TimerB.Start();
                game.TimerW.Stop();

                if (game.Check == false)
                {
                    form3.Label2.BackColor = Color.LightGreen;
                }
                else
                {
                    form3.Label2.BackColor = Color.Orange;

                }


                form3.Label1.BackColor = Color.Transparent;
            }
            UpdateTimerW();
            UpdateTimerB();
        }
       public void UpdateTimerW()
       {
            form3.Label3.Text = GetMinuteFormat(game.TimerValueW);
        }

        public void UpdateTimerB()
        {
            form3.Label6.Text = GetMinuteFormat(game.TimerValueB);
        }

        public String GetMinuteFormat(int a)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((a / 60).ToString() + ":" + (a % 60).ToString());
            return sb.ToString();
        }



        public void OverMessage()
        {
            if (game.Over == true)
            {
                form3.Label4.Hide();
                form3.Label5.Hide();
                form3.Label6.Hide();
                if (game.Stalemate == true)
                {
                    form3.Label1.BackColor = Color.LightGray;
                    form3.Label2.BackColor = Color.LightGray;
                    form3.Label3.Text = "STALEMATE";
                    form3.Label3.Font = new Font(form3.Label3.Font.FontFamily, 24);
                    form3.Label3.Location = new Point((form3.ClientSize.Width - form3.Label3.Width) / 2, form3.Label2.Bottom + 20);
                }
                else if (game.Checkmate == true)
                {
                    if (game.Winner == Side.White)
                    {
                        form3.Label1.BackColor = Color.Gold;
                        form3.Label2.BackColor = Color.Transparent;
                    }
                    else
                    {
                        form3.Label2.BackColor = Color.Gold;
                        form3.Label1.BackColor = Color.Transparent;
                    }
                    form3.BackColor = Color.LightGreen;
                    form3.Label3.Text = "WINNER";
                    form3.Label3.Font = new Font(form3.Label3.Font.FontFamily, 24);
                    form3.Label3.Location = new Point((form3.ClientSize.Width - form3.Label3.Width) / 2, form3.Label2.Bottom + 20);
                }
                else if (game.Check == true)
                {
                    if (game.Turn == Side.White)
                    {
                        form3.Label1.BackColor = Color.Red;
                    }
                    else
                    {
                        form3.Label2.BackColor = Color.Red;
                    }
                }
                else
                {
                    if (game.Winner == Side.White)
                    {
                        form3.Label1.BackColor = Color.Gold;
                        form3.Label2.BackColor = Color.Transparent;
                    }
                    else
                    {
                        form3.Label2.BackColor = Color.Gold;
                        form3.Label1.BackColor = Color.Transparent;
                    }
                    form3.BackColor = Color.LightGreen;
                    form3.Label3.Text = "WINNER";
                    form3.Label3.Font = new Font(form3.Label3.Font.FontFamily, 24);
                    form3.Label3.Location = new Point((form3.ClientSize.Width - form3.Label3.Width) / 2, form3.Label2.Bottom + 20);
                }

            }
        }

        private void Form3UpdateTimerElapsed(object sender, EventArgs e)
        {
            if (game.Over != true)//
            {
                UpdateForm3();
            }
            else
            {
                OverMessage();
            }
        }

        public void PictureBox1_Click(object sender, EventArgs e)
        {

            MouseEventArgs mouse_ev = (MouseEventArgs)e;
            int posX = mouse_ev.X / (this.pictureBox1.Width / 8);
            int posY = mouse_ev.Y / (this.pictureBox1.Height / 8);


            if (selectedPieceIndex != -1)
            {
                List<Position> list = logic.GetPossibleMoves(pieces[selectedPieceIndex].Item1);
              
                if ( logic.IsReachable(pieces[selectedPieceIndex].Item1, posX, posY))
                {
                    pieces[selectedPieceIndex].Item1.IsValidMove(posX, posY);
                    if(pieces[selectedPieceIndex].Item1.Position.X != posX && pieces[selectedPieceIndex].Item1.PieceType == ChessModel.Type.Pawn) // en passant
                    {
                        Position removePosition = logic.GetRemovePosEP(pieces[selectedPieceIndex].Item1, posX, posY);
                        int index = dictionary[logic.Board[removePosition.X, removePosition.Y]];
                       
                        RemovePiece(index);
                    }
                    MovePiece(selectedPieceIndex, posX, posY);
                }
            }
            selectedPieceIndex = -1;

            RemovePossibleHighlights();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (pieces[exchangePieceIndex].Item1.Side == Side.White)
            {
                int posX = pieces[exchangePieceIndex].Item1.Position.X;
                RemovePiece(exchangePieceIndex);
                pieces[exchangePieceIndex] = new Tuple<Pieces, PictureBox>(new Queen(Side.White), new PictureBox());
                pieces[exchangePieceIndex].Item2.Image = Properties.Resources.queen_white;
                ConfigPieces(exchangePieceIndex, posX, 0);
            }
            else
            {
                int posX = pieces[exchangePieceIndex].Item1.Position.X;
                RemovePiece(exchangePieceIndex);
                pieces[exchangePieceIndex] = new Tuple<Pieces, PictureBox>(new Queen(Side.Black), new PictureBox());
                pieces[exchangePieceIndex].Item2.Image = Properties.Resources.queen_black;
                ConfigPieces(exchangePieceIndex, posX, 7);
            }
           
            DisableExchangeBox();
        }
        private void Button2_Click(object sender, EventArgs e)
        {

            if (pieces[exchangePieceIndex].Item1.Side == Side.White)
            {
                int posX = pieces[exchangePieceIndex].Item1.Position.X;
                RemovePiece(exchangePieceIndex);
                pieces[exchangePieceIndex] = new Tuple<Pieces, PictureBox>(new Rook(Side.White), new PictureBox());
                pieces[exchangePieceIndex].Item2.Image = Properties.Resources.rook_white;
                ConfigPieces(exchangePieceIndex, posX, 0);
            }
            else
            {
                int posX = pieces[exchangePieceIndex].Item1.Position.X;
                RemovePiece(exchangePieceIndex);
                pieces[exchangePieceIndex] = new Tuple<Pieces, PictureBox>(new Rook(Side.Black), new PictureBox());
                pieces[exchangePieceIndex].Item2.Image = Properties.Resources.rook_black;
                ConfigPieces(exchangePieceIndex, posX, 7);
            }


            DisableExchangeBox();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (pieces[exchangePieceIndex].Item1.Side == Side.White)
            {
                int posX = pieces[exchangePieceIndex].Item1.Position.X;
                RemovePiece(exchangePieceIndex);
                pieces[exchangePieceIndex] = new Tuple<Pieces, PictureBox>(new Bishop(Side.White), new PictureBox());
                pieces[exchangePieceIndex].Item2.Image = Properties.Resources.bishop_white;
                ConfigPieces(exchangePieceIndex, posX, 0);
            }
            else
            {
                int posX = pieces[exchangePieceIndex].Item1.Position.X;
                RemovePiece(exchangePieceIndex);
                pieces[exchangePieceIndex] = new Tuple<Pieces, PictureBox>(new Bishop(Side.Black), new PictureBox());
                pieces[exchangePieceIndex].Item2.Image = Properties.Resources.bishop_black;
                ConfigPieces(exchangePieceIndex, posX, 7);
            }

            DisableExchangeBox();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (pieces[exchangePieceIndex].Item1.Side == Side.White)
            {
                int posX = pieces[exchangePieceIndex].Item1.Position.X;
                RemovePiece(exchangePieceIndex);
                pieces[exchangePieceIndex] = new Tuple<Pieces, PictureBox>(new Knight(Side.White), new PictureBox());
                pieces[exchangePieceIndex].Item2.Image = Properties.Resources.knight_white;
                ConfigPieces(exchangePieceIndex, posX, 0);
            }
            else
            {
                int posX = pieces[exchangePieceIndex].Item1.Position.X;
                RemovePiece(exchangePieceIndex);
                pieces[exchangePieceIndex] = new Tuple<Pieces, PictureBox>(new Knight(Side.Black), new PictureBox());
                pieces[exchangePieceIndex].Item2.Image = Properties.Resources.knight_black;
                ConfigPieces(exchangePieceIndex, posX, 7);
            }

            DisableExchangeBox();
        }



    }
}
