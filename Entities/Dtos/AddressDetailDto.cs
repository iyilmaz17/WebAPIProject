using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AddressDetailDto : IDto
    {
        public int AddressId { get; set; }
        public string UserName { get; set; }
        public string AddressText { get; set; }
    }
}
