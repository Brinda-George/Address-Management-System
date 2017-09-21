<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AddressManagementSystem.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p>
        <asp:HyperLink runat="server" ID="AddUserHyperLink" NavigateUrl="~/AddUser.aspx">Enter User Details</asp:HyperLink> | 
        <asp:HyperLink runat="server" ID="ViewUserHyperLink" NavigateUrl="~/ViewUserDetails.aspx">View User Details</asp:HyperLink>
    </p>
</asp:Content>
