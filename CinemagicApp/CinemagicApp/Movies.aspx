<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="PLWebcinemagic.Movies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movies</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" OnClick="btnLogout_Click"></asp:Button>
    <div>
    PLEASE CHOOSE YOUR MOVIE:
        <br />
            <div>
            <asp:Image ID="Image1" runat="server" Height="139px" Width="89px"/>
                <asp:Button ID="btnMovie1" runat="server" Text="Movie1" OnClick="Movie1_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
        <div>
            <asp:Image ID="Image2" runat="server" Height="139px" Width="89px" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </div>
       </div>
    </form>
</body>
</html>
