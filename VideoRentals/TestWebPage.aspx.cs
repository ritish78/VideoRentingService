using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//imports for table
using System.Data;
using System.Text;

namespace VideoRentals
{
    public partial class TestWebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.AddRange(new DataColumn[5] {new DataColumn("Thumbnail", typeof(string)),
                                        new DataColumn("Title", typeof(string)), new DataColumn("Length", typeof(string)),
                                        new DataColumn("Rating", typeof(string)), new DataColumn("Category", typeof(string))});
                dataTable.Rows.Add("Thumnail Picture", "Testing Title", "Length of video", "Five Star", "Comedy");



                StringBuilder sb = new StringBuilder();
                //Creating a HTML table
                sb.Append("<table class=\"table table-hover\">");
                sb.Append("<tr>");

                //Adding table header
                foreach (DataColumn column in dataTable.Columns)
                {
                    sb.Append("<td>" + column.ColumnName + "</td>");
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

                    //Closing table
                    sb.Append("</table>");
                    Label1.Text = sb.ToString();
                }
                Label2.Text = "<img src=\"/blob/defaultThumbnail.png\" />";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string thumbnailName = FileUpload1.FileName.Split('.')[0] + DateTime.Today.ToString("g").Split(' ')[0];
                FileUpload1.SaveAs(Server.MapPath("~/blob/") + thumbnailName);
                Label3.Text = "Uploaded sucessfully!";
            }
            else
            {
                Label3.Text = "Couldn't add";
            }
        }
    }
}