<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeatReservationPage.aspx.cs" Inherits="PLWebcinemagic.SeatReservationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seat Reservation</title>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" OnClick="btnLogout_Click"></asp:Button>
    <div>
    
        SEAT RESERVATION:<br />
        <br />
        <asp:Label ID="MovieTitel" runat="server"></asp:Label>
        <br />
        <asp:Label ID="MovieTime" runat="server"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="ddlRow" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Row" runat="server"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlSeat" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Seat" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="ADD" />
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
    </form>
</body>
</html>
