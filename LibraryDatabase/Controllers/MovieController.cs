using LibraryDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace LibraryDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MySqlConnection _connection;

        public MovieController(MySqlConnection connection)
        {
            this._connection = connection;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movies = new List<Movie>();
            using (var connection = _connection)
            {
                connection.Open();
                var query =
                    "SELECT movie_id, title, director, duration, release_date, genre FROM Movies";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie
                        {
                            movie_id = reader.GetInt32("movie_id"),
                            title = reader.GetString("title"),
                            director = reader.GetString("director"),
                            duration = reader.GetString("duration"),
                            release_date = reader.GetDateTime("release_date"),
                            genre = reader.GetString("genre")
                        });
                    }
                }
            }
            return Ok(movies);
        }



    }
}