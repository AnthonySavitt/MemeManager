using System.Collections.Generic;
using System.Threading.Tasks;
using MemeManager.Data;
using MemeManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MemeManager.Pages
{
    [AllowAnonymous]
    public class ImageGalleryModel : PageModel
    {
        private ApplicationDbContext _context;
        public List<GalleryImage> GalleryImages { get; set; }
        public ImageGalleryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGet()
        {
            ViewData["SuccessMessage"] = TempData["SuccessMessage"];
            GalleryImages = await _context.GalleryImages.ToListAsync();
        }
    }
}