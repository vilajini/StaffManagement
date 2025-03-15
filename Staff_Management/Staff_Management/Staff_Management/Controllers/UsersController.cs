using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staff_Management.models;
using System.Data.SqlClient;

namespace Staff_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("registration")]
        public Response register(Users users)
        {
            Response response = new Response();
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SMCS").ToString());
            response= dal.register(users, connection);
            return response;
        }
        [HttpPost]
        [Route("login")]
        public Response login(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SMCS").ToString());
            Response response = dal.login(users, connection);
            return response;

        }
        [HttpPost]
        [Route("viewUser")]
        public Response viewUser(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SMCS").ToString());
            Response response = dal.viewUser(users, connection);
            return response;
        }
        [HttpPost]
        [Route("updateProfile")]
        public Response updateProfile(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SMCS").ToString());
            Response response = dal.updateProfile(users,connection);
            return response;

        }
    }

}
