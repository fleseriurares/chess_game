using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ChessModel
{
    public class Logic
    {
        private Board board;
        private List<Tuple<Pawn, Pawn>> enPassant;
        private King kingW, kingB;
        public Logic()
        {
            board = new Board();
            enPassant = new List<Tuple<Pawn, Pawn>>();
            kingW = new King(Side.White);
            kingW.Position = new Position(4, 7);
            kingB = new King(Side.Black);
            kingB.Position = new Position(4, 0);
        }

        public Board Board
        {
            get { return board; }
        }

        public List<Tuple<Pawn, Pawn>> EnPassant
        {
            get { return enPassant; }
        }


        public List<Position> GetPossibleMoves(Pieces piece)
        {
            List<Position> list = new List<Position>();
            int ind;
            Pawn pawn = null;

            if (piece.PieceType == Type.Pawn)
            {
                pawn = (Pawn)piece;

                if (SearchEnPassant(pawn))
                {
                    foreach (Tuple<Pawn, Pawn> tup in enPassant)
                    {
                        if (tup.Item1.Side == Side.White)
                        {
                            Position nextPosition = tup.Item1.Position + new Position(0, 1);
                            if (CheckNextBoard(tup.Item2, nextPosition))
                            {
                                list.Add(nextPosition);
                            }
                        }
                        else
                        {
                            Position nextPosition = tup.Item1.Position + new Position(0, -1);
                            if (CheckNextBoard(tup.Item2, nextPosition))
                            {
                                list.Add(nextPosition);

                            }
                        }
                    }
                }

            }
            foreach (Position dir in piece.Direction)
            {
                int k = 1;
                ind = 1;

                Position newPos = (dir * k) + piece.Position;
                while (ind == 1 && newPos.isValid() && k <= piece.Limit)
                {

                    if (piece.PieceType == Type.Pawn && k == 1)
                    {
                        Position newPos1 = new Position(-1, 0) + (dir * k) + piece.Position;
                        Position newPos2 = new Position(1, 0) + (dir * k) + piece.Position;

                        if (newPos1.isValid() && board.mat[newPos1.X, newPos1.Y] != null && board.mat[newPos1.X, newPos1.Y].Side != piece.Side && CheckNextBoard(piece, newPos1))
                        {
                            list.Add(newPos1);
                        }
                        if (newPos2.isValid() && board.mat[newPos2.X, newPos2.Y] != null && board.mat[newPos2.X, newPos2.Y].Side != piece.Side && CheckNextBoard(piece, newPos2))
                        {
                            list.Add(newPos2);
                        }

                    }

                    if (board.mat[newPos.X, newPos.Y] == null && CheckNextBoard(piece, newPos))
                    {
                        list.Add(newPos);
                    }
                    else if (board.mat[newPos.X, newPos.Y] != null && (board.mat[newPos.X, newPos.Y].Side == piece.Side || (piece.PieceType == Type.Pawn && board.mat[newPos.X, newPos.Y].Side != piece.Side) || board.mat[newPos.X, newPos.Y].PieceType == Type.King))
                    {
                        ind = 0;
                    }
                    else if (CheckNextBoard(piece, newPos))
                    {
                        list.Add(newPos);
                        ind = 0;

                    }

                    k++;
                    newPos = (dir * k) + piece.Position;
                }
            }
            return list;
        }


        public List<Position> GetKingAttacks(Pieces piece, Board board)
        {
            List<Position> list = new List<Position>();
            int ind;
            foreach (Position dir in piece.Direction)
            {
                int k = 1;
                ind = 1;

                Position newPos = (dir * k) + piece.Position;
                while (ind == 1 && newPos.isValid() && k <= piece.Limit)
                {

                    if (piece.PieceType == Type.Pawn && k == 1)
                    {
                        Position newPos1 = new Position(-1, 0) + (dir * k) + piece.Position;
                        Position newPos2 = new Position(1, 0) + (dir * k) + piece.Position;

                        if (newPos1.isValid() && board.mat[newPos1.X, newPos1.Y] != null && board.mat[newPos1.X, newPos1.Y].Side != piece.Side)
                        {
                            list.Add(newPos1);
                        }
                        if (newPos2.isValid() && board.mat[newPos2.X, newPos2.Y] != null && board.mat[newPos2.X, newPos2.Y].Side != piece.Side)
                        {
                            list.Add(newPos2);
                        }

                    }

                    if (board.mat[newPos.X, newPos.Y] == null)// && CheckNextBoard(piece, newPos))
                    {
                        list.Add(newPos);
                    }
                    else if (board.mat[newPos.X, newPos.Y].Side == piece.Side || (piece.PieceType == Type.Pawn && board.mat[newPos.X, newPos.Y].Side != piece.Side))
                    {
                        ind = 0;
                    }
                    else// if (CheckNextBoard(piece, newPos))
                    {
                        list.Add(newPos);
                        ind = 0;

                    }

                    k++;
                    newPos = (dir * k) + piece.Position;

                }
            }

            return list;
        }


        public Boolean CheckNextBoard(Pieces piece, Position pos)
        {
            Board boardNext = new Board(board);
            Pieces newPiece = boardNext[piece.Position.X, piece.Position.Y];
            MovePiece(boardNext, newPiece, pos.X, pos.Y);

            return !(CheckForCheck(newPiece.Side, boardNext));
        }

        public Boolean CanCastle(Pieces p1, Pieces p2)
        {
            if ((p1.PieceType == Type.Rook && p2.PieceType == Type.King) || (p2.PieceType == Type.Rook && p1.PieceType == Type.King))
            {
                if (p1.HasMoved == false && p2.HasMoved == false)
                {
                    int startPoint = Math.Min(p1.Position.X, p2.Position.X);
                    int finishPoint = Math.Max(p1.Position.X, p2.Position.X);
                    Pieces king;
                    if (p1.PieceType == Type.King)
                    {
                        king = p1;
                    }
                    else
                    {
                        king = p2;
                    }
                    for (int i = startPoint + 1; i < finishPoint; i++)
                    {
                        if (Board[i, p1.Position.Y] != null)
                        {
                            return false;
                        }
                    }
                    if (startPoint == 0)
                    {
                        startPoint = 2;
                        finishPoint = 4;
                    }
                    else
                    {
                        finishPoint--;
                    }
                    for (int i = startPoint; i <= finishPoint; i++)
                    {
                        if (!CheckNextBoard(king, new Position(i, p1.Position.Y)))
                        {
                            return false;
                        }
                    }


                    return true;
                }
            }

            return false;
        }

        public Boolean Castle(Pieces p1, Pieces p2)
        {
            if (CanCastle(p1, p2))
            {
                Pieces rook, king;
                if (p1.PieceType == Type.Rook)
                {
                    rook = p1;
                    king = p2;
                }
                else
                {
                    rook = p2;
                    king = p1;
                }
                if (rook.Position.X > king.Position.X)
                {
                    MovePiece(this.board, rook, 5, rook.Position.Y);
                    MovePiece(this.board, king, 6, king.Position.Y);
                }
                else
                {
                    MovePiece(this.board, rook, 3, rook.Position.Y);
                    MovePiece(this.board, king, 2, king.Position.Y);
                }
                return true;
            }
            return false;
        }

        public Pieces ExchangePawn()
        {
            for (int i = 0; i < 8; i++) //pentru white
            {
                if (this.board[i, 0] != null && this.board[i, 0].PieceType == Type.Pawn && this.board[i, 0].Side == Side.White)
                {
                    return this.board[i, 0];
                }
            }

            for (int i = 0; i < 8; i++) //pentru black
            {
                if (this.board[i, 7] != null && this.board[i, 7].PieceType == Type.Pawn && this.board[i, 7].Side == Side.Black)
                {
                    return this.board[i, 7];
                }
            }

            return null;
        }
        public Boolean CheckForCheck(Side s, Board board2)
        {
            List<Pieces> list;
            Position kingPos;

            if (s == Side.White)
            {
                list = board2.GetPieces(Side.Black);
                kingPos = board2.GetKingPosition(s);
            }
            else
            {
                list = board2.GetPieces(Side.White);
                kingPos = board2.GetKingPosition(s);
            }
            foreach (Pieces piece in list)
            {
                if (IsReachableKing(piece, board2, kingPos.X, kingPos.Y))
                {
                    return true;
                }
            }

            return false;
        }


        public Boolean IsReachable(Pieces piece, int x, int y)
        {
            List<Position> positions = GetPossibleMoves(piece);
            foreach (Position pos in positions)
            {
                if (pos == new Position(x, y)) //overload pe ==
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean IsReachableKing(Pieces piece, Board board2, int x, int y)
        {
            List<Position> positions = GetKingAttacks(piece, board2);
            foreach (Position pos in positions)
            {
                if (pos == new Position(x, y)) //overload pe ==
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean SearchEnPassant(Pawn pawn)
        {

            foreach (Tuple<Pawn, Pawn> tup in enPassant)
            {
                if (tup.Item2 == pawn) { return true; }
            }
            return false;
        }

        public void AddIfEnPassant(Pawn pawn)
        {
            Position pos = pawn.Position;
            if (pawn.enPassantCond)
            {
                if (pos.X < 7 && Board[pos.X + 1, pos.Y] != null && Board[pos.X + 1, pos.Y].PieceType == Type.Pawn && Board[pos.X + 1, pos.Y].Side != pawn.Side && CheckPositionEP(pawn, (Pawn)Board[pos.X + 1, pos.Y]))
                {
                    ((Pawn)Board[pos.X + 1, pos.Y]).enPassantCondDir[1] = true;
                    enPassant.Add(new Tuple<Pawn, Pawn>(pawn, (Pawn)Board[pos.X + 1, pos.Y]));
                }
                if (pos.X > 0 && Board[pos.X - 1, pos.Y] != null && Board[pos.X - 1, pos.Y].PieceType == Type.Pawn && Board[pos.X - 1, pos.Y].Side != pawn.Side && CheckPositionEP(pawn, (Pawn)Board[pos.X - 1, pos.Y]))
                {
                    ((Pawn)Board[pos.X - 1, pos.Y]).enPassantCondDir[0] = true;
                    enPassant.Add(new Tuple<Pawn, Pawn>(pawn, (Pawn)Board[pos.X - 1, pos.Y]));
                }
            }
        }

        public void MovePiece(Board board, Pieces piece, int posX, int posY)
        {
            if (piece.PieceType == Type.Pawn && MoveIsEnPassant(board, piece, posX, posY))
            {
                board[GetRemovePosEP(piece, posX, posY).X, GetRemovePosEP(piece, posX, posY).Y] = null;
            }

            board[piece.Position.X, piece.Position.Y] = null;
            piece.Position = new Position(posX, posY);
            board[posX, posY] = piece;
            piece.HasMoved = true;

            if (piece.PieceType == ChessModel.Type.Pawn)
            {
                ReviewEnPassant((Pawn)piece);
                AddIfEnPassant((Pawn)piece);
            }

        }

        public Boolean CheckPositionEP(Pawn p1, Pawn p2)
        {
            if (p1.Side == Side.White)
            {
                if (p1.Position.Y == p2.Position.Y && p1.Position.Y == 4)
                    return true;
            }
            if (p1.Side == Side.Black)
            {
                if (p1.Position.Y == p2.Position.Y && p1.Position.Y == 3)
                    return true;
            }


            return false;

        }

        public Boolean MoveIsEnPassant(Board board, Pieces piece, int posX, int posY)
        {
            if (posX != piece.Position.X && board[posX, posY] == null)
            {
                return true;
            }
            return false;
        }

        public Position GetRemovePosEP(Pieces piece, int x, int y) // x,y noile pozitii
        {
            if (piece.Side == Side.White)
            {
                return new Position(x, y + 1);
            }
            else
            {
                return new Position(x, y - 1);
            }
        }

        public void ReviewEnPassant(Pawn pawn)
        {
            List<Tuple<Pawn, Pawn>> removable = new List<Tuple<Pawn, Pawn>>();
            foreach (Tuple<Pawn, Pawn> tup in enPassant)
            {
                if (tup.Item1.enPassantCond == false)
                {
                    removable.Add(tup);
                }
                else if (tup.Item2.Position.Y != tup.Item1.Position.Y)
                {
                    removable.Add(tup);
                }
            }
            foreach (Tuple<Pawn, Pawn> tup in removable)
            {
                enPassant.Remove(tup);
            }

        }




    }
}