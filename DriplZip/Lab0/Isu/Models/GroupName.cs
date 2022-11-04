using Isu.Tools;

namespace Isu.Models;

public class GroupName
{
    private const int MinNumberOfGroupsPerStream = 0;
    private const int MaxNumberOfGroupsPerStream = 20;
    private const int MinGroupNameLenght = 5;
    private const int MaxGroupNameLenght = 6;
    private const int BachelorGroupLabel = 3;
    private const int MagistracyGroupLabel = 4;
    private const int FirstDirection = 1;
    private const int SecondDirection = 2;

    private string _groupName;

    public GroupName(string groupName)
    {
        if (groupName.Length is < MinGroupNameLenght or > MaxGroupNameLenght)
            throw new IsuException("Incorrect group name lenght");

        if (!char.IsLetter(groupName[0])) throw new IsuException("Incorrect group name symbol");

        if (int.Parse(groupName.Substring(1, 1)) is < BachelorGroupLabel or > MagistracyGroupLabel)
            throw new IsuException("Incorrect group stage");

        new CourseNumber(int.Parse(groupName.Substring(2, 1)));

        if (int.Parse(groupName.Substring(3, 2)) is < MinNumberOfGroupsPerStream or > MaxNumberOfGroupsPerStream)
            throw new IsuException("Group limit exceeded");

        if (int.Parse(groupName.Substring(5, 1)) is < FirstDirection or > SecondDirection)
            throw new IsuException("Incorrect group direction");

        _groupName = groupName;
        CourseNumber = new CourseNumber(groupName[2] - '0');
    }

    public CourseNumber CourseNumber { get; }
}