using System.Diagnostics.Eventing.Reader;
using System.Text;
using System;
using System.Timers;

namespace ChessModel
{
    public class Game
    {
        private Side turn;
        private Side winner;
        private Boolean check;
        private Boolean checkmate;
        private Boolean stalemate;
        private Boolean over;
        private Logic gameLogic;
        private static int timerValueW;
        private static int timerValueB;
        private System.Timers.Timer timerW;
        private System.Timers.Timer timerB;
        public Game()
        {
            turn = Side.White;
            check = false;
            checkmate = false;
            stalemate = false;
            gameLogic = new Logic();
            SetTimers();

        }

        public void SetTimers()
        {
            timerValueW = 601;
            timerValueB = 601;
            timerW = new System.Timers.Timer(1000);
            timerB = new System.Timers.Timer(1000);
            timerW.Elapsed += TimerElapsedW;
            timerW.Start();
            timerB.Elapsed += TimerElapsedB;
            timerB.Start();
        }

        public Logic GameLogic
        {
            get { return gameLogic; }
        }

        public Side Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        public Boolean Check
        {
            get { return check; }
            set { check = value; }
        }

        public Boolean Over
        {
            get { return over; }
            set { over = value; }
        }

        public Boolean Checkmate
        {
            get { return checkmate; }
            set { checkmate = value; }
        }

        public Side Winner
        {
            get { return winner; }
            set { winner = value; }
        }

        public Boolean Stalemate
        {
            get { return stalemate; }
            set { stalemate = value; }
        }


        public Side OtherTurn()
        {
            if (turn == Side.White) { return Side.Black; }
            else { return Side.White; }
        }

        public void ChangeTurn()
        {
            if (turn == Side.White) { turn = Side.Black; }
            else { turn = Side.White; }
           
            if (gameLogic.CheckForCheck(turn, gameLogic.Board))
            {
                check = true;
                if(NoMoreMoves())
                {
                    check = false;
                    checkmate = true;
                    winner = OtherTurn();
                }
            }
            else
            {
                check = false;
                if (NoMoreMoves())
                {
                    check = false;
                    stalemate = true;
                }
            }
        }

        public Boolean NoMoreMoves()
        {
            

            List<Pieces> list = gameLogic.Board.GetPieces(turn);
           
                foreach(Pieces piece in list) 
                {
                    List<Position> possibleMoves = gameLogic.GetPossibleMoves(piece);
                if (possibleMoves.Count() > 0)
                    {
                        return false;
                    }
                }
     
            return true;
        }

        
        public void TimerElapsedW(object sender, ElapsedEventArgs e)
        {
            timerValueW--;
            if (timerValueW <= 0)
            {
                timerW.Stop();
                timerB.Stop();
                winner = Side.Black;
                over = true;
            }

        }

        public void TimerElapsedB(object sender, ElapsedEventArgs e)
        {
            timerValueB--;
            if (timerValueB <= 0)
            {
                timerW.Stop();
                timerB.Stop();
                winner = Side.White;
                over = true;
            }

        }

        public int TimerValueW
        {
            get { return timerValueW; }
        }

        public int TimerValueB
        {
            get { return timerValueB; }
        }

        public System.Timers.Timer TimerW
        {
            get { return timerW; }
        }

        public System.Timers.Timer TimerB
        {
            get { return timerB; }
        }

    }
}
