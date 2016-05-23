using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class NoticeImage
    {
        [Key]
        public int NoticeImageId { get; set; }

        public int NoticeId { get; set; }

        public virtual Notice Notice { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        public NoticeImage(int noticeImageId, int noticeId, string imageUrl, string description)
        {
            NoticeImageId = NoticeImageId;
            NoticeId = noticeId;
            ImageUrl = imageUrl;
            Description = description;
            this.Notice = new Notice();

        }

        public  NoticeImage()
        {
            this.Notice = new Notice();
        }
    }
}