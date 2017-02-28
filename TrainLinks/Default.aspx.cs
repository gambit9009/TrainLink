using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrainLinks
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectToSQL();
        }
        private void ConnectToSQL()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["TrainLinkConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(constring);
            connect.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            lblPageTitle.Text = "Search";
            command.CommandText = "GetCategories";
            //command.Parameters.Add("@Cat", SqlDbType.VarChar, 50).Value = strCat;
            command.Connection = connect;
            SqlDataReader reader = command.ExecuteReader();
            Panel1.Controls.Add(new LiteralControl(@"<u><b>CATEGORIES</u></b><br/>"));
            Panel1.Controls.Add(new LiteralControl(@"<table Width=""100 % "">"));
            int Counter = 0;
            int CounterRow = 0;//im lazy
            while (reader.Read())
            {
                Counter = Counter + 1;
                CounterRow = CounterRow + 1;
                if (CounterRow == 1)
                {
                    Panel1.Controls.Add(new LiteralControl(@"<tr><td style=""width: 1%;""></td>"));
                }
                Panel1.Controls.Add(new LiteralControl(@"<td style=""width: 30%;"">"));
                string strCat = reader["Cat"].ToString();
                Label myLabel = new Label();
                myLabel.Text = "&nbsp;&nbsp;" + strCat;
                myLabel.ID = "CatLabel" + Counter.ToString();
                myLabel.Font.Size = 12;
                Panel1.Controls.Add(myLabel);
                Panel1.Controls.Add(new LiteralControl(@"</td>"));
                if (CounterRow == 3)
                {
                    //end td and row and restart 
                    CounterRow = 0;
                    Panel1.Controls.Add(new LiteralControl(@"</tr>"));
                }
                //loop to next row of SQL data
            } //reader loop
            if (CounterRow ==0)
            {

            }
             if (CounterRow == 0)
            {

            }
            Panel1.Controls.Add(new LiteralControl("</tr></table>"));
            Panel1.Controls.Add(new LiteralControl("<br/><br/><br/>"));
            connect.Close();

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            // Gets a reference to a TextBox control inside 
            // a ContentPlaceHolder
            ContentPlaceHolder mpContentPlaceHolder;
            TextBox mpTextBox;
            mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("MainContent");
            if (mpContentPlaceHolder != null)
            {
                mpTextBox = (TextBox)mpContentPlaceHolder.FindControl("txtBoxSearch");
                if (mpTextBox != null)
                {
                    string getSearch = mpTextBox.Text.Trim();
                    if (getSearch != "")
                    {
                        getSearch = "./LinkPage?search=" + getSearch;
                        //LinkPage?search=mssolve
                        Response.Redirect(getSearch);
                    }

                }
            }
        }
    }
}