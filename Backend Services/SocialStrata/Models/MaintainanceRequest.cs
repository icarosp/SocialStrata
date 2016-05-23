using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class MaintainanceRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int ResidenceId { get; set; }
        public virtual Residence Residence { get; set; }

        public virtual ICollection<MaintainanceRequestImage> MaintainanceRequestImages { get; set; }

        public MaintainanceRequest()
        {
            this.MaintainanceRequestImages = new HashSet<MaintainanceRequestImage>();
        }
    }
}