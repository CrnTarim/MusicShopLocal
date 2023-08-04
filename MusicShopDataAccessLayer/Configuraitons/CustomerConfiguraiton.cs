using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShopEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDataAccessLayer.Configuraitons
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(c => c.Albums) 
                        .WithOne(a => a.Customer) 
                        .HasForeignKey(a => a.CustomerId) 
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade); 

            builder.ToTable("Customers");
        }
    }
}
