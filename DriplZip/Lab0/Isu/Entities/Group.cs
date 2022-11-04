using Isu.Models;
using Isu.Tools;

namespace Isu.Entities;

public class Group
{
    private const int MaxGroupSize = 26;
    private List<Student> _students;

    public Group(GroupName groupName)
    {
        _students = new List<Student>();
        GroupName = groupName;
    }

    public GroupName GroupName { get; }

    public IReadOnlyCollection<Student> Students => _students.AsReadOnly();

    public void AddStudentToGroup(Student student)
    {
        if (_students.Count == MaxGroupSize) throw new IsuException("Group has a maximum size");

        if (_students.FirstOrDefault(selectedStudent => selectedStudent.Equals(student)) != null) throw new IsuException("Student already in group");

        _students.Add(student);
    }

    public bool RemoveStudentFromGroup(Student student)
    {
        if (_students.FirstOrDefault(currentStudent => currentStudent.IsuNumber == student.IsuNumber) is null)
            throw new IsuException("Student doesn't exist");

        return _students.Remove(student);
    }
}