using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shotly.Models
{
    public class PostViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }

       [Display(Name = "Image")]
        public string? Image { get; set; }


        [Required]
        [Display(Name ="Url")]
        public string? Url { get; set; }
    }
}