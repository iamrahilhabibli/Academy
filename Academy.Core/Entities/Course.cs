using Academy.Core.Interface;

namespace Academy.Core.Entities;

public class Course : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    private static int _count { get; set; }

    private Course()
    {
        Id = _count++;
    }
    public Course(string name) : this()
    {
        this.Name = name;
    }
}

