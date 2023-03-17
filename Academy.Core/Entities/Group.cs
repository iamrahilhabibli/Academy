using Academy.Core.Interface;

namespace Academy.Core.Entities;

public class Group : IEntity
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string GroupName { get; set; }
    public GroupType Type { get; set; }
    public int MaxCount { get; }
    private static int _count { get; set; }

    private Group()
    {
        Id = _count++;
    }
    public Group(string groupName, int maxCount, int courseId, GroupType type) : this()
    {
        this.GroupName = groupName;
        this.MaxCount = maxCount;
        Type = type;
        this.CourseId = courseId;
    }

}

public enum GroupType { Programming = 1, Design, Marketing };

