namespace Staff_Management.models
{
    public class EmployeeSchedules
    {
        public int ScheduleID { get; set; }
        public int EmployeeID { get; set; }
        public DateOnly ScheduleDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
