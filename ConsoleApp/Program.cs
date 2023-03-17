using System.Data;
using Academy.Core.Entities;
using Academy.Infrastructure.Services;

CourseService courseService = new CourseService();
GroupService groupService = new GroupService();
Console.WriteLine("Welcome");
while (true)
{
    Console.WriteLine("Exit - 0 | Create Course - 1 | List Courses - 2 | Create Group - 3 | List Group - 4");
    string? response = Console.ReadLine();
    int menu;
    bool tryToInt = int.TryParse(response, out menu);
    if (tryToInt)
    {
        switch (menu)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                Console.WriteLine("Enter Course Name: ");
                string? res_coursename = Console.ReadLine();
                try
                {
                    courseService.Create(res_coursename);
                    Console.WriteLine($"New course: {res_coursename}");
                }
                catch (DuplicateNameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case 2:
                Console.WriteLine("Course List");
                courseService.GetAll();
                break;
            case 3:
                Console.WriteLine("Enter Group Name: ");
                string? groupName = Console.ReadLine();
            max_count:
                Console.WriteLine("Enter Max Count: ");
                string? maxCount = Console.ReadLine();
                int max_count;
                bool tryToIntMax = int.TryParse(maxCount, out max_count);
                if (!tryToIntMax)
                {
                    Console.WriteLine("Enter correct format");
                    goto max_count;
                }
            group_type:
                Console.WriteLine("Enter Group type (number): ");
                foreach (var groupType in Enum.GetValues(typeof(GroupType)))
                {
                    Console.WriteLine((int)groupType + "-" + groupType);
                }
                string? grouptype = Console.ReadLine();
                int type_count;
                bool tryToIntType = int.TryParse(grouptype, out type_count);
                if (!tryToIntType)
                {
                    Console.WriteLine("Enter correct format");
                    goto group_type;
                }

            select_course:
                Console.WriteLine("Enter Course Id: ");
                courseService.GetAll();
                string? select_course = Console.ReadLine();
                int courseId;
                bool tryIdCourse = int.TryParse(select_course, out courseId);
                if (!tryIdCourse)
                {
                    Console.WriteLine("Enter correct ID");
                    goto select_course;
                }
                try
                {
                    groupService.Create(groupName, max_count, courseId, type_count);
                    Console.WriteLine("Created Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto case 3;
                }
                break;
            case 4:
                Console.WriteLine("Group list: ");
                groupService.GetAll();
                break;
            default:
                Console.WriteLine("Select correct option");
                break;
        }
    }
    else
    {
        Console.WriteLine("Enter valid menu option");
    }
}