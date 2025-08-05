using LibraryDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace LibraryDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly string connectionString = "server=localhost;database=Database_project_library;user=root;password=dblibrarysql;";

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var employees = new List<Employee>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query =
                    "SELECT employee_id, name, email, phone_number, street, city, state, zip FROM Employees";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            employee_id = reader.GetInt32("employee_id"),
                            name = reader.GetString("name"),
                            email = reader.GetString("email"),
                            phone_number = reader.GetString("phone_number"),
                            street = reader.GetString("street"),
                            city = reader.GetString("city"),
                            state = reader.GetString("state"),
                            zip = reader.GetString("zip")
                        });
                    }
                }
            }
            return Ok(employees);
        }

 

    }
}