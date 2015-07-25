<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoviesPage.aspx.cs" Inherits="PLWebcinemagic.MoviesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movies</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" OnClick="btnLogout_Click"></asp:Button>
        </div>
        <div>
            <h1>CHOOSE YOUR MOVIE:</h1>
            <asp:DataList ID="DlMovies" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnPicture" runat="server" ImageUrl='<%# Eval("PictureUrl")%>' OnClick="ibtnPicture_Click" CommandArgument='<%# Eval("MovieId") + "," + Eval("Title")%>' Width="200px"></asp:ImageButton>
                    <br />
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title")%>'></asp:Label>
                </ItemTemplate>
            </asp:DataList>
       </div>
        
    </form>
</body>
</html>
