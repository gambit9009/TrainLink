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
            string strPageID = Request.QueryString["pageid"];
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["TrainLinkConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(constring);
            connect.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            //command.CommandType = CommandType.Text;
            command.CommandText = "GetPageLink";
            //command.Parameters["@LinkPageID"] = SqlParameter strPageID;
            command.Parameters.Add("@LinkPageID", SqlDbType.Int).Value = strPageID;
            //command.CommandText = "SELECT * from Link";
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
                //myHTML = myHTML + "</br>" + strLinkName;
                //for (int i = 1; i <= numlabels; i++)
                //{
                Panel1.Controls.Add(new LiteralControl("<table><tr><td>&nbsp;</td><td>"));
                Label myLabel = new Label();
                myLabel.Text = strLinkName;//i.ToString();
                myLabel.ID = "Label" + "LinkName";
                myLabel.Font.Size = 13;
                myLabel.BackColor = System.Drawing.Color.Gold;
                Panel1.Controls.Add(new LiteralControl("<b>"));
                Panel1.Controls.Add(myLabel);
                Panel1.Controls.Add(new LiteralControl("</b>"));
                //next
                Label myLabelLink = new Label();
                myLabelLink.Text = strLinkLink;//i.ToString();
                myLabelLink.ID = "Label" + "LinkLink";
                Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                Panel1.Controls.Add(myLabelLink);
                Panel1.Controls.Add(new LiteralControl("<br />"));
                Panel1.Controls.Add(new LiteralControl("</td></tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;</td><td>"));
                //next
                Label myLabel1 = new Label();
                myLabel1.Text = strLinkDescript;//i.ToString();
                myLabel1.ID = "Label" + "LinkDescript";
                Panel1.Controls.Add(myLabel1);
                Panel1.Controls.Add(new LiteralControl("<br />"));
                if (strLinkHelpful.ToString() != null && strLinkHelpful != "")
                {                    
                    // next
                    Label myLabel6 = new Label();
                    myLabel6.Text = "Helpful Info:" + strLinkHelpful.ToString();
                    myLabel6.ID = "Label" + "buildCat";
                    Panel1.Controls.Add(myLabel6);
                    Panel1.Controls.Add(new LiteralControl("<br />"));
                }
                // next
                //if any 1 of the 3 download train short...get added, then make a br
                bool MakeABreak = false;
                if (strLinkDownload.ToString() != null && strLinkDownload != "")
                {
                    Label myLabel2 = new Label();
                    myLabel2.Text = strLinkDownload;//i.ToString();
                    myLabel2.ID = "Label" + "LinkDownload";
                    Panel1.Controls.Add(myLabel2);
                    Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;"));
                    MakeABreak = true;
                }
                // next
                if (strLinkTraining.ToString() != null && strLinkTraining != "")
                {
                    Label myLabel3 = new Label();
                    myLabel3.Text = strLinkTraining;
                    myLabel3.ID = "Label" + "LinkTraining";
                    Panel1.Controls.Add(myLabel3);
                    Panel1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;"));
                    MakeABreak = true;
                }
                // next
                if (strLinkShort.ToString() != null && strLinkShort != "")
                {
                    Label myLabel4 = new Label();
                    myLabel4.Text = strLinkShort;
                    Panel1.Controls.Add(new LiteralControl("Short URL: "));
                    myLabel4.ID = "Label" + "LinkShort";
                    Panel1.Controls.Add(myLabel4);
                    MakeABreak = true;
                }
                if (MakeABreak == true)
                {
                    Panel1.Controls.Add(new LiteralControl("<br />"));
                }
                

                Panel1.Controls.Add(new LiteralControl("</td></tr></table>"));
                //Panel1.Controls.Add(new LiteralControl("<hr/>"));
                //build categories if they are there
                string buildCat = "";
                if (strLinkCat != null && strLinkCat != "")
                {
                    buildCat = "Categories: " + strLinkCat.ToString();
                    if (strLinkSubCat1 != null && strLinkSubCat1 != "")
                    {
                        buildCat = buildCat + " -> " + strLinkSubCat1.ToString();
                        if (strLinkSubCat2 != null && strLinkSubCat2 != "")
                        {
                            buildCat = buildCat + strLinkSubCat2.ToString();
                            if (strLinkSubCat3 != null && strLinkSubCat3 != "")
                            {
                                buildCat = buildCat + strLinkSubCat3.ToString();

                            }
                        }
                    }
                }
                if (buildCat != "")
                {

                }
                //Panel1.Controls.Add(new LiteralControl("<br />"));
                if (buildCat != "")
                {
                    // next
                    Label myLabel5 = new Label();
                    myLabel5.Text = buildCat;
                    myLabel5.ID = "Label" + "buildCat";
                    Panel1.Controls.Add(myLabel5);
                    Panel1.Controls.Add(new LiteralControl("<br />"));
                }

                //string strLinkMisc1 = reader["LinkMisc1"].ToString();
                //string strLinkMisc2 = reader["LinkMisc2"].ToString();
                //string strLinkMisc3 = reader["LinkMisc3"].ToString();
            }
            connect.Close();


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