using Isu.Entities;
using Isu.Models;
using Isu.Services;
using Xunit;

namespace Isu.Test;

public class IsuServiceTest
{
    private IsuService _isuService = new IsuService();

    [Fact]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        Group group = _isuService.AddGroup(new GroupName("M32061"));
        Student student = _isuService.AddStudent(group, "Artem", "Shevnin");
        Assert.Contains(student, group.Students);
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        Assert.ThrowsAny<Exception>(() =>
        {
            Group group = _isuService.AddGroup(new GroupName("M32061"));
            for (int i = 0; i < 27; i++)
            {
                _isuService.AddStudent(group, "Artem", "Shevnin");
            }
        });
    }

    [Fact]
    public void CreateGroupWithInvalidName_ThrowException()
    {
        Assert.ThrowsAny<Exception>(() => new Group(new GroupName("V702550")));
    }

    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        Group initialGroup = _isuService.AddGroup(new GroupName("M32061"));
        Group translationGroup = _isuService.AddGroup(new GroupName("M32071"));

        Student student = _isuService.AddStudent(initialGroup, "Artem", "Shevnin");

        _isuService.ChangeStudentGroup(student, translationGroup);

        Assert.Contains(student, translationGroup.Students);
    }
}