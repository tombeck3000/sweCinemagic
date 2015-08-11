<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="PLWebcinemagic.RegisterPage" %>


<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title>Register</title>
    <link rel="stylesheet" href="Styles/RegisterPage.css"/>
    <link rel="stylesheet" href="Styles/Layout.css"/>
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
                    <td class="column1">REGISTER:</td>
                    <td class="column2"></td>
                    <td class="column3"></td>
                </tr>
                <tr class="row2">
                    <td class="column1">USERNAME</td>
                    <td class="column2">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                    <td class="column3">
                        <asp:RequiredFieldValidator ID="reqUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter an username." ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="row3">
                    <td class="column1">FIRST NAME</td>
                    <td class="column2">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                    <td class="column3">
                        <asp:RequiredFieldValidator ID="reqFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter your first name." ></asp:RequiredFieldValidator>
                    </td>
                    </tr>
                <tr class="row4">
                    <td class="column1">LAST NAME</td>
                    <td class="column2">
                         <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                    <td class="column3">
                        <asp:RequiredFieldValidator ID="reqLastNAme" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please enter your last name." ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="row5">
                    <td class="column1">E-MAIL</td>
                    <td class="column2">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                    <td class="column3">
                        <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter your e-mail." ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="row6">
                    <td class="column1">PASSWORD</td>
                    <td class="column2">
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                    <td class="column3">
                       <asp:RequiredFieldValidator ID="ReqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter a password." ></asp:RequiredFieldValidator>
                    </td>
                </tr>
               <tr class="row7">
                    <td class="column1">REPEAT PASSWORD</td>
                    <td class="column2">
                         <asp:TextBox ID="txtPassword2" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                    <td class="column3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword2" ErrorMessage="Please repeat your password."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="row8">
                    <td class="column1"></td>
                    <td class="column2">
                         <asp:Button ID="btnRegister" runat="server" Text="REGISTER" OnClick="btnRegister_Click" />
                    </td>
                    <td class="column3">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPassword2" ErrorMessage="The passwords do not match."></asp:CompareValidator>
                    </td>
                </tr>
            </table>
        </div>
        <div id="footer">
            Copyright © Sabine Hubner | Martin Gugler | Junxiang Qiu
        </div>
    </form>
</body>
</html>
