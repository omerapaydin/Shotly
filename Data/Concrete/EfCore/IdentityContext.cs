using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shotly.Entity;

namespace Shotly.Data.Concrete.EfCore
{
    public class IdentityContext:IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options ) :base(options)
        {
            
        }

            public DbSet<Post> Posts => Set<Post>();
            public DbSet<Comment> Comments => Set<Comment>();



    }
}