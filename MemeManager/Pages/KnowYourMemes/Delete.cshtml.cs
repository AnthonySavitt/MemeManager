using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MemeManager.Data;
using MemeManager.Models;

namespace MemeManager.Pages.KnowYourMemes
{
    public class DeleteModel : PageModel
    {
        private readonly MemeManager.Data.ApplicationDbContext _context;

        public DeleteModel(MemeManager.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KnowYourMeme = await _context.KnowYourMeme.FindAsync(id);

            if (KnowYourMeme != null)
            {
                _context.KnowYourMeme.Remove(KnowYourMeme);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
