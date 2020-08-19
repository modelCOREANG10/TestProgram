using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test1.Data;
using Test1.Models;

namespace Test1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ITestDB _dbf;
        private readonly string _path = @"F:\Proiecte\";

        public EmailController(ITestDB dbf)
        {
            _dbf = dbf;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var rez = await _dbf.OpenDBF(_path); // @"D:\DB\" + CODM + "\"
            //var rez = await _dbf.ConvertToAuthStoc(CODM, table);
            return Ok(new { rez, status = "200" });
        }

        [HttpGet("se/{ID}")]
        public async Task<IActionResult> GetSE(string ID)
        {
            var rez = await _dbf.GetEmail(_path, ID, false);
            return Ok(new { rez, status = "200" });
        }

        [HttpGet("ex/{ID}")]
        public async Task<IActionResult> GetEX(string ID)
        {
            var rez = await _dbf.GetEmail(_path, ID, true);
            return Ok(new { rez, status = "200" });
        }

        [HttpPost("del/{ID}")]
        public async Task<IActionResult> PostDEL(string ID)
        {
            return Ok(new { status = "200" });
        }

        [HttpPost("reed/{ID}")]
        public async Task<IActionResult> PostREED(string ID)
        {
            return Ok(new { status = "200" });
        }
        [HttpPost("{ID}")]
        public async Task<IActionResult> PostSend([FromRoute] string ID,[FromBody] AddEmail emailC)
        {
            return Ok(new { status = "200" });
        }


    }
}
