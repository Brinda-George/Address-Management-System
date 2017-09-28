<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AddressManagementSystem.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/googlemap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <hr /><br />
    <div class="row">
        <div class="col-md-6">
            <div class="form-horizontal center-block"><br />
                <asp:ValidationSummary runat="server" CssClass="text-danger" HeaderText="Please fix the following errors" />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Name: </asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
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
                        <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" CssClass="form-control" Rows="5" Width="280px" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtComments" CssClass="text-danger" Display="Dynamic" ErrorMessage="The Comments field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-4 col-md-8">
                        <asp:LinkButton ID="linkButton" runat="server" CssClass="btn btn-default" OnClick="linkButton_Click"><i class="fa fa-paper-plane" aria-hidden="true"></i>&nbsp;Submit</asp:LinkButton>
                    </div>
                </div>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </div>
        <div class="col-md-6">
            <div>
                <p>Contact us and we'll get back to you within 24 hours.</p>
                <p><span class="glyphicon glyphicon-map-marker"></span>&nbsp;Kochi, India</p>
                <p><span class="glyphicon glyphicon-phone"></span>&nbsp;+91 1515151515</p>
                <p><span class="glyphicon glyphicon-envelope"></span>&nbsp;myemail@suyati.com</p>
            </div><hr />
            <div id="googleMap" style="height: 290px; width: 430px;"></div><br />
            <div class="col-md-offset-3">
                <ul class="list-inline">
                  <li class="list-inline-item">
                    <a href="#">
                      <span class="fa-stack fa-lg">
                        <i class="fa fa-circle fa-stack-2x"></i>
                        <i class="fa fa-twitter fa-stack-1x fa-inverse"></i>
                      </span>
                    </a>
                  </li>
                  <li class="list-inline-item">
                    <a href="#">
                      <span class="fa-stack fa-lg">
                        <i class="fa fa-circle fa-stack-2x"></i>
                        <i class="fa fa-facebook fa-stack-1x fa-inverse"></i>
                      </span>
                    </a>
                  </li>
                  <li class="list-inline-item">
                    <a href="#">
                      <span class="fa-stack fa-lg">
                        <i class="fa fa-circle fa-stack-2x"></i>
                        <i class="fa fa-github fa-stack-1x fa-inverse"></i>
                      </span>
                    </a>
                  </li>
                </ul>
            </div>
        </div>
    </div>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAKHm92mmR3rlFZ75RpvnlRPjvPtM7KDL0&callback=initMap"></script>
</asp:Content>
