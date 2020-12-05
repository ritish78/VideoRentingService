<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogIn.aspx.cs" Inherits="VideoRentals.AdminLogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Log In</title>
    <link href="LogInAdminStyleSheet.css" rel="stylesheet" />
    <style>
            @import url('https://fonts.googleapis.com/css2?family=Pacifico&display=swap');
         .auto-style1 {
             text-align: center;
         }
     </style>
</head>
<body>
    <form id="form1" runat="server">
        <section class="background">
        </section>
        <div class="section2">
            <div class="container">
                <div class="content">
                    <h2>Admin Log In</h2>

                    <asp:TextBox ID="txtBox_email" placeholder="email" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtBox_password" placeholder="password" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbl_signIn" runat="server" Text="Incorrect Details!" Visible="false" CssClass="lbl"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btn_LogIn" runat="server" Text="Submit" OnClick="btn_LogIn_Click" />
                </div>
             </div>

        </div>
    </form>
    
</body>
</html>
