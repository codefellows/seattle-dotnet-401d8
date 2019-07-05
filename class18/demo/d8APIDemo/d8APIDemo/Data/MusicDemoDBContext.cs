using d8APIDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d8APIDemo.Data
{
    public class MusicDemoDBContext : DbContext
    {
        public MusicDemoDBContext(DbContextOptions<MusicDemoDBContext> options): base(options)
        {
            
        }

        public DbSet<Song> Songs { get; set; }
    }
}
