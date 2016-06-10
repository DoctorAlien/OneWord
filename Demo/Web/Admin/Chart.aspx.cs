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

            ChartAttention_Page_Load();

            ChartWordsLike_Page_Load();
        }
    }
    #region 点赞热度统计
    private void ChartWordsLike_Page_Load()
    {
        chartWordsLike.DataSource = BLL.AdminBLL.GetChartWordsLike().Tables[0].DefaultView;
        chartWordsLike.Series[0].XValueMember = "wbid";
        chartWordsLike.Series[0].YValueMembers = "number_";
        chartWordsLike.ChartAreas["chartWordsLikeArea"].AxisY.Title = "人数(人)";
        chartWordsLike.ChartAreas["chartWordsLikeArea"].AxisX.Title = "编号";
        chartWordsLike.Series[0].IsValueShownAsLabel = true;
        chartWordsLike.DataBind();
    }
    #endregion
    
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
        chartUsers.Series[0].IsValueShownAsLabel = true;
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
        chartOneWord.Series[0].IsValueShownAsLabel = true;
        chartOneWord.DataBind();
    }
    #endregion
    #region 关注热度
    private void ChartAttention_Page_Load()
    {
        chartAttention.DataSource = BLL.AdminBLL.GetChartAttention().Tables[0].DefaultView;
        chartAttention.Series[0].XValueMember = "username_";
        chartAttention.Series[0].YValueMembers = "count_uuid_to";
        chartAttention.ChartAreas["chartAttentionArea"].AxisY.Title = "人数(人)";
        chartAttention.Series[0].IsValueShownAsLabel = true;
        chartAttention.DataBind();
    }
    #endregion
}