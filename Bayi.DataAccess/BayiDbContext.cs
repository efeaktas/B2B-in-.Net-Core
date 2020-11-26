using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DataAccess
{
    public class BayiDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=Dealer;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);

        }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<AdminSale> AdminSale { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<DealerProduct> DealerProduct { get; set; }
        public virtual DbSet<DealerSale> DealerSale { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Error> Error { get; set; }
    }
}
