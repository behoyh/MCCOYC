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

namespace MCCOYC.UserRoleControllers.Parent
{
    public partial class Parent_Registration : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            UserType.SelectedValue = "Youth";
            UserTypeColumn.Visible = false;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            string UserID = Request.QueryString["UserID"];
            string Self = Request.QueryString["Self"];

            var user = manager.FindById(User.Identity.GetUserId());





            var WaiverStuff = $@"As Consideration for being allowed to attend and/or Participate in any program or recreational activities, the undersigned, on his or her behalf, and on the behalf of the Participant(s) identified below, acknowledges, appreciates, understands, and agrees to the following:  1.  I represent that I am the parent or legal guardian of the Participant(s) named below or I have obtained permission from the parent/legal guardian of the Participant(s) named below to execute this agreement on their behalf.  ";

            var MedicalStuff = $@"I, {user.FirstName} {user.LastName}, give my son/daughter, _______________, permission to attend the Midwest Christian 
                                            Coptic Orthodox Youth Convention.  I hereby authorize the leaders of the convention to act for me according to their best 
                                            judgment in an emergency requiring medical attention and I agree to take responsibility for the expense of such procedure. 
                                            I understand the Convention and Bowling Green State University will not be responsible for any accident or injury and are held 
                                             harmless of any liabilities. See Thirty-Second Annual Midwest Christian Coptic Orthodox Youth Convention, Waiver, Release, 
                                            Hold Harmless & Indemnity Agreement that is incorporated herein by reference.
                                            I, {user.FirstName} {user.LastName}, the undersigned, am also responsible for any damage my son/daughter, _______________, 
                                            would cause during their stay, and I understand that there are rules and guidelines, my son/daughter has to follow.";

            var DamageStuff = $@"2:  I acknowledge and understand that there are known and unknown risks associated with participation in the attendance and participation in any Youth Programs or recreational activities, including but not limited to: contusions, fractures, scraped, cuts, bumps, paralysis, or death.  3: I, for myself and the Participant(s) named, willingly assume the risks associated with participation and accept that there are also risks that may arise due to OTHER PARTICIPANTS which I also willingly assume.  4:  I agree that the Participant(s) named, and I shall comply with all stated and customary terms, posted safety signs, rules, and verbal instructions as conditions for participation in any programs or recreational activities.   5:  I, for myself, the Participant(s) named, our heirs, assigns, representatives, and next of kin agree to hold harmless, release, waive and indemnify all participating Coptic Orthodox Churches, their predecessors, parent subsidiaries, and affiliates, officers and employees from any and all injuries, liabilities or damages from participation in any programs or recreational activities / volunteers.  6:  I additionally agree to indemnify all participating Coptic Orthodox Churches, their predecessors, parent, subsidiaries, and affiliates, officers, and employees for any defense cost or expense arising from any and all claims, injuries, liabilities or damages arising from participation, in any program or recreational activities.  7:  I am of physical ability to participate and am legally competent to understand and complete this agreement.I hereby execute this agreement without coercion.  8:  The invalidity or unenforceability of any provisions of this Agreement shall not affect the validity or enforceability of any other provision of this Agreement, which shall remain in full force and effect.  9:  Any controversy, dispute, or claim arising out of or related to this Agreement, which the parties are unable to resolve by mutual agreement, shall be settled exclusively by submission by either party of the controversy, claim or dispute to binding arbitration in Cuyahoga County in accordance with the rules of the American Arbitration Association then in effect. ";






            if (!String.IsNullOrEmpty(UserID))
            {
                if (User.IsInRole("Youth") || User.IsInRole("Parent"))
                {
                    UserType.SelectedValue = "Youth";
                    UserTypeColumn.Visible = false;
                }

                else
                {
                    UserType.SelectedValue = "Servant";
                }

                using (var db = new ApplicationDbContext())
                {
                    var YO = db.YouthRegistration.Where(s => s.UserID == UserID && s.Year == DateTime.Now.Year).FirstOrDefault();
                    var NO = db.Users.Where(u => u.Id == UserID).SingleOrDefault();
                    Email.Text = NO.Email;
                    FirstName.Text = NO.FirstName;
                    LastName.Text = NO.LastName;
                    BirthDate.Text = NO.Birthdate;
                    Gender.SelectedValue = NO.Gender;
                    City.Text = NO.City;
                    State.Text = NO.State;
                    AddressLine1.Text = NO.AddressLine1;
                    AddressLine2.Text = NO.AddressLine2;
                    ZipCode.Text = NO.ZipCode;
                    CellPhone.Text = NO.CellPhone;
                    HomePhone.Text = NO.HomePhone;
                    Church.SelectedValue = NO.ChurchID;
                    PreistName.Text = NO.PriestName;

                    if (YO != null)
                    {
                        if (YO.WaiverConfirm)
                        {
                            RoomID.Text = YO.RoomID.ToString();
                            TShirtSize.Text = YO.ShirtSize;
                            MedicalHistory.Text = YO.MedicalHistory;
                            Medications.Text = YO.Medications;
                            Allergies.Text = YO.Allergies;
                            EmergencyName.Text = YO.EmergencyName;
                            EmergencyRelationship.Text = YO.EmergencyRelationship;
                            EmergencyPhone.Text = YO.EmergencyPhone;
                            MedicalCo.Text = YO.MedicalInsuranceCompanies;
                            PolicyNo.Text = YO.PolicyNumber;
                            Group.Text = YO.Group;
                            DI.Text = YO.DamageInitial;
                            MI.Text = YO.MedicalInitial;
                            WI.Text = YO.WaiverInitial;
                            WaiverConfirm.Checked = YO.WaiverConfirm;
                            Signature.Text = YO.Signature;

                            RoomID.Enabled = false;
                            TShirtSize.Enabled = false;
                            MedicalHistory.Enabled = false;
                            Medications.Enabled = false;
                            Allergies.Enabled = false;
                            EmergencyName.Enabled = false;
                            EmergencyRelationship.Enabled = false;
                            EmergencyPhone.Enabled = false;
                            MedicalCo.Enabled = false;
                            PolicyNo.Enabled = false;
                            Group.Enabled = false;
                            DI.Enabled = false;
                            MI.Enabled = false;
                            WI.Enabled = false;
                            WaiverConfirm.Enabled = false;
                            Signature.Enabled = false;
                            submitBtn.Enabled = false;

                            Email.Enabled = false;
                            FirstName.Enabled = false;
                            LastName.Enabled = false;
                            BirthDate.Enabled = false;
                            Gender.Enabled = false;
                            City.Enabled = false;
                            State.Enabled = false;
                            AddressLine1.Enabled = false;
                            AddressLine2.Enabled = false;
                            ZipCode.Enabled = false;
                            CellPhone.Enabled = false;
                            HomePhone.Enabled = false;
                            Church.Enabled = false;
                            PreistName.Enabled = false;
                            NewID.Enabled = false;
                            CheckID.Enabled = false;

                        }
                    }
                    else
                    {
                        RoomID.Text = YO.RoomID.ToString();
                        TShirtSize.Text = YO.ShirtSize;
                    }



                    WaiverStuff = $@"As Consideration for being allowed to attend and/or Participate in any program or recreational activities, the undersigned, on his or her behalf, and on the behalf of the Participant(s) identified below, acknowledges, appreciates, understands, and agrees to the following:  1.  I represent that I am the parent or legal guardian of the Participant(s) named below or I have obtained permission from the parent/legal guardian of the Participant(s) named below to execute this agreement on their behalf.  ";

                    MedicalStuff = $@"I, {user.FirstName} {user.LastName}, give my son/daughter, {NO.FirstName} {NO.LastName}, permission to attend the Midwest Christian 
                                            Coptic Orthodox Youth Convention.  I hereby authorize the leaders of the convention to act for me according to their best 
                                            judgment in an emergency requiring medical attention and I agree to take responsibility for the expense of such procedure. 
                                            I understand the Convention and Bowling Green State University will not be responsible for any accident or injury and are held 
                                             harmless of any liabilities. See Thirty-Second Annual Midwest Christian Coptic Orthodox Youth Convention, Waiver, Release, 
                                            Hold Harmless & Indemnity Agreement that is incorporated herein by reference.
                                            I, {user.FirstName} {user.LastName}, the undersigned, am also responsible for any damage my son/daughter, {NO.FirstName} {NO.LastName}, 
                                            would cause during their stay, and I understand that there are rules and guidelines, my son/daughter has to follow.";

                    DamageStuff = $@"2:  I acknowledge and understand that there are known and unknown risks associated with participation in the attendance and participation in any Youth Programs or recreational activities, including but not limited to: contusions, fractures, scraped, cuts, bumps, paralysis, or death.  3: I, for myself and the Participant(s) named, willingly assume the risks associated with participation and accept that there are also risks that may arise due to OTHER PARTICIPANTS which I also willingly assume.  4:  I agree that the Participant(s) named, and I shall comply with all stated and customary terms, posted safety signs, rules, and verbal instructions as conditions for participation in any programs or recreational activities.   5:  I, for myself, the Participant(s) named, our heirs, assigns, representatives, and next of kin agree to hold harmless, release, waive and indemnify all participating Coptic Orthodox Churches, their predecessors, parent subsidiaries, and affiliates, officers and employees from any and all injuries, liabilities or damages from participation in any programs or recreational activities / volunteers.  6:  I additionally agree to indemnify all participating Coptic Orthodox Churches, their predecessors, parent, subsidiaries, and affiliates, officers, and employees for any defense cost or expense arising from any and all claims, injuries, liabilities or damages arising from participation, in any program or recreational activities.  7:  I am of physical ability to participate and am legally competent to understand and complete this agreement.I hereby execute this agreement without coercion.  8:  The invalidity or unenforceability of any provisions of this Agreement shall not affect the validity or enforceability of any other provision of this Agreement, which shall remain in full force and effect.  9:  Any controversy, dispute, or claim arising out of or related to this Agreement, which the parties are unable to resolve by mutual agreement, shall be settled exclusively by submission by either party of the controversy, claim or dispute to binding arbitration in Cuyahoga County in accordance with the rules of the American Arbitration Association then in effect. ";



                }
            }

            if (!String.IsNullOrEmpty(Self))
            {
                WaiverStuff = $@"As Consideration for being allowed to attend and/or Participate in any program or recreational activities, I the undersigned, acknowledge, appreciate, understand, and agree to the following:  1.  I represent that I am the Participant(s) named below to execute this agreement.  ";

                MedicalStuff = $@"I, {user.FirstName} {user.LastName}, give myself permission to attend the Midwest Christian 
                                            Coptic Orthodox Youth Convention.  I hereby authorize the leaders of the convention to act for me according to their best 
                                            judgment in an emergency requiring medical attention and I agree to take responsibility for the expense of such procedure. 
                                            I understand the Convention and Bowling Green State University will not be responsible for any accident or injury and are held 
                                            harmless of any liabilities. See Thirty-Second Annual Midwest Christian Coptic Orthodox Youth Convention, Waiver, Release, 
                                            Hold Harmless & Indemnity Agreement that is incorporated herein by reference.
                                            I, {user.FirstName} {user.LastName}, the undersigned, am also responsible for any damage I, {user.FirstName} {user.LastName} 
                                            would cause during their stay, and I understand that there are rules and guidelines I have to follow.";

                DamageStuff = $@"2:  I acknowledge and understand that there are known and unknown risks associated with participation in the attendance and participation in any Youth Programs or recreational activities, including but not limited to: contusions, fractures, scraped, cuts, bumps, paralysis, or death.  3: I, for myself and the Participant(s) named, willingly assume the risks associated with participation and accept that there are also risks that may arise due to OTHER PARTICIPANTS which I also willingly assume.  4:  I agree that the Participant(s) named, and I shall comply with all stated and customary terms, posted safety signs, rules, and verbal instructions as conditions for participation in any programs or recreational activities.   5:  I, for myself, the Participant(s) named, our heirs, assigns, representatives, and next of kin agree to hold harmless, release, waive and indemnify all participating Coptic Orthodox Churches, their predecessors, parent subsidiaries, and affiliates, officers and employees from any and all injuries, liabilities or damages from participation in any programs or recreational activities / volunteers.  6:  I additionally agree to indemnify all participating Coptic Orthodox Churches, their predecessors, parent, subsidiaries, and affiliates, officers, and employees for any defense cost or expense arising from any and all claims, injuries, liabilities or damages arising from participation, in any program or recreational activities.  7:  I am of physical ability to participate and am legally competent to understand and complete this agreement.I hereby execute this agreement without coercion.  8:  The invalidity or unenforceability of any provisions of this Agreement shall not affect the validity or enforceability of any other provision of this Agreement, which shall remain in full force and effect.  9:  Any controversy, dispute, or claim arising out of or related to this Agreement, which the parties are unable to resolve by mutual agreement, shall be settled exclusively by submission by either party of the controversy, claim or dispute to binding arbitration in Cuyahoga County in accordance with the rules of the American Arbitration Association then in effect. ";


                Email.Text = user.Email;
                Email.Enabled = false;
                UserTypeColumn.Visible = false;

                using (var db = new ApplicationDbContext())
                {
                    Email.Text = user.Email;
                    FirstName.Text = user.FirstName;
                    LastName.Text = user.LastName;
                    BirthDate.Text = user.Birthdate;
                    Gender.SelectedValue = user.Gender;
                    City.Text = user.City;
                    State.Text = user.State;
                    AddressLine1.Text = user.AddressLine1;
                    AddressLine2.Text = user.AddressLine2;
                    ZipCode.Text = user.ZipCode;
                    CellPhone.Text = user.CellPhone;
                    HomePhone.Text = user.HomePhone;
                    Church.SelectedValue = user.ChurchID;
                    PreistName.Text = user.PriestName;


                    var YO = db.YouthRegistration.Where(s => s.UserID == user.Id && s.Year == DateTime.Now.Year).FirstOrDefault();

                        if (YO != null)
                        {
                            if (YO.WaiverConfirm)
                            {
                                RoomID.Text = YO.RoomID.ToString();
                                TShirtSize.Text = YO.ShirtSize;
                                MedicalHistory.Text = YO.MedicalHistory;
                                Medications.Text = YO.Medications;
                                Allergies.Text = YO.Allergies;
                                EmergencyName.Text = YO.EmergencyName;
                                EmergencyRelationship.Text = YO.EmergencyRelationship;
                                EmergencyPhone.Text = YO.EmergencyPhone;
                                MedicalCo.Text = YO.MedicalInsuranceCompanies;
                                PolicyNo.Text = YO.PolicyNumber;
                                Group.Text = YO.Group;
                                DI.Text = YO.DamageInitial;
                                MI.Text = YO.MedicalInitial;
                                WI.Text = YO.WaiverInitial;
                                WaiverConfirm.Checked = YO.WaiverConfirm;
                                Signature.Text = YO.Signature;

                                RoomID.Enabled = false;
                                TShirtSize.Enabled = false;
                                MedicalHistory.Enabled = false;
                                Medications.Enabled = false;
                                Allergies.Enabled = false;
                                EmergencyName.Enabled = false;
                                EmergencyRelationship.Enabled = false;
                                EmergencyPhone.Enabled = false;
                                MedicalCo.Enabled = false;
                                PolicyNo.Enabled = false;
                                Group.Enabled = false;
                                DI.Enabled = false;
                                MI.Enabled = false;
                                WI.Enabled = false;
                                WaiverConfirm.Enabled = false;
                                Signature.Enabled = false;
                                submitBtn.Enabled = false;

                                Email.Enabled = false;
                                FirstName.Enabled = false;
                                LastName.Enabled = false;
                                BirthDate.Enabled = false;
                                Gender.Enabled = false;
                                City.Enabled = false;
                                State.Enabled = false;
                                AddressLine1.Enabled = false;
                                AddressLine2.Enabled = false;
                                ZipCode.Enabled = false;
                                CellPhone.Enabled = false;
                                HomePhone.Enabled = false;
                                Church.Enabled = false;
                                PreistName.Enabled = false;
                                NewID.Enabled = false;
                                CheckID.Enabled = false;

                            }
                        }
                    }
                


                if (User.IsInRole("Youth"))
                {
                    UserType.SelectedValue = "Youth";
                }
                if (User.IsInRole("Parent"))
                {
                    UserType.SelectedValue = "Parent";
                }
                if (User.IsInRole("Servant"))
                {
                    UserType.SelectedValue = "Servant";
                }
            }


            WaiverText.InnerText = WaiverStuff;
            MedicalText.InnerText = MedicalStuff;
            DamageText.InnerText = DamageStuff;

        }


        public void YouthRegistrationSubmit(object sender, EventArgs e)
        {
            if (WaiverConfirm.Checked)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(User.Identity.GetUserId());
                string UserID = Request.QueryString["UserID"];

                DateTime today = DateTime.Now;
                TimeSpan age = today - DateTime.Parse(user.Birthdate);

                if (User.IsInRole("Parent") || User.IsInRole("ChurchAdmin") || age.TotalDays >= 6570)
                {
                    if (!String.IsNullOrEmpty(UserID))
                    {
                        using (var db = new ApplicationDbContext())
                        {
                            var updateYouthRegistration = db.YouthRegistration.Where(s => s.UserID == UserID).FirstOrDefault();

                            if (updateYouthRegistration != null)
                            {
                                Email.Enabled = false;

                                updateYouthRegistration.Allergies = Allergies.Text;
                                updateYouthRegistration.Group = Group.Text;
                                updateYouthRegistration.MedicalHistory = MedicalHistory.Text;
                                updateYouthRegistration.Medications = Medications.Text;
                                updateYouthRegistration.Year = DateTime.Now.Year;
                                updateYouthRegistration.PolicyNumber = PolicyNo.Text;
                                updateYouthRegistration.WaiverConfirm = WaiverConfirm.Checked;
                                updateYouthRegistration.Signature = Signature.Text;
                                updateYouthRegistration.EmergencyName = EmergencyName.Text;
                                updateYouthRegistration.EmergencyRelationship = EmergencyRelationship.Text;
                                updateYouthRegistration.EmergencyPhone = EmergencyPhone.Text;
                                updateYouthRegistration.MedicalInsuranceCompanies = MedicalCo.Text;
                                updateYouthRegistration.ParentAuth = true;
                                updateYouthRegistration.MedicalInitial = MI.Text;
                                updateYouthRegistration.DamageInitial = DI.Text;
                                updateYouthRegistration.WaiverInitial = WI.Text;


                                db.SaveChanges();
                                submitBtn.Enabled = false;
                                submitBtn.Text = "Submitted";
                                submitBtn.CssClass = "btn btn-success";

                                var youth = manager.FindById(UserID);

                                MailMessage objMail = new MailMessage("mccoyconline@gmail.com", user.Email, $"{ user.FirstName } was confirmed by you to go to MCCOYC { DateTime.Now.Year}.", $"If you have not paid the registration fee already, please do so before attending MCCOYC {DateTime.Now.Year}");
                                NetworkCredential objNC = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                ServicePointManager.ServerCertificateValidationCallback =
                                 delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                                 { return true; };
                                smtp.EnableSsl = true;
                                smtp.Credentials = objNC;
                                smtp.Send(objMail);
                            }
                        }
                    }
                    else
                    {
                        if (UserType.SelectedValue == "Youth")
                        {
                            using (var db = new ApplicationDbContext())
                            {

                                var matchingUser = manager.Users.Where(u => u.Email == Email.Text).FirstOrDefault();

                                if (matchingUser != null)
                                {
                                    Email.Enabled = false;
                                    var RegisterAction = db.YouthRegistration.Where(r => r.UserID == matchingUser.Id && r.ParentEmail == user.Email).FirstOrDefault();

                                    if (RegisterAction != null)
                                    {
                                        RegisterAction.Allergies = Allergies.Text;
                                        RegisterAction.Group = Group.Text;
                                        RegisterAction.MedicalHistory = MedicalHistory.Text;
                                        RegisterAction.Medications = Medications.Text;
                                        RegisterAction.PolicyNumber = PolicyNo.Text;
                                        RegisterAction.WaiverConfirm = WaiverConfirm.Checked;
                                        RegisterAction.Signature = Signature.Text;
                                        RegisterAction.Year = DateTime.Now.Year;
                                        RegisterAction.EmergencyName = EmergencyName.Text;
                                        RegisterAction.EmergencyRelationship = EmergencyRelationship.Text;
                                        RegisterAction.EmergencyPhone = EmergencyPhone.Text;
                                        RegisterAction.MedicalInsuranceCompanies = MedicalCo.Text;
                                        RegisterAction.ParentAuth = true;
                                        RegisterAction.MedicalInitial = MI.Text;
                                        RegisterAction.DamageInitial = DI.Text;
                                        RegisterAction.WaiverInitial = WI.Text;
                                        RegisterAction.UserID = matchingUser.Id;
                                        RegisterAction.ParentEmail = user.Email;
                                        RegisterAction.ShirtSize = TShirtSize.Text;
                                        RegisterAction.RoomID = Int32.Parse(RoomID.Text);

                                        MailMessage toYouthObjMail = new MailMessage("mccoyconline@gmail.com", matchingUser.Email, $"MCCOYC Registration confirmation", $"Your parent has completed your application to the {DateTime.Now.Year} MCCOYC. Please be sure to submit payment to the church registration table by July 10, 2016. The fee for this year's registration is $240. Until paid, your registration will not be complete. Until then, your application will be pending church approval. You will be notified when your application is completed.");
                                        NetworkCredential objNC = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        ServicePointManager.ServerCertificateValidationCallback =
                                         delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                                         { return true; };
                                        smtp.EnableSsl = true;
                                        smtp.Credentials = objNC;
                                        smtp.Send(toYouthObjMail);

                                        MailMessage objMail = new MailMessage("mccoyconline@gmail.com", user.Email, $"MCCOYC Registration confirmation", $"Thank you for completeing your youth's application to the {DateTime.Now.Year} MCCOYC. Please be sure to submit payment to the church registration table by July 10, 2016. The fee for this year's registration is $240. Until paid, your registration will not be complete. Until then, your application will be pending church approval. You will be notified when your application is completed.");
                                        NetworkCredential objNC1 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                                        SmtpClient smtp1 = new SmtpClient("smtp.gmail.com", 587);
                                        smtp1.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        ServicePointManager.ServerCertificateValidationCallback =
                                         delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                                         { return true; };
                                        smtp1.EnableSsl = true;
                                        smtp1.Credentials = objNC1;
                                        smtp1.Send(objMail);

                                        RegisterAction.WaiverConfirm = true;
                                        RegisterAction.Signature = Signature.Text;

                                        db.SaveChanges();
                                        submitBtn.Enabled = false;
                                        submitBtn.Text = "Submitted";
                                        submitBtn.CssClass = "btn btn-success";
                                    }
                                    else
                                    {
                                        var newAction = new YouthRegistration();
                                        newAction.Allergies = Allergies.Text;
                                        newAction.Group = Group.Text;
                                        newAction.MedicalHistory = MedicalHistory.Text;
                                        newAction.Medications = Medications.Text;
                                        newAction.PolicyNumber = PolicyNo.Text;
                                        newAction.WaiverConfirm = WaiverConfirm.Checked;
                                        newAction.Signature = Signature.Text;
                                        newAction.EmergencyName = EmergencyName.Text;
                                        newAction.EmergencyRelationship = EmergencyRelationship.Text;
                                        newAction.EmergencyPhone = EmergencyPhone.Text;
                                        newAction.MedicalInsuranceCompanies = MedicalCo.Text;
                                        newAction.ParentAuth = true;
                                        newAction.ShirtSize = TShirtSize.Text;
                                        newAction.RoomID = Int32.Parse(RoomID.Text);
                                        newAction.DamageInitial = DI.Text;
                                        newAction.MedicalInitial = MI.Text;
                                        newAction.WaiverInitial = WI.Text;
                                        newAction.Year = DateTime.Now.Year;
                                        newAction.UserID = matchingUser.Id;
                                        newAction.ParentEmail = user.Email;
                                        newAction.WaiverConfirm = true;
                                        newAction.Signature = Signature.Text;
                                        db.YouthRegistration.Add(newAction);
                                        db.SaveChanges();

                                        submitBtn.Enabled = false;
                                        submitBtn.Text = "Submitted";
                                        submitBtn.CssClass = "btn btn-success";
                                    }

                                }
                                else
                                {
                                    var usernew = new ApplicationUser() { UserName = Email.Text, Email = Email.Text, FirstName = FirstName.Text, LastName = LastName.Text, Birthdate = BirthDate.Text, Gender = Gender.Text, City = City.Text, State = State.Text, ZipCode = ZipCode.Text, HomePhone = HomePhone.Text, CellPhone = CellPhone.Text, ChurchID = Church.SelectedValue, PriestName = PreistName.Text };
                                    var password = new Guid().ToString();
                                    IdentityResult result = manager.Create(usernew, password);
                                    if (result.Succeeded)
                                    {
                                        manager.AddToRole(usernew.Id, UserType.SelectedValue);


                                        var newRegistration = new YouthRegistration();
                                        newRegistration.UserID = usernew.Id;
                                        newRegistration.Allergies = Allergies.Text;
                                        newRegistration.Group = Group.Text;
                                        newRegistration.MedicalHistory = MedicalHistory.Text;
                                        newRegistration.Medications = Medications.Text;
                                        newRegistration.PolicyNumber = PolicyNo.Text;
                                        newRegistration.WaiverConfirm = WaiverConfirm.Checked;
                                        newRegistration.Signature = Signature.Text;
                                        newRegistration.EmergencyName = EmergencyName.Text;
                                        newRegistration.EmergencyRelationship = EmergencyRelationship.Text;
                                        newRegistration.EmergencyPhone = EmergencyPhone.Text;
                                        newRegistration.MedicalInsuranceCompanies = MedicalCo.Text;
                                        newRegistration.ParentAuth = true;
                                        newRegistration.Year = DateTime.Now.Year;
                                        newRegistration.ShirtSize = TShirtSize.Text;
                                        newRegistration.RoomID = Int32.Parse(RoomID.Text);
                                        newRegistration.DamageInitial = DI.Text;
                                        newRegistration.MedicalInitial = MI.Text;
                                        newRegistration.WaiverInitial = WI.Text;
                                        newRegistration.UserID = usernew.Id;
                                        newRegistration.ParentEmail = user.Email;
                                        newRegistration.WaiverConfirm = true;
                                        newRegistration.Signature = Signature.Text;
                                        db.YouthRegistration.Add(newRegistration);
                                        db.SaveChanges();
                                        submitBtn.Enabled = false;
                                        submitBtn.Text = "Submitted";
                                        submitBtn.CssClass = "btn btn-success";

                                        MailMessage objMail = new MailMessage("mccoyconline@gmail.com", user.Email, $"MCCOYC Registration Confirmation", $"Thank you for completeing your youth's application to the {DateTime.Now.Year} MCCOYC. Please be sure to submit payment to the church registration table by July 10, 2016. The fee for this year's registration is $240. Until paid, your registration will not be complete. Until then, your application will be pending church approval. You will be notified when your application is completed.");
                                        NetworkCredential objNC = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        ServicePointManager.ServerCertificateValidationCallback =
                                         delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                                         { return true; };
                                        smtp.EnableSsl = true;
                                        smtp.Credentials = objNC;
                                        smtp.Send(objMail);

                                        MailMessage objMail2 = new MailMessage("mccoyconline@gmail.com", usernew.Email, $"MCCOYC Registration Confirmation", $@"Your parent has completed your registration for the {DateTime.Now.Year} MCCOYC.
To review your application, please log in to mccoyc.azurewebsites.net using the email address {usernew.Email} and the password: {password}. Please be sure to submit payment to the church registration table by July 10, 2016. The fee for this year's registration is $240. Until paid, your registration will not be complete. Until then, your application will be pending church approval. You will be notified when your application is complete.");
                                        NetworkCredential objNC2 = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                                        SmtpClient smtp2 = new SmtpClient("smtp.gmail.com", 587);
                                        smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        ServicePointManager.ServerCertificateValidationCallback =
                                         delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                                         { return true; };
                                        smtp2.EnableSsl = true;
                                        smtp2.Credentials = objNC2;
                                        smtp2.Send(objMail2);

                                    }
                                }
                            }
                        }
                        else
                        {
                            using (var db = new ApplicationDbContext())
                            {
                                Email.Enabled = true;
                                var selfRegister = new YouthRegistration();
                                selfRegister.Allergies = Allergies.Text;
                                selfRegister.Group = Group.Text;
                                selfRegister.MedicalHistory = MedicalHistory.Text;
                                selfRegister.Medications = Medications.Text;
                                selfRegister.PolicyNumber = PolicyNo.Text;
                                selfRegister.WaiverConfirm = WaiverConfirm.Checked;
                                selfRegister.Signature = Signature.Text;
                                selfRegister.EmergencyName = EmergencyName.Text;
                                selfRegister.EmergencyRelationship = EmergencyRelationship.Text;
                                selfRegister.EmergencyPhone = EmergencyPhone.Text;
                                selfRegister.MedicalInsuranceCompanies = MedicalCo.Text;
                                selfRegister.ParentAuth = true;
                                selfRegister.UserID = user.Id;
                                selfRegister.Year = DateTime.Now.Year;
                                selfRegister.ShirtSize = TShirtSize.Text;
                                selfRegister.RoomID = Int32.Parse(RoomID.Text);
                                selfRegister.DamageInitial = DI.Text;
                                selfRegister.MedicalInitial = MI.Text;
                                selfRegister.WaiverInitial = WI.Text;
                                selfRegister.WaiverConfirm = true;
                                selfRegister.Signature = Signature.Text;

                                db.YouthRegistration.Add(selfRegister);

                                MailMessage objMail = new MailMessage("mccoyconline@gmail.com", user.Email, $"MCCOYC Registration Confirmation", $"Thank you for completeing your youth's application to the {DateTime.Now.Year} MCCOYC. Please be sure to submit payment to the church registration table by July 10, 2016. The fee for this year's registration is $240 for a double room. Until paid, your registration will not be complete. Until then, your application will be pending church approval. You will be notified when your application is completed.");
                                NetworkCredential objNC = new NetworkCredential("mccoyconline@gmail.com", "stmarkmi123");
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                ServicePointManager.ServerCertificateValidationCallback =
                                 delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                                 { return true; };
                                smtp.EnableSsl = true;
                                smtp.Credentials = objNC;
                                smtp.Send(objMail);

                                db.SaveChanges();
                                submitBtn.Enabled = false;
                                submitBtn.Text = "Submitted";
                                submitBtn.CssClass = "btn btn-success";
                            }
                        }
                    }
                }

                else
                {
                    ErrorMessage.Text = "You are not authorized to submit these forms for this user.";
                }
                ErrorMessage.Text = "";
            }
            else
            {
                ErrorMessage.Text = "Adopt and Sign is required.";
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
                        db.SaveChanges();

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