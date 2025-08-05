namespace LibraryDatabase.Models {

    public class LibraryCard { 
        public int LibraryCardID { get; set; }
        public int MemberID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Fees { get; set; }
    }
}