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

namespace MCCOYC.UserRoleControllers.ChurchAdmin
{
    public partial class ChurchAdmin_Review : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            string RegisterID = Request.QueryString["RegisterID"];
            manager.FindById(User.Identity.GetUserId());

            YouthRegistration Register = null;
            if (RegisterID != null)
            {

                ApproveBtn.CommandArgument = RegisterID;
                ApproveBtn.CommandName = "Approve";
                RejectBtn.CommandArgument = RegisterID;
                RejectBtn.CommandName = "Reject";

                var inty = Int32.Parse(RegisterID);

                using (var db = new ApplicationDbContext())
                {
                    Register = db.YouthRegistration.Where(yr => yr.ID == inty).FirstOrDefault();
                }

               
                var RegisterUser = manager.FindById(Register.UserID);

                if (RegisterUser != null && Register != null)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        Email.Text = RegisterUser.Email;
                        FirstName.Text = RegisterUser.FirstName;
                        LastName.Text = RegisterUser.LastName;
                        BirthDate.Text = RegisterUser.Birthdate;
                        Gender.SelectedValue = RegisterUser.Gender;
                        City.Text = RegisterUser.City;
                        State.Text = RegisterUser.State;
                        AddressLine1.Text = RegisterUser.AddressLine1;
                        AddressLine2.Text = RegisterUser.AddressLine2;
                        ZipCode.Text = RegisterUser.ZipCode;
                        CellPhone.Text = RegisterUser.CellPhone;
                        HomePhone.Text = RegisterUser.HomePhone;
                        Church.SelectedValue = RegisterUser.ChurchID;
                        PreistName.Text = RegisterUser.PriestName;
                        //UserType.SelectedValue = RegisterUser.Roles.FirstOrDefault().RoleId;
                        TShirtSize.Text = Register.ShirtSize;
                        RoomID.Text = Register.RoomID.ToString();
                        MedicalHistory.Text = Register.MedicalHistory;
                        Medications.Text = Register.Medications;
                        Allergies.Text = Register.Allergies;
                        EmergencyPhone.Text = Register.EmergencyPhone;
                        MedicalCo.Text = Register.MedicalInsuranceCompanies;
                        PolicyNo.Text = Register.PolicyNumber;
                        MI.Text = Register.MedicalInitial;
                        DI.Text = Register.DamageInitial;
                        WI.Text = Register.WaiverInitial;
                        WaiverConfirm.Checked = Register.WaiverConfirm;
                        Signature.Text = Register.Signature;

                    }
                }

            }
            else
            {
                ErrorMessage.Text = "Error! Please go back to MCCOYC Registration Home and try again.";
            }
        }


        protected void ApproveReject(object sender, EventArgs e)
        {

            Button BIsForBeshoy = (Button)sender;
            var RegisterId = BIsForBeshoy.CommandArgument;
            var Action = BIsForBeshoy.CommandName;

            using (var db = new ApplicationDbContext())
            {
                var inty = Int32.Parse(RegisterId);
                var registration = db.YouthRegistration.Where(yr => yr.ID == inty).FirstOrDefault();
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(User.Identity.GetUserId());
                var approveUser = manager.FindById(registration.UserID);

                ApplicationUser parentUser = null;
                if (registration.UserID != null)
                {
                    parentUser = manager.FindById(registration.UserID);
                }

                switch (Action)
                {
                    case "Approve":
                        registration.AdminAuth = true;


                        MailMessage objMail = new MailMessage("mccoyconline@gmail.com", parentUser.Email, $"{ approveUser.Email } was approved to go to MCCOYC { DateTime.Now.Year}.", $"If you have not paid the registration fee already, please do so before attending MCCOYC {DateTime.Now.Year}");
                        NetworkCredential objNC = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        ServicePointManager.ServerCertificateValidationCallback =
                         delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                         { return true; };
                        smtp.EnableSsl = true;
                        smtp.Credentials = objNC;
                        smtp.Send(objMail);

                        MailMessage objMail2 = new MailMessage("mccoyconline@gmail.com", user.Email, $"{ approveUser.Email } was approved to go to MCCOYC { DateTime.Now.Year}.", $"You have just approved {approveUser.Email} for MCCOYC {DateTime.Now.Year}.");
                        NetworkCredential objNC2 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                        SmtpClient smtp2 = new SmtpClient("smtp.gmail.com", 587);
                        smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
                        ServicePointManager.ServerCertificateValidationCallback =
                         delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                         { return true; };
                        smtp2.EnableSsl = true;
                        smtp2.Credentials = objNC2;
                        smtp2.Send(objMail2);

                        if (registration.UserID != null)
                        {

                            MailMessage objMail3 = new MailMessage("mccoyconline@gmail.com", user.Email, $"Hi {approveUser.FirstName}! You were approved to go to MCCOYC { DateTime.Now.Year}.", $"You have just been approved for MCCOYC {DateTime.Now.Year}. Please remember to pay before the bus leaves!");
                            NetworkCredential objNC3 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                            SmtpClient smtp3 = new SmtpClient("smtp.gmail.com", 587);
                            smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
                            ServicePointManager.ServerCertificateValidationCallback =
                             delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                             { return true; };
                            smtp3.EnableSsl = true;
                            smtp3.Credentials = objNC3;
                            smtp3.Send(objMail3);
                        }
                        break;
                    case "Reject":
                        registration.AdminAuth = false;


                        MailMessage objMail4 = new MailMessage("mccoyconline@gmail.com", parentUser.Email,
                            $" { approveUser.Email } was not approved to go to MCCOYC { DateTime.Now.Year}", $"Please sign in to MCCOYC Registration Home mccoyc.azurewebsites.net to correct / add additional information.");
                        NetworkCredential objNC4 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                        SmtpClient smtp4 = new SmtpClient("smtp.gmail.com", 587);
                        smtp4.DeliveryMethod = SmtpDeliveryMethod.Network;
                        ServicePointManager.ServerCertificateValidationCallback =
                         delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                         { return true; };
                        smtp4.EnableSsl = true;
                        smtp4.Credentials = objNC4;
                        smtp4.Send(objMail4);


                        MailMessage objMail7 = new MailMessage("mccoyconline@gmail.com", user.Email, $"{ approveUser.Email } was not approved to go to MCCOYC { DateTime.Now.Year}.                     !", $"You have just rejected {approveUser.Email} for MCCOYC {DateTime.Now.Year}.");
                        NetworkCredential objNC7 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                        SmtpClient smtp7 = new SmtpClient("smtp.gmail.com", 587);
                        smtp7.DeliveryMethod = SmtpDeliveryMethod.Network;
                        ServicePointManager.ServerCertificateValidationCallback =
                         delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                         { return true; };
                        smtp7.EnableSsl = true;
                        smtp7.Credentials = objNC7;
                        smtp7.Send(objMail7);

                        if (registration.UserID != null)
                        {
                            MailMessage objMail8 = new MailMessage("mccoyconline@gmail.com", user.Email, $"You were not approved to go to MCCOYC { DateTime.Now.Year}", $"Please re-rergister at mccoyc.azurewebsites.net");
                            NetworkCredential objNC8 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                            SmtpClient smtp8 = new SmtpClient("smtp.gmail.com", 587);
                            smtp8.DeliveryMethod = SmtpDeliveryMethod.Network;
                            ServicePointManager.ServerCertificateValidationCallback =
                             delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                             { return true; };
                            smtp8.EnableSsl = true;
                            smtp8.Credentials = objNC8;
                            smtp8.Send(objMail8);
                        }
                        break;
                    default:
                        ErrorMessage.Text = "YOOOO! Error!!!";
                        break;
                }

                db.SaveChanges();
            }
        }
    }
}
