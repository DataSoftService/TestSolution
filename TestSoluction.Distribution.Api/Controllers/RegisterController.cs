using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Solution.Application.Module.Services.Services;
using TestSolution.Application.DTOs.Dto;
using TestSolution.Application.DTOs.Dto.Send;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestSoluction.Distribution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        RegisterAppService db;
        public RegisterController(RegisterAppService _db)
        {
            db = _db;
        }
        // GET: api/<RegisterController>
        [HttpGet]
        public string Get()
        {
            var sendRegister = new SendRegisterViewModel { 
                error=new Error(),
                register=new RegisterDto(),
                registers=new List<RegisterDto>()
            };
            try
            {
                sendRegister.registers = db.list().Result;
                sendRegister.error.status = true;
            }
            catch (Exception x)
            {
                sendRegister.error.message = x.Message;
                sendRegister.error.source = x.Source;
                sendRegister.error.stack = x.StackTrace;
                sendRegister.error.status = false;
            }
            return JsonConvert.SerializeObject(sendRegister);
        }
        

        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RegisterController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
