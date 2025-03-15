namespace Staff_Management.models
{
    public class Response
    {
        public int StatusCode {  get; set; }
        public string StatusMessage { get; set; }
        public List<Users> listUsers { get; set; }
        public Users user { get; set; }
        public List<Departments> listDepartments { get; set; }
        public Departments department { get; set; }
        public List<Positions> listPositions { get; set; }
        public Positions position { get; set; }
        public List<Attendance> listAttendance { get; set; }
        public List<Leaves> listLeaves { get; set; }
        public Leaves leave { get; set; }
        public List<EmployeeSchedules> listEmployeeSchedulesLeaves { get; set; }
        public EmployeeSchedules employeeSchedule { get; set; }
        public List<Payroll> listPayroll { get; set; }



    }
}
