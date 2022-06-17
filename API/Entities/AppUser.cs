using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        // Creating an ID property for Users. The value is an integer.
        public int Id { get; set; } //get set means

        //username property
        public string Username { get; set; }

        public byte[] PasswordHash {get; set; }

        public byte[] PasswordSalt {get; set; }
    }
}