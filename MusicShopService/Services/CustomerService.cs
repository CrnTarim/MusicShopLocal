using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicShopEntities.DTOs;
using MusicShopEntities.Entities;
using MusicShopEntities.IUnitOfWork;
using MusicShopEntities.Repositories;
using MusicShopEntities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopService.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(
            IGenericRepository<Customer> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICustomerRepository customerRepository
        ) : base(repository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<List<AlbumDto>> GetAllAlbum(int customerId)
        {
            var albums = await _customerRepository.GetAllAlbum(customerId).ToListAsync();
            var albumDtos = _mapper.Map<List<AlbumDto>>(albums);
            return albumDtos;
        }

    }

}
