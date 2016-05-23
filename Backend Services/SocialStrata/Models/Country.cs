using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class Country
    {
        public int Id { get; set; }
          
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(3)]
        [Required]
        public string Currency { get; set; }


    }
}