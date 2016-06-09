using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_UserTest : System.Web.UI.Page
{
    DataSet dsAside = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        if (Session["uuid"] == null || Session["uuid"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        repOneWord_Load();
        dsAside = BLL.UserBLL.GetInfoAside(int.Parse(Session["uuid"].ToString()));
        if (dsAside.Tables.Count > 0 && dsAside.Tables[0].Rows.Count > 0)
        {
            repAside.DataSource = BLL.UserBLL.GetInfoAside(int.Parse(Session["uuid"].ToString())).Tables[0].DefaultView;
            repAside.DataBind();
        }
        else
        {
            lblUserName.Text = Session["username"].ToString();
            pnlAsideNull.Visible = true;
        }
        repAttentionRandom_Page_Load();
    }

    private void repAttentionRandom_Page_Load()
    {
        repAttentionRandom.DataSource = BLL.UserBLL.GetAttentionRandom(int.Parse(Session["uuid"].ToString())).Tables[0].DefaultView;
        repAttentionRandom.DataBind();
    }
    private void repOneWord_Load()
    {
        repOneWord.DataSource = BLL.UserBLL.GetWordSet().Tables[0].DefaultView;
        repOneWord.DataBind();
    }
    protected void btnPublish_Click(object sender, EventArgs e)
    {
        string word = txtOneWord.Text.Trim();
        int uuid = int.Parse(Session["uuid"].ToString());
        if (BLL.UserBLL.InsertWord(uuid, word))
        {
            Response.Redirect("User.aspx");
        }
        else
        {
            Response.Redirect("User.aspx");
        }
    }
    protected void lbtnRefresh_Click(object sender, EventArgs e)
    {
        repOneWord_Load();
    }
    protected void lbtnRefresh_bottom_Click(object sender, EventArgs e)
    {
        repOneWord_Load();
    }
    protected void lbtnAttentionRandomChange_Click(object sender, EventArgs e)
    {
        repAttentionRandom_Page_Load();
    }
}