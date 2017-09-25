<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AddressManagementSystem.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" HeaderText="Please fix the following errors"/>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Name: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="The Email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtSubject" CssClass="col-md-2 control-label">Subject: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtSubject" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSubject" CssClass="text-danger" ErrorMessage="The Subject field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtComments" CssClass="col-md-2 control-label">Comments: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" CssClass="form-control" Rows="5" Width="280px"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtComments" CssClass="text-danger" Display="Dynamic" ErrorMessage="The Comments field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-default" />
            </div>
        </div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
</asp:Content>
