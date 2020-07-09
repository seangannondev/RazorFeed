using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorFeed.Data;
using RazorFeed.Models;

namespace RazorFeed.Pages
{
    public class CreateModel : PageModel
    {
        private readonly RazorFeed.Data.RazorFeedContext _context;

        public CreateModel(RazorFeed.Data.RazorFeedContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserPost UserPost { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserPost.Add(UserPost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
