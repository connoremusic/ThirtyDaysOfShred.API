using ThirtyDaysOfShred.API.Entities.GuitarTabs;

namespace ThirtyDaysOfShred.API.DTOs
{
    public class FavoritedTabDto
    {
        public int Id { get; set; }
        public GuitarTab GuitarTab { get; set; }
    }
}