using ThirtyDaysOfShred.API.Entities.GuitarTabs;

namespace ThirtyDaysOfShred.API.DTOs
{
    public class GuitarTabDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SkillLevel { get; set; }
        public string Author { get; set; }
        public bool IsPublic { get; set; }
        public ICollection<GuitarTabTagDto> Tags { get; set; }
        public string FileLocationUrl { get; set; }
        public string PreviewImageUrl { get; set; }
        public int NumberOfFavorites { get; set; }
    }
}
