using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class UsersController : BaseApiController // derives from our base API controller, giving us less to type and so we don't have to repeat ourselves.  
    {
        private readonly DataContext _context; // constructor
        public UsersController(DataContext context)
        {
            _context = context;
        } // gives us access to our database, using Db Context

        [HttpGet] //the controller endpoint, where we are getting data
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var result = await _context.Users.ToListAsync();
            return await _context.Users.ToListAsync();
        }

       
        [HttpGet("{id}")] 
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
           return await _context.Users.FindAsync(id);
        }

    }
}