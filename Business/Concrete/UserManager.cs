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

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
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
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
