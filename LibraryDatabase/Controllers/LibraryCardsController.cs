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
    public class LibraryCardsController : ControllerBase
    {
        private readonly string connectionString = "server=localhost;database=Database_project_library;user=root;password=dblibrarysql;";

        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get()
        {
            var librarycards = new List<LibraryCard>();
            using (var connection = new MySqlConnection(connectionString))
            {

                connection.Open();
                var query =
                    "SELECT library_card_id, member_id, creation_date, expiration_date, fees FROM Library_cards";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        librarycards.Add(new LibraryCard
                        {
                            LibraryCardID = reader.GetInt32("library_card_id"),
                            MemberID = reader.GetInt32("member_id"),
                            CreationDate = reader.GetDateTime("creation_date"),
                            ExpirationDate = reader.GetDateTime("expiration_date"),
                            Fees = reader.GetDecimal("fees"),
                           
                        });
                    }
                }
            }
            return Ok(librarycards);
        }
    }
}
