using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JoinClassGestaodeHorario.API.Controllers
{
    public class HomeControllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class HomeController : ControllerBase
        {
            [HttpGet("hello")]
            public IActionResult HelloWorld()
            {
                return Ok("Hello, World!");
            }
        }
    }
}