using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FromId { get; set; }
        public virtual Person From { get; set; }

        public int ToId { get; set; }
        public virtual Person To { get; set; }

        [Required]
        public DateTime PublishiedDate { get; set; }

        [Required]
        public bool Private { get; set; }

        [Required]
        [MaxLength(127)]
        public string Mensage { get; set; }

        [Required]
        public bool IsRead { get; set; }

    }
}