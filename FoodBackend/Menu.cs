using System;
using System.Collections.Generic;

#nullable disable

namespace foodbackend.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Mycarts = new HashSet<Mycart>();
            Orderlists = new HashSet<Orderlist>();
        }

        public int FoodCode { get; set; }
        public string FoodName { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Mycart> Mycarts { get; set; }
        public virtual ICollection<Orderlist> Orderlists { get; set; }
    }
}
