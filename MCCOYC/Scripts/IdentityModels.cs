using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MCCOYC.Models;
using System.Data.Entity;
using RestSharp;
using RestSharp.Authenticators;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;

namespace MCCOYC.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string ChurchID { get; set; }
        public string PriestName { get; set; }


        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<YouthRegistration> YouthRegistration { get; set; }
        public virtual DbSet<Room> Room { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}

public class Room
{
    public int ID { get; set; }
    public string UserID1 { get; set; }
    public string UserID2 { get; set; }
}

public class YouthRegistration
{
    public int ID { get; set; }
    public string UserID { get; set; }
    public string ParentEmail { get; set; }
    public string ShirtSize { get; set; }
    public int? RoomID { get; set; }
    public string MedicalHistory { get; set; }
    public string Medications { get; set; }
    public string Allergies { get; set; }
    public string EmergencyName { get; set; }
    public string EmergencyRelationship { get; set; }
    public string EmergencyPhone { get; set; }
    public string MedicalInsuranceCompanies { get; set; }
    public string PolicyNumber { get; set; }
    public string Group { get; set; }
    public string MedicalInitial { get; set; }
    public string DamageInitial { get; set; }
    public string WaiverInitial { get; set; }
    public bool WaiverConfirm { get; set; }
    public string Signature { get; set; }
    public int Year { get; set; }
    public bool ParentAuth { get; set; }
    public bool AdminAuth { get; set; }
    public string RobereProperty { get; set; }
}

#region Helpers
namespace MCCOYC
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, System.Web.HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }

        public static async Task<bool> SendEmail(string email, string subject, string text)
        {
            try
            {

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes("api" + ":" + "key-e2723a53c2fae1b010f951a555a4b197")));


                var form = new Dictionary<string, string>();
                form["from"] = "MCCOYC <postmaster@sandbox5b9301387a754f5caa73941a91df6ff5.mailgun.org>";
                form["to"] = $"{email}";
                form["subject"] = subject;
                form["text"] = text;


                var response = await client.PostAsync("https://api.mailgun.net/v3/" + "sandbox5b9301387a754f5caa73941a91df6ff5.mailgun.org" + "/messages", new FormUrlEncodedContent(form));

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception!" + " " + ex.Message);
            }
        }

        public class Email
        {
            public string To { get; set; }
            public string Subject { get; set; }
            public string Text { get; set; }
        }
    }
}
#endregion
