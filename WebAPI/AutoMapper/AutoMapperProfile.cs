using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;

namespace WebAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForRegisterDto>().ReverseMap();
            CreateMap<Customer, CustomerForRegisterDto>().ReverseMap();
            CreateMap<Address, CustomerForRegisterDto>().ReverseMap();
        }
    }
}
