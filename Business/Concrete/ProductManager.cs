using Business.Abstract;
using Business.Constants;
using Business.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
        }

        public IResult AddProduct(Product product)
        {
            

            _productDal.Add(product);
            return new Result(true,Messages.productAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId == id);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id));
        }

        public Product GetCategoryName(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        public List<GetProductCategoryNameDto> GetproductDetails()
        {
            return _productDal.GetproductDetails();
        }
    }
}
