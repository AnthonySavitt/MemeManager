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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MemeManager.Pages.Memes
{
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        //Added these sorts to contain sorting parameters
        public string NameSort { get; set; }
        public string GenreSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        //Just Above

        public IList<Meme> Meme { get; set; }
        //public PaginatedList<Meme> Meme2 { get; set; }

        //Added (sortOrder) parameter. Wow it worked
        //Adding (searchString) paramter now. Wow it worked!
        //Adding pageIndex now for Page Functionality
        public async Task OnGetAsync(string sortOrder, string searchString)// int? pageIndex, string currentFilter)
        {
            var meme = from c in Context.Meme
                           select c;

            var isAuthorized = User.IsInRole(Constants.MemeManagersRole) ||
                               User.IsInRole(Constants.MemeAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            // Only approved meme are shown UNLESS you're authorized to see them
            // or you are the owner.
            if (!isAuthorized)
            {
                meme = meme.Where(c => c.Status == MemeStatus.Approved
                                            || c.OwnerID == currentUserId);
            }

            //Added below is to receive a sortORder paramter from
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            GenreSort = sortOrder == "Genre" ? "genre_desc" : "Genre";

            /*
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            */

            CurrentFilter = searchString;

            IQueryable<Meme> memeIQ = from s in Context.Meme
                                            select s;

            //Added to LINQ statement. Select only the title 
            //or genere that is contained in the searchstring
            if (!String.IsNullOrEmpty(searchString))
            {
                memeIQ = memeIQ.Where(s => s.Title.Contains(searchString)
                                       || s.Genre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    memeIQ = memeIQ.OrderByDescending(s => s.Title);
                    break;
                case "Genre":
                    memeIQ = memeIQ.OrderBy(s => s.Genre);
                    break;
                case "genre_desc":
                    memeIQ = memeIQ.OrderByDescending(s => s.Genre);
                    break;
                default:
                    memeIQ = memeIQ.OrderBy(s => s.Title);
                    break;
            }

            
           // int pageSize = 3;
           // Meme = await PaginatedList<Meme>.CreateAsync(
              //  memeIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            //can I have 2 of these? REmove memeIQ if does't work...
            Meme = await meme.ToListAsync();
            Meme = await memeIQ.AsNoTracking().ToListAsync();
        }

        /*Trying to figure out how to make it so after the user uploads their meme, removes the meme suggestions 
         * Perhaps might be better suited for the 'imageuploadform.cshtml.cs..'
         * 
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
        */
    }
}
