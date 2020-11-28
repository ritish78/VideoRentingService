<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="VideoRentals.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link href="LogInStyleSheet.css" rel="stylesheet" />
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
                <div class="social">
                    <asp:Image ID="image_facebook" runat="server" ImageUrl="~/Images/Facebook-Logo.png" ToolTip="Facebook" />
                    <asp:Image ID="image_twitter" runat="server" ImageUrl="~/Images/Twitter-Logo.png" ToolTip="Twitter"/>
                    <asp:Image ID="image_google" runat="server" ImageUrl="~/Images/Google-Logo.png" ToolTip="Google"/>
                </div>

                <div class="content">
                    <h2>Sign In</h2>

                    <asp:TextBox ID="txtBox_email" placeholder="email" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtBox_password" placeholder="password" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <br />
                    <asp:LinkButton ID="lnkBtn_SignUp" runat="server" PostBackUrl="~/CustomerRegistration.aspx" Text="Sign up here." CssClass="signup"></asp:LinkButton>
                    <asp:LinkButton ID="lnkBtn_Admin" runat="server" PostBackUrl="~/AdminLogIn.aspx" Text="Admin Sign in." CssClass="signup"></asp:LinkButton>
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
