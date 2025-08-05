using LibraryDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly string connectionString = "server=localhost;database=Database_project_library;user=root;password=dblibrarysql;";

        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get() {
            var members = new List<Member>();
            using (var connection = new MySqlConnection(connectionString))
            {

                connection.Open();
                var query =
                    "SELECT member_id, name, email, phone_number, street, city, state, zip  FROM Members";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(new Member
                        {
                            ID = reader.GetInt32("member_id"),
                            Name = reader.GetString("name"),
                            EmailAddress = reader.GetString("email"),
                            PhoneNumber = reader.GetString("phone_number"),
                            StreetAddress = reader.GetString("street"),
                            City = reader.GetString("city"),
                            State = reader.GetString("state"),
                            ZIP = reader.GetString("zip"),
                        });
                    }
                }
            }
            return Ok(members);
        }
    }
}
