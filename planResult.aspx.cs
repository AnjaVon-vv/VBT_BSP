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
    public partial class planResult : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public string sta, end;
        public string tip;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["sta"] != null) && (Request.QueryString["end"] != null))
            {
                sta = Request.QueryString["sta"].ToString();
                end = Request.QueryString["end"].ToString();
                connection.Open();
                
                int sFlag = IsStop(sta);
                int eFlag = IsStop(end);
                if ((sFlag == 0) && (eFlag == 0)) //都是站点
                {
                    tip = "从" + sta + "出发、到" + end + "可选择如下的出行方案——";

                }
                else if ((sFlag == 0) && (eFlag == 0)) //换起点
                {
                    tip = "起点" + sta + "附近有如下站点，请选择出发站！";

                    Response.Redirect("planResult.aspx?sta=" + "&end=" + end);
                }
                else if ((sFlag == 0) && (eFlag == 0)) //换终点
                {
                    tip = "终点" + end + "附近有如下站点，请选择到达站！";

                    Response.Redirect("planResult.aspx?sta=" + sta + "&end=");
                }
                else if ((sFlag == 0) && (eFlag == 0)) //都换
                {
                    tip = "起点" + sta + "附近有如下站点，请选择出发站！";

                    string tip2 = "终点" + end + "附近有如下站点，请选择到达站！";


                }
                else
                    tip = "从" + sta + "出发、到" + end + "暂无可行的解决方案";



                connection.Close();
            
            
            }
            else
                Response.Redirect("Search.aspx");
        }

        /// <summary>
        /// 判断是否为站点
        /// </summary>
        /// <param name="str">传入地名</param>
        /// <returns>
        /// 0 站点
        /// 1 周边    2 道路
        /// -1 啥也不是
        /// </returns>
        public int IsStop(string str)
        {
            SqlCommand cmd = new SqlCommand("select Sname from SV where Sname = '" + str + "'", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return 0; //为站点
            else
            {
                SqlCommand acmd = new SqlCommand("select Sname from SV where around = '" + str + "'", connection);
                reader = acmd.ExecuteReader();
                if (reader.HasRows)
                    return 1; //为周边地标
                else
                {
                    SqlCommand rcmd = new SqlCommand("select Sname from SV where road = '" + str + "'", connection);
                    reader = rcmd.ExecuteReader();
                    if (reader.HasRows)
                        return 2; //为所在道路
                    else
                        return -1; //啥也不是
                }
            }
        }
    }

    // 转化为站


    // 规划道路


}