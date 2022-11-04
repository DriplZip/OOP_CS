using Isu.Models;
using Isu.Tools;

namespace Isu.Entities;

public class Student
{
    private string _surname;
    private string _name;

    public Student(string surname, string name, int isuNumber, GroupName groupName)
    {
        if (string.IsNullOrWhiteSpace(surname)) throw new IsuException("string surname is empty");
        _surname = surname;

        if (string.IsNullOrWhiteSpace(name)) throw new IsuException("string name is empty");
        _name = name;

        IsuNumber = isuNumber;
        GroupName = groupName;
    }

    public int IsuNumber { get; }

    public GroupName GroupName { get; set; }
}