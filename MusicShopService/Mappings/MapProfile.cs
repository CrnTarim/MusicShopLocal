using AutoMapper;
using MusicShopEntities.DTOs;
using MusicShopEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopService.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Album, AlbumDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<RecordCompany, RecordCompanyDto>().ReverseMap();
            CreateMap<UserAutho, UserAuthoDto>().ReverseMap();


        }
    }
}
