using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;

namespace TrainLinks
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strName = HttpContext.Current.User.Identity.Name.ToString();
            //Response.Write("httpcontext " + strName);
            //strName = Request.ServerVariables["AUTH_USER"];
            //WindowsIdentity.GetCurrent().Name; //gets IIS APPOOL login
            string strURL = HttpContext.Current.Request.Url.AbsoluteUri; ;
            if (IsPostBack == false)
            {
                try
                {
                    string constring = System.Configuration.ConfigurationManager.ConnectionStrings["TrainLinkConnectionString"].ConnectionString;
                    SqlConnection connect = new SqlConnection(constring);
                    connect.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "TrackUser";
                    command.Parameters.Add("@UserName", SqlDbType.VarChar, 200).Value = strName;
                    command.Parameters.Add("@UserApp", SqlDbType.VarChar, 20).Value = "TrainLink";
                    command.Parameters.Add("@UserFeature", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@UserMisc", SqlDbType.VarChar, 300).Value = strURL;
                    command.Connection = connect;
                    command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Response.Write("Error - <br/><br/><br/>");
                    Response.Write(ex.Message);
                }

            }
            strName = strName.ToLower();
            strURL = strURL.ToLower();
            if (strName.Contains("toddhayn") || strName.Contains("shbarret") || strName.Contains("jonclark") || strName.Contains("jopilov"))
            {
                pnlAdmin.Visible = true;
            }
            else if (strURL.Contains("adminlinks"))
            {
                Response.Redirect("./default.aspx");
            }
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {

        }
    }
}