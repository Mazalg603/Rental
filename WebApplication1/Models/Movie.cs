using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Movie
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The Name must contain at least 2 characters and a maximum of 50 characters")]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string MovieCategory { get; set; }

        public int MovieId { get; set; }

    }
}