using System.Linq;
using Isu.Entities;
using Isu.Models;
using Isu.Tools;

namespace Isu.Services;

public class IsuService : IIsuService
{
    private List<Group> _groups = new List<Group>();
    private IsuNumber _isuNumber = new IsuNumber();

    public Group AddGroup(GroupName name)
    {
        if (FindExistingGroup(name)) throw new IsuException("Group already exist");

        Group group = new Group(name);
        _groups.Add(group);

        return group;
    }

    public Student AddStudent(Group group, string name, string surname)
    {
        if (!FindExistingGroup(group.GroupName)) throw new IsuException("Group doesn't exist");

        Student student = new Student(surname, name, _isuNumber.GenerateId(), group.GroupName);

        _groups.First(groups => groups.GroupName == group.GroupName).AddStudentToGroup(student);
        return student;
    }

    public Student GetStudent(int id)
    {
        Student? student = FindStudent(id);
        if (student == null) throw new IsuException("Student with this id does not exist");

        return student;
    }

    public Student? FindStudent(int id)
    {
        return _groups.SelectMany(groups => groups.Students).FirstOrDefault(students => students.IsuNumber.Equals(id));
    }

    public List<Student> FindStudents(GroupName groupName)
    {
        Group? group = FindGroup(groupName);

        return group?.Students.ToList() ?? new List<Student>();
    }

    public List<Student> FindStudents(CourseNumber courseNumber)
    {
        List<Group> groups = FindGroups(courseNumber);
        List<Student> students = new List<Student>();

        groups.ForEach(group => students.AddRange(group.Students));

        return students;
    }

    public Group? FindGroup(GroupName groupName)
    {
        return _groups.FirstOrDefault(groups => groups.GroupName == groupName);
    }

    public List<Group> FindGroups(CourseNumber courseNumber)
    {
        return _groups.FindAll(groups => groups.GroupName.CourseNumber == courseNumber);
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        if (FindStudent(student.IsuNumber) is null) throw new IsuException("This student does not exist");
        if (FindGroup(newGroup.GroupName) is null) throw new IsuException("New group does not exist");

        GroupName pastStudentGroupName = student.GroupName;
        student.GroupName = newGroup.GroupName;

        _groups.First(group => group.GroupName == newGroup.GroupName).AddStudentToGroup(student);

        _groups.First(group => group.GroupName == pastStudentGroupName).RemoveStudentFromGroup(student);
    }

    private bool FindExistingGroup(GroupName name)
    {
        return _groups.Any(groups => groups.GroupName == name);
    }
}