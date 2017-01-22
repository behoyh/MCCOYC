using MCCOYC.Migrations;
using MCCOYC.Models;
using MCCOYC.UserRoleControllers.Youth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using static MCCOYC.Models.ApplicationDbContext;

namespace MCCOYC
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            if (User.IsInRole("Youth"))
            {

                using (var db = new ApplicationDbContext())
                {

                    DateTime today = DateTime.Now;
                    TimeSpan age = today - DateTime.Parse(user.Birthdate);

                    if (age.TotalDays >= 6570)
                    {
                        var YO = db.YouthRegistration.Where(s => s.Year == DateTime.Now.Year && s.UserID == user.Id).FirstOrDefault();
                        if (YO != null)
                        {
                            Register.Enabled = false;
                            Register.Text = $"Awaiting Parental Copmpletion of Application";
                        }
                        else
                        {
                            Register.Text = $"Start Registration for {DateTime.Now.Year} »";
                            Register.PostBackUrl = "/UserRoleControllers/Youth/Youth Registration.aspx";
                        }
                    }
                    else
                    {
                        Register.Text = "Register Myself »";
                        Register.PostBackUrl = "/UserRoleControllers/Parent/Parent Registration.aspx?Self=\"true\"";
                    }
                }
            }
            if (User.IsInRole("Servant"))
            {
                Register.Text = "Register Myself »";
                Register.PostBackUrl = "/UserRoleControllers/Parent/Parent Registration.aspx?Self=\"true\"";


                using (var db = new ApplicationDbContext())
                {
                    var YO = db.YouthRegistration.Where(s => s.UserID == user.Id && s.Year == DateTime.Now.Year).FirstOrDefault();


                    if (YO != null)
                    {
                        if (YO.WaiverConfirm)
                        {
                            Register.Text = "View Registration »";
                        }
                    }
                }

            }
            if (User.IsInRole("Parent"))
            {
                Register.Text = "Register New Youth »";
                Register.PostBackUrl = "/UserRoleControllers/Parent/Parent Registration.aspx";

                RegisterSelf.Visible = true;
                RegisterSelf.Text = "Register Myself »";
                RegisterSelf.PostBackUrl = "/UserRoleControllers/Parent/Parent Registration.aspx?Self=\"true\"";

                using (var db = new ApplicationDbContext())
                {
                    var YO = db.YouthRegistration.Where(s => s.UserID == user.Id && s.Year == DateTime.Now.Year).FirstOrDefault();


                    if (YO != null)
                    {
                        if (YO.WaiverConfirm)
                        {
                            Register.Text = "View Registration »";
                        }
                    }
                }
            }
            if (User.IsInRole("ChurchAdmin"))
            {
                Register.Text = "New Registration »";
                Register.PostBackUrl = "/UserRoleControllers/Parent/Parent Registration.aspx";
            }
            if (User.IsInRole("Admin"))
            {

            }
        }

        protected void ApproveYouth(object sender, EventArgs e)
        {
            if (User.IsInRole("ChurchAdmin"))
            {
                CheckBox btn = (CheckBox)sender;

                string UserId = btn.Text;

                using (var db = new ApplicationDbContext())
                {
                    var YR = db.YouthRegistration.Where(yr => yr.ParentAuth == true && yr.UserID.ToString().ToLower() == UserId.ToLower()).FirstOrDefault();

                    YR.AdminAuth = true;

                    db.SaveChanges();

                }


            }
        }
    }
}