using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Chart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlYears.DataSource = BLL.AdminBLL.GetChartYear().Tables[0].DefaultView;
            ddlYears.DataTextField = "year_";
            ddlYears.DataBind();

            ChartUsers_Page_Load();
            ChartOneWord_Page_Load();
        }
    }

    
    protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChartUsers_Page_Load();
        ChartOneWord_Page_Load();
    }
    #region 用户统计
    private void ChartUsers_Page_Load()
    {
        int month = int.Parse(ddlYears.SelectedItem.Text.Trim().ToString());
        chartUsers.DataSource = BLL.AdminBLL.GetChartUsers(month).Tables[0].DefaultView;
        chartUsers.Series[0].XValueMember = "month_";
        chartUsers.Series[0].YValueMembers = "sum_people";
        chartUsers.ChartAreas["chartUsersArea"].AxisY.Title = "人数(人)";
        chartUsers.ChartAreas["chartUsersArea"].AxisX.Title = "月份(月)";
        chartUsers.DataBind();
    }
    #endregion
    #region 一言统计
    private void ChartOneWord_Page_Load()
    {
        int month = int.Parse(ddlYears.SelectedItem.Text.Trim().ToString());
        chartOneWord.DataSource = BLL.AdminBLL.GetChartWords(month).Tables[0].DefaultView;
        chartOneWord.Series[0].XValueMember = "month_";
        chartOneWord.Series[0].YValueMembers = "sum_word";
        chartOneWord.ChartAreas["chartOneWordArea"].AxisY.Title = "条数(条)";
        chartOneWord.ChartAreas["chartOneWordArea"].AxisX.Title = "月份(月)";
        chartOneWord.DataBind();
    }
    #endregion

}