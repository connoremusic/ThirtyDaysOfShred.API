using ThirtyDaysOfShred.API.Entities.GuitarTabs;

namespace ThirtyDaysOfShred.API.DTOs
{
    public class AuthoredTabsDto
    {
        public int Id { get; set; }
        public ICollection<GuitarTab> Tabs { get; set; }
    }
}