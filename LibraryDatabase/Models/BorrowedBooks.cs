namespace LibraryDatabase.Models
{
    public class BorrowedBook
    {
        public int BookID { get; set; }

        public int MemberID { get; set; }
        public int BorrowedBookID { get; set; }
        public string MemberName { get; set; }
        public string Title { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime? returnDate { get; set; }

    }
}