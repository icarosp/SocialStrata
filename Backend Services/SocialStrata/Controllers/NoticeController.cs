using SocialStrata.Models;
using SocialStrata.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialStrata.Controllers
{
    public class NoticesController : ApiController
    {


        public NoticesController()
        {

        }

        public IEnumerable<NoticeDTO> GetAllNotices()
        {
            using (var db = new ApplicationDbContext())
            {
                var q = from n in db.Notices
                        select new NoticeDTO()
                        {
                            Id = n.Id,
                            Title = n.Title,
                            Description = n.Description,
                        };

                return q.ToList();
            }
            
        }

        public IHttpActionResult GetNotice(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var q = (from n in db.Notices where n.Id == id
                        select new NoticeDTO()
                            {
                                Id = n.Id,
                                Title = n.Title,
                                Description = n.Description,
                            }).FirstOrDefault();

                if (q == null)
                {
                    return NotFound();
                }
                return Ok(q);

            }

        }

        public IHttpActionResult GetConnection()
        {
            
            return Ok(new ApplicationDbContext().ConnectionString());
        }

        public IHttpActionResult GetHomeNotice()
        {
            using (var db = new ApplicationDbContext())
            {
                var q = (from n in db.Notices
                        select new NoticeDTO()
                        {
                            Id = n.Id,
                            Title = n.Title,
                            Description = n.Description,
                        }).FirstOrDefault();

                if (q == null)
                {
                    return NotFound();
                }
                return Ok(q);

            }
        }

    }
}
