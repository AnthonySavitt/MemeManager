using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MemeManager.Data;
using MemeManager.Models;

namespace MemeManager.Pages.KnowYourMemes
{
    public class CreateModel : PageModel
    {
        private readonly MemeManager.Data.ApplicationDbContext _context;

        public CreateModel(MemeManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KnowYourMeme KnowYourMeme { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.KnowYourMeme.Add(KnowYourMeme);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}