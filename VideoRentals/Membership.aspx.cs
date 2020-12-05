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
    public partial class Membership : System.Web.UI.Page
    {
        private HttpCookie cookie;

        protected void Page_Load(object sender, EventArgs e)
        {
            //At first calendar and the buttons associated with it is not visible.
            if (!IsPostBack) {
                calendar_membership.Visible = false;
                btn_save.Visible = false;
                btn_Close.Visible = false;
            }

            //Getting the person's info
            if (Request.Cookies["UserDetails"] != null)
            {
                cookie = Request.Cookies["UserDetails"];

                lbl_NameData.Text = cookie["Name"] + " " + cookie["LastName"];
                lbl_EmailData.Text = cookie["Email"];
                lbl_PhoneNumberData.Text = cookie["PhoneNumber"];
                lbl_DateOfBirthData.Text = cookie["DateOfBirth"];
                

            }

            //Now creating the connection with the database for the membership info
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCustomerInfo"].ConnectionString))
            {
                cookie = Request.Cookies["UserDetails"];
                try
                {
                    sqlConnection.Open();

                    //Checking if the membership exists
                    string query = "SELECT COUNT(*) FROM membershipInfo WHERE ID=@ID";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@ID", cookie["ID"]);
                    int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    if (count == 1)
                    {
                        string queryTaken = "SELECT takenOn FROM membershipInfo WHERE ID=@ID";
                        SqlCommand sqlCommandTaken = new SqlCommand(queryTaken, sqlConnection);
                        sqlCommandTaken.Parameters.AddWithValue("@ID", cookie["ID"]);

                        //Splitting the date and time to get the date only. It stores as 10/10/2010 12:00:00 AM.
                        string[] takenOn = sqlCommandTaken.ExecuteScalar().ToString().Split(' ');

                        string queryTill = "SELECT finishedOn FROM membershipInfo WHERE ID=@ID";
                        SqlCommand sqlCommandTill = new SqlCommand(queryTill, sqlConnection);
                        sqlCommandTill.Parameters.AddWithValue("@ID", cookie["ID"]);

                        //splitting the date with the time. We don't need to display time.
                        string[] takenTill = sqlCommandTill.ExecuteScalar().ToString().Split(' ');

                        //Assigning the values in the labels
                        lbl_MembershipData.Text = "Yes";
                        lbl_RegisteredOnData.Text = takenOn[0];
                        lbl_RegisteredTillData.Text = takenTill[0];
                    }
                   
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }



        }

        protected void btn_Register_Click(object sender, EventArgs e)
        {
            //By clicking the register button, we are making calendar, and its associated buttons visible
            calendar_membership.Visible = true;
            btn_save.Visible = false;
            btn_Close.Visible = true;
        }

        protected void btn_Close_Click(object sender, EventArgs e)
        {
            //By clicking close, we are making the controls for calendar not visible to users
            calendar_membership.Visible = false;
            btn_save.Visible = false;
            btn_Close.Visible = false;

        }

        protected void calendar_membership_SelectionChanged(object sender, EventArgs e)
        {
            btn_save.Visible = true;

            
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCustomerInfo"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();


                    //Scenario 1 - Where the user is already member and needs to extend the membership
                    string checkQuery = "SELECT COUNT(*) FROM membershipInfo WHERE ID=@ID";
                    SqlCommand sqlCommandCheck = new SqlCommand(checkQuery, sqlConnection);
                    sqlCommandCheck.Parameters.AddWithValue("@ID", Request.Cookies["UserDetails"]["ID"]);

                    //if the memebership exists, then the table should have one row of user details
                    int count = Convert.ToInt32(sqlCommandCheck.ExecuteScalar());

                    if (count == 1)
                    {
                        string updateQuery = "UPDATE membershipInfo SET takenOn=@takenOn , finishedOn=@finishedOn WHERE ID=@ID";
                        SqlCommand updateSqlCommand = new SqlCommand(updateQuery, sqlConnection);
                        updateSqlCommand.Parameters.AddWithValue("@takenOn", DateTime.Now.ToString("MM-dd-yyyy"));
                        updateSqlCommand.Parameters.AddWithValue("@finishedOn", calendar_membership.SelectedDate.ToString("MM-dd-yyyy"));
                        updateSqlCommand.Parameters.AddWithValue("@ID", Request.Cookies["UserDetails"]["ID"]);

                        updateSqlCommand.ExecuteScalar();
                    }
                    if (count == 0)
                    {
                        //Scenario 2 - Where the user is not a member and needs to apply for membership
                        string insertQuery = "INSERT INTO membershipInfo(ID,takenOn,finishedOn) " +
                            "VALUES(@ID,@takenOn,@finishedOn)";
                        SqlCommand insertSqlCommand = new SqlCommand(insertQuery, sqlConnection);
                        insertSqlCommand.Parameters.AddWithValue("@ID", Request.Cookies["UserDetails"]["ID"]);
                        insertSqlCommand.Parameters.AddWithValue("@takenOn", DateTime.Now.ToString("MM-dd-yyyy"));
                        insertSqlCommand.Parameters.AddWithValue("@finishedOn", calendar_membership.SelectedDate.ToString("MM-dd-yyyy"));

                        insertSqlCommand.ExecuteScalar();
                    }

                    //Redirecting to the same website
                    Response.Redirect("Membership.aspx");

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }

            }
        }
    }
}