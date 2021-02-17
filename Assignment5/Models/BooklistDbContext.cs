using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class BooklistDbContext : DbContext
    {
        //This is how we are querying the database
        public BooklistDbContext(DbContextOptions<BooklistDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        
    }
}
