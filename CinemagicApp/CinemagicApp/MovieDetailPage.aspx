<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieDetailPage.aspx.cs" Inherits="PLWebcinemagic.MovieDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MovieDetail</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" OnClick="btnLogout_Click"></asp:Button>
    <div>
        <asp:Label ID="lblTitleValue" runat="server"></asp:Label>
        <br />
        <asp:Image ID="picture" runat="server"></asp:Image>
        <asp:Label ID="lblDescription" Text="Description" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblDescriptionValue" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblLength" Text="Length: " runat="server"></asp:Label>
        <asp:Label ID="lblLengthValue" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblFsk" Text="FSK: " runat="server"></asp:Label>
        <asp:Label ID="lblFskValue" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblGenre" Text="Genre: " runat="server"></asp:Label>
        <asp:Label ID="lblGenreValue" runat="server"></asp:Label>
    </div>
    <div>
        NEXT SHOWS:
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="DateAndTime1" />
        <asp:Button ID="Button2" runat="server" Text="DateAndTime2" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="DateAndTime3" />
    </div>
    </form>
</body>
</html>
