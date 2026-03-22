using System.Reflection.Metadata.Ecma335;

namespace Chessuniverse.Library.Pieces;

public class Pawn(PieceColor color) : Piece(color, PieceType.Pawn), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? '♙' : '♟';
    }
    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
        if (color == PieceColor.White)
        {
            if (start.Number < end.Number)
            {
                Console.WriteLine("Pawn can go only forward");
                return false;
            }
            if (start.Letter == end.Letter)
            {
                if ((int)start.Number == 6)
                {
                    //1 step
                    if ((start.Number - end.Number) == 1)
                    {
                        if (board[(int)end.Number, (int)end.Letter] != null)
                        {
                            Console.WriteLine("Pawn cant eat forwardly");
                            return false;
                        }
                    }
                    //2 step
                    else if (start.Number - end.Number == 2)
                    {
                        if (board[(int)(start.Number - 1), (int)start.Letter] != null || board[(int)end.Number, (int)end.Letter] != null)
                        {
                            Console.WriteLine("is occupied");
                            return false;
                        }
                    }
                    else return false;
                }
                else
                {
                    if ((start.Number - end.Number) != 1)
                    {
                        Console.WriteLine("Pawn can't go");
                        return false;
                    }
                    if (board[(int)end.Number, (int)end.Letter] != null)
                    {
                        Console.WriteLine("The place is occupied by another piece");
                        return false;
                    }
                }
                board[(int)end.Number, (int)end.Letter] = this;
                board[(int)start.Number, (int)start.Letter] = null;
                return true;
            }
            //diagonal
            else if (Math.Abs(start.Letter - end.Letter) == 1 && (start.Number - end.Number) == 1)
            {
                if (board[(int)end.Number, (int)end.Letter] == null ||
            board[(int)end.Number, (int)end.Letter].Color == this.Color)
                {
                    Console.WriteLine("There isn't figure, that can be eaten or the  figure has the same color");
                    return false;
                }
                else
                {
                    board[(int)end.Number, (int)end.Letter] = this;
                    board[(int)start.Number, (int)start.Letter] = null;
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Invalid pawn move");
                return false;
            }
        }
        //return false;

        else if (color == PieceColor.Black)
        {
            if (start.Number > end.Number)
            {
                Console.WriteLine("Pawn can go only forward");
                return false;
            }
            if (start.Letter == end.Letter)
            {
                if ((int)start.Number == 1)
                {
                    //1 step
                    if ((start.Number - end.Number) == -1)
                    {
                        if (board[(int)end.Number, (int)end.Letter] != null)
                        {
                            Console.WriteLine("Pawn cant eat forwardly");
                            return false;
                        }
                    }
                    //2 step
                    else if (start.Number - end.Number == -2)
                    {
                        if (board[(int)(start.Number + 1), (int)start.Letter] != null || board[(int)end.Number, (int)end.Letter] != null)
                        {
                            Console.WriteLine("is occupied");
                            return false;
                        }
                    }
                    else return false;
                }
                else
                {
                    if ((start.Number - end.Number) != -1)
                    {
                        Console.WriteLine("Pawn can't go");
                        return false;
                    }
                    if (board[(int)end.Number, (int)end.Letter] != null)
                    {
                        Console.WriteLine("The place is occupied by another piece");
                        return false;
                    }
                }
                board[(int)end.Number, (int)end.Letter] = this;
                board[(int)start.Number, (int)start.Letter] = null;
                return true;
            }
            //diagonal
            else if (Math.Abs(start.Letter - end.Letter) == 1 && (start.Number - end.Number) == -1)
            {
                if (board[(int)end.Number, (int)end.Letter] == null ||
            board[(int)end.Number, (int)end.Letter].Color == this.Color)
                {
                    Console.WriteLine("There isn't figure, that can be eaten or the  figure has the same color");
                    return false;
                }
                else
                {
                    board[(int)end.Number, (int)end.Letter] = this;
                    board[(int)start.Number, (int)start.Letter] = null;
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Invalid pawn move");
                return false;
            }
        }
        return false;
    }
}