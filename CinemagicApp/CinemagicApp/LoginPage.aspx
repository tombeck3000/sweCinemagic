<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PLWebcinemagic.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login</title>    
</head>
<body>
    <form id="form1" runat="server">  
        PLEASE LOG IN:<br />

         USERNAME:  <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="reqUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter your username." ></asp:RequiredFieldValidator><br />
        PASSWORD:  <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="ReqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter your password." ></asp:RequiredFieldValidator><br />
         

        <br />
        <asp:Button ID="btnLogin" runat="server" Text="LOG IN" OnClick="btnLogin_Click" />


    </form>
</body>
</html>
