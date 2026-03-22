namespace Chessuniverse.Library;

public struct Coordinate
{
    public Letters Letter;
    public Numbers Number;
    public Coordinate(Letters letter, Numbers number)
    {
        Letter = letter;
        Number = number;
    }
}
