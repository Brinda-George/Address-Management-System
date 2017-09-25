<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AddressManagementSystem._default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h1><%: Title %>.</h1>
        <h2>Address Management System can help you collect user details.</h2>
        <p class="lead">Addressing made easy.Explore the many ways you can efficiently manage and process your address lists</p>
        <p>
            <asp:HyperLink runat="server" ID="HomeHyperLink" NavigateUrl="~/Home.aspx">Go To Home Page</asp:HyperLink>
        </p>
</asp:Content>