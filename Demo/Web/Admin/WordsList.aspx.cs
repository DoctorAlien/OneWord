using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_WordList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        repWordsList.DataSource = BLL.AdminBLL.GetWordsList().Tables[0].DefaultView;
        repWordsList.DataBind();
    }
}