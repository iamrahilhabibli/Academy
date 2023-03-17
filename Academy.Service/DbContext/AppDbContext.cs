using Academy.Core.Entities;

namespace Academy.Infrastructure.DbContext;

public static class AppDbContext
{
    public static Student[] Students { get; set; } = new Student[1600];
    public static Group[] Groups { get; set; } = new Group[100];
    public static Course[] Courses { get; set; } = new Course[100];
}

