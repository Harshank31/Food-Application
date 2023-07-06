using foodbackend.Authentication;
using foodbackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Logindtl login)
        {
            AuthenticationManager jWTAuthenticationManager = new AuthenticationManager(_configuration.GetValue<string>("TokenKey"));
            var token = jWTAuthenticationManager.Authenticate(login.CustName, login.CustPassword);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Logindtl ud)
        {
            try
            {
                using (foodyContext entities = new foodyContext())
                {
                    entities.Logindtls.Add(ud);
                    await entities.SaveChangesAsync();
                    return new JsonResult("User registered successfully.");
                }
            }
            catch (Exception)
            {
                return new JsonResult("Error while registering User.");
            }
        }
    }
}

