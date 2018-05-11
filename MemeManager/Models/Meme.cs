using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemeManager.Models
{
    public class Meme
    {
        public int Id { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        public MemeStatus Status { get; set; }

        //Connects to GaleryImage Model which has ability to display images
        public GalleryImage Image { get; set; }
    }
    public enum MemeStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
