using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Entities.GuitarTabs
{
    public enum AppUserType { Author, Liker, Favoriter }
    public class GuitarTab
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SkillLevel { get; set; }
        public string Author { get; set; }
        public bool IsPublic { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string FileLocationUrl { get; set; }
        public string PreviewImageUrl { get; set; }
        public int NumberOfFavorites { get; set; }
        public int NumberOfLikes { get; set; }
    }
}
