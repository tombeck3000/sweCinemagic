<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookedPage.aspx.cs" Inherits="PLWebcinemagic.BookedPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Booked</title>
    <link rel="stylesheet" href="Content/BookedPage.css"/>
    <link rel="stylesheet" href="Content/Layout.css"/>
    <link rel="shortcut icon" type="image/x-icon" href="Images/cinemagiclogo.png" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" OnClick="btnLogout_Click"></asp:Button>
            <asp:Image ID="logo" ImageUrl="Images/cinemagiclogo.png" runat="server"/>
        </div>
        <div id="content">
            THANK YOU FOR USING CINEMAGIC!
            <br />
            YOUR FRIENDLY BOOKING SYSTEM.
            <br />
            YOUR RESERVATION NUMBER: <asp:Label ID="lblReservationNumber" runat="server"></asp:Label>
        </div>
        <div id="footer">
            Copyright © Sabine Hubner | Martin Gugler | Junxiang Qiu
        </div>
    </form>
</body>
</html>
