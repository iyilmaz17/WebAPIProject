using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerForRegisterDto>().ReverseMap();
            CreateMap<Address, CustomerForRegisterDto>().ReverseMap();
        }
    }
}
