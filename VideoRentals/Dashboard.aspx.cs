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
using System.Text;

namespace VideoRentals
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_SearchResult.Visible = false;

            if (Request.Cookies["UserDetails"] != null)
            {
                HttpCookie cookie = Request.Cookies["UserDetails"];
             
                lbl_NameData.Text = cookie["Name"] + " " + cookie["LastName"];
                lbl_EmailData.Text = cookie["Email"];
                lbl_PhoneNumberData.Text = cookie["PhoneNumber"];
                lbl_DateOfBirthData.Text = cookie["DateOfBirth"];

            }

            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCustomerInfo"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    //To get Number of videos rented
                    string videoRentedQuery = "SELECT noOfVideos FROM regi WHERE email=@email";
                    SqlCommand videoSqlCommand = new SqlCommand(videoRentedQuery, sqlConnection);
                    videoSqlCommand.Parameters.AddWithValue("@email", Request.Cookies["UserDetails"]["Email"]);

                    var noOfVideos = videoSqlCommand.ExecuteScalar();

                    if (noOfVideos.ToString().Equals(string.Empty) || noOfVideos == null)
                    {
                        lbl_VideosRented.Text = "Videos Rented: 0";
                    }
                    else
                    {
                        lbl_VideosRented.Text = "Videos Rented: " + noOfVideos.ToString();
                    }


                    //To get Membership
                    string membershipQuery = "SELECT COUNT(*) FROM membershipInfo WHERE ID=@ID";
                    SqlCommand membershipSqlCommand = new SqlCommand(membershipQuery, sqlConnection);
                    membershipSqlCommand.Parameters.AddWithValue("@ID", Request.Cookies["UserDetails"]["ID"]);

                    int activeMembership = Convert.ToInt32(membershipSqlCommand.ExecuteScalar());

                    if (activeMembership == 0)
                    {
                        lbl_Membership.Text = "Membership not active";
                    }
                    else
                    {
                        lbl_Membership.Text = "Membership active";
                    }

                    //To get overdue Fees
                    string overdueQuery = "SELECT overdueFees FROM regi WHERE EMAIL=@email";
                    SqlCommand overdueSqlCommand = new SqlCommand(overdueQuery, sqlConnection);
                    overdueSqlCommand.Parameters.AddWithValue("@email", Request.Cookies["UserDetails"]["Email"]);

                    //double overdue = Convert.ToDouble(overdueSqlCommand.ExecuteScalar());
                    var overdue = overdueSqlCommand.ExecuteScalar();

                    if (overdue.ToString().Equals(string.Empty) || overdue == null)
                    {
                        lbl_OverdueFees.Text = "Overdue Fees: 0";
                    }
                    else
                    {
                        lbl_OverdueFees.Text = "Overdue Fees: " + overdue.ToString();
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

        protected void imgBtn_search_Click(object sender, ImageClickEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCustomerInfo"].ConnectionString))
            {
                try {
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