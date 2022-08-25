using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        //[Email]
        //[Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
