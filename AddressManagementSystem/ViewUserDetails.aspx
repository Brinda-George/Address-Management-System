<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUserDetails.aspx.cs" Inherits="AddressManagementSystem.ViewUserDetails" %>
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
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" CssClass="text-danger" ErrorMessage="The User Name field is required." Text="*" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Age" SortExpression="Age">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAge" runat="server" Text='<%# Bind("Age") %>'></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAge" CssClass="text-danger" ErrorMessage="The Age field is required." Text="*" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAge" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Of Birth" SortExpression="DOB">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDOB" runat="server" Text='<%# Bind("DOB") %>' TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDOB" CssClass="text-danger" ErrorMessage="The Date Of Birth field is required." Text="*" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDOB" runat="server" Text='<%# Bind("DOB") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address" SortExpression="Address">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress" CssClass="text-danger" ErrorMessage="The Address field is required." Text="*" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' TextMode-="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="The Email field is required." Text="*" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone Number" SortExpression="PhoneNumber">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPhoneNo" runat="server" Text='<%# Bind("PhoneNumber") %>' TextMode="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhoneNo" CssClass="text-danger" ErrorMessage="The Phone Number field is required." Text="*" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
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
