using LibraryDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace LibraryDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly MySqlConnection _connection;

        public CheckoutController(MySqlConnection connection)
        {
            this._connection = connection;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var checkOuts = new List<checkOuts>();
            using (var connection = _connection)
            {
                connection.Open();
                var query = "SELECT check_outs.check_outs_id, " +
            "check_outs.check_out_date, " +
            "employees.name AS employee_name, " +
            "members.name AS member_name " +  
            "FROM check_outs " +
            "JOIN employees ON check_outs.employee_id = employees.employee_id " +  
            "JOIN members ON check_outs.member_id = members.member_id;";
                using (var command = new MySqlCommand(query, connection)) 
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        checkOuts.Add(new checkOuts
                        {
                            check_out_id = reader.GetInt32("check_outs_id"),
                            employee_name = reader.GetString("employee_name"),
                            member_name = reader.GetString("member_name"),
                            check_out_date = reader.GetDateTime("check_out_date"),
                        });
                    }
                }
            }
            return Ok(checkOuts);
        }



    }
}