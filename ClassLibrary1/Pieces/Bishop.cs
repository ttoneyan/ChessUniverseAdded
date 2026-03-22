namespace Chessuniverse.Library.Pieces;

public class Bishop(PieceColor color) : Piece(color, PieceType.Bishop), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? '♗' : '♝';
    }
    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
        //Basic Bishop Logic
        if (Math.Abs(start.Letter - end.Letter) != Math.Abs(start.Number - end.Number)) return false;
        //Determine Direction (1 or -1)
        int stepOfLetter = end.Letter > start.Letter ? 1 : -1;
        int stepOfNumber = end.Number > start.Number ? 1 : -1;
        // Check for interrupting figures
        int currentLetter = (int)start.Letter + stepOfLetter;
        int currentNumber = (int)start.Number + stepOfNumber;
        //until we reach the square just before the 'end' coordinate
        while (currentLetter != (int)end.Letter && currentNumber != (int)end.Number)
        {
            if (board[currentNumber,currentLetter] != null)
            {
                return false; // Path is blocked
            }
            currentLetter += stepOfLetter;
            currentNumber += stepOfNumber;
        }
        //Check the end square
        if (board[(int)end.Number,(int)end.Letter] != null && board[(int)end.Number, (int)end.Letter].Color == this.Color)
        {
            return false; // Cannot capture your own piece
        }
        //Update the board and Move the figure
        board[(int)end.Number,(int)end.Letter] = this;
        board[(int)start.Number,(int)start.Letter] = null;
   
        return true;
    }
}
        
