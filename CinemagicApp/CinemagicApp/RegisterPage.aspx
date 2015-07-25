<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="PLWebcinemagic.RegisterPage" %>


<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title>Register</title>    
</head>
<body>
    <form id="form1" runat="server">  
        PLEASE REGISTER:<br />

         USERNAME:  <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="reqUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter an username." ></asp:RequiredFieldValidator><br />
         FIRST NAME:  <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="reqFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter your first name." ></asp:RequiredFieldValidator><br />
         LAST NAME:  <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="reqLastNAme" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please enter your last name." ></asp:RequiredFieldValidator><br />
         E-MAIL:  <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter your e-mail." ></asp:RequiredFieldValidator><br />
         PASSWORD:  <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="ReqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter a password." ></asp:RequiredFieldValidator><br />
         REPEAT PASSWORD:  <asp:TextBox ID="txtPassword2" TextMode="Password" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPassword2" ErrorMessage="The passwords do not match."></asp:CompareValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword2" ErrorMessage="Please repeat your password."></asp:RequiredFieldValidator>
        <br />


        <br />
        <asp:Button ID="btnRegister" runat="server" Text="REGISTER" OnClick="btnRegister_Click" />


    </form>
</body>
</html>
