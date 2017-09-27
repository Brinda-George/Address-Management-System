<%@ Page Title="View User Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUserDetails.aspx.cs" Inherits="AddressManagementSystem.ViewUserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../Scripts/print.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <asp:ValidationSummary runat="server" CssClass="text-danger" />
    <asp:GridView ID="GridViewUser" runat="server" DataKeyNames="Name" CssClass="gridview" AutoGenerateColumns="False" OnRowDataBound="GridViewUser_RowDataBound" OnRowCancelingEdit="GridViewUser_RowCancelingEdit" OnRowDeleting="GridViewUser_RowDeleting" OnRowEditing="GridViewUser_RowEditing" OnRowUpdating="GridViewUser_RowUpdating">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
            <asp:TemplateField HeaderText="Date Of Birth" SortExpression="DOB">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDOB" runat="server" Text='<%# Bind("DOB") %>' TextMode="Date"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDOB" runat="server" Text='<%# Bind("DOB") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
            <asp:CommandField ShowEditButton="True"></asp:CommandField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkBtnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete? This cannot be undone.');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:DetailsView ID="DetailsViewUser" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" ClientIDMode="Static" DataSourceID="SqlDataSource1">
        <Fields>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
            <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SUYPC211;Initial Catalog=AddressDb;User ID=sa;Password=Suyati123" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Name], [Age], [DOB], [Address], [Email], [PhoneNumber] FROM [tblUserDetails] WHERE ([Name] = @Name)">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridViewUser" Name="Name" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="PrintDetailsView()" />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <p><asp:HyperLink runat="server" ID="HomeHyperLink" NavigateUrl="~/Home.aspx">Back To Home Page</asp:HyperLink> | <asp:HyperLink runat="server" ID="AddUserHyperLink" NavigateUrl="~/AddUser.aspx">Add a new user</asp:HyperLink></p>
</asp:Content>
