using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class User_UserCenter : System.Web.UI.Page
{
    DataSet dsSearchSet = new DataSet();
    DataSet dsAside = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Redirect("../Default.aspx");
            }
            lblUserName.Text = Session["username"].ToString();
            int uuid = int.Parse(Session["uuid"].ToString()) ;
            string searchWord = txtSearch.Text.Trim();

            //repAside.DataSource = BLL.UserBLL.GetInfoAside(uuid).Tables[0].DefaultView;
            //repAside.DataBind();

            dsAside = BLL.UserBLL.GetInfoAside(uuid);
            if (dsAside.Tables.Count>0&&dsAside.Tables[0].Rows.Count>0)
            {
                repAside.DataSource = BLL.UserBLL.GetInfoAside(uuid).Tables[0].DefaultView;
                repAside.DataBind();
            }
            else
            {
                pnlAsideNull.Visible = true;
            }

            dsSearchSet = BLL.UserBLL.GetSearchSet(searchWord, uuid);
            if (dsSearchSet.Tables.Count > 0 && dsSearchSet.Tables[0].Rows.Count > 0)
            {
                pnlMyOW.Visible = true;
                pnlErrorLoadNull.Visible = false;
                pnlErrorSearchNull.Visible = false;
                repMyOW.DataSource = BLL.UserBLL.GetSearchSet(searchWord, uuid).Tables[0].DefaultView;
                repMyOW.DataBind();
            }
            else
            {
                pnlMyOW.Visible = false;
                pnlErrorSearchNull.Visible = false;
                pnlErrorLoadNull.Visible = true;
            }
            #region 获取个人基本信息
            SqlDataReader sdrInfo = BLL.UserBLL.GetMyInfo(uuid);
            if (sdrInfo.HasRows)
            {
                while (sdrInfo.Read())
                {
                    txtUUID.Text = sdrInfo["uuid"].ToString();
                    txtUserName.Text = sdrInfo["username_"].ToString();
                    txtMobile.Text = sdrInfo["mobile_"].ToString();
                    txtCreateTime.Text = sdrInfo["create_time"].ToString();
                    txtCreateIP.Text = sdrInfo["create_ip"].ToString();
                }
            } sdrInfo.Close();
            #endregion
            repMusic.DataSource = BLL.UserBLL.GetMusicInfo().Tables[0].DefaultView;
            repMusic.DataBind();
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int uuid = int.Parse(Session["uuid"].ToString());
        string password = txtPassword.Text.Trim();
        string mobile = txtMobile.Text.Trim();
        if (password == null || password == "")
        {
            if (BLL.AdminBLL.EditUserNull(mobile, uuid))
            {
                Response.Redirect("UserCenter.aspx");
            }
        }
        else
        {
            if (BLL.AdminBLL.EditUser(BLL.CommonBLL.GetMD5(password), mobile, uuid))
            {
                Response.Redirect("../Default.aspx");
            }
        }
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    { 
        int uuid = int.Parse(Session["uuid"].ToString());
        string searchWord = txtSearch.Text.Trim();
        dsSearchSet = BLL.UserBLL.GetSearchSet(searchWord, uuid);
        if (dsSearchSet.Tables.Count>0&&dsSearchSet.Tables[0].Rows.Count>0)
        {
            pnlMyOW.Visible = true;
            pnlErrorLoadNull.Visible = false;
            pnlErrorSearchNull.Visible = false;
            repMyOW.DataSource = BLL.UserBLL.GetSearchSet(searchWord, uuid).Tables[0].DefaultView;
            repMyOW.DataBind();
        }
        else
        {
            pnlMyOW.Visible = false;
            pnlErrorLoadNull.Visible = false;
            pnlErrorSearchNull.Visible = true;
        }
    }
}