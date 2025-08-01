using LibraryDatabase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace LibraryDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly string connectionString = "server=localhost;database=librarydb;user=root;password=Sotamaw@2204;";

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = new List<Book>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT BookID, Title, Author FROM Books";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            BookID = reader.GetInt32("BookID"),
                            Title = reader.GetString("Title"),
                            Author = reader.GetString("Author")
                        });
                    }
                }
            }
            return Ok(books);
        }

        [HttpGet("test-connection")]
        public IActionResult TestConnection()
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                using var command = new MySqlCommand("SELECT 1", connection);
                var result = command.ExecuteScalar();

                return Ok("✅ Connection to MySQL successful. Result: " + result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "❌ Connection failed: " + ex.Message);
            }
        }

    }
}