using System.Xml.Linq;
using Academy.Core.Entities;
using Academy.Infrastructure.DbContext;
using Academy.Infrastructure.Utilities.Exceptions;

namespace Academy.Infrastructure.Services;

public class CourseService
{
    private static int indexCounter = 0;

    public void Create(string? name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException();
        }
        bool exists = false;
        for (int i = 0; i < indexCounter; i++)
        {
            if (AppDbContext.Courses[i].Name.ToUpper() == name.ToUpper())
            {
                exists = true; break;
            }
        }
        if (exists)
        {
            throw new DuplicateNameException("This Course name already exists");
        }
        Course newCourse = new(name);
        AppDbContext.Courses[indexCounter++] = newCourse;
    }

    public void GetAll()
    {
        for (int i = 0; i < indexCounter; i++)
        {
            Console.WriteLine(AppDbContext.Courses[i].Id + " - " + AppDbContext.Courses[i].Name);
        }
    }
}

