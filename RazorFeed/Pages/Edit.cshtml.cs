using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorFeed.Data;
using RazorFeed.Models;

namespace RazorFeed.Pages
{
    public class EditModel : PageModel
    {
        private readonly RazorFeed.Data.RazorFeedContext _context;

        public EditModel(RazorFeed.Data.RazorFeedContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPostExists(UserPost.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserPostExists(int id)
        {
            return _context.UserPost.Any(e => e.Id == id);
        }
    }
}
