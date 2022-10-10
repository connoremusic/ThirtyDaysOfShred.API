namespace ThirtyDaysOfShred.API.Helpers
{
    public class GuitarTabParams : PaginationParams
    {
        public string SearchString { get; set; } = null;
        public int MinSkillLevel { get; set; } = 1;
        public int MaxSkillLevel { get; set; } = 5;
        public string OrderBy { get; set; } = "created";
    }
}
