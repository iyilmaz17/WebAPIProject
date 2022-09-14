using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet]
        public List<Address> GetUserAddress(int id)
        {
            return _addressService.GetAll().Where(p=>p.CustomerId==id).ToList();
        }
        [HttpGet("{ll}")]

        public List<AddressDetailDto> adresgetir()
        {
            return _addressService.GetAddressDetailDtos();
        }
    }
}
