<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="VideoRentals.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link href="Dashboard.css" rel="stylesheet" />
    <style>
@import url('https://fonts.googleapis.com/css2?family=Pacifico&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Modak&family=Pacifico&display=swap');
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Dashboard</h1>
        </div>
        
        <div class="jumbotron">
            <h4>Your details: </h4>
            <br />
            <h5>
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
                </h5>
            
        </div>
     
        <div class="container">
            <div class="jumbotron">
                <h4>Search any video</h4>
               <div>
                   <table class="table-active">
                       <tr>
                           <td>
                               <asp:TextBox ID="txtBox_search" runat="server" class="form-control mr-sm-2" TextMode="SingleLine"  placeholder="Search"></asp:TextBox>
                           </td>
                           <td>
                               <asp:ImageButton ID="imgBtn_search" runat="server" CssClass="btn btn-secondary btn-center" ImageUrl="~/Images/Search-Icon.png" OnClick="imgBtn_search_Click"/> 

                           </td>
                       </tr>
                       <tr>
                           <td>
                               <asp:Label ID="lbl_SearchResult" runat="server" Text=""></asp:Label>
                           </td>
                       </tr>
                   </table>
                   
                   
               </div> 
            </div>
        </div>
        <section class="card mb-3">
            
            <h4 class="card-body">Select Options:</h4>
            
            <table class="btn-center">
                <tr>
                    <td>
                <div>
                    <div class="card text-white bg-warning mb-3" style="max-width: 20rem;">
                        <div class="card-header">
                            <asp:Label ID="lbl_VideosRented" runat="server" Text="Videos Rented"></asp:Label>
                        </div>
                            <div class="card-body">
                                <asp:ImageButton ID="imgBtn_VideosRented" runat="server" ImageUrl="~/Images/videoRented.png" AlternateText="0" PostBackUrl="~/Videos.aspx"/>
                            </div>
                    </div>
                </div>
                        </td>
                    <td>
                    
                        <div class="card text-white bg-success mb-3" style="max-width: 20rem;">
                            <div class="card-header">
                                <asp:Label ID="lbl_Membership" runat="server" Text="Membership"></asp:Label>
                            </div>
                                <div class="card-body">
                                    <asp:ImageButton ID="imgBtn_Membership" runat="server" ImageUrl="~/Images/membership.png" PostBackUrl="~/Membership.aspx" />
                                </div>
                        </div>
                        </td>
                    <td>
                        <div>
                    <div class="card text-white bg-danger mb-3" style="max-width: 20rem;">
                        <div class="card-header">
                            <asp:Label ID="lbl_OverdueFees" runat="server" Text="Overdue Fees"></asp:Label>
                        </div>
                            <div class="card-body">
                            <asp:ImageButton ID="imgBtn_OverdueFees" runat="server" ImageUrl="~/Images/overdueFees.png"/>
                            </div>
                        </div>
                    </div>
                        </td>
                    </tr>
                </table>
     
        </section>
   </form>
</body>
</html>
