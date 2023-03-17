using Academy.Core.Entities;
using Academy.Infrastructure.DbContext;
using Academy.Infrastructure.Utilities.Exceptions;
using System.Xml.Linq;

namespace Academy.Infrastructure.Services;

public class GroupService
{
    private static int indexCounter = 0;

    public void Create(string? groupname, int maxCount, int courseid, int type)
    {
        if (string.IsNullOrEmpty(groupname))
        {
            throw new ArgumentNullException();
        }
        bool exists = false;
        for (int i = 0; i < indexCounter; i++)
        {
            if (AppDbContext.Groups[i].GroupName.ToUpper() == groupname.ToUpper())
            {
                exists = true; break;
            }
        }
        if (exists)
        {
            throw new DuplicateNameException("This Group name already exists");
        }
        GroupType groupType;
        if (Enum.IsDefined(typeof(GroupType), type))   // Lecture 3 11:20
        {
            groupType = (GroupType)type;
        }
        else
        {
            throw new NotExistException("Select correct group type");
        }
        Group newGroup = new Group(groupname, maxCount, courseid, groupType);
        AppDbContext.Groups[indexCounter++] = newGroup;
    }

    public void GetAll()
    {
        for (int i = 0; i < indexCounter; i++)
        {
            string temp_course = string.Empty;
            foreach (var course in AppDbContext.Courses)
            {
                if (course is null)
                {
                    break;
                }
                if (AppDbContext.Groups[i].CourseId == course.Id)
                {
                    temp_course = course.Name;
                    break;
                }
            }
            Console.WriteLine($"ID: {AppDbContext.Groups[i].Id} - " +
                $"GROUP: {AppDbContext.Groups[i].GroupName} " +
                $"TYPE: {AppDbContext.Groups[i].Type} " +
                $"MAXCOUNT: {AppDbContext.Groups[i].MaxCount} " +
                $"BELONGS TO: {temp_course} ");
        }
    }
}

