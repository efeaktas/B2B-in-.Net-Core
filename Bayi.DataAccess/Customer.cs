using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bayi.DataAccess
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string AuthorizedPerson { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public virtual List<DealerSale> DealerSales { get; set; }
        [ForeignKey("Dealer")]
        public virtual int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
