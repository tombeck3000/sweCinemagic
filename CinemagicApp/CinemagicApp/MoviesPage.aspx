<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoviesPage.aspx.cs" Inherits="PLWebcinemagic.MoviesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movies</title>
    <link rel="stylesheet" href="Styles/MoviesPage.css" />
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
            <div id="headText">PLEASE CHOOSE YOUR MOVIE:</div>
            <asp:DataList ID="DlMovies" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnPicture" runat="server" ImageUrl='<%# Eval("PictureUrl")%>' OnClick="ibtnPicture_Click" CommandArgument='<%# Eval("MovieId")%>' Width="200px" Height="300px"></asp:ImageButton>
                    <br />
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title")%>'></asp:Label>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div id="footer">
            Copyright © Sabine Hubner | Martin Gugler | Junxiang Qiu
        </div>
        
    </form>
</body>
</html>
