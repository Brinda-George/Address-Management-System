<%@ Page Title="Application Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="AddressManagementSystem.Public.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h2><%: Title %>.</h2>
    <hr />
    <asp:Label runat="server" CssClass="h3 text-danger">
        An unkown error has occured on this web site. Please try again. Sorry for the inconvinience caused.
    </asp:Label><br /><br />
    <asp:Label runat="server" CssClass="h5">
        If you need further assistance, please contact our helpdesk at helpdesk@companyhelpdesk.com
    </asp:Label>--%>
    <h2>Error:</h2>
    <p></p>
    <asp:Label ID="FriendlyErrorMsg" runat="server" Text="Label" Font-Size="Large" style="color: red"></asp:Label>

    <asp:Panel ID="DetailedErrorPanel" runat="server" Visible="false">
        <p>&nbsp;</p>
        <h4>Detailed Error:</h4>
        <p>
            <asp:Label ID="ErrorDetailedMsg" runat="server" Font-Size="Small" /><br />
        </p>

        <h4>Error Handler:</h4>
        <p>
            <asp:Label ID="ErrorHandler" runat="server" Font-Size="Small" /><br />
        </p>

        <h4>Detailed Error Message:</h4>
        <p>
            <asp:Label ID="InnerMessage" runat="server" Font-Size="Small" /><br />
        </p>
        <p>
            <asp:Label ID="InnerTrace" runat="server"  />
        </p>
    </asp:Panel>
</asp:Content>
