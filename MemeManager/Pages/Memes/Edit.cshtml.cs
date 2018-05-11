using MemeManager.Authorization;
using MemeManager.Data;
using MemeManager.Models;
using MemeManager.Pages.Memes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MemeManager.Pages.Memes
{
    public class EditModel : DI_BasePageModel
    {
        public EditModel(
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
                                                      MemeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch Meme from DB to get OwnerID.
            var meme = await Context
                .Meme.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meme == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, meme,
                                                     MemeOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Meme.OwnerID = meme.OwnerID;

            Context.Attach(Meme).State = EntityState.Modified;

            if (meme.Status == MemeStatus.Approved)
            {
                // If the meme is updated after approval, 
                // and the user cannot approve,
                // set the status back to submitted so the update can be
                // checked and approved.
                var canApprove = await AuthorizationService.AuthorizeAsync(User,
                                        meme,
                                        MemeOperations.Approve);

                if (!canApprove.Succeeded)
                {
                    meme.Status = MemeStatus.Submitted;
                }
            }

            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool MemeExists(int id)
        {
            return Context.Meme.Any(e => e.Id == id);
        }
    }
}