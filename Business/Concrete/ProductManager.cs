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
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = new List<Product>();
            if (_cacheManager.IsAdd("GetAll"))
            {
                result = _cacheManager.Get<List<Product>>("GetAll");
                return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed1);
            }
            else
            {
                result = _productDal.GetAll();
                _cacheManager.Add("GetAll", result, 1);
                return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
            }
        }
        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId).ToList());
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id));
        }

        public Product GetCategoryName(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        public IDataResult<List<GetProductCategoryNameDto>> GetProductCategoryName()
        {
            return new SuccessDataResult<List<GetProductCategoryNameDto>>(_productDal.GetProductCategoryName());

        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
