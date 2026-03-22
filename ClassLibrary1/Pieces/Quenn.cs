using System.Collections;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chessuniverse.Library.Pieces;

public class Queen(PieceColor color) : Piece(color, PieceType.Queen), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? '♕' : '♛';
    }
    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
        if (((start.Letter == end.Letter) || (start.Number == end.Number)) ||
            (Math.Abs(start.Letter - end.Letter) == Math.Abs(start.Number - end.Number)))
        {
            int stepOfLetter = 0;
            int stepOfNumber = 0;
            if(end.Letter>start.Letter) stepOfLetter = 1; 
            else if(end.Letter<start.Letter) stepOfLetter = -1;

            if(end.Number>start.Number) stepOfNumber = 1; 
            else if(end.Number<start.Number) stepOfNumber = -1;

            int currentLetter= (int)start.Letter + stepOfLetter;
            int currentNumber= (int)start.Number + stepOfNumber;

            while(currentLetter != (int)end.Letter || currentNumber != (int)end.Number)
            {
                if (board[currentNumber, currentLetter] != null)
                {
                    Console.WriteLine("Queen cant move, because there is another figure , which interupts it");
                    return false;
                }
                currentLetter += stepOfLetter;
                currentNumber += stepOfNumber;
            }
            if(board[(int)end.Number, (int)end.Letter] != null && board[(int)end.Number, (int)end.Letter].Color == this.Color)
            {
                Console.WriteLine("Cannot eat, beacuse there is a pice in the same color");
                return false;
            }
            board[(int)end.Number, (int)end.Letter] = this;
            board[(int)start.Number, (int)start.Letter] = null;
            return true;
    }
        Console.WriteLine("Invalid Queen move");
        return false;
    }
}