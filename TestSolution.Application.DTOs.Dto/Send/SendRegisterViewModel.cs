using System;
using System.Collections.Generic;
using System.Text;

namespace TestSolution.Application.DTOs.Dto.Send
{
    public class SendRegisterViewModel
    {
        public Error error { get; set; }
        public RegisterDto register { get; set; }
        public IEnumerable<RegisterDto> registers { get; set; }
    }
}
