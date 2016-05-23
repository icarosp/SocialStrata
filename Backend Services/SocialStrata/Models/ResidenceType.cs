using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class ResidenceType
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "You need enter the service name")]
        public string Description { get; set; }

        public virtual ICollection<Residence> Residences { get; set; }

        public  ResidenceType()
        {
            this.Residences = new HashSet<Residence>();
        }
    }
}