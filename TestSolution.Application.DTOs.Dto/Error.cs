using System;
using System.Collections.Generic;
using System.Text;

namespace TestSolution.Application.DTOs.Dto
{
    public class Error
    {
        public string message { get; set; }
        public string source { get; set; }
        public string stack { get; set; }
        public bool status { get; set; }
    }
}
