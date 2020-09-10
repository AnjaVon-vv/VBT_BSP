using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VBT_BSP
{
    public partial class routeResult : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public string path = "";
        public string rn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["rn"] != null)
            {
                rn = Request.QueryString["rn"].ToString();
                connection.Open();

                //基本信息
                SqlCommand infoCmd = new SqlCommand("select * from RV where Rname='" + rn + "'", connection);
                SqlDataReader infoReader = infoCmd.ExecuteReader();
                this.Rinfo.DataSource = infoReader;
                this.Rinfo.DataBind();
                infoReader.Close();

                //途径站点
                SqlCommand stopCmd = new SqlCommand("select * from PV where Rname='" + rn + "' order by serial ASC", connection);
                SqlDataReader stopReader = stopCmd.ExecuteReader();
                if (stopReader.HasRows)
                {
                    try
                    {
                        while (stopReader.Read())
                        {
                            path += stopReader["Sname"].ToString();
                            path = path.Replace(stopReader["Sname"].ToString(), "<font color=#333>" + stopReader["Sname"].ToString() + "</font>");
                            path += " — ";
                        }
                    }
                    finally
                    {
                        stopReader.Close();
                        connection.Close();
                    }
                    //去掉尾部多余“ — ”
                    int i = Convert.ToInt32(path.Length);
                    path = path.Substring(0, i - 3);
                }
                else
                    path += "该线路无具体途径站点信息！";
            }
            else
                Response.Redirect("Search.aspx");
        }
    }
}