using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Net.Mail;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet("id")]
        public User Get(int id)
        {
            return userService.GetById(id);
        }
        [HttpGet]
        public List<User> GetAll()
        {
            return userService.GetAll();
        }
        [HttpGet("userdetailsandgetroles")]
        public ActionResult UserDetailsGetRoles()
        {
            var result = userService.GetRolesGetRoles();
            return Ok(result); 
        }


    }
}
