namespace Staff_Management.models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int EmployeeID { get; set; }
        public DateOnly  a_Date { get; set; }
        public TimeOnly  ClockInTime { get; set; }
        public TimeOnly ClockOutTime { get; set; }
    }
}
