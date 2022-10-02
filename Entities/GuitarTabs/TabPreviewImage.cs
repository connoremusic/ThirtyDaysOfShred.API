namespace ThirtyDaysOfShred.API.Entities.GuitarTabs
{
    public class TabPreviewImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public GuitarTab GuitarTab { get; set; }
        public int GuitarTabId { get; set; }
    }
}
