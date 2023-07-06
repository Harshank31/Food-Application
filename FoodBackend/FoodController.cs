using foodbackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<Menu>> Get()
        {
            using (foodyContext entities = new foodyContext())
            {
                return await entities.Menus.ToListAsync();
            }
        }
    }
}


