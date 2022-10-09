namespace ThirtyDaysOfShred.API.Entities.Lessons
{
    public class LessonTag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public Lesson Lesson { get; set; }
        public int LessonId { get; set; }
    }
}
