using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MemeManager.Data;
using MemeManager.Models;
using MemeManager.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MemeManager.Pages.Memes
{
    public class DetailsModel : DI_BasePageModel
    {
        public DetailsModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public Meme Meme { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Meme = await Context.Meme.FirstOrDefaultAsync(m => m.Id == id);

            if (Meme == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, MemeStatus status)
        {
            var meme = await Context.Meme.FirstOrDefaultAsync(
                                                      m => m.Id == id);

            if (meme == null)
            {
                return NotFound();
            }

            var memeOperation = (status == MemeStatus.Approved)
                                                       ? MemeOperations.Approve
                                                       : MemeOperations.Reject;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, meme,
                                        memeOperation);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }
            meme.Status = status;
            Context.Meme.Update(meme);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
