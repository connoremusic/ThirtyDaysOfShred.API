using ThirtyDaysOfShred.API.Entities.Lessons;
using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Entities.GuitarTabs
{
    public class PracticeRoutineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SkillLevel { get; set; }
        public string Author { get; set; }
        public bool IsPublic { get; set; }
        public ICollection<GuitarTab> Tabs { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastPracticed { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }

    }
}
