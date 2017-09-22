<%@ Page Title="Enter User Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="AddressManagementSystem.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <h4>Add a new user</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" CssClass="text-danger" ErrorMessage="The User Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAge" CssClass="col-md-2 control-label">Age</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAge" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAge" CssClass="text-danger" ErrorMessage="The Age field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtDOB" CssClass="col-md-2 control-label">Date Of Birth</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDOB" CssClass="form-control" TextMode="Date" Width="280px"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDOB" CssClass="text-danger" ErrorMessage="The Date Of Birth field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-2 control-label">Address</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" Height="100px"/>
                <%--<textarea id="txtAreaAddress" runat="server" cols="20" rows="2" CssClass="form-control"></textarea>--%>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress" CssClass="text-danger" ErrorMessage="The Address field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                <%--<asp:Panel ID="pnlEmails" runat="server">
                </asp:Panel>
                <asp:Button ID="btnAddEmail" runat="server" Text="Add Email" OnClick="btnAddEmail_Click" />--%>
                <%--<asp:Button ID="Add" runat="server" Text="Add Email" />
                <asp:Button ID="Remove" runat="server" Text="Remove Email" />
                <div id="textboxDiv"></div>  
                <script>  
                    $(document).ready(function () {
                        var count = 0;
                        $("#Add").on("click", function () {
                            count += 1;
                            $("#textboxDiv").append("<div><br><input type='text'CssClass='form-control'/><br></div>");
                        });  
                        $("#Remove").on("click", function() {  
                            $("#textboxDiv").children().last().remove();  
                        });  
                    });  
                </script>  --%>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="The Email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPhoneNo" CssClass="col-md-2 control-label">Phone Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPhoneNo" CssClass="form-control"/>
                <%--<asp:Panel ID="pnlPhoneNos" runat="server">
                </asp:Panel>
                <asp:Button ID="btnPhoneNo" runat="server" Text="Add Phone Number" OnClick="btnAddPhoneNo_Click" />--%>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhoneNo" CssClass="text-danger" ErrorMessage="The Phone Number field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="btnSave_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
        <p>
            <asp:HyperLink runat="server" ID="HomeHyperLink" NavigateUrl="~/Home.aspx">Back To Home Page</asp:HyperLink> | <asp:HyperLink runat="server" ID="ViewUserDetailsHyperLink" NavigateUrl="~/ViewUserDetails.aspx">View User Details</asp:HyperLink>
        </p>
        <p>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </p>
    </div>
</asp:Content>
