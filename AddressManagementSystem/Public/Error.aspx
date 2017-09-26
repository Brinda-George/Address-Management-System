<%@ Page Title="Application Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="AddressManagementSystem.Public.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr />
    <asp:Label runat="server" CssClass="h3 text-danger">
        An unkown error has occured on this web site. Please try again. Sorry for the inconvinience caused.
    </asp:Label><br /><br />
    <asp:Label runat="server" CssClass="h5">
        If you need further assistance, please contact our helpdesk at helpdesk@companyhelpdesk.com
    </asp:Label>
</asp:Content>
