using Microsoft.EntityFrameworkCore;
using MusicShopEntities.Entities;
using MusicShopEntities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDataAccessLayer.Repositories
{
    public class CustomerRepo : GenericRepository<Customer>, ICustomerRepository
    {
        protected readonly AppDBContext _context;
        private readonly DbSet<Customer> _dbSet;
       
        public CustomerRepo(AppDBContext context) : base(context)
        {

            _context = context;
            _dbSet = _context.Set<Customer>();
        }

        IQueryable<Album> ICustomerRepository.GetAllAlbum(int customerId)
        {
            return _dbSet.Include(c => c.Albums).Where(c => c.Id == customerId).SelectMany(c => c.Albums).AsNoTracking();
        }
    }
}
