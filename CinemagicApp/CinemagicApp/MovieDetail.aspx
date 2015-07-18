<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieDetail.aspx.cs" Inherits="PLWebcinemagic.MovieDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MovieDetail</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" OnClick="btnLogout_Click"></asp:Button>
    <div>
    PLEASE CHOOSE YOUR MOVIE:
        <br />
            <div>
            <asp:Label ID="Label1" runat="server" Text="Titel"></asp:Label>
                <br />
            <asp:Image ID="Image1" runat="server" Height="139px" Width="89px" />
                <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
            <br />
            </div>
        <div>
            NEXT SHOWS:<br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="DateAndTime1" />
            <asp:Button ID="Button2" runat="server" Text="DateAndTime2" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="DateAndTime3" />

        </div>
       </div>
    </form>
</body>
</html>
