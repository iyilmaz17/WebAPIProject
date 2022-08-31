using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class GetProductCategoryNameDto : IDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public int UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public string Image1 { get; set; }
    }
}
