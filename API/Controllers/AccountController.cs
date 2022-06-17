using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        
        //adding a constructor so we can inject our DataContext into this class
        private readonly DataContext _context;
        
        public AccountController(DataContext context)
        {
            _context = context;
        
        }

    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto) //AppUser is there to specify the type of thing we will be controlling
    {
        if(await UserExists(registerDto.Username)) return BadRequest("Username is Taken");
        
        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            Username = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        _context.Users.Add(user); //not adding anything here, but instead it tracking the user in entity framework
        await _context.SaveChangesAsync(); //calls users into database and then saves it 

        return user;

    }

    [HttpPost("login")]
    public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == loginDto.Username);

        if (user == null) return Unauthorized("Invalid username");

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return Unauthorized ("Invalid password");
        }

        return user;
    }

        private async Task <bool> UserExists(string username) //helper method
            {
              return await _context.Users.AnyAsync(x => x.Username == username.ToLower()); //makes sure that the username is unique
            }


    }
}