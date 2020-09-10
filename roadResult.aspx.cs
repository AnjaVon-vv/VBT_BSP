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
    public partial class roadResult : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public string str;
        public string tip;
        public string stops = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["sn"] != null)
            {
                str = Request.QueryString["sn"].ToString();
                connection.Open();

                SqlCommand aCmd = new SqlCommand("select Sname from SV where around='" + str + "'", connection);
                SqlDataReader aReader = aCmd.ExecuteReader();
                if (aReader.HasRows) //周边地标
                {
                    tip = str + "附近站点【点击可查询站点及可乘线路信息】";
                    while (aReader.Read())
                    {
                        string sn = "<a href=\"stopResult.aspx?sn=" + aReader["Sname"].ToString() + "\" class=\"btn button\">" + aReader["Sname"].ToString() + "</a>";
                        stops += sn;
                    }
                    aReader.Close();
                }
                else
                {
                    SqlCommand rCmd = new SqlCommand("select Sname from SV where road='" + str + "'", connection);
                    SqlDataReader rReader = rCmd.ExecuteReader();
                    if (rReader.HasRows) //所在道路
                    {
                        tip = "位于" + str + "上的站点【点击可查询站点及可乘线路信息】";
                        while (rReader.Read())
                        {
                            string sn = "<a href=\"stopResult.aspx?sn=" + rReader["Sname"].ToString() + "\" class=\"btn button\">" + rReader["Sname"].ToString() + "</a>";
                            stops += sn;
                        }
                        rReader.Close();
                    }
                    else
                        tip = "暂无" + str + "周边站点信息！";
                }
                connection.Close();
            }
            else
                Response.Redirect("Search.aspx");
        }
    }
}