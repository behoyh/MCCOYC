using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using MCCOYC.Models;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace MCCOYC.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text, FirstName = FirstName.Text, LastName = LastName.Text, Birthdate = BirthDate.Text, Gender = Gender.Text, City = City.Text, State = State.Text, AddressLine1 = AddressLine1.Text, AddressLine2 = AddressLine2.Text, ZipCode = ZipCode.Text, HomePhone = HomePhone.Text, CellPhone = CellPhone.Text, ChurchID = Church.SelectedValue, PriestName = PreistName.Text };


            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {

                MailMessage objMail = new MailMessage("mccoyconline@gmail.com", user.UserName, $"Thanks for creating your account, {FirstName.Text}!",
    $@"Thank you {FirstName.Text} for creating your profile on the MCCOYC registration website. Please be sure to log back into mccoyc.azurewebsites.net to complete registration for this years convention.

For more information on the online registration process refer to the instructions section on our home page, or email us at mccoyconline@gmail.com.

Thank You,

The 2016 MCCOYC Committee
");
                NetworkCredential objNC = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                ServicePointManager.ServerCertificateValidationCallback =
                 delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                 { return true; };
                smtp.EnableSsl = true;
                smtp.Credentials = objNC;
                smtp.Send(objMail);

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                manager.AddToRole(user.Id, UserType.SelectedValue);
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                var redirectTo = "/Default.aspx";


                IdentityHelper.RedirectToReturnUrl(redirectTo, Response);

            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}