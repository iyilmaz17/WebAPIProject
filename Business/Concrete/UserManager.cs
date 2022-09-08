using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Results;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IAddressService _addressService;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IAddressService addressService, IMapper mapper)
        {
            _userDal = userDal;
            _addressService = addressService;
            _mapper = mapper;
        }  
        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetById(int id)
        {
            return _userDal.Get(p => p.Id == id);
        }

        public void add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public UserForLoginDto Login(UserForLoginDto userForLoginDto)
        {
            var result = _userDal.Get(p => p.Email == userForLoginDto.Email && p.Password == userForLoginDto.Password);
            if (result != null)
            {
                return userForLoginDto;
            }
            return null;

        }

        //public void Register(UserForRegisterDto userForRegisterDto)
        //{
        //    // User And UserForRegisterDto AutoMapping
        //    var user = new User();
        //    user = _mapper.Map<User>(userForRegisterDto);
        //    _userDal.Add(user);

        //    var address = new Address
        //    {
        //        UserId = user.Id,
        //        AddressText = userForRegisterDto.AddressText,
        //        CityId = userForRegisterDto.CityId,
        //        DistrictId = userForRegisterDto.DistrictId,

        //    };
        //    _addressService.AddAddress(address);
        //}

        //public void Register(UserForRegisterDto userForRegisterDto)
        //{
        //    var user = new User
        //    {
        //        Email = userForRegisterDto.Email,
        //        Name = userForRegisterDto.Name,
        //        Surname = userForRegisterDto.Surname,
        //        Password = userForRegisterDto.Password,
        //        Phone = userForRegisterDto.Phone,
        //        ProfilImage = userForRegisterDto.ProfilImage,
        //        BirthDate = userForRegisterDto.BirthDate,

        //    };
        //    _userDal.Add(user);

        //}
    }
}
