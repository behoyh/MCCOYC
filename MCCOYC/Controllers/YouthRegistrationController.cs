using MCCOYC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MCCOYC.Controllers
{
    [RoutePrefix("api")]
    public class YouthRegistrationController : ApiController
    {
        [AcceptVerbs("GET")]
        [Route("YouthParentConfirm")]
        public IHttpActionResult getPreRegisteredYouthForParentApproval()
        {
            List<object> NO = new List<object>();
            List<YouthRegistration> YO = new List<YouthRegistration>();


            ApplicationUser user = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());

            if (User.IsInRole("Parent"))
            {
                using (var db = new ApplicationDbContext())
                {
                    YO = db.YouthRegistration.Where(s => s.ParentEmail == user.Email && s.Year == DateTime.Now.Year).ToList();

                    foreach (var yo in YO)
                    {
                        var no = db.Users.Where(u => u.Id == yo.UserID).SingleOrDefault();
                        if (no != null)
                        {
                            var conf = "";
                            NO.Add(new { path = $"/UserRoleControllers/Parent/Parent Registration.aspx?UserID={no.Id}", Name = no.FirstName + " " + no.LastName, Status = yo.ParentAuth && yo.AdminAuth ? "RET2GO" : conf = yo.ParentAuth == true ? "Parent Confirmed" : "Not Confirmed", Email = no.Email });
                        }
                    }
                }
            }

            if (User.IsInRole("ChurchAdmin"))
            {
                using (var db = new ApplicationDbContext())
                {
                    //Get Youths With Approval Status Parent
                    YO = db.YouthRegistration.Where(s => s.Year == DateTime.Now.Year && s.ParentAuth == true).ToList();


                    foreach (var yo in YO)
                    {
                        var no = db.Users.Where(u => u.Id == yo.UserID && u.ChurchID == user.ChurchID).SingleOrDefault();

                        if (no != null)
                        {
                            var conf = "";
                            NO.Add(new { path = $"/UserRoleControllers/ChurchAdmin/ChurchAdmin Review.aspx?RegisterID={yo.ID}", ID = yo.ID, Name = no.FirstName + no.LastName, Status = yo.ParentAuth && yo.AdminAuth ? "RET2GO" : conf = yo.ParentAuth == true ? "Parent Confirmed" : "Not Confirmed", Email = no.Email, Admin = true });
                        }
                    }
                }
            }
            return Ok(NO);
        }
    }
}
