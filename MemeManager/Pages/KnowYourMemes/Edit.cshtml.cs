using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MemeManager.Data;
using MemeManager.Models;

namespace MemeManager.Pages.KnowYourMemes
{
    public class EditModel : PageModel
    {
        private readonly MemeManager.Data.ApplicationDbContext _context;

        public EditModel(MemeManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KnowYourMeme KnowYourMeme { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KnowYourMeme = await _context.KnowYourMeme.SingleOrDefaultAsync(m => m.Genre == id);

            if (KnowYourMeme == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(KnowYourMeme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnowYourMemeExists(KnowYourMeme.Genre))
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

        private bool KnowYourMemeExists(string id)
        {
            return _context.KnowYourMeme.Any(e => e.Genre == id);
        }
    }
}
