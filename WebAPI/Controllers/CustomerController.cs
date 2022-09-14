using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost("register")]
        public ActionResult Register(CustomerForRegisterDto customerForRegisterDto)
        {
            var userExists = _customerService.UserExists(customerForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _customerService.Register(customerForRegisterDto, customerForRegisterDto.Password);
            {
                return Ok(registerResult.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult Login(CustomerForLoginDto customerForLoginDto)
        {
            var userToLogin = _customerService.Login(customerForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
                return Ok(userToLogin.Message);
        }
    }
}