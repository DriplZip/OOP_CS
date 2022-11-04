namespace Isu.Models;

public class IsuNumber
{
    private const int FirstIsuNumber = 100000;
    private int _isuNumber = FirstIsuNumber;

    public int GenerateId()
    {
        return _isuNumber++;
    }
}