<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeatReservationPage.aspx.cs" Inherits="PLWebcinemagic.SeatReservationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seat Reservation</title>
    <link rel="stylesheet" href="Styles/SeatReservationPage.css"/>
    <link rel="stylesheet" href="Styles/Layout.css"/>
    <link rel="shortcut icon" type="image/x-icon" href="Images/cinemagiclogo.png" />
</head>
<body>
    
    <form id="form1" runat="server">
        <div id="header">
            <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" OnClick="btnLogout_Click"></asp:Button>
            <asp:Image ID="logo" ImageUrl="Images/cinemagiclogo.png" runat="server"/>
        </div>
        <div id="content">
            SEAT RESERVATION:<br />
            <br />
            <asp:Label ID="lblMovieTitle" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblMovieTime" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblRow" Text="Row" runat="server"></asp:Label>
            <asp:DropDownList ID="ddlRow" runat="server"></asp:DropDownList>
            <br />
            <asp:Label ID="lblSeat" Text="Seat" runat="server"></asp:Label>
            <asp:DropDownList ID="ddlSeat" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" />
            <br />
            <br />
            YOUR CHOOSEN SEAT(S):<br />
            <asp:Label ID="lblChoosenSeat" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnDrop" runat="server" Text="DROP" />
            <br />
            <br />
            <asp:Button ID="btnBook" runat="server" OnClick="btnBook_Click" Text="BOOK" />
        </div>
        <div id="footer">
            Copyright © Sabine Hubner | Martin Gugler | Junxiang Qiu
        </div>
    </form>
</body>
</html>
