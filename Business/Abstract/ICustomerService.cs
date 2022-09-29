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
    public  interface ICustomerService
    {
        IResult Register(CustomerForRegisterDto customerForRegisterDto);
        IResult UserExists(string email);
        IDataResult<List<Customer>> GetAll();
        IDataResult<ReturnCustomerForloginDto> Login(CustomerForLoginDto customerForLoginDto);
        //IDataResult<CustomerForLoginDto> Login(CustomerForLoginDto customerForLoginDto);

    }
}
