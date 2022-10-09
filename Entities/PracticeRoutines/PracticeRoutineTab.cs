using ThirtyDaysOfShred.API.Entities.GuitarTabs;

namespace ThirtyDaysOfShred.API.Entities.PracticeRoutines
{
    public class PracticeRoutineTab
    {
        public PracticeRoutine PracticeRoutine { get; set; }
        public int PracticeRoutineId { get; set; }
        public GuitarTab GuitarTab { get; set; }
        public int GuitarTabId { get; set; }
    }
}
