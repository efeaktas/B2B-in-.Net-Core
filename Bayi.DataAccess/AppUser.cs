using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DataAccess
{
    public class AppUser :IdentityUser<int>
    {
        public string CompanyName { get; set; }
        public string AuthorizedPerson { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Dealer> Dealers { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<AdminSale> AdminSales { get; set; }
    }
}
