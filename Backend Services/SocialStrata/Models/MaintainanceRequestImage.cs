using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SocialStrata.Models
{
    public class MaintainanceRequestImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MaintainanceRequestId { get; set; }
        public virtual MaintainanceRequest MaintainanceRequest { get; set; }

          
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

   
    }
}