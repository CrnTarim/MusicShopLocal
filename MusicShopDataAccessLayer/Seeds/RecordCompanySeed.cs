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
    public class RecordCompanySeed : IEntityTypeConfiguration<RecordCompany>
    {
        public void Configure(EntityTypeBuilder<RecordCompany> builder)
        {
            builder.HasData(
                 new RecordCompany { Id = 10, Name = "Atlanta", CompanyYear = 1990, CompanyValue = 1000000, AlbumId = 1000 },
                 new RecordCompany { Id = 11, Name = "Parental", CompanyYear = 2000, CompanyValue = 2000000, AlbumId = 1001 }
                );
        }
    }
}
