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
    public class CartController : ControllerBase
    {


        [HttpGet]
        public async Task<IEnumerable<Mycart>> Get()
        {
            using (foodyContext entities = new foodyContext())
            {
                return await entities.Mycarts.ToListAsync();
            }
        }


        [HttpGet("{id}", Name = "GetCartId")]
        public async Task<IActionResult> GetCartId(string id)
        {
            List<Mycart> clist = new List<Mycart>();
            using (foodyContext entities = new foodyContext())
            {
                clist = await entities.Mycarts.ToListAsync();
                var Check = clist.FindAll(uid => uid.Custid == id);
                if (Check != null)
                {
                    return Ok(Check);
                }
                else
                {
                    return NotFound("Not Found.");
                }
            }
        }


        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Mycart c)
        {
            try
            {
                using (foodyContext entities = new foodyContext())
                {
                    if (entities.Mycarts.Where(cart => cart.FoodCode == c.FoodCode).Count() > 0)
                    {
                        var cartData = entities.Mycarts.Where(cart => cart.FoodCode == c.FoodCode).FirstOrDefault();
                        cartData.Quantity = cartData.Quantity + 1;
                        entities.Mycarts.Update(cartData);
                        await entities.SaveChangesAsync();
                        return new JsonResult("Food added to cart.");
                    }
                    else
                    {
                        entities.Mycarts.Add(c);
                        await entities.SaveChangesAsync();
                        return new JsonResult("Food added to cart.");
                    }

                }
            }
            catch (Exception)
            {
                return new JsonResult("Unable to add Food to the cart.");
            }
        }

        [HttpDelete("{cid}")]
        public async Task<JsonResult> Delete(int cid)
        {
            try
            {
                using (foodyContext entities = new foodyContext())
                {
                    var entity = await entities.Mycarts.SingleOrDefaultAsync(cart => cart.CartId == cid);
                    if (entity == null)
                    {
                        return new JsonResult("Unable to Remove Food from Cart.");
                    }
                    else
                    {
                        entities.Mycarts.Remove(entity);
                        await entities.SaveChangesAsync();
                        return new JsonResult("Food Removed from Cart.");
                    }
                }
            }
            catch (Exception)
            {
                return new JsonResult("Cart Item not found.");
            }
        }
    }
}
