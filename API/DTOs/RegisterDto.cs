using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required] //data anotation
        public string Username {get; set; }

        [Required] //data anotation
        public string Password {get; set; }
    }
}