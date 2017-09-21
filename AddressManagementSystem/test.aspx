<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="AddressManagementSystem.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlTextBoxes" runat="server">
        </asp:Panel>
        <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="AddTextBox" />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="GetTextBoxValues" />
    </div>
    </form>
</body>
</html>
