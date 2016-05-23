using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using SocialStrata.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace SocialStrata.Models
{
    public class Notice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public virtual ICollection<NoticeImage> Images { get; set; }

        [Required]
        public bool Public { get; set; }


        public Notice()
        {
            Images = new Collection<NoticeImage>();
        }

        
    }
}