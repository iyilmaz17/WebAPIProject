using Business.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult AddProduct(Product product);
        IDataResult< List<Product>> GetAll();
        IDataResult<Product> GetById(int id);
        List<Product> GetAllByCategoryId(int id);
        Product GetCategoryName (int id);
        List<GetProductCategoryNameDto> GetproductDetails();
    }
}
