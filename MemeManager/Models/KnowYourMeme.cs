using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemeManager.Models
{
    public class KnowYourMeme
    {
        [Key]
        public string Genre { get; set; }

        public string Description { get; set; }
    }
}
