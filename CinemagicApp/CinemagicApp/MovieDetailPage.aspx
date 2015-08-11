<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieDetailPage.aspx.cs" Inherits="PLWebcinemagic.MovieDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MovieDetail</title>
    <link rel="stylesheet" href="Styles/MovieDetailPage.css"/>
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
            <asp:Label ID="lblTitleValue" runat="server"></asp:Label>
            <div id="table">
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="picture" ImageAlign="Left" Width="300px" Height="450px" runat="server"></asp:Image>
                        </td>
                        <td class="textColumn">
                            <asp:Label ID="lblDescription" CssClass="" Text="Description:" runat="server"></asp:Label>
                            <br/>
                            <asp:Label ID="lblDescriptionValue" runat="server"></asp:Label>
                            <br/>
                            <asp:Label ID="lblLength" Text="Length: " runat="server"></asp:Label>
                            <asp:Label ID="lblLengthValue" runat="server"></asp:Label>
                            <br/>
                            <asp:Label ID="lblFsk" Text="FSK: " runat="server"></asp:Label>
                            <asp:Label ID="lblFskValue" runat="server"></asp:Label>
                            <br/>
                            <asp:Label ID="lblGenre" Text="Genre: " runat="server"></asp:Label>
                            <asp:Label ID="lblGenreValue" runat="server"></asp:Label>
                            <br/>
                            <br/>
                            <br/>
                            <asp:Label ID="lblNextShows" Text="NEXT SHOWS:" runat="server"></asp:Label> 
                            <br/>
                            <asp:Button ID="btn1" CssClass="bigButton" runat="server" Text="DateAndTime1" OnClick="btn1_Click" />
                            <asp:Button ID="btn2" CssClass="bigButton" runat="server" Text="DateAndTime2" OnClick="btn2_Click" />
                            <asp:Button ID="btn3" CssClass="bigButton" runat="server" Text="DateAndTime3" OnClick="btn3_Click"/>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                
            </div>
        </div>
        <div id="footer">
            Copyright © Sabine Hubner | Martin Gugler | Junxiang Qiu
        </div>
    </form>
</body>
</html>
