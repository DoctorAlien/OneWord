﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_index : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        else if (Session["admin"]!=null&&Session["admin"]=="true")
        {
            lblUserName.Text = Session["username"].ToString();
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }
}
