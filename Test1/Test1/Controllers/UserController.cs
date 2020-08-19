using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test1.Data;

namespace Test1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITestDB _dbf;
        private readonly string _path = @"F:\Proiecte\_Lucru\";

        public UserController(ITestDB dbf)
        {
            _dbf = dbf;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var rez = await _dbf.GetUsers();
            return Ok(new { rez, status = "200" });
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> Get(int ID)
        {
            var rez = await _dbf.GetPerson(ID);
            return Ok(new { rez, status = "200" });
        }


    }
}
