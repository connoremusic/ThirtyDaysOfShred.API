namespace ThirtyDaysOfShred.API.Entities.Users
{
    public class ProfilePhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
