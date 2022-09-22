using DemoBankProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoBankProject.Data
{
  
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }

       
            public DbSet<Customer> Customers { get; set; }
             public DbSet<Account> Accounts { get; set; }
            public DbSet<Transaction> Transactions { get; set; }
    }
}
