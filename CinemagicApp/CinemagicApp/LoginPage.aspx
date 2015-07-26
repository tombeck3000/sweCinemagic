<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PLWebcinemagic.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login</title>
    <link rel="stylesheet" href="Content/LoginPage.css"/>
    <link rel="stylesheet" href="Content/Layout.css"/>
    <link rel="shortcut icon" type="image/x-icon" href="Images/cinemagiclogo.png" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <asp:Image ID="logo" ImageUrl="Images/cinemagiclogo.png" runat="server"/>
        </div>
        <div id="content">
            <table>
                <tr class="row1">
                    <td class="column1">PLEASE LOG IN:</td>
                    <td class="column2"></td>
                    <td class="column3"></td>
                </tr>
                <tr class="row2">
                    <td class="column1">USERNAME:</td>
                    <td class="column2">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                    <td class="column3">
                        <asp:RequiredFieldValidator ID="reqUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter your username." ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="row3">
                    <td class="column1">PASSWORD:</td>
                    <td class="column2">
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                    <td class="column3">
                        <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter your password." ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="row4">
                    <td class="column1"></td>
                    <td class="column2">
                         <asp:Button ID="btnLogin" runat="server" Text="LOG IN" OnClick="btnLogin_Click" />
                    </td>
                    <td class="column3"></td>
                </tr>
            </table>
        </div>
        <div id="footer">
            Copyright © Sabine Hubner | Martin Gugler | Junxiang Qiu
        </div>
    </form>
</body>
</html>
