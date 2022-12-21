using System;
using System.Collections.Generic;
using System.Text;

namespace TestSolution.Application.DTOs.Dto
{
    public class RegisterDto
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
