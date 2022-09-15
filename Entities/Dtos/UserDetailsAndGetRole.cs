using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserDetailsAndGetRole
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string RolName { get; set; }
    }
}
