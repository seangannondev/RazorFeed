using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorFeed.Models;

namespace RazorFeed.Data
{
    public class RazorFeedContext : DbContext
    {
        public RazorFeedContext (DbContextOptions<RazorFeedContext> options)
            : base(options)
        {
        }

        public DbSet<RazorFeed.Models.UserPost> UserPost { get; set; }
    }
}
