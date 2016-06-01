using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MusicsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        repMusicsList.DataSource = BLL.AdminBLL.GetMusicsList().Tables[0].DefaultView;
        repMusicsList.DataBind();
    }
}