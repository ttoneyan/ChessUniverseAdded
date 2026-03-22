namespace Chessuniverse.Library.Pieces;

public class King(PieceColor color) : Piece(color, PieceType.King), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? '♔' : '♚';
    }
    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
        if ((Math.Abs(start.Letter - end.Letter) <= 1) && (Math.Abs(start.Number - end.Number) <= 1))
        {
            int difOfLetters = Math.Abs(end.Letter - start.Letter);
            int difOfNumbers = Math.Abs(end.Number - start.Number);

            if (difOfLetters > 1 || difOfNumbers > 1) return false;
            if (board[(int)end.Number, (int)end.Letter] != null && board[(int)end.Number, (int)end.Letter].Color == this.Color)
            return false;

            board[(int)end.Number, (int)end.Letter] = this;
            board[(int)start.Number, (int)start.Letter] = null;
            return true;
        }
        return false;
    }
}
