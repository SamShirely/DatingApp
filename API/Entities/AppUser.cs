using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        // Creating an ID property for Users. The value is an integer.
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}