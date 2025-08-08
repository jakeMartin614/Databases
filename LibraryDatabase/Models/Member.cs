namespace LibraryDatabase.Models {
    public class Member { 
        public int ID { get; set; }

        public int LibraryCard {  get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }

        // Navigation property
        public virtual ICollection<BorrowedMovies> BorrowedMovies { get; set; }
    }
}
