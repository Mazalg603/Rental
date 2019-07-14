using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Rental
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The Costomer Name must contain at least 2 characters and a maximum of 50 characters")]
        [Display(Name = "Costomer Name")]
        public string CostomerName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The Movie Name must contain at least 2 characters and a maximum of 50 characters")]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        public int ID { get;  set; }

    }
}