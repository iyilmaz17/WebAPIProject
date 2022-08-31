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
        void AddProduct(Product product);
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> GetAllByCategoryId(int id);
        Product GetCategoryName (int id);
        List<GetProductCategoryNameDto> GetproductDetails();
    }
}
