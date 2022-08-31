using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return productService.GetById(id).Data ;
        }
        [HttpGet]
        public List<GetProductCategoryNameDto> GetAll()
        {
            return productService.GetproductDetails();
        }
        [HttpPost("add")]
        public IActionResult AddProduct(Product product)
        {
           var result = productService.AddProduct(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll1()
        {

            var result = productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
