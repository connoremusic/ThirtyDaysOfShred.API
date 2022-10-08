namespace ThirtyDaysOfShred.API.Entities.PracticeRoutines
{
    public class PracticeRoutineTag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public PracticeRoutine PracticeRoutine { get; set; }
        public int PracticeRoutineId { get; set; }
    }
}
