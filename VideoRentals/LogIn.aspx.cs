using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//imports for SQL
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace VideoRentals
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_signIn.Visible = false;
        }

        protected void btn_LogIn_Click(object sender, EventArgs e)
        {
           using(SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCustomerInfo"].ConnectionString))
            {
                sqlConnection.Open();
                string query = "SELECT COUNT(1) FROM regi WHERE email=@email AND passwd=@passwd";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@email", txtBox_email.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@passwd", txtBox_password.Text.Trim());

                //counting the number of users of the provided details
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                if (count == 1)
                {
                    string queryName = "SELECT firstName FROM regi WHERE email=@email";
                    string queryLast = "SELECT lastName FROM regi WHERE email=@email";
                    string queryPhoneNo = "SELECT phoneNumber FROM regi WHERE email=@email";
                    string queryDOB = "SELECT dateOfBirth FROM regi WHERE email=@email";
                    string queryID = "SELECT ID FROM regi WHERE email=@email";

                    //For name
                    SqlCommand sqlCommandName = new SqlCommand(queryName, sqlConnection);
                    sqlCommandName.Parameters.AddWithValue("@email", txtBox_email.Text.Trim());
                    //For last name
                    SqlCommand sqlCommandLast = new SqlCommand(queryLast, sqlConnection);
                    sqlCommandLast.Parameters.AddWithValue("@email", txtBox_email.Text.Trim());
                    //For Phone number
                    SqlCommand sqlCommandPhone = new SqlCommand(queryPhoneNo, sqlConnection);
                    sqlCommandPhone.Parameters.AddWithValue("@email", txtBox_email.Text.Trim());
                    //For Date of Birth
                    SqlCommand sqlCommandDOB = new SqlCommand(queryDOB, sqlConnection);
                    sqlCommandDOB.Parameters.AddWithValue("@email", txtBox_email.Text.Trim());
                    //For ID
                    SqlCommand sqlCommandID = new SqlCommand(queryID, sqlConnection);
                    sqlCommandID.Parameters.AddWithValue("@email", txtBox_email.Text.Trim());

                    //Writing the name of the user with the email associated
                    //Session["firstName"] = sqlCommandName.ExecuteScalar().ToString();


                    //Creating a cookie to store information about the user
                    HttpCookie cookie = new HttpCookie("UserDetails");
                    string name = sqlCommandName.ExecuteScalar().ToString();
                    string last = sqlCommandLast.ExecuteScalar().ToString();
                    string phoneNumber = sqlCommandPhone.ExecuteScalar().ToString();
                    string dateOfBirth = sqlCommandDOB.ExecuteScalar().ToString();
                    string id = sqlCommandID.ExecuteScalar().ToString();

       
                    cookie.Values.Add("Name", name);
                    cookie.Values.Add("LastName", last);
                    cookie.Values.Add("PhoneNumber", phoneNumber);
                    cookie.Values.Add("DateOfBirth", dateOfBirth);
                    cookie.Values.Add("Email", txtBox_email.Text);
                    cookie.Values.Add("ID", id);

                    //Making the cookie persistent
                    cookie.Expires = DateTime.Now.AddDays(1);

                    Response.Cookies.Add(cookie);
                    //Redirecting the user to the other webpage
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    lbl_signIn.Visible = true;
                }

                sqlConnection.Close();
            }
        }
    }
}