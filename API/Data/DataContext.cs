using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext 
    {
        
        public DataContext([NotNullAttribute] DbContextOptions options) : base(options) //constructor
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}