namespace LibraryDatabase.Models
{
    public class BorrowedMovie
    {
        public int borrowedMoviesID { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime? returnDate { get; set; }
        public string MemberName { get; set; }
        public string Title { get; set; }

        // Foreign Keys
        public int MovieID { get; set; } // FK to Movie
        public int MemberID { get; set; } // FK to Member
  
    }
}