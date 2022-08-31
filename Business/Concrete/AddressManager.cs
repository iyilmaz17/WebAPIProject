using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void AddAddress(Address address)
        {
            
            _addressDal.Add(address);
        }

        public List<AddressDetailDto> GetAddressDetailDtos()
        {
            return _addressDal.GetAddressDetailDtos();

        }

        public List<Address> GetAll()
        {
            return _addressDal.GetAll();
        }
    }
}
