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
        private readonly MySqlConnection _connection;

        public MembersController(MySqlConnection connection)
        {
            this._connection = connection;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get() {
            var members = new List<Member>();
            using (var connection = _connection)
            {

                connection.Open();
                var query =
                    "SELECT member_id, name, email, phone_number, street, city, state, zip FROM Members";
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

        [HttpGet("MemberLibraryCard")]
        public ActionResult<IEnumerable<Member>> GetMemberLibraryCard() {
            var members = new List<Member>();
            using (var connection = _connection)
            {

                connection.Open();
                var query =
                    "SELECT Members.member_id, Members.name, Members.email, Members.phone_number, Members.street, Members.city, Members.state, Members.zip, Library_cards.library_card_id FROM Members INNER JOIN Library_cards ON Members.member_id = Library_cards.member_id";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(new Member
                        {
                            ID = reader.GetInt32("member_id"),
                            LibraryCard = reader.GetInt32("library_card_id"),
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
