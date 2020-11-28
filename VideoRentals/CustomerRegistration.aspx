<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="VideoRentals.CustomerRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Here!</title>
    <link href="Style.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Modak&display=swap" rel="stylesheet">
    <style>
@import url('https://fonts.googleapis.com/css2?family=Pacifico&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Modak&family=Pacifico&display=swap');
</style>
</head>
<body>
    <form id="form1" runat="server">
        <section>
            <div class="container">
                <div class="innerContainer1">
                    <span>Use Social Media to Sign Up</span><br /><br />
                    <a href="#" class="fb">Sign up with Facebook</a><br />
                    <a href="#" class="tw">Sign up with Twitter</a><br />
                    <a href="#" class="gg">Sign up with Google</a><br />
                </div>
                <div class ="innerContainer2">
                    <h3>Sign up</h3>
                    <asp:TextBox ID="txtBox_firstName" placeholder="First Name" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_firstName" ControlToValidate="txtBox_firstName" runat="server" Font-Size="Small" ForeColor="Red" Display="Dynamic" ErrorMessage="First Name is required to continue."></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtBox_lastName" placeholder="Last Name" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_lastName" ControlToValidate="txtBox_lastName" runat="server"  Font-Size="Small" ForeColor="Red" Display="Dynamic" ErrorMessage="Last Name is required to continue."></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtBox_email" placeholder="Email" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_email" ControlToValidate="txtBox_email" runat="server"  Font-Size="Small" ForeColor="Red" Display="Dynamic" ErrorMessage="Email is required to continue."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_email" ControlToValidate="txtBox_email" Font-Size="Small" ForeColor="Red" Display="Dynamic" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please enter a valid email to continue."></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtBox_password" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_password" ControlToValidate="txtBox_password" Font-Size="Small" ForeColor="Red" Display="Dynamic" runat="server" ValidationExpression="((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{6,20})" ToolTip="Password needs to be between 8-20 characters, needs to contain atleast one digit, one upper case, one lower case and one special character" ErrorMessage="*"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtBox_confirmPassword" placeholder="Confirm Password"  TextMode="Password" runat="server"></asp:TextBox>
                    
                    <asp:CompareValidator ID="CompareValidator_password" runat="server" ControlToCompare="txtBox_password" ControlToValidate="txtBox_confirmPassword" Font-Size="Small" ForeColor="Red" Display="Dynamic" ErrorMessage="Password Mismatch. Please re enter the password.">Password Mismatch. Please re enter the password.</asp:CompareValidator>
                    <asp:TextBox ID="txtBox_phoneNumber" placeholder="Phone Number" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_phoneNumber" runat="server" ControlToValidate="txtBox_phoneNumber" Font-Size="Small" ForeColor="Red" ValidationExpression="[0-9]{10}" ErrorMessage="Enter number of 10 characters!"></asp:RegularExpressionValidator>
                    
                    <asp:TextBox ID="txtBox_dateOfBirth" placeholder="Date Of Birth" runat="server" OnTextChanged="txtBox_dateOfBirth_TextChanged"></asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_dateOfBirth" ControlToValidate="txtBox_dateOfBirth" Font-Size="Small" ForeColor="Red" Display="Dynamic" runat="server" ValidationExpression="[0-9]{2}/[0-9]{2}/[0-9]{4}"  ErrorMessage="Correct date format: MM/DD/YYYY"></asp:RegularExpressionValidator>
                    
                    <asp:Button ID="btn_signUp" OnClick="btn_signUp_Click" CssClass="myButton" runat="server" Text="Sign Up!" />
                    <asp:Label ID="lbl_signUp" Visible="false" runat="server" Text="" Font-Size="Small" ForeColor="#660066" Display="Dynamic"></asp:Label>
                </div>
                
               
            </div>
            <div>
                    <asp:Calendar ID="Calendar_dob" runat="server" Visible="false" ClientIDMode="Inherit" OnSelectionChanged="Calendar_dob_SelectionChanged"></asp:Calendar>
                </div>
        </section>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringCustomerInfo %>" SelectCommand="SELECT * FROM [regi]"></asp:SqlDataSource>
        
    </form>
    </body>
</html>
