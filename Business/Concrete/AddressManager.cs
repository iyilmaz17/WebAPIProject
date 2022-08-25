using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
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
        IUserDal _userDal;  

        public AddressManager(IAddressDal addressDal, IUserDal userDal)
        {
            _addressDal = addressDal;
            _userDal = userDal;
        }

        public List<Address> GetAll()
        {
            return _addressDal.GetAll();
        }
    }
}
