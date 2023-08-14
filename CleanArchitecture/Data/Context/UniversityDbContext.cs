using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options):base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
