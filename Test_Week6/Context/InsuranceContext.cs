using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Week6.Models;

namespace Test_Week6.Context
{
    public class InsuranceContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<CarPolicy> CarPolicies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False; 
                                    Integrated Security = true; 
                                    Initial Catalog = Assicurazioni; 
                                    Server = .\SQLEXPRESS");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<CarPolicy>(new CarPolicyConfiguration());

        }
    }
}
