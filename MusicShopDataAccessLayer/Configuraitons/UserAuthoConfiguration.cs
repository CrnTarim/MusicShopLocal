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
    public class UserAuthoConfiguration : IEntityTypeConfiguration<UserAutho>
    {
        public void Configure(EntityTypeBuilder<UserAutho> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("UserAutho");
        }
    }
}
