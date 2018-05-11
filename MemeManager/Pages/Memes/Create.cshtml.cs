using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MemeManager.Data;
using MemeManager.Models;
using MemeManager.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MemeManager.Pages.Memes
{
    public class CreateModel : DI_BasePageModel
    {
        //private readonly MemeManager.Data.ApplicationDbContext _context;

            public CreateModel(
                ApplicationDbContext context,
                IAuthorizationService authorizationService,
                UserManager<ApplicationUser> userManager)
                : base(context, authorizationService, userManager)
            {
            }

            public IActionResult OnGet()
            {
                return Page();
            }

            [BindProperty]
            public Meme Meme { get; set; }

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                Meme.OwnerID = UserManager.GetUserId(User);

                // requires using MemeManager.Authorization;
                var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                            User, Meme,
                                                            MemeOperations.Create);
                if (!isAuthorized.Succeeded)
                {
                    return new ChallengeResult();
                }

                Context.Meme.Add(Meme);
                await Context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }
    }
