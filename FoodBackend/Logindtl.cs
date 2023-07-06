using System;
using System.Collections.Generic;

#nullable disable

namespace foodbackend.Models
{
    public partial class Logindtl
    {
        public Logindtl()
        {
            Mycarts = new HashSet<Mycart>();
            Orderlists = new HashSet<Orderlist>();
        }

        public string Custid { get; set; }
        public string CustName { get; set; }
        public string CustPhone { get; set; }
        public string CustAddress { get; set; }
        public string CustPassword { get; set; }

        public virtual ICollection<Mycart> Mycarts { get; set; }
        public virtual ICollection<Orderlist> Orderlists { get; set; }
    }
}
