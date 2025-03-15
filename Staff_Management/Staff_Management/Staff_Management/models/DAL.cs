using System.Data;
using System.Data.SqlClient;




namespace Staff_Management.models
{
    public class DAL
    {
        public Response register(Users users,SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_register",connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", Users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", Users.LastName);
            cmd.Parameters.AddWithValue("@Email", Users.Email);
            cmd.Parameters.AddWithValue("@password", Users.password);
          

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.StatusCode=200;
                response.StatusMessage = "User Registered successfully.";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User Registration failed.";
            }

            
            return response;
        }

        public Response login(Users users,SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_login" , connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", Users.Email);
            da.SelectCommand.Parameters.AddWithValue("@password", Users.password);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"])
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"])
                user.Email = Convert.ToString(dt.Rows[0]["Email"])
                user.Type = Convert.ToString(dt.Rows[0]["Type"])
                response.StatusCode = 200;
                response.StatusMessage = "User is valid.";
                response.user= user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User is invalid.";
                response.user = null;

            }
            return response;

        }

        public Response viewUser(Users users,SqlConnection connection)
        {
            SqlDataAdapter da= new SqlDataAdapter("sp_viewUser" , connection);
            da.SelectCommand.CommandType= CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@EmployeeID", Users.EmployeeID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"])
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"])
                user.Email = Convert.ToString(dt.Rows[0]["Email"])
                user.Type = Convert.ToString(dt.Rows[0]["Type"])
                user.Phone = v
                int v = Convert.ToInt32(dt.Rows[0]["Phone"]);
                user.Gender = Convert.ToString(dt.Rows[0]["Gender"])
                user.Address = Convert.ToString(dt.Rows[0]["Address"])
                user.DepartmentID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                user.PositionID = Convert.ToInt32(dt.Rows[0]["PositionID"]);
                user.password = Convert.ToString(dt.Rows[0]["password"])
                user.EmploymentStartDate = Convert.ToDateTime](dt.Rows[0]["EmploymentStartDate"])
                user.EmploymentEndDate = Convert.ToDateTime](dt.Rows[0]["EmploymentEndDate"])
                response.StatusCode = 200;
                response.StatusMessage = "User exists.";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User does not exist.";
                response.user = user;
            }
            return response;

        }

        public Response updateProfile(Users users,SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_updateProfile", connection);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@password", users.password);
            cmd.Parameters.AddWithValue("@Phone", users.Phone);
            connection.Open();
            int i = cmd.EndExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Record updated successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Some error occured. try after sometime";
            }
            return response;
        }

        public Response addToPayroll(Payroll payroll, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_addToPayroll", connection);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PayrollID", payroll.PayrollID);
            cmd.Parameters.AddWithValue("@EmployeeID", payroll.EmployeeID);
            cmd.Parameters.AddWithValue("@PayPeriodStartDate", payroll.PayPeriodStartDate);
            cmd.Parameters.AddWithValue("@PayPeriodEndDate", payroll.PayPeriodEndDate);
            cmd.Parameters.AddWithValue("@BaseSalary", payroll.BaseSalary);
            cmd.Parameters.AddWithValue("@Bonus", payroll.Bonus);
            cmd.Parameters.AddWithValue("@Deductions", payroll.Deductions);
            cmd.Parameters.AddWithValue("@NetSalary", payroll.NetSalary);
            connection.Open();  
            int i=cmd.ExecuteNonQuery();   
            connection.Close(); 
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Salary added successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Salary could not be added";
            }
            return response;

        }

        public Response listPayroll(Users users, SqlConnection connection)
        {
            Response response = new Response();
            List<Payroll> listPayroll = new List<Payroll>();
            SqlDataAdapter da = new SqlDataAdapter("sp_viewPayroll", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            da.SelectCommand.Parameters.AddWithValue("@EmployeeID", users.EmployeeID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    Payroll payroll = new Payroll();
                    payroll.EmployeeID = Convert.ToInt32(dt.Rows[i]["EmployeeID"]);
                    payroll.PayPeriodStartDate = Convert.ToDateTime(dt.Rows[i]["PayPeriodStartDate"]);
                    payroll.PayPeriodEndDate = Convert.ToDateTime(dt.Rows[i]["PayPeriodEndDate"]);
                    payroll.BaseSalary = Convert.ToDecimal (dt.Rows[i]["BaseSalary"]);
                    payroll.Bonus = Convert.ToDecimal (dt.Rows[i]["Bonus"]);
                    payroll.Deductions = Convert.ToDecimal (dt.Rows[i]["Deductions"]);
                    payroll.NetSalary = Convert.ToDecimal (dt.Rows[i]["NetSalary"]);
                    listPayroll.Add(payroll);
                }
                if(listPayroll.Count > 0)
                { 
                    response.StatusCode = 200;
                    response.StatusMessage = "Payroll details fetched";
                    response.listPayroll = listPayroll;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Payroll details are not available";
                    response.listPayroll = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Payroll details are not available";
                response.listPayroll = null;
            }
            return response;
        }

        public Response addUpdateDepartment(Departments departments, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_addUpdateDepartment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentName", departments.DepartmentName);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i> 0)
            {
                response.StatusCode= 200;
                response.StatusMessage = "Department inserted successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Department did not save. try again.";
            }
            return response;
        }

        public Response addUpdatePosition(Positions positions, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_addUpdatePostion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PositionName", positions.PositionName);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Position inserted successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Position did not save. try again.";
            }
            return response;
        }

        public Response userList(Users users, SqlConnection connection)
        {
            Response response = new Response();
            List<Users> listUsers = new List<Users>();
            SqlDataAdapter da = new SqlDataAdapter("sp_userList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users users = new Users();
                    users.EmployeeID = Convert.ToInt32(dt.Rows[i]["EmployeeID"]);
                    users.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    users.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    users.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
                    users.Phone = Convert.ToInt32(dt.Rows[i]["Phone"]);
                    users.Gender = Convert.ToString(dt.Rows[i]["Gender"]);
                    users.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    users.Address = Convert.ToString(dt.Rows[i]["Address"]);
                    users.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
                    users.PositionID = Convert.ToInt32(dt.Rows[i]["PositionID"]);
                    users.password = Convert.ToString(dt.Rows[i]["password"]);
                    users.Type = Convert.ToString(dt.Rows[i]["Type"]);
                    users.EmploymentStartDate = Convert.ToDateTime(dt.Rows[i]["EmploymentStartDate"]);
                    users.EmploymentEndDate = Convert.ToDateTime(dt.Rows[i]["EmploymentEndDate"]);
                    listUsers.Add(users);
                }
                if (listUsers.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "User details fetched";
                    response.listUsers = listUsers;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User details are not available";
                    response.listUsers = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User details are not available";
                response.listUsers = null;
            }
            return response;
        }

    }
}
