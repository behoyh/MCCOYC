<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChurchAdmin Review.aspx.cs" Inherits="MCCOYC.UserRoleControllers.ChurchAdmin.ChurchAdmin_Review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Register For MCCOYC 2016.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="container">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="control-label">Email</asp:Label>
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="Email is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="control-label">FirstName</asp:Label>
                        <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="First Name is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="LastName" CssClass="control-label">LastName</asp:Label>
                        <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="Birthdate" CssClass="control-label">Birthdate</asp:Label>
                        <asp:TextBox runat="server" ID="BirthDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="BirthDate"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="Gender" CssClass="control-label">Gender</asp:Label>
                        <asp:RadioButtonList runat="server" ID="Gender" CssClass="checkbox-circle">
                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="BirthDate"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="City" CssClass="control-label">City</asp:Label>
                        <asp:TextBox runat="server" ID="City" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="BirthDate"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="State" CssClass="control-label">State</asp:Label>
                        <asp:TextBox runat="server" ID="State" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="BirthDate"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="AddressLine1" CssClass="control-label">Address Line 1</asp:Label>
                        <asp:TextBox runat="server" ID="AddressLine1" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="State"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The Address Line 1 field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="AddressLine2" CssClass="control-label">Address Line 2</asp:Label>
                        <asp:TextBox runat="server" ID="AddressLine2" CssClass="form-control"></asp:TextBox>

                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="ZipCode" CssClass="control-label">ZipCode</asp:Label>
                        <asp:TextBox runat="server" ID="ZipCode" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ZipCode"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The zipcode field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="CellPhone" CssClass="control-label">Cell Phone</asp:Label>
                        <asp:TextBox runat="server" ID="CellPhone" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="CellPhone"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The cell phone field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="HomePhone" CssClass="control-label">Home Phone</asp:Label>
                        <asp:TextBox runat="server" ID="HomePhone" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="HomePhone"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="Church" CssClass="control-label">Church</asp:Label>
                        <asp:DropDownList runat="server" ID="Church" CssClass="form-control">
                            <asp:ListItem Text="St. George - Chicago"></asp:ListItem>
                            <asp:ListItem Text="St. Mark - Chicago"></asp:ListItem>
                            <asp:ListItem Text="St. Mary - Chicago"></asp:ListItem>
                            <asp:ListItem Text="St. Mark - Cleveland"></asp:ListItem>
                            <asp:ListItem Text="St. Mary - Columbus"></asp:ListItem>
                            <asp:ListItem Text="St. Mina & St. Abanoub - Dayton"></asp:ListItem>
                            <asp:ListItem Text="St. Mark - Detroit"></asp:ListItem>
                            <asp:ListItem Text="St. Mary & St. Mark - Indianapolis"></asp:ListItem>
                            <asp:ListItem Text="St. Mary - Columbus"></asp:ListItem>
                            <asp:ListItem Text="St. Mary & St. Rewis - Madison"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Church"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="PreistName" CssClass="control-label">Priest Name</asp:Label>
                        <asp:TextBox runat="server" ID="PreistName" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PreistName"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="Who is your father of Confession?" />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="UserType" CssClass="control-label">UserType</asp:Label>
                        <asp:RadioButtonList runat="server" ID="UserType" CssClass="radio-primary">
                            <asp:ListItem Text="Youth" Value="Youth"></asp:ListItem>
                            <asp:ListItem Text="Servant" Value="Servant"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="col-md-4 col-sm-6">
                    <asp:Label runat="server" AssociatedControlID="TShirtSize" CssClass="control-label">T-Shirt Size</asp:Label>
                    <asp:TextBox runat="server" ID="TShirtSize" CssClass="form-control" />
                </div>
                <div class="col-md-4 col-sm-6">
                    <asp:Label runat="server" AssociatedControlID="RoomID" CssClass="control-label">Room ID</asp:Label>
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="RoomID" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>


            <div class="form-group">
                <div class="col-md-12">
                    <asp:Label runat="server" AssociatedControlID="MedicalHistory" CssClass="control-label">Medical History</asp:Label>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="MedicalHistory" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <asp:Label runat="server" AssociatedControlID="Medications" CssClass="control-label">Medications</asp:Label>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="Medications" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <asp:Label runat="server" AssociatedControlID="Allergies" CssClass="control-label">Allergies</asp:Label>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="Allergies" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <asp:Label runat="server" AssociatedControlID="EmergencyPhone" CssClass="control-label">Emergency Phone</asp:Label>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="EmergencyPhone" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <asp:Label runat="server" AssociatedControlID="MedicalCo" CssClass="control-label">MedicalCo</asp:Label>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="MedicalCo" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-6">
                    <asp:Label runat="server" AssociatedControlID="PolicyNo" CssClass="control-label">PolicyNo</asp:Label>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="PolicyNo" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-6">
                    <asp:Label runat="server" AssociatedControlID="Group" CssClass="control-label">Group</asp:Label>
                    <asp:TextBox runat="server" ID="Group" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <div class="well">
                        <p runat="server" id="MedicalText">Medical Initial</p>
                    </div>
                    <asp:Label runat="server" AssociatedControlID="MI" CssClass="control-label">Initals</asp:Label>
                    <asp:TextBox runat="server" ID="MI" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <div class="well">
                        <p runat="server" id="DamageText">Damage Initial</p>
                    </div>
                    <asp:Label runat="server" AssociatedControlID="DI" CssClass="control-label">Initals</asp:Label>
                    <asp:TextBox runat="server" ID="DI" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <div class="well">
                        <p runat="server" id="WaiverText">Waiver Initial</p>
                    </div>
                    <asp:Label runat="server" AssociatedControlID="WI" CssClass="control-label">Initals</asp:Label>
                    <asp:TextBox runat="server" ID="WI" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-6">
                    <asp:Label runat="server" AssociatedControlID="WaiverConfirm" CssClass="control-label">Waiver Confirm</asp:Label>
                    <asp:CheckBox runat="server" ID="WaiverConfirm" CssClass="control-label"></asp:CheckBox>
                </div>
                <div class="col-md-4 col-sm-6">
                    <asp:Label runat="server" AssociatedControlID="Signature" CssClass="control-label">Signature</asp:Label>
                    <asp:TextBox runat="server" ID="Signature" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class=" text-center col-md-12">
            <asp:Button runat="server" ID="ApproveBtn" OnClick="ApproveReject" Text="Approve" CssClass="btn btn-success" />
            <asp:Button runat="server" ID="RejectBtn" OnClick="ApproveReject" Text="Reject" CssClass="btn btn-danger" />
        </div>
    </div>
</asp:Content>
