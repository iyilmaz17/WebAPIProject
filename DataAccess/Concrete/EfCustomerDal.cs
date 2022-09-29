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


        public ReturnCustomerForloginDto GetCustomer(CustomerForLoginDto customer)
        {
            using (var context = new WebAPIContext())
            {
                var value = Get(p => p.Email == customer.Email);
                ReturnCustomerForloginDto resultDto = new()
                {
                    Email = value.Email,
                    Id = value.Id,
                    Name = value.Name
                };
                return resultDto;

            }
        }
    }
}
