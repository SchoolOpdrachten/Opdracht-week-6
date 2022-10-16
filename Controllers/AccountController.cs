using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Opdracht_week_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        [HttpPost]
        [Route("login")]
        public async Task Login(Persoon persoon)
        {
            
        }

        [HttpPost]
        [Route("registreer")]
        public async Task Registreer(Persoon persoon)
        {
            
        }
    }
}
