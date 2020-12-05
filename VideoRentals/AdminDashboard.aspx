<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="VideoRentals.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link href="Dashboard.css" rel="stylesheet" />
    <style>
@import url('https://fonts.googleapis.com/css2?family=Pacifico&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Modak&family=Pacifico&display=swap');
</style>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <h1>Admin Dashboard</h1>
           <hr class="my-4" />
          
        </div>
        <div class="jumbotron">
             <h4>Your details: </h4>
            <br />
            <table class="h5">
                <tr>
                    <td>
                        <asp:Label ID="lbl_AdminName" runat="server" Text="Name: "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbl_AdminNameData" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                <td>
                    <asp:Label ID="lbl_AdminEmail" runat="server" Text="Email: "></asp:Label>
                    
                </td>
                    <td>
                        <asp:Label ID="lbl_AdminEmailData" runat="server" Text=""></asp:Label>
                    </td>
                    </tr>
            </table>
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
        <div class="container">
            <div class="jumbotron">
                   <h4>Add Videos</h4>
                <br />
                       <table class="table table-hover">
                           <tr>
                               <td>
                               <asp:Label ID="lbl_Thumbnail" runat="server" Text="Thumbnail: "></asp:Label>
                                   </td>
                               <td>
                                   <asp:FileUpload ID="fileUpload_Thumnail" runat="server" />
                               </td>
                           </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Title" runat="server" Text="Title: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBox_Title" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Length" runat="server" Text="Length: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBox_Length" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Rating" runat="server" Text="Rating: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBox_Rating" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Category" runat="server" Text="Category: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBox_Category" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btn_AddVideo" CssClass="btn btn-primary" runat="server" Text="Add Video" OnClick="btn_AddVideo_Click" />
                        </td>
                    </tr>
                           <tr>
                               <td></td>
                               <td>
                                   <asp:Label ID="lbl_AddVideo" runat="server" Text="Video Added Sucessfully!" Visible="False"></asp:Label>
                               </td>
                           </tr>
                </table>
            </div>
        </div>

        <div class="container">
            <div class="jumbotron">
                <h4>Add User</h4>
                <br />    
                 <table class="table table-hover">
                    <tr>
                        <td>
                            <asp:Label ID="lbl_FirstName" runat="server" Text="First Name: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBox_FirstName" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_LastName" runat="server" Text="Last Name: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBox_LastName" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Email" runat="server" Text="Email: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBox_Email" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                         <td>
                             <asp:Label ID="lbl_Password" runat="server" Text="Password: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="txtBox_Password" CssClass="form-control" runat="server" TextMode="Password">
                             </asp:TextBox>
                         </td>
                     </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_PhoneNumber" runat="server" Text="Phone Number: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBox_PhoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                         <td>
                             <asp:Label ID="lbl_DateOfBirth" runat="server" Text="Date Of Birth: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="txtBox_DateOfBirth" CssClass="form-control" runat="server"></asp:TextBox>
                         </td>
                     </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btn_AddUser" CssClass="btn btn-primary" runat="server" Text="Add User" OnClick="btn_AddUser_Click" />
                        </td>
                    </tr>
                     <tr>
                         <td>
                         </td>
                         <td>
                             <asp:Label ID="lbl_AddUser" runat="server" Text="User added sucessfully!" Visible="False"></asp:Label>
                         </td>
                     </tr>
                </table>
            </div>
        </div>
            
            
    </form>
</body>
</html>
