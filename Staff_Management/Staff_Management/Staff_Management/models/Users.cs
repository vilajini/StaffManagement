namespace Staff_Management.models
{
    public class Users
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; 
        public int DepartmentID { get; set; }
        public int PositionID { get; set; }
        public DateOnly EmploymentStartDate { get; set; }
        public DateOnly EmploymentEndDate { get; set; }
        public string password { get; set; }
        public string Type { get; set; }

    }
}
