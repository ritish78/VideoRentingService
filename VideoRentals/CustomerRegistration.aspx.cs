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
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_signUp.Visible = false;
        }

        protected void btn_signUp_Click(object sender, EventArgs e)
        {
            //Setting up connection to the database using the connection string
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCustomerInfo"].ConnectionString);

            try
            {
                sqlConnection.Open();
                string command = "INSERT INTO regi(firstName,lastName,email,passwd,phoneNumber,dateOfBirth) " +
                    "VALUES(@firstName,@lastName,@email,@passwd,@phoneNumber,@dateOfBirth)";
                SqlCommand cmd = new SqlCommand(command, sqlConnection);

                cmd.Parameters.AddWithValue("@firstName", txtBox_firstName.Text.Trim());
                cmd.Parameters.AddWithValue("@lastName", txtBox_lastName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtBox_email.Text.Trim());
                cmd.Parameters.AddWithValue("@passwd", txtBox_password.Text.Trim());
                cmd.Parameters.AddWithValue("@phoneNumber", txtBox_phoneNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@dateOfBirth", txtBox_dateOfBirth.Text.Trim());

                //checking if the email provided in the textbox is in the database
                string mailQuery = "SELECT COUNT(*) FROM regi WHERE email=@email";
                SqlCommand sqlCommand = new SqlCommand(mailQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@email", txtBox_email.Text.Trim());
                int noOfEmail = Convert.ToInt32(sqlCommand.ExecuteScalar());

                if (noOfEmail == 0)
                {

                    cmd.ExecuteNonQuery();

                    lbl_signUp.Visible = true;
                    lbl_signUp.Text = "Signed Up Sucessfully!";
                }
                else
                {
                    lbl_signUp.Visible = true;
                    lbl_signUp.Text = "Email is already in use!";
                }

            }
            catch (Exception)
            {
                lbl_signUp.Visible = true;
                lbl_signUp.Text = "Oops! Something went wrong!";
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void txtBox_dateOfBirth_TextChanged(object sender, EventArgs e)
        {
            Calendar_dob.Visible = false;

        }

        protected void Calendar_dob_SelectionChanged(object sender, EventArgs e)
        {
            txtBox_dateOfBirth.Text = Calendar_dob.SelectedDate.Month.ToString() + "/" + Calendar_dob.SelectedDate.Day.ToString() + "/" + Calendar_dob.SelectedDate.Year.ToString();

        }

    }
}
