<%@ Page Title="Registation For MCCOYC 2016" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MCCOYC.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <h4>Create a new account.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="container">
            <div class="form-group">
                <div class="row">
                    
                   <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="control-label">First Name</asp:Label>
                        <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The First Name field is required." />
                    </div>
                    
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="LastName" CssClass="control-label">Last Name</asp:Label>
                        <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The Last Name field is required." />
                    </div>
                    
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="control-label">Email</asp:Label>
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The Email field is required." />
                    </div>


                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="Birthdate" CssClass="control-label">Date of Birth</asp:Label>
                        <asp:TextBox runat="server" ID="BirthDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="BirthDate"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The Date of Birth field is required." />
                    </div>
                    
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="Gender" CssClass="control-label">Gender</asp:Label>
                        <asp:RadioButtonList runat="server" ID="Gender" CssClass="checkbox-circle">
                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Gender"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The Gender field is required." />
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
                        <asp:Label runat="server" AssociatedControlID="City" CssClass="control-label">City</asp:Label>
                        <asp:TextBox runat="server" ID="City" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="City"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The City field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="State" CssClass="control-label">State</asp:Label>
                        <asp:TextBox runat="server" ID="State" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="State"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The State field is required." />
                    </div>

                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="ZipCode" CssClass="control-label">Zip Code</asp:Label>
                        <asp:TextBox runat="server" ID="ZipCode" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ZipCode"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The zip code field is required." />
                    </div>
                    
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="State" CssClass="control-label">Cell Phone</asp:Label>
                        <asp:TextBox runat="server" ID="CellPhone" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="CellPhone"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The Cell Phone field is required." />
                    </div>
                    
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="State" CssClass="control-label">Home Phone</asp:Label>
                        <asp:TextBox runat="server" ID="HomePhone" CssClass="form-control"></asp:TextBox>
                    </div>
                    
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="Church" CssClass="control-label">Home Parish</asp:Label>
               <asp:DropDownList runat="server" ID="Church" CssClass="form-control">
                            <asp:ListItem Text="St. Mark - Troy, MI"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Church"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The Church field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="PreistName" CssClass="control-label">Priest Name</asp:Label>
                        <asp:TextBox runat="server" ID="PreistName" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PreistName"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="Priest Name field is required" />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="UserType" CssClass="control-label">I am a:</asp:Label>
                        <asp:RadioButtonList runat="server" ID="UserType" CssClass="radio-primary">
                            <asp:ListItem Text="Youth" Value="Youth"></asp:ListItem>
                            <asp:ListItem Text="Parent" Value="Parent"></asp:ListItem>
                            <asp:ListItem Text="Servant" Value="Servant"></asp:ListItem>
                        </asp:RadioButtonList>
                        <p style="color:grey">Select "Parent" if you are both a parent and a servant</p>
  <asp:RequiredFieldValidator runat="server" ControlToValidate="UserType"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The User Type field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="control-label">Confirm password</asp:Label>
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class=" text-center col-md-12">
            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
