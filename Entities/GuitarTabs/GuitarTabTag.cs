namespace ThirtyDaysOfShred.API.Entities.GuitarTabs
{
    public class GuitarTabTag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public GuitarTab GuitarTab { get; set; }
        public int GuitarTabId { get; set; }
    }
}