<%@ Page Title="Youth Sign-up Form" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Youth Registration.aspx.cs" Inherits="MCCOYC.UserRoleControllers.Youth.Youth_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Register For MCCOYC 2016.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <div class="col-md-4 col-sm-6">
                <asp:Label runat="server" AssociatedControlID="ParentEmail" CssClass="control-label">Parent Email</asp:Label>
                <asp:TextBox runat="server" ID="ParentEmail" CssClass="form-control" TextMode="Email" />
            </div>
            <div class="col-md-4 col-sm-6">
                <asp:Label runat="server" AssociatedControlID="ParentEmail" CssClass="control-label">T-Shirt Size</asp:Label>
                <asp:TextBox runat="server" ID="TShirtSize" CssClass="form-control" />
            </div>
            <div class="col-md-4 col-sm-6">
                <asp:Label runat="server" AssociatedControlID="RoomID" CssClass="control-label">Room ID</asp:Label>
                                <p> Use this to indicate your roommate! If you don't have a roommate, or are registering before your roommate, click new. 
      If your roommate has already registered for the convention online, ask them for their room ID 
      and put it in this field.  Only 2 people can use the same room id, so make sure you do this step correctly!
</p>
                <div class="input-group">
                    <asp:TextBox runat="server" TextMode="Number" ID="RoomID" CssClass="form-control"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button runat="server" ID="NewID" CssClass="btn btn-default" Text="New" OnClick="NewID_Click"></asp:Button>
                    </span>
                    <span class="input-group-btn">
                        <asp:Button runat="server" ID="CheckID" CssClass="btn btn-success" Text="Check" OnClick="CheckID_Click"></asp:Button>
                    </span>
                </div>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class=" text-center col-md-12">
            <asp:Button runat="server" OnClick="YouthRegistrationSubmit" Text="Register" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
