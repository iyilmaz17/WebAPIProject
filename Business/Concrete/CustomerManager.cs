using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Results;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDal customerDal, IAddressService addressService, IMapper mapper)
        {
            _customerDal = customerDal;
            _addressService = addressService;
            _mapper = mapper;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result);
        }

        //Çalışan kod
        public IDataResult<ReturnCustomerForloginDto> Login(CustomerForLoginDto customerForLoginDto)
        {
            var userToCheck = _customerDal.Get(x => x.Email == customerForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<ReturnCustomerForloginDto>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(customerForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<ReturnCustomerForloginDto>(Messages.PasswordError);
            }
            ReturnCustomerForloginDto ReturnUserToCheck = new ReturnCustomerForloginDto
            {
                Id = userToCheck.Id,
                Name = userToCheck.Name
            };
            return new SuccessDataResult<ReturnCustomerForloginDto>(ReturnUserToCheck, Messages.SuccessfulLogin);
        }


        public IResult Register(CustomerForRegisterDto customerForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(customerForRegisterDto.Password, out passwordHash, out passwordSalt);
            var customer = new Customer();
            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;
            customer = _mapper.Map<Customer>(customerForRegisterDto);
            //önce atama yap sonra map

            //var customer = new Customer
            //{
            //    Email = customerForRegisterDto.Email,
            //    Name = customerForRegisterDto.Name,
            //    Password = customerForRegisterDto.Password,
            //    Surname = customerForRegisterDto.Surname,
            //    PasswordHash = passwordHash,
            //    PasswordSalt = passwordSalt,
            //    Phone = customerForRegisterDto.Phone,
            //    ProfilImage = customerForRegisterDto.ProfilImage,
            //    BirthDate = customerForRegisterDto.BirthDate,
            //    Status = true
            //};
            _customerDal.Add(customer);

            var address = new Address
            {
                CustomerId = customer.Id,
                AddressText = customerForRegisterDto.AddressText,
                CityId = customerForRegisterDto.CityId,
                DistrictId = customerForRegisterDto.DistrictId,

            };
            _addressService.AddAddress(address);
            return new SuccessResult(Messages.UserRegisterOk);
        }

        public IResult UserExists(string email)
        {
            var result = _customerDal.GetAll(x => x.Email == email).Count;
            if (result != 0)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
