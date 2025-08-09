using System.Reflection.PortableExecutable;

namespace LibraryDatabase.Models
{
    public class checkOuts
    {
        public int check_out_id { get; set; }
        public string employee_name { get; set; }

        public DateTime check_out_date { get; set; }
        public string member_name { get; set; }

    }
}
