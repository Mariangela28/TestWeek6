using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Week6.Models;

namespace Test_Week6.Context
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(cf => cf.CF);
            builder.Property(cf => cf.CF).IsFixedLength().HasMaxLength(16);
            builder.Property(f => f.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(l => l.LastName).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Address).HasMaxLength(50).IsRequired();


            
        }
    }
}
