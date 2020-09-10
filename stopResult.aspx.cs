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
    public partial class stopResult : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public string sn;
        public string routes = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["sn"] != null)
            {
                sn = Request.QueryString["sn"].ToString();
                connection.Open();

                //基本信息
                SqlCommand infoCmd = new SqlCommand("select * from SV where Sname='" + sn + "'", connection);
                SqlDataReader infoReader = infoCmd.ExecuteReader();
                this.Sinfo.DataSource = infoReader;
                this.Sinfo.DataBind();
                infoReader.Close();

                //可乘线路
                SqlCommand routeCmd = new SqlCommand("select distinct Rname from PV where Sname='" + sn + "'", connection);
                SqlDataReader routeReader = routeCmd.ExecuteReader();
                if (routeReader.HasRows)
                {
                    try
                    {
                        while (routeReader.Read())
                        {
                            string rn = "<a href=\"routeResult.aspx?rn=" + routeReader["Rname"].ToString() + "\" class=\"btn button\">" + routeReader["Rname"].ToString() + "</a>";
                            routes += rn;
                        }
                    }
                    finally
                    {
                        routeReader.Close();
                        connection.Close();
                    }
                }
                else
                    routes += "该站点暂无可乘线路！";
            }
            else
                Response.Redirect("Search.aspx");
        }
    }
}