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
    public class DetailsModel : PageModel
    {
        private readonly MemeManager.Data.ApplicationDbContext _context;

        public DetailsModel(MemeManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
