using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IAddressService _addressService;

        public UserManager(IUserDal userDal, IAddressService addressService)
        {
            _userDal = userDal;
            _addressService = addressService;
        }
        public void Register(UserForRegisterDto userForRegisterDto)
        {

            var user = new User
            {
                Name = userForRegisterDto.Name,
                Surname = userForRegisterDto.Surname,
                Email = userForRegisterDto.Email,
                Password = userForRegisterDto.Password,
                Phone = userForRegisterDto.Phone,
                ProfilImage = userForRegisterDto.ProfilImage,
                BirthDate = userForRegisterDto.BirthDate,
            };
            _userDal.Add(user);
            var address = new Address
            {
                UserId = user.Id,
                AddressText = userForRegisterDto.AddressText,
                CityId = userForRegisterDto.CityId,
                DistrictId = userForRegisterDto.DistrictId,
                

            };
            _addressService.AddAddress(address);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetById(int id)
        {
            return _userDal.Get(p => p.Id == id);
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
