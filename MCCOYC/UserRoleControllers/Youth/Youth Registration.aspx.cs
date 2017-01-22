using MCCOYC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static MCCOYC.Models.ApplicationDbContext;

namespace MCCOYC.UserRoleControllers.Youth
{
    public partial class Youth_Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void YouthRegistrationSubmit(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            using (var db = new ApplicationDbContext())
            {
                var YouthRegistrationSubmit = new YouthRegistration()
                {
                    UserID = user.Id,
                    ParentEmail = ParentEmail.Text,
                    ShirtSize = TShirtSize.Text,
                    RoomID = Int32.Parse(RoomID.Text),
                    Year = DateTime.Now.Year
                };


                db.YouthRegistration.Add(YouthRegistrationSubmit);
                db.SaveChanges();





                var parent = manager.Users.Where(x => x.Email == ParentEmail.Text).SingleOrDefault();

                if (parent == null)
                {
                    MailMessage objMail3 = new MailMessage("mccoyconline@gmail.com", user.Email, $@"MCCOYC { DateTime.Now.Year} Registration", $@"Thank you for starting your registration for this year's convention.
To continue registration, please have a parent or gaurdian sign up online with {ParentEmail.Text} at: mccoyc.azurewebsites.net/Account/Register.aspx.
Once signed up, your parent will need to click on your name (on the home page) to complete your registration form (insurance, waiver, etc). You will not be registered for the convention until this step is complete and you have paid for the convention at the registration table in church.
The cost of this year's convention is $240. You can give this money to the registration table in the church. 

Thank you,

The MCCOYC Committee");
                    NetworkCredential objNC3 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                    SmtpClient smtp2 = new SmtpClient("smtp.gmail.com", 587);
                    smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
                    ServicePointManager.ServerCertificateValidationCallback =
                     delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                     { return true; };
                    smtp2.EnableSsl = true;
                    smtp2.Credentials = objNC3;
                    smtp2.Send(objMail3);

                    MailMessage objMail4 = new MailMessage("mccoyconline@gmail.com",  ParentEmail.Text, $"Complete MCCOYC Registration for {user.FirstName}.", $@"Your youth has begun the registration process for the 2016 Midwest Christian Coptic Orthodox Youth Convention.
To continue registration, please sign up and login with {ParentEmail.Text} at: mccoyc.azurewebsites.net/Account/Login.aspx. Once logged in, You will need to click on your child's name (on the home page) to complete their registration form. Your youth will not be registered for the convention until this step is complete and you have paid the registration fee.
The cost of this year's convention is $240. You can give this money to the registration table in the church. 

Thank you,

The MCCOYC Committee
");
                    NetworkCredential objNC4 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                    SmtpClient smtp4 = new SmtpClient("smtp.gmail.com", 587);
                    smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
                    ServicePointManager.ServerCertificateValidationCallback =
                     delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                     { return true; };
                    smtp4.EnableSsl = true;
                    smtp4.Credentials = objNC4;
                    smtp4.Send(objMail4);

                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    if (manager.IsInRole(parent.Id, "Parent"))
                    {
                        YouthRegistrationSubmit.UserID = parent.Id;

                        MailMessage objMail3 = new MailMessage("mccoyconline@gmail.com", user.Email, $@"MCCOYC { DateTime.Now.Year} Registration", $@"Thank you for starting your registration for this year's convention.
To continue registration, please have a parent or gaurdian sign up online with {parent.Email} at: mccoyc.azurewebsites.net/Account/Register.aspx.
Once signed up, your parent will need to click on your name (on the home page) to complete your registration form (insurance, waiver, etc). You will not be registered for the convention until this step is complete and you have paid for the convention at the registration table in church.
The cost of this year's convention is $240. You can give this money to the registration table in the church. 

Thank you,

The MCCOYC Committee");
                        NetworkCredential objNC3 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                        SmtpClient smtp2 = new SmtpClient("smtp.gmail.com", 587);
                        smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
                        ServicePointManager.ServerCertificateValidationCallback =
                         delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                         { return true; };
                        smtp2.EnableSsl = true;
                        smtp2.Credentials = objNC3;
                        smtp2.Send(objMail3);

                        MailMessage objMail4 = new MailMessage("mccoyconline@gmail.com", parent.Email, $"Complete MCCOYC Registration for {user.FirstName}.", $@"Your youth has begun the registration process for the 2016 Midwest Christian Coptic Orthodox Youth Convention.
To continue registration, please sign up and login with {parent.Email} at: mccoyc.azurewebsites.net/Account/Login.aspx. Once logged in, You will need to click on your child's name (on the home page) to complete their registration form. Your youth will not be registered for the convention until this step is complete and you have paid the registration fee.
The cost of this year's convention is $240. You can give this money to the registration table in the church. 

Thank you,

The MCCOYC Committee
");
                        NetworkCredential objNC4 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                        SmtpClient smtp4 = new SmtpClient("smtp.gmail.com", 587);
                        smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
                        ServicePointManager.ServerCertificateValidationCallback =
                         delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                         { return true; };
                        smtp4.EnableSsl = true;
                        smtp4.Credentials = objNC4;
                        smtp4.Send(objMail4);
                    }
                    else
                    {
                        ErrorMessage.Text = "Parent email is associated with a non-parent account";
                    }
                }
            }

        }

        protected void CheckID_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                int RoomI = 0;

                if (Int32.TryParse(RoomID.Text, out RoomI))
                {
                    var Room = db.Room.Where(r => r.ID == RoomI).FirstOrDefault();

                    if (Room != null)
                    {
                        Room.UserID2 = User.Identity.GetUserId();
                    }
                    else
                    {
                        RoomID.Text = "RoomID not found.";
                    }
                }
                else
                {
                    RoomID.Text = "Input a number.";
                }
            }
        }

        protected void NewID_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                var Room = new Room();


                Room.UserID1 = User.Identity.GetUserId();
                db.Room.Add(Room);
                db.SaveChanges();
                RoomID.Text = Room.ID.ToString();

            }
        }
    }
}