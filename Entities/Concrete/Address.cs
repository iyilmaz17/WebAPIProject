using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Address :IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string AddressText { get; set; }
        public Customer Customer { get; set; }

    }
}
