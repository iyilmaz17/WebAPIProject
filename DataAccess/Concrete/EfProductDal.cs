using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, WebAPIContext>, IProductDal
    {
        public List<GetProductCategoryNameDto> GetProductCategoryName()
        {
            using (WebAPIContext context = new WebAPIContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new GetProductCategoryNameDto
                             {
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 Stock = p.Stock,
                                 Brand = p.Brand,
                                 UnitPrice = p.UnitPrice,
                                 Image1 = p.Image1,
                                 Id=p.Id,
                             };
                return result.ToList();
            }
        }
    }
}
