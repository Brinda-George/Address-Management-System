<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AddressManagementSystem.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div></div>
    <p>
        <asp:HyperLink runat="server" ID="AddUserHyperLink" NavigateUrl="~/AddUser.aspx" CssClass="h4"><i class="fa fa-pencil-square-o" aria-hidden="true"></i>&nbsp;Add User</asp:HyperLink> | 
        <asp:HyperLink runat="server" ID="ViewUserHyperLink" NavigateUrl="~/ViewUserDetails.aspx" CssClass="h4"><i class="fa fa-address-book-o" aria-hidden="true"></i>&nbsp;View User Details</asp:HyperLink>
    </p>
    <img src="Images/address.JPG" width="400px"/>
</asp:Content>
