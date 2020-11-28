using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//imports for table
using System.Data;
using System.Text;
//imports for SQL
using System.Data.SqlClient;
using System.Configuration;


namespace VideoRentals
{
    public partial class Videos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //First, creating a data table to add video information to the table
                DataTable dataTable = new DataTable();

                //Adding the table header
                dataTable.Columns.AddRange(new DataColumn[5] {new DataColumn("Thumbnail", typeof(string)),
                                        new DataColumn("Title", typeof(string)), new DataColumn("Length", typeof(string)),
                                        new DataColumn("Rating", typeof(string)), new DataColumn("Category", typeof(string))});
                //dataTable.Rows.Add("First", "Testing Title", "Length of video", "Five Star", "Comedy");

                using(SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCustomerInfo"].ConnectionString))
                {
                    try
                    {
                        sqlConnection.Open();

                        string noOfVideos = "SELECT * FROM videoInfo";
                        SqlCommand videoSqlCommand = new SqlCommand(noOfVideos, sqlConnection);
                        int count = 0;
                        string thumbnail = "";
                        using (SqlDataReader reader = videoSqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count++;
                                //reader.GetValue(0) is ID of the video from the videoInfo table.
                                if (reader.GetValue(1) == null || reader.GetValue(1).ToString().Equals(string.Empty))
                                {
                                    thumbnail = "<img src=\"/blob/defaultThumbnail.png\" />";
                                }
                                else
                                {
                                    thumbnail = "<img src=\"/blob/" + reader.GetValue(1).ToString() + "\" width=\"64\" height=\"64\">";
                                }
                                
                                dataTable.Rows.Add(thumbnail, reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5));
                            }
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

                StringBuilder sb = new StringBuilder();
                //Creating a HTML table
                sb.Append("<table class=\"table table-hover\">");
                sb.Append("<tr>");

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
                lbl_Table.Text = sb.ToString();
            }
        }
    }
}