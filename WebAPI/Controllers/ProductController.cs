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
        public Product Get(int id)
        {
            return productService.GetById(id);
        }
        [HttpGet]
        public List<GetProductCategoryNameDto> GetAll()
        {
            return productService.GetproductDetails();
        }
        [HttpPost]
        public void AddProduct(Product product)
        {
            productService.AddProduct(product);
        }
    }
}
