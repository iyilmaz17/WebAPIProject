using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal, IAddressService addressService)
        {
            _userDal = userDal;
        }

        public void Register(UserForRegisterDto userForRegisterDto)
        {
            var user = new User
            {
                Email = userForRegisterDto.Email,
                Name = userForRegisterDto.Name,
                Surname = userForRegisterDto.Surname,
                Password = userForRegisterDto.Password,
                Phone = userForRegisterDto.Phone,
                ProfilImage= userForRegisterDto.ProfilImage,
                BirthDate =userForRegisterDto.BirthDate,

            };
            _userDal.Add(user);
            
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetById(int id)
        {
            return _userDal.Get(p => p.UserId == id);
        }
        public UserForLoginDto Login(UserForLoginDto userForLoginDto)
        {
            var result = _userDal.Get(p => p.Email == userForLoginDto.Email && p.Password == userForLoginDto.Password);
            if (result != null)
            {
                return new UserForLoginDto { Email = userForLoginDto.Email };
            }
            return new UserForLoginDto { };


        }



    }
}
