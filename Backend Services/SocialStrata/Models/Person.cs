using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SocialStrata.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(128)]
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        [Required]
        public bool IsLandlord { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
      
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string EmailAddess { get; set; }

        [Required]
        public string PayPalAccount { get; set; }


        //[Required(ErrorMessage = "We need your Social insurance number to tax report")]
        //public string SIN { get; set; } // Social insurance number



    }
}