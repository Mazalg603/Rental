using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Customer
    {
      
        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The Name must contain at least 2 characters and a maximum of 50 characters")]
        [Display(Name = "Customer Name")]
        public string CustomersName { get; set; }

        
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Customer Subscription")]
        public string CustomersSubscription { get; set; }

       
        [Required(ErrorMessage = "This field is required")]
        [Range(18, 120, ErrorMessage = "Sorry, you must be bigger than 18 ")]
        [Display(Name = "Customer Age")]
        public int CustomersAge { get; set; }
    }
}