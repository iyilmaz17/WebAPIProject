using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dtos;

namespace WebAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForRegisterDto>().ReverseMap();
        }
    }
}
