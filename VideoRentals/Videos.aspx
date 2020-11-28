<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Videos.aspx.cs" Inherits="VideoRentals.Videos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Videos to your library!</title>
    <link href="VideoStyleSheet.css" rel="stylesheet" />
    <style>
@import url('https://fonts.googleapis.com/css2?family=Pacifico&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Modak&family=Pacifico&display=swap');
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Videos</h1>
            <hr class="my-4" />
        </div>
        <div>
            <h2>Top Rated Videos:</h2>
        </div>
        <div class="jumbotron">
          <asp:Label ID="lbl_Table" runat="server" Text=""></asp:Label>
        </div>
        <div>
            
        </div>
    </form>
</body>
</html>
