<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUserDetails.aspx.cs" Inherits="AddressManagementSystem.ViewUserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="~/Content/gridstyle.css" rel="stylesheet" type="text/css" />--%>
    <style>
        .gridview 
        {
            border-collapse: collapse;
            width: 100%;
            margin:50px auto;
        }
        .gridview th, td 
        {
            text-align: left;
            padding: 8px;
            border: none;
        }
        .gridview tr:nth-child(even)
        {
            background-color: #f2f2f2
        }
        .gridview th 
        {
            background-color: #044980;
            color: white;
            font-weight: bold; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewUser" runat="server" CssClass="gridview" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
            <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AddressDbConnectionString2 %>" SelectCommand="spGetUserDetailsbyUserId" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="" Name="UserId" SessionField="UserId" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
</asp:Content>
