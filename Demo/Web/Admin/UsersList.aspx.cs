﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        repUsersList.DataSource = BLL.AdminBLL.GetUsersList().Tables[0].DefaultView;
        repUsersList.DataBind();
    }
}