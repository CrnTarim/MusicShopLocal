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
    public class RecordCompanyConfiguration : IEntityTypeConfiguration<RecordCompany>
    {
        public void Configure(EntityTypeBuilder<RecordCompany> builder)
        {
            builder.ToTable("RecordCompanies");

            builder.HasKey(rc => rc.Id);
            builder.Property(rc => rc.Id).UseIdentityColumn();
            builder.Property(rc => rc.Name).IsRequired().HasMaxLength(100);
            builder.Property(rc => rc.CompanyYear).IsRequired();
            builder.Property(rc => rc.CompanyValue).IsRequired();

            
            builder.HasOne(rc => rc.Album)
                .WithOne(a => a.RecordCompany)
                .HasForeignKey<RecordCompany>(rc => rc.AlbumId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
