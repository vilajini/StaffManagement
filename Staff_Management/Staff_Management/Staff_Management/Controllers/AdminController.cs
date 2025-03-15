using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staff_Management.models;
using System.Data.SqlClient;

namespace Staff_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addUpdateDepartment")]
        public Response addUpdateDepartment(Departments departments)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SMCS").ToString());

            Response response = dal.addUpdateDepartment(departments, connection);
            return response;
        }

        [HttpPost]
        [Route("addUpdatePosition")]
        public Response addUpdatePosition(Positions positions)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SMCS").ToString());

            Response response = dal.addUpdatePosition(positions, connection);
            return response;
        }

        [HttpGet]
        [Route("userList")]
        public Response userList(Users users)
        {

            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SMCS").ToString());

            Response response= dal.userList(users, connection);
            return response;    
        }
    }
}
