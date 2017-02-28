using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TrainLinks
{
    public partial class LinkPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ConnectToSQL();
        }
        private void ConnectToSQL()
        {
            string strPageID = null;
            string strSearch = null;
            string strCat = null;
            try
            {
                strPageID = Request.QueryString["pageid"];
            }
            catch { }
            try
            {
                strSearch = Request.QueryString["search"];
            }
            catch { }
            try
            {
                strCat = Request.QueryString["cat"];
            }
            catch { }
            if ((strPageID == "" || strPageID == null) && (strSearch == "" || strSearch == null) && (strCat== "" || strCat == null))
            { 
                Panel1.Controls.Add(new LiteralControl(@"no query string"));
                return;
            }
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["TrainLinkConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(constring);
            connect.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            if (strPageID != "" && strPageID != null)
            {
                lblPageTitle.Text = "Link Page by PageID - " + strPageID;
                command.CommandText = "GetPageLink";
                command.Parameters.Add("@LinkPageID", SqlDbType.Int).Value = strPageID;
            }
            else if (strSearch != "" && strSearch != null)
            {
                lblPageTitle.Text = "Link Page by Search - " + strSearch;
                command.CommandText = "GetPageLinkSearch";
                command.Parameters.Add("@Search", SqlDbType.VarChar,500).Value = strSearch;
            }
            else if (strCat != "" && strCat != null)
            {
                lblPageTitle.Text = "Link Page by Category - " + strCat;
                command.CommandText = "GetPageLinkCat";
                command.Parameters.Add("@Cat", SqlDbType.VarChar,50).Value = strCat;
            }
            command.Connection = connect;
            SqlDataReader reader = command.ExecuteReader();
            //string myHTML = "";
            while (reader.Read())
            {
                string strLinkName = reader["LinkName"].ToString();
                string strLinkID = reader["LinkID"].ToString();
                string strLinkPageID = reader["LinkPageID"].ToString();
                string strLinkLink = reader["LinkLink"].ToString();
                string strLinkDescript = reader["LinkDescript"].ToString();
                string strLinkCat = reader["LinkCat"].ToString();
                string strLinkSubCat1 = reader["LinkSubCat1"].ToString();
                string strLinkSubCat2 = reader["LinkSubCat2"].ToString();
                string strLinkSubCat3 = reader["LinkSubCat3"].ToString();
                string strLinkHelpful = reader["LinkHelpful"].ToString();
                string strLinkTraining = reader["LinkTraining"].ToString();
                string strLinkMisc1 = reader["LinkMisc1"].ToString();
                string strLinkMisc2 = reader["LinkMisc2"].ToString();
                string strLinkMisc3 = reader["LinkMisc3"].ToString();
                string strLinkDownload = reader["LinkDownload"].ToString();
                string strLinkShort = reader["LinkShort"].ToString();
                string strLinkOneNote = reader["LinkOneNote"].ToString();
                string strLinkYammer = reader["LinkYammer"].ToString();
                string strLinkTeams = reader["LinkTeams"].ToString();
                //myHTML = myHTML + "</br>" + strLinkName;
                //for (int i = 1; i <= numlabels; i++)
                //{
                //Panel1.Controls.Add(new LiteralControl("<table><tr><td>&nbsp;</td><td>"));
                Panel1.Controls.Add(new LiteralControl(@"<table Width=""100 % "">"));
                Panel1.Controls.Add(new LiteralControl(@"<tr><td style=""width: 1%;""></td><td colspan=""2"">"));
                 Label myLabel = new Label();
                myLabel.Text = "&nbsp;&nbsp;" + strLinkName + "&nbsp;&nbsp;";//i.ToString();
                myLabel.ID = "Label" + "LinkName";
                myLabel.Font.Size = 14;
                myLabel.BackColor = System.Drawing.Color.Gold;
                Panel1.Controls.Add(new LiteralControl("<b>"));
                Panel1.Controls.Add(myLabel);
                Panel1.Controls.Add(new LiteralControl("</b>"));
                //next
                Label myLabelLink = new Label();
                myLabelLink.Text = strLinkLink;//i.ToString();
                myLabelLink.ID = "Label" + "LinkLink";
                myLabelLink.Font.Size = 13;
                Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;"));
                Panel1.Controls.Add(myLabelLink);
                Panel1.Controls.Add(new LiteralControl(@"</td></tr><tr><td style=""width: 1%;""></td><td style=""width: 2%;""></td><td>"));
                //next
                Label myLabel1 = new Label();
                myLabel1.Text = "<b>Description:</b> " + strLinkDescript;//i.ToString();
                myLabel1.ID = "Label" + "LinkDescript";
                myLabel1.Font.Size = 13;
                Panel1.Controls.Add(myLabel1);
                Panel1.Controls.Add(new LiteralControl("<br />"));
                if (strLinkHelpful.ToString() != null && strLinkHelpful != "")
                {                    
                    // next
                    Label myLabel6 = new Label();
                    myLabel6.Text = "<b>Helpful Info:</b> ";
                    myLabel6.ID = "Label" + "LinkHelpRed";
                    myLabel6.ForeColor = System.Drawing.Color.Red;
                    myLabel6.Font.Size = 12;
                    Label myLabel7 = new Label();
                    myLabel7.Text = strLinkHelpful.ToString();
                    myLabel7.ID = "Label" + "LinkHelp";
                    myLabel7.Font.Size = 12;
                    Panel1.Controls.Add(myLabel6);
                    Panel1.Controls.Add(myLabel7);
                    Panel1.Controls.Add(new LiteralControl("<br />"));
                }
                // next
                //build categories if they are there
                string buildCat = "";
                if (strLinkCat != null && strLinkCat != "")
                {
                    buildCat = "<b>Categories:</b> " + strLinkCat.ToString();
                    if (strLinkSubCat1 != null && strLinkSubCat1 != "")
                    {
                        buildCat = buildCat + " <b>-></b> " + strLinkSubCat1.ToString();
                        if (strLinkSubCat2 != null && strLinkSubCat2 != "")
                        {
                            buildCat = buildCat + " <b>-></b> " + strLinkSubCat2.ToString();
                            if (strLinkSubCat3 != null && strLinkSubCat3 != "")
                            {
                                buildCat = buildCat + " <b>-></b> " + strLinkSubCat3.ToString();

                            }
                        }
                    }
                }
                //Panel1.Controls.Add(new LiteralControl("<br />"));
                if (buildCat != "")
                {
                    // next
                    Label myLabel5 = new Label();
                    myLabel5.Text = buildCat;
                    myLabel5.ID = "Label" + "buildCat";
                    myLabel5.Font.Size = 12;
                    Panel1.Controls.Add(myLabel5);
                    Panel1.Controls.Add(new LiteralControl("<br />"));
                }
                //list these on the same line...will be several short links where they exist
                if (strLinkDownload.ToString() != null && strLinkDownload != "")
                {
                    Label myLabel2 = new Label();
                    myLabel2.Text = strLinkDownload;//i.ToString();
                    myLabel2.ID = "Label" + "LinkDownload";
                    myLabel2.Font.Size = 12;
                    Panel1.Controls.Add(myLabel2);
                    Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                    }
                // next
                if (strLinkTraining.ToString() != null && strLinkTraining != "")
                {
                    Label myLabel3 = new Label();
                    myLabel3.Text = strLinkTraining;
                    myLabel3.ID = "Label" + "LinkTraining";
                    myLabel3.Font.Size = 12;
                    Panel1.Controls.Add(myLabel3);
                    Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                }
                // next
                if (strLinkShort.ToString() != null && strLinkShort != "")
                {
                    Label myLabel4 = new Label();
                    myLabel4.Text = strLinkShort;
                    Panel1.Controls.Add(new LiteralControl("<b>Short URL:</b>"));
                    myLabel4.ID = "Label" + "LinkShort";
                    myLabel4.Font.Size = 12;
                    Panel1.Controls.Add(myLabel4);
                    Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                }
                if (strLinkPageID != null && strLinkPageID != "")
                {
                    Label myLabel8 = new Label();
                    myLabel8.Text = strLinkPageID;
                    //Panel1.Controls.Add(new LiteralControl("<b>PageID" + "</b>"));
                    myLabel8.ID = "Label" + "LinkPageID";
                    myLabel8.Font.Size = 12;
                    Panel1.Controls.Add(myLabel8);
                    Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                }
                if (strLinkOneNote != null && strLinkOneNote != "")
                {
                    Label myLabel9 = new Label();
                    myLabel9.Text = strLinkOneNote;
                    //Panel1.Controls.Add(new LiteralControl("<b>PageID" + "</b>"));
                    myLabel9.ID = "Label" + "LinkOneNote";
                    myLabel9.Font.Size = 12;
                    Panel1.Controls.Add(myLabel9);
                    Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                }
                if (strLinkYammer != null && strLinkYammer != "")
                {
                    Label myLabel10 = new Label();
                    myLabel10.Text = strLinkYammer;
                    //Panel1.Controls.Add(new LiteralControl("<b>PageID" + "</b>"));
                    myLabel10.ID = "Label" + "LinkYammer";
                    myLabel10.Font.Size = 12;
                    Panel1.Controls.Add(myLabel10);
                    Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                }
                if (strLinkTeams != null && strLinkTeams != "")
                {
                    Label myLabel11 = new Label();
                    myLabel11.Text = strLinkTeams;
                    //Panel1.Controls.Add(new LiteralControl("<b>PageID" + "</b>"));
                    myLabel11.ID = "Label" + "LinkTeams";
                    myLabel11.Font.Size = 12;
                    Panel1.Controls.Add(myLabel11);
                    Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                }



                //
                //end of the table, loop to next row of SQL data
                Panel1.Controls.Add(new LiteralControl("</td></tr></table>"));


                //string strLinkMisc1 = reader["LinkMisc1"].ToString();
                //string strLinkMisc2 = reader["LinkMisc2"].ToString();
                //string strLinkMisc3 = reader["LinkMisc3"].ToString();

                ////string constring = System.Configuration.ConfigurationManager.ConnectionStrings["TrainLinkConnectionString"].ConnectionString;
                ////SqlConnection connect = new SqlConnection(constring);
                ////connect.Open();
                ////SqlCommand command = new SqlCommand();
                ////command.CommandType = CommandType.StoredProcedure;
                //////command.CommandType = CommandType.Text;
                ////command.CommandText = "GetPageLink";
                //////command.Parameters["@LinkPageID"] = SqlParameter strPageID;
                ////command.Parameters.Add("@LinkPageID", SqlDbType.Int).Value = strPageID;
                //////command.CommandText = "SELECT * from Link";
                ////command.Connection = connect;

                ////SqlDataReader reader = command.ExecuteReader();
                //////string myHTML = "";
                ////while (reader.Read())
                ////{

            } //reader loop
            connect.Close();

            Panel1.Controls.Add(new LiteralControl("<br/><br/><br/>"));
            //Response.Write(myHTML);
            //PlaceHolder1.Controls.Add(new Literal { Text = myHTML });
        }
        private DataSet TestFill()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["TrainLinkConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * from Link", con);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                con.Open();
                dataAdapter.Fill(ds, "table");
                return ds;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                
            }
            return null;

            //another test
            SqlConnection conn = new SqlConnection("connectionstringhere");
            SqlCommand cmd = new SqlCommand("SELECT * FROM TABLE", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
             //   MyFunction(dr["Id"].ToString(), dr["Name"].ToString());
            }



            Console.Read();
        }
    }
}