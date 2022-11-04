using Isu.Tools;

namespace Isu.Models;

public class CourseNumber
{
    private const int MinCourseNumber = 1;
    private const int MaxCourseNumber = 4;

    private int _courseNumber;

    public CourseNumber(int courseNumber)
    {
        if (courseNumber is < MinCourseNumber or > MaxCourseNumber)
        {
            throw new IsuException("Wrong courseNumber");
        }

        _courseNumber = courseNumber;
    }
}