using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class LostAndFound
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(25)]
        public string Item { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public bool IsLost { get; set; }

        [Required]
        public bool WasFound { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string GeoLocalization { get; set; }

        public int WasLostForId { get; set; }
        public virtual Person WasLostFor { get; set; }

        public int WasFoundForId { get; set; }
        public virtual Person WasFoundFor { get; set; }
    
    }
}