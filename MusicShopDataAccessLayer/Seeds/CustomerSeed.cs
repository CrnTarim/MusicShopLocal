using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShopEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDataAccessLayer.Seeds
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer { Id = 100, Name = "Ceren", Email = "ceren@gmail.com", Phone = "1234567890" },
                new Customer { Id = 101, Name = "Tuana", Email = "tuana2@gmail.com", Phone = "9876543210" }               
                );
        }
    }
}
