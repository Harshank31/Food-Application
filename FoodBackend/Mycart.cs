using System;
using System.Collections.Generic;

#nullable disable

namespace foodbackend.Models
{
    public partial class Mycart
    {
        public int CartId { get; set; }
        public string Custid { get; set; }
        public int? FoodCode { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }

        public virtual Logindtl Cust { get; set; }
        public virtual Menu FoodNameNavigation { get; set; }
    }
}
