using ThirtyDaysOfShred.API.Entities.Users;

namespace ThirtyDaysOfShred.API.DTOs
{
    public class MemberUpdateDto
    {
        public string About { get; set; }
        public string Influences { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public string Country { get; set; }
    }
}
