using Business.Results;
using Core.Entities.Concrete;
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
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        void add(User user);
        List<User> GetAll();
        User GetById(int id);
        UserForLoginDto Login(UserForLoginDto userForLoginDto);

    }
}
