using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class PersonCreditCard
    {
        public int Id { get; set; }

        [Required]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        [Required]
        [MaxLength(12)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(6)]
        public string SecurityCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}