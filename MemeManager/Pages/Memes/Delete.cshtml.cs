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
using Microsoft.AspNetCore.Identity;
using MemeManager.Authorization;

namespace MemeManager.Pages.Memes
{
    public class DeleteModel : DI_BasePageModel
    {
        public DeleteModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Meme Meme { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Meme = await Context.Meme.FirstOrDefaultAsync(
                                                 m => m.Id == id);

            if (Meme == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Meme,
                                                     MemeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Meme = await Context.Meme.FindAsync(id);

            var meme = await Context
                .Meme.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meme == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, meme,
                                                     MemeOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.Meme.Remove(Meme);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
