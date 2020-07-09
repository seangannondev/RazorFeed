using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFeed.Data;
using RazorFeed.Models;

namespace RazorFeed.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly RazorFeed.Data.RazorFeedContext _context;

        public DetailsModel(RazorFeed.Data.RazorFeedContext context)
        {
            _context = context;
        }

        public UserPost UserPost { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserPost = await _context.UserPost.FirstOrDefaultAsync(m => m.Id == id);

            if (UserPost == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
