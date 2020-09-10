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
    public partial class Search : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //连接数据库
                connection.Open();

                //查询
                string query = @"select Rname from RV order by Rid ASC";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                //赋值
                this.routeList.DataSource = reader;
                this.routeList.DataTextField = "Rname";
                this.routeList.DataValueField = "Rname";
                this.routeList.DataBind();

                //添加默认项
                this.routeList.Items.Insert(0, new ListItem("-- 请选择 --", "0"));
                this.routeList.SelectedIndex = 0;

                reader.Close();
                connection.Close();
            }
        }

        protected void routeBtn_Click(object sender, EventArgs e)
        {
            string rn = this.routeList.SelectedValue.ToString();
            Response.Redirect("routeResult.aspx?rn=" + rn);
        }

        public string stopTip = "";
        protected void stopBtn_Click(object sender, EventArgs e)
        {
            string sn = this.stopTxt.Text;
            if ((sn != null) && (sn != ""))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select Sname from SV where Sname='" + sn + "'", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                        Response.Redirect("stopResult.aspx?sn=" + sn);
                    else
                        Response.Redirect("roadResult.aspx?sn=" + sn); //非站点名【周边 or 道路 or 非】
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                }
            }
            else
                stopTip = "<div class=\"alert alert-danger alert - dismissible\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>请输入查询内容！</div>";
        }

        public string planTip = "";
        protected void planBtn_Click(object sender, EventArgs e)
        {
            string sta = this.startTxt.Text;
            string end = this.endTxt.Text;
            if (((sta != null) && (sta != "")) && ((end != null) && (end != "")))
                Response.Redirect("planResult.aspx?sta=" + sta + "&end=" + end);
            else
                planTip = "<div class=\"alert alert-warning alert - dismissible\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>请正确输入查询内容！</div>";
        }
    }
}