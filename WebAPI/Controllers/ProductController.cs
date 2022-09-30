using Business.Abstract;
using Business.Constants;
using Business.Results;
using Core.CrossCuttingConcerns.Caching;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using System.Data;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICacheManager _cacheManager;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ICacheManager cacheManager, ILogger<ProductController> logger)
        {
            _productService = productService;
            _cacheManager = cacheManager;
            _logger = logger;   
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                LogContext.PushProperty("UserId", product.Id);
                _logger.LogInformation("Yeni ürün eklendi {product}", product.Id);
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [ResponseCache(Duration = 30)]
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("categorynamegetall")]
        public IActionResult GetAllCategoryName()
        {
            var result = _productService.GetProductCategoryName();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        //[Authorize(Roles = "User")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAllByCategoryId")]
        public IActionResult GetAllByCategoryId(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
