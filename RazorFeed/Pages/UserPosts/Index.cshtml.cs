using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFeed.Data;
using RazorFeed.Models;

namespace RazorFeed.Pages.UserPosts
{
    public class IndexModel : PageModel
    {
        private readonly RazorFeed.Data.RazorFeedContext _context;

        public IndexModel(RazorFeed.Data.RazorFeedContext context)
        {
            _context = context;
        }

        public IList<UserPost> UserPost { get;set; }

        public async Task OnGetAsync()
        {
            UserPost = await _context.UserPost.ToListAsync();
        }
    }
}
