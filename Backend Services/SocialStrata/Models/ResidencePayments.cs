using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class ResidencePayments
    {
        public int Id { get; set; }

        [Required]
        public int ResidenceId { get; set; }
        public virtual Residence Residence { get; set; }

        public int PersonCreditCardId { get; set; }
        public virtual PersonCreditCard PersonCreditCard { get; set; }

        public string PayPalToken { get; set; }

        [Required]
        public DateTime PayamentDate { get; set; }

        [Required]
        public double PaidValue { get; set; }
    }
}