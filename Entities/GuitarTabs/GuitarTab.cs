using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.Entities.GuitarTabs
{
    public class GuitarTab
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SkillLevel { get; set; }
        public string Author { get; set; }
        public bool IsPublic { get; set; }
        public ICollection<GuitarTabTag> Tags { get; set; }
        public string FileLocationUrl { get; set; }
        public TabPreviewImage PreviewImage { get; set; }
        public ICollection<GuitarTabFavorite> FavoritedByUser { get; set; }
        public int NumberOfFavorites { get; set; }
    }
}
