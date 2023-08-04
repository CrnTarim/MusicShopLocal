using Microsoft.EntityFrameworkCore;
using MusicShopEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDataAccessLayer
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opitons) : base(opitons)
        {

        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RecordCompany> RecordCompanies { get; set; }

        public DbSet<UserAutho> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//PROTECTED 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
