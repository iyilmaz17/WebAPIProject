using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService districtService;

        public DistrictController(IDistrictService districtService)
        {
            this.districtService = districtService;
        }
        [HttpGet]
        public List<District> GetAll()
        {
            return districtService.GetAll();
        }

        [HttpGet("{id}")]
        public List<District> GetById(int id)
        {
            return districtService.GetByCityId(id);
        }
    }
}
