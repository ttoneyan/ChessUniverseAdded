using System.ComponentModel;

namespace Chessuniverse.Library.Pieces;

public class Rook(PieceColor color) : Piece(color, PieceType.Rook), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? '♖' : '♜';
    }
    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
        if ((start.Letter == end.Letter) || (start.Number == end.Number))
        {
            int currentLetter = (int)start.Letter;
            int currentNumber = (int)start.Number;
            while (start.Letter != end.Letter || start.Number != end.Number)
            {
                if (start.Letter < end.Letter) currentLetter++;
                else if (start.Letter > end.Letter) currentLetter--;
                else if (start.Number < end.Number) currentNumber++;
                else if (start.Number > end.Number) currentNumber--;
                if (currentLetter == (int)end.Letter && currentNumber == (int)end.Number) break;
                if (board[currentNumber, currentLetter] != null)
                {
                    Console.WriteLine("Rook cant move, because there is another figure , which interupts it");
                    return false;
                }
            }
            if (board[(int)end.Number, (int)end.Letter] != null && board[(int)end.Number, (int)end.Letter].Color == this.Color)
            {
                Console.WriteLine("Cannot eat, beacuse there is a pice in the same color");
                return false;
            }
            board[(int)end.Number, (int)end.Letter] = this;
            board[(int)start.Number, (int)start.Letter] = null;
            return true;
        }

        Console.WriteLine("Rook can't move to that destination");
        return false;
    }
}

