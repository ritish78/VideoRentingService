<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWebPage.aspx.cs" Inherits="VideoRentals.TestWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Testing</title>
    <link href="VideoStyleSheet.css" rel="stylesheet" />
    <style>
@import url('https://fonts.googleapis.com/css2?family=Pacifico&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Modak&family=Pacifico&display=swap');
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Image ID='Image1' runat='server' ImageUrl='~/blob/defaultThumbnail.png' />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
