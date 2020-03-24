using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElipgoBE.Models;

namespace ElipgoBE.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<ArticlesInformation> Articles { get; set; }
        public DbSet<StoresInformation> Stores { get; set; }
        public DbSet<LoginModel> Login { get; set; }
    }
}
 