namespace Chessuniverse.Library.Pieces;

public class Bishop(PieceColor color) : Piece(color, PieceType.Bishop), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? '♗' : '♝';
    }
        public bool Move(Coordinate start, Coordinate end, ChessBoard board)
        {
            int sCol = (int)start.Letter;
            int sRow = (int)start.Number;
            int eCol = (int)end.Letter;
            int eRow = (int)end.Number;

            // 1. Diagonal Check: Absolute difference of rows must equal absolute difference of columns
            if (Math.Abs(sCol - eCol) != Math.Abs(sRow - eRow)) return false;

            // 2. Prevent moving to the same square
            if (sCol == eCol && sRow == eRow) return false;

            // 3. Directions
            int stepCol = eCol > sCol ? 1 : -1;
            int stepRow = eRow > sRow ? 1 : -1;

            // 4. Path Check: Start checking from the square AFTER the start
            int currCol = sCol + stepCol;
            int currRow = sRow + stepRow;

            while (currCol != eCol)
            {
                if (board[currRow, currCol] != null) return false; // Blocked

                currCol += stepCol;
                currRow += stepRow;
            }

            // 5. Destination Check: Cannot take your own piece
            var target = board[eRow, eCol];
            if (target != null && target.Color == this.Color) return false;

            return true;
        }
}
        
