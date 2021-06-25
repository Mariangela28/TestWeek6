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
    public class CarPolicyConfiguration : IEntityTypeConfiguration<CarPolicy>
    {
        public void Configure(EntityTypeBuilder<CarPolicy> builder)
        {
            builder.ToTable("Car Policy");
            
            builder.HasKey(n => n.Number);
            builder.Property(d => d.DateStipulates).IsRequired();
            builder.Property(i => i.InsuredAmmount).IsRequired();
            builder.Property(m => m.MonthlyInstallment).IsRequired();


            builder.HasOne(c => c.Client).WithMany(c => c.CarPolicies).HasForeignKey(k => k.ClientCF);

            //Per gestire la gerarchia
            builder.HasDiscriminator<string>("CarPolicy_type")
                   .HasValue<CarPolicy>("Car Policy")
                   .HasValue<RCauto>("RC auto")
                   .HasValue<Robbery>("Robbery")
                   .HasValue<Life>("Life");
            //con discriminante intero
            builder.HasDiscriminator<int>("CarPolicy_type")
                   .HasValue<CarPolicy>(1)
                   .HasValue<RCauto>(2)
                   .HasValue<Robbery>(3)
                     .HasValue<Life>(4);

        }
    }
}
