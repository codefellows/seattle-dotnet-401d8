using Cohort8CMSProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohort8CMSProject.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext>options):base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
