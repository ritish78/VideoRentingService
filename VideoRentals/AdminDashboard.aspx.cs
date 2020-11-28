using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//imports for SQL connection
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace VideoRentals
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_AddVideo.Visible = false;
            lbl_AddUser.Visible = false;
            lbl_SearchResult.Visible = false;

            if (Request.Cookies["AdminDetails"] != null)
            {
                HttpCookie cookie = Request.Cookies["AdminDetails"];

                lbl_AdminNameData.Text = cookie["Name"] + " " + cookie["LastName"];
                lbl_AdminEmailData.Text = cookie["Email"];
            }

        }

        protected void btn_AddVideo_Click(object sender, EventArgs e)
        {
            lbl_AddUser.Visible = false;

            

            using(SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCustomerInfo"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    if (fileUpload_Thumnail.HasFile)
                    {
                        string fileExtension = System.IO.Path.GetExtension(fileUpload_Thumnail.FileName);


                        if (fileExtension.ToUpper().Equals(".PNG") || fileExtension.ToUpper().Equals(".JPG") || fileExtension.ToUpper().Equals(".JPEG"))
                        {
                            //Getting the uploaded file Date and Time
                            //Returns 10 / 10 / 2010 12:00 AM
                            //if we change 'g' to 'd' it returns date only. 10 / 10 / 2020
                            //string dateTime = DateTime.Today.ToString("g");
                            //Getting the thumbnail first word and adding dateTime to it
                            //string thumbnailName = fileUpload_Thumnail.FileName.Split('.')[0] + fileExtension;

                            //Saving the thumbnail
                            fileUpload_Thumnail.SaveAs(Server.MapPath("~/blob/") + fileUpload_Thumnail.FileName);

                            //Referencing thumnail name to the database
                            string addWithThumbnail = "INSERT INTO videoInfo(thumbnail,title,lenth,rating,category) VALUES(@thumbnail,@title,@lenth,@rating,@category)";
                            SqlCommand addSqlCommand = new SqlCommand(addWithThumbnail, sqlConnection);
                            addSqlCommand.Parameters.AddWithValue("@thumbnail", fileUpload_Thumnail.FileName);
                            addSqlCommand.Parameters.AddWithValue("@title", txtBox_Title.Text.Trim());
                            addSqlCommand.Parameters.AddWithValue("@lenth", Convert.ToDateTime(txtBox_Length.Text.Trim()));
                            addSqlCommand.Parameters.AddWithValue("@rating", txtBox_Rating.Text.Trim());
                            addSqlCommand.Parameters.AddWithValue("@category", txtBox_Category.Text.Trim());

                            addSqlCommand.ExecuteNonQuery();                           
                        }
                        else
                        {
                            lbl_AddVideo.Text = "Please add only images with PNG and JPG extension";
                            lbl_AddVideo.Visible = true;
                        }
                    }
                    else
                    {
                        string addQuery = "INSERT INTO videoInfo(title,lenth,rating,category) VALUES(@title,@lenth,@rating,@category)";
                        SqlCommand addSqlCommand = new SqlCommand(addQuery, sqlConnection);
                        addSqlCommand.Parameters.AddWithValue("@title", txtBox_Title.Text.Trim());
                        addSqlCommand.Parameters.AddWithValue("@lenth", Convert.ToDateTime(txtBox_Length.Text.Trim()));
                        addSqlCommand.Parameters.AddWithValue("@rating", txtBox_Rating.Text.Trim());
                        addSqlCommand.Parameters.AddWithValue("@category", txtBox_Category.Text.Trim());

                        addSqlCommand.ExecuteNonQuery();
                    }


                    //Showing the video added sucessfully!
                    lbl_AddVideo.Visible = true;

                    //Removing everything from the text box if added sucessfully
                    txtBox_Title.Text = string.Empty;
                    txtBox_Length.Text = string.Empty;
                    txtBox_Rating.Text = string.Empty;
                    txtBox_Category.Text = string.Empty;

                }
                catch (Exception)
                {
                    lbl_AddVideo.Text = "Sorry! Due to some error, couldn't add video!";
                    lbl_AddVideo.Visible = true;

                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        protected void btn_AddUser_Click(object sender, EventArgs e)
        {
            lbl_AddVideo.Visible = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCustomerInfo"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    string addQuery = "INSERT INTO regi(firstName,lastName,email,passwd,phoneNumber,dateOfBirth) values(@firstName,@lastName,@email,@passwd,@phoneNumber,@dateOfBirth)";
                    SqlCommand addSqlCommand = new SqlCommand(addQuery, sqlConnection);
                    addSqlCommand.Parameters.AddWithValue("@firstName", txtBox_FirstName.Text.Trim());
                    addSqlCommand.Parameters.AddWithValue("@lastName", txtBox_LastName.Text.Trim());
                    addSqlCommand.Parameters.AddWithValue("@email", txtBox_Email.Text.Trim());
                    addSqlCommand.Parameters.AddWithValue("@passwd", txtBox_Password.Text.Trim());
                    addSqlCommand.Parameters.AddWithValue("@phoneNumber", txtBox_PhoneNumber.Text.Trim());
                    addSqlCommand.Parameters.AddWithValue("@dateOfBirth", txtBox_DateOfBirth.Text.Trim());

                    addSqlCommand.ExecuteNonQuery();

                    //Making 'User added sucessfully!' label display in user's screen
                    lbl_AddUser.Visible = true;

                    //Removing everything from textbox if added sucessfully
                    txtBox_FirstName.Text = string.Empty; 
                    txtBox_LastName.Text = string.Empty;
                    txtBox_Email.Text = string.Empty;
                    txtBox_Password.Text = string.Empty;
                    txtBox_PhoneNumber.Text = string.Empty;
                    txtBox_DateOfBirth.Text = string.Empty;

                }
                catch (Exception)
                {
                    lbl_AddUser.Text = "Sorry! Due to some error, couldn't add user!";
                    lbl_AddUser.Visible = false;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        protected void imgBtn_search_Click(object sender, ImageClickEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCustomerInfo"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    if (!txtBox_search.Equals(string.Empty))
                    {
                        //Creating the data table
                        DataTable dataTable = new DataTable();

                        //Adding the table header
                        dataTable.Columns.AddRange(new DataColumn[5] {new DataColumn("Thumbnail", typeof(string)),
                                        new DataColumn("Title", typeof(string)), new DataColumn("Length", typeof(string)),
                                        new DataColumn("Rating", typeof(string)), new DataColumn("Category", typeof(string))});
                        string thumbnail = "";

                        string getVideo = "SELECT * FROM videoInfo WHERE title=@title";
                        SqlCommand getVideoCommand = new SqlCommand(getVideo, sqlConnection);
                        getVideoCommand.Parameters.AddWithValue("@title", txtBox_search.Text);

                        int count = 0;
                        using (SqlDataReader sqlDataReader = getVideoCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                count++;
                                if (sqlDataReader.GetValue(1) == null || sqlDataReader.GetValue(1).ToString().Equals(string.Empty))
                                {
                                    thumbnail = "<img src=\"/blob/defaultThumbnail.png\" />";
                                }
                                else
                                {
                                    thumbnail = "<img src=\"/blob/" + sqlDataReader.GetValue(1).ToString() + "\" width=\"64\" height=\"64\">";
                                }

                                dataTable.Rows.Add(thumbnail, sqlDataReader.GetValue(2), sqlDataReader.GetValue(3), sqlDataReader.GetValue(4), sqlDataReader.GetValue(5));
                            }
                        }
                        StringBuilder sb = new StringBuilder();
                        //Creating a HTML table
                        sb.Append("<table class=\"table table-hover\">");
                        sb.Append("<tr>");

                        if (count != 0)
                        {
                            //Adding table header
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                sb.Append("<td><b>" + column.ColumnName + "</b></td>");
                            }

                            //Adding data from rows
                            foreach (DataRow row in dataTable.Rows)
                            {
                                sb.Append("<tr>");
                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    sb.Append("<td>" + row[column.ColumnName].ToString() + "</td>");
                                }
                                sb.Append("</tr>");
                            }

                            //Closing table
                            sb.Append("</table>");
                            lbl_SearchResult.Text = sb.ToString();
                            lbl_SearchResult.Visible = true;
                        }
                        else
                        {
                            lbl_SearchResult.Text = "Searched Video does not exists!";
                            lbl_SearchResult.Visible = true;
                        }
                    }
                    else
                    {
                        lbl_SearchResult.Text = "Enter video title to search!";
                        lbl_SearchResult.Visible = true;
                    }
                }
                catch (Exception)
                {
                    lbl_SearchResult.Text = "Couldn't fetch the searched video!";
                    lbl_SearchResult.Visible = true;
                }
                finally
                {
                    sqlConnection.Close();
                }

            }
        }
    }
}