using Business.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService

    {
        List<User> GetAll();
        User GetById(int id);
        void Register(UserForRegisterDto userForRegisterDto);
        UserForLoginDto Login(UserForLoginDto userForLoginDto);

    }
}
