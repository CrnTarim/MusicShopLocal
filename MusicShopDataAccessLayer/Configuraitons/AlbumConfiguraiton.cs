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
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Singer).HasMaxLength(50);
            builder.Property(a => a.CreatedYear).IsRequired();
            builder.Property(a => a.RecordCompanyName).IsRequired().HasMaxLength(50);

           
            builder.HasOne(a => a.Customer)
                .WithMany(c => c.Albums)
                .HasForeignKey(a => a.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); 

            
            builder.HasOne(a => a.RecordCompany)
                .WithOne()
                .HasForeignKey<Album>(a => a.RecordCompanyName)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
