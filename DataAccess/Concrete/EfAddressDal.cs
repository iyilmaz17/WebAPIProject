using Core.DataAccess.EntityFramework;
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
    public class EfAddressDal : EfEntityRepositoryBase<Address, WebAPIContext>, IAddressDal
    {
        public List<AddressDetailDto> GetAddressDetailDtos()
        {
            using (WebAPIContext context = new WebAPIContext())
            {
                var result = from a in context.Addresses
                             join u in context.Users
                             on a.UserId equals u.Id
                             select new AddressDetailDto
                             {
                                 AddressId = a.Id,
                                 AddressText = a.AddressText,
                                 UserName = u.Name,
                             };
                return result.ToList();
            }
        }
    }
}
