using MusicShopEntities.DTOs;
using MusicShopEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopEntities.Services
{
    public interface ICustomerService : IService<Customer>
    {
        Task<List<AlbumDto>> GetAllAlbum(int customerId);
    }
}
