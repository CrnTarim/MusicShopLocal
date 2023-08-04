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
    public class AlbumSeed : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasData(
                new Album { Id = 1000, Name = "UltraVolence", Singer = "Lana", CreatedYear = 2021, RecordCompanyName = "Atlanta", CustomerId = 100 },
                new Album { Id = 1001, Name = "NormanFW", Singer = "Lana", CreatedYear = 2022, RecordCompanyName = "Parental", CustomerId = 101 }
                );
        }
    }
}
