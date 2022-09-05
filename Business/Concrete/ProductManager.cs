using Business.Abstract;
using Business.Constants;
using Business.Results;
using Core.CrossCuttingConcerns.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICacheManager _cacheManager;

        public ProductManager(IProductDal productDal, ICacheManager cacheManager)
        {
            _productDal = productDal;
            _cacheManager = cacheManager;
        }
        public IResult AddProduct(Product product)
        {

            _productDal.Add(product);
            return new Result(true, Messages.productAdded);
        }
        //public IDataResult<List<Product>> GetAll()
        //{
        //    if (_cacheManager.IsAdd("GetAll"))
        //    {
        //        return _cacheManager.Get<IDataResult<List<Product>>>("GetAll");
        //    }
        //   else
        //    {
        //        var value = _productDal.GetAll();
        //        _cacheManager.Add("GetAll", value, 10);
        //        return new SuccessDataResult<List<Product>>(value, Messages.ProductsListed);
        //    }

        //}
        //public IDataResult<List<Product>> GetAll()
        //{
        //    //var result = new List<Product>();
        //    //if (_cacheManager.IsAdd("GetAll"))
        //    //{
        //    //    result = _cacheManager.Get<IDataResult<List<Product>>>
        //    //}
        //}

        public List<Product> GetAll()
        {
            
            var result = new List<Product>();
            if (_cacheManager.IsAdd("GetAll"))
            {
                result = _cacheManager.Get<List<Product>>("GetAll");
                return new List<Product>(result);
            }
            result = _productDal.GetAll();
            _cacheManager.Add("GetAll", result, 10);
            return new List<Product>(result);
        }





        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
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
