using LibraryDatabase.Models;
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
        private readonly MySqlConnection _connection;

        public BooksController(MySqlConnection connection)
        {
            this._connection = connection;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = new List<Book>();
            using (var connection = _connection)
            {
                connection.Open();
                var query = 
                    "SELECT book_id, book_name, author, isbn FROM Books";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            BookID = reader.GetInt32("book_id"),
                            Title = reader.GetString("book_name"),
                            ISBN = reader.GetString("isbn"),
                            Author = reader.GetString("author")
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
                using var connection = _connection;
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