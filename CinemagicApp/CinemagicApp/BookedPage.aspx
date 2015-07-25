<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookedPage.aspx.cs" Inherits="PLWebcinemagic.BookedPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" OnClick="btnLogout_Click"></asp:Button>
    <div>
    
        THANK YOU FOR USING CINEMAGIC!<br />
        YOUR FRIENDLY BOOKING SYSTEM.<br />
        <br />
        <br />
        <br />
        YOUR RESERVATION NUMBER:<br />
        <asp:Label ID="lblReservationNumber" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
