namespace ThirtyDaysOfShred.API.Entities.Users
{
    public class Goal
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public AppUser AppUser { get; set; } 
        public int AppUserId { get; set; }
    }
}
