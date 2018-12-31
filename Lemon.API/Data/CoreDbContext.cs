using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lemon.API.Models;

namespace Lemon.API.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }
        public DbSet<Lemon.API.Models.BlogModel> BlogModel { get; set; }
        public DbSet<Lemon.API.Models.ReplyModel> ReplyModel { get; set; }
        public DbSet<UserModel> userModels { get; set; }
    }
}
