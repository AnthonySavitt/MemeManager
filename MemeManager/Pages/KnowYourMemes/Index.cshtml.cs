using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MemeManager.Data;
using MemeManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace MemeManager.Pages.KnowYourMemes
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly MemeManager.Data.ApplicationDbContext _context;

        public IndexModel(MemeManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<KnowYourMeme> KnowYourMeme { get;set; }

        public async Task OnGetAsync()
        {
            KnowYourMeme = await _context.KnowYourMeme.ToListAsync();
        }
    }
}
