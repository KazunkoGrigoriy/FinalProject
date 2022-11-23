using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.AppUsers;

namespace Website.DbDataContext
{
    public class DbDataUsers : DbContext
    {
        public DbDataUsers(DbContextOptions options) : base(options) {}

        public DbSet<User> Users { get; set; }
    }
}
