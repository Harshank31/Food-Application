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
    public class OrderController : ControllerBase
    {


        [HttpGet]
        public async Task<IEnumerable<Orderlist>> Get()
        {
            using (foodyContext entities = new foodyContext())
            {
                return await entities.Orderlists.ToListAsync();
            }
        }


        [HttpGet("{id}", Name = "GetBill")]
        public async Task<IActionResult> GetBill(string id)
        {
            List<Orderlist> clist = new List<Orderlist>();
            using (foodyContext entities = new foodyContext())
            {
                clist = await entities.Orderlists.Where(uid => uid.Custid == id).ToListAsync();
                var data = clist.GroupBy(order => order.OrderNo).ToList();
                //var Check = clist.FindAll(uid => uid.Custid == id);

                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound("Not Found.");
                }
            }
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Orderlist bd)
        {
            try
            {
                using (foodyContext entities = new foodyContext())
                {
                    entities.Orderlists.Add(bd);
                    await entities.SaveChangesAsync();
                    return new JsonResult("Bill Generated Successfully.");
                }
            }
            catch (Exception)
            {
                return new JsonResult("Unable to Generate Bill.");
            }
        }

        //[HttpDelete("{oid}")]
        //public async Task<JsonResult> Delete(int oid)
        //{
        //    try
        //    {
        //        using (foodyContext entities = new foodyContext())
        //        {
        //            var entity = await entities.Orderlists.SingleOrDefaultAsync(cart => cart.OrderNo == oid);
        //            if (entity == null)
        //            {
        //                return new JsonResult("Unable to Remove Food from Bill.");
        //            }
        //            else
        //            {
        //                entities.Orderlists.Remove(entity);
        //                await entities.SaveChangesAsync();
        //                return new JsonResult("Food Removed from Bill.");
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return new JsonResult("Bill not found.");
        //    }
        //}
    }
}

