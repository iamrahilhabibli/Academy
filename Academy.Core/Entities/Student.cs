using Academy.Core.Interface;

namespace Academy.Core.Entities;

public class Student : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    private static int _count { get; set; }

    private Student()
    {
        Id = _count++;
    }

    public Student(string name, string surname) : this()
    {
        Name = name;
        Surname = surname;
    }
}

