﻿using MusicShopEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopEntities.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IQueryable<Album> GetAllAlbum(int id);
    }
}
