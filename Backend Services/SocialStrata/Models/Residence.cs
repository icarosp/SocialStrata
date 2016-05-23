using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class Residence
    {
        [Key]
        public int ResidenceId { get; set; }

        public int LivingPersonInId { get; set; }
        public virtual Person LivingPersonIn { get; set; }

        public int LandlordPersonId { get; set; }
        public virtual Person LandlordPerson { get; set; }

        [Required]
        [MaxLength(30)]
        public string Description { get; set; }

        [MaxLength(30)]
        public string ActiveContractId { get; set; }

        [MaxLength(80)]
        public string Address { get; set; }

        [Required]
        public bool LivingLandlord { get; set; }

        [Required]
        public int ResidenceTypeId { get; set; }
        public virtual ResidenceType ResidenceType { get; set; }

        [Required]
        public bool Rented { get; set; }

        [Required]
        public double RentVal { get; set; }

    }
}