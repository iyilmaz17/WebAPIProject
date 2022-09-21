using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, WebAPIContext>, ICustomerDal
    {


        //public CustomerForLoginDto GetCustomer(CustomerForLoginDto customer)
        //{
        //    using (var context = new WebAPIContext())
        //    {
        //         Get(p => p.Email == customer.Email && p.Password == customer.Password);
        //        CustomerForLoginDto resultDto = new()
        //        {
        //            Email = customer.Email,
        //            Password = customer.Password
        //        };
        //        return resultDto;

        //    }
        //}
    }
}
