<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="PLWebcinemagic._DefaultPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Welcome</title>
    <link rel="stylesheet" href="Styles/DefaultPage.css" />
    <link rel="stylesheet" href="Styles/Layout.css"/>
    <link rel="shortcut icon" type="image/x-icon" href="Images/cinemagiclogo.png" />
</head>
<body>
    <form id="form1" runat="server">
         <div id="header">
             <asp:Image ID="logo" ImageUrl="Images/cinemagiclogo.png" runat="server"/>
        </div>
        <div id="content">
            <div id="welcomeText">
                WELCOME TO CINEMAGIC!
                <br />
                YOUR FRIENDLY BOOKING SYSTEM.
                <br /> 
            </div>
            <div id="buttonArea">
                <asp:Button ID="btnLogin" runat="server" Text="LOG IN" OnClick="btnLogin_Click" />
                <asp:Button ID="btnSignup" runat="server" Text="SIGN UP" OnClick="btnSignup_Click" />
            </div>
        </div>
        <div id="footer">
            Copyright © Sabine Hubner | Martin Gugler | Junxiang Qiu
        </div>
    </form>
</body>
</html>
