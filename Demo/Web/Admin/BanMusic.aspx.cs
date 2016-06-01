using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BanMusic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int mbid = int.Parse(Request.QueryString["mbid"]);
        if (BLL.AdminBLL.BanMusic(mbid))
        {
            Response.Redirect("MusicsList.aspx");
        }
        else
        {
            Response.Redirect("MusicsList.aspx");
        }
    }
}