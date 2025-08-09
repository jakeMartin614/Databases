using LibraryDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Reflection.Metadata.Ecma335;

namespace LibraryDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedMoviesController : ControllerBase
    {
        private readonly MySqlConnection _connection;

        public BorrowedMoviesController(MySqlConnection connection)
        {
            this._connection = connection;
        }

        // GET: api/BorrowedMovies
        [HttpGet]
        public ActionResult<IEnumerable<BorrowedMovie>> Get()
        {
            var borrowedMovies = new List<BorrowedMovie>();
            using (var connection = _connection)
            {
                connection.Open();
                var query = @"
                    SELECT b.borrowed_movies_id, 
                           b.member_id, b.movie_id, 
                           b.due_date, 
                           b.return_date,
                           m.title as movie_title,
                           mem.name as member_name
                    FROM borrowed_movies b
                    JOIN Movies m ON b.movie_id = m.movie_id
                    JOIN Members mem ON b.member_id = mem.member_id";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        borrowedMovies.Add(new BorrowedMovie
                        {
                            borrowedMoviesID = reader.GetInt32("borrowed_movies_id"),
                            MemberID = reader.GetInt32("member_id"),
                            MovieID = reader.GetInt32("movie_id"),
                            Title = reader.GetString("movie_title"),
                            MemberName = reader.GetString("member_name"),
                            dueDate = reader.GetDateTime("due_date"),
                            returnDate = reader.IsDBNull(reader.GetOrdinal("return_date")) ? null : reader.GetDateTime("return_date")
                        });
                    }
                }
            }
            return Ok(borrowedMovies);
        }
      
    }

}
