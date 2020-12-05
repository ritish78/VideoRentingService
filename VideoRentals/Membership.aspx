<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Membership.aspx.cs" Inherits="VideoRentals.Membership" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Membership</title>
    <link href="MembershipStyleSheet.css" rel="stylesheet" />
   <style>
@import url('https://fonts.googleapis.com/css2?family=Pacifico&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Modak&family=Pacifico&display=swap');
</style>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <h1>Membership</h1>
        </div>
        
        <div class="jumbotron">
            <h2>Your details: </h2>
            <br />
            <h3>
            <asp:Label ID="lbl_Name" runat="server" Text="Name: "></asp:Label>
            <asp:Label ID="lbl_NameData" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbl_email" runat="server" Text="Email: "></asp:Label>
            <asp:Label ID="lbl_EmailData" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbl_PhoneNumber" runat="server" Text="Phone Number: "></asp:Label>
            <asp:Label ID="lbl_PhoneNumberData" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbl_DateOfBirth" runat="server" Text="Date of Birth: "></asp:Label>
            <asp:Label ID="lbl_DateOfBirthData" runat="server"></asp:Label>
                </h3>
            
        </div>

        <div class="jumbotron">
            <h2>Membership Details: </h2>
            <hr class="my-4" />
            <br />
            
                <table class="table table-hover">
                    <tr class="table-active">
                        <td>
                <asp:Label ID="lbl_Membership" runat="server" Text="Membership active: "></asp:Label></td>
                <td><asp:Label ID="lbl_MembershipData" runat="server" Text="No"></asp:Label></td>
               
                        </tr>
                    <tr class="table-light"><td>
                <asp:Label ID="lbl_RegisteredOn" runat="server" Text="Registered On: "></asp:Label></td>
                <td><asp:Label ID="lbl_RegisteredOnData" runat="server" Text="N/A"></asp:Label></td>
                
                        </tr>
                <tr class="table-active"><td><asp:Label ID="lbl_RegisteredTill" runat="server" Text="Registered Till: "></asp:Label></td>
                <td><asp:Label ID="lbl_RegisteredTillData" runat="server" Text="N/A"></asp:Label></td>
                    </tr>
                    <tr class="table-responsive-md"><td>
               
                <asp:Button ID="btn_Register" CssClass="btn btn-outline-primary" runat="server" Text="Register Your Membership" OnClick="btn_Register_Click" />
                        </td></tr>
                    <tr class="table-active">
                       <td></td>
                        <td><asp:Calendar ID="calendar_membership" runat="server" OnSelectionChanged="calendar_membership_SelectionChanged" ValidateRequestMode="Disabled"></asp:Calendar>

                            </td>
                    </tr><tr><td></td>
                    <td><asp:Button ID="btn_save" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btn_save_Click" />
                        
                            <asp:Button ID="btn_Close" CssClass="btn btn-secondary" runat="server" Text="Close" OnClick="btn_Close_Click" />
                        </td>
                         </tr>
                    </table>
           
        </div>
    </form>
</body>
</html>
