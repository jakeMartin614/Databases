using LibraryDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Reflection.Metadata.Ecma335;

namespace LibraryDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBooksController : ControllerBase
    {
        private readonly MySqlConnection _connection;

        public BorrowedBooksController(MySqlConnection connection)
        {
            this._connection = connection;
        }

   
        [HttpGet]
        public ActionResult<IEnumerable<BorrowedBook>> Get()
        {
            var borrowedBooks = new List<BorrowedBook>();
            using (var connection = _connection)
            {
                connection.Open();
                var query = @"
                    SELECT b.borrowed_book_id, 
                           b.member_id, b.book_id, 
                           b.due_date, 
                           b.return_date,
                           books.book_name as book_title,
                           mem.name as member_name
                    FROM borrowed_books b
                    JOIN books ON b.book_id = books.book_id
                    JOIN Members mem ON b.member_id = mem.member_id";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        borrowedBooks.Add(new BorrowedBook
                        {
                            BorrowedBookID = reader.GetInt32("borrowed_book_id"),
                            MemberID = reader.GetInt32("member_id"),
                            BookID = reader.GetInt32("book_id"),
                            Title = reader.GetString("book_title"),
                            MemberName = reader.GetString("member_name"),
                            dueDate = reader.GetDateTime("due_date"),
                            returnDate = reader.IsDBNull(reader.GetOrdinal("return_date")) ? null : reader.GetDateTime("return_date")
                        });
                    }
                }
            }
            return Ok(borrowedBooks);
        }

    }

}
