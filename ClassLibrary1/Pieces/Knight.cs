namespace Chessuniverse.Library.Pieces;

public class Knight(PieceColor color) : Piece(color, PieceType.Knight), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? '♘' : '♞';
    }
    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
        if (((Math.Abs(start.Letter - end.Letter) == 1) && (Math.Abs(start.Number - end.Number) == 2)) ||
            ((Math.Abs(start.Letter - end.Letter) == 2) && (Math.Abs(start.Number - end.Number) == 1)))
        {
            if (board[(int)end.Number, (int)end.Letter] != null && board[(int)end.Number, (int)end.Letter].Color == this.Color)
            {
                return false;
            }
            else {
                board[(int)end.Number, (int)end.Letter] = this;
                board[(int)start.Number, (int)start.Letter] = null;
                return true;
            }
        }
        return false;
    }
}
