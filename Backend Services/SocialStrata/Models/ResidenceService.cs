using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class ResidenceService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ResidenceId { get; set; }
        public virtual Residence Residence { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public bool IsPaid { get; set; }

        public double FinalValue { get; set; }

    }
}