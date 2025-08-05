namespace LibraryDatabase.Models
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string name { get; set; }

        public string email { get; set; }
        public string phone_number { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }
}
