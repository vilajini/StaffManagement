using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staff_Management.models;
using System.Data.SqlClient;

namespace Staff_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PayrollController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("addToPayroll")]
        public Response addToPayroll(Payroll payroll)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SMCS").ToString());
            Response response = dal.addToPayroll(payroll, connection);
            return response;
        }
        [HttpPost]
        [Route("listPayroll")]
        public Response listPayroll(Users users) 
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SMCS").ToString());
            Response response = dal.listPayroll(payroll, connection);
            return response;
        }
    }
}
