using System;

namespace TestSolution.Domain.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public DateTime birth_date { get; set; }
    }
}
