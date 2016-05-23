using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SocialStrata.Models;
using SocialStrata.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialStrata.Controllers
{
    public class WelcomeController : ApiController
    {
        public class WelcomeDTO
        {
            public string NoticeDescription { get; set; }
            public string EventDescription { get; set; }
        }

        public WelcomeController()
        {

        }

        public IHttpActionResult GetWelcomeScreen()
        {
            using (var db = new ApplicationDbContext())
            {

                var notice = (from n in db.Notices
                              select n).LastOrDefault();

                var evt = (from e in db.Event
                           select e).LastOrDefault();

                
                return Ok(new WelcomeDTO { NoticeDescription = notice.Description, EventDescription = evt.Description });
            }

        }

        //public async Task<RegisterResultDTO> Register(RegisterViewModel model)
        //{
        //    RegisterResultDTO ret = new RegisterResultDTO();

        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        //            ret.UserId = user.Email;
        //            ret.Success = true;

        //            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //            // Send an email with this link
        //            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

        //            return ret;
        //        }

        //        foreach (var error in result.Errors)
        //            ret.Messages += error + "\n";

        //    }

        //    // If we got this far, something failed, redisplay form
        //    return ret;
        //}


    }
}
