using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using D = DAL;
using System.Text.RegularExpressions;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Random_Validate_Load();
        }
    }

    private void Random_Validate_Load()
    {
        Random ran = new Random();
        lbtnValidateCode_login.Text = ran.Next(10000, 99999).ToString();
        lbtnValidateCode_register.Text = ran.Next(10000, 99999).ToString();
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string username = txtUserName_register.Text.Trim();
            string password = BLL.CommonBLL.GetMD5(txtPassword_register.Text.Trim());
            string mobile = txtMobile_register.Text.Trim();
            string createip = GetIpAddress();
            if (BLL.LoginBLL.InsertUser(username, password, mobile, createip))
            {
                Response.Redirect("Default.aspx#login");
            }
            else
            {
                Response.Redirect("Default.aspx#register");
            }
        }
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string username = txtUserName_login.Text.Trim();
            string password = txtPassword_login.Text.Trim();
            if (BLL.LoginBLL.IsExist(username, BLL.CommonBLL.GetMD5(password)))
            {
                SqlDataReader sdr = BLL.LoginBLL.GetDataReader(username);
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Session["uuid"] = sdr["uuid"];
                    }
                }
                Session["username"] = username;
                if (BLL.LoginBLL.IsAdmin(username))
                {
                    Response.Redirect("Admin/Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("User/User.aspx");
                }
            }
        }
        
    }
    /// <summary>
    /// 获取IP地址
    /// </summary>
    /// <returns></returns>
    public static string GetIpAddress()
    {
        string ipAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ipAddr))
            ipAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        if (string.IsNullOrEmpty(ipAddr))
            ipAddr = HttpContext.Current.Request.UserHostAddress;

        return ipAddr;
    }
    protected void lbtnValidateCode_register_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx#register");
    }
    protected void lbtnValidateCode_login_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx#login");
    }
    #region 验证控件
    protected void cvUserName_register_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string username = txtUserName_register.Text.Trim();
        Regex reg = new Regex("[A-Za-z0-9]");
        SqlParameter[] values = new SqlParameter[]{
        new SqlParameter("@username",username)
        };
        args.IsValid = false;
        if (username == "")
        {
            cvUserName_register.ErrorMessage = "*用户名不能为空";
        }
        else if (username.Length < 4)
        {
            cvUserName_register.ErrorMessage = "*用户名长度过短";
        }
        else if (!reg.IsMatch(username))
        {
            cvUserName_register.ErrorMessage = "*用户名只能是数字英文";
        }
        else if (BLL.LoginBLL.IsRegister(username))
        {
            cvUserName_register.ErrorMessage = "*该用户名已被注册";
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void cvPassword_register_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string password = txtPassword_register.Text.Trim();
        Regex reg = new Regex("[A-Za-z0-9]{6,}");
        args.IsValid = false;
        if (password == "")
        {
            cvPassword_register.ErrorMessage = "*密码不能为空";
        }
        else if (password.Length < 6)
        {
            cvPassword_register.ErrorMessage = "*密码长度过段";
        }
        else if (!reg.IsMatch(password))
        {
            cvPassword_register.ErrorMessage = "*密码只能是数字英文";
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void cvMobile_register_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string mobile = txtMobile_register.Text.Trim();
        Regex reg = new Regex(@"^1[3|4|5|8][0-9]\d{4,8}");
        args.IsValid = false;
        if (mobile == "")
        {
            cvMobile_register.ErrorMessage = "*手机号不能为空";
        }
        else if (mobile.Length != 11)
        {
            cvMobile_register.ErrorMessage = "*手机号长度不正确";
        }
        else if (!reg.IsMatch(mobile))
        {
            cvMobile_register.ErrorMessage = "*手机号格式不正确";
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void cvValidate_register_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string text_validate = txtValidateCode_register.Text.Trim();
        string lbtn_validate = lbtnValidateCode_register.Text.Trim();
        args.IsValid = false;
        if (text_validate == "")
        {
            cvValidate_register.ErrorMessage = "*验证码不能为空";
        }
        else if (text_validate != lbtn_validate)
        {
            cvValidate_register.ErrorMessage = "*验证码错误";
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void cvUserName_login_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string username = txtUserName_login.Text.Trim();
        args.IsValid = false;
        if (username=="")
        {
            cvUserName_login.ErrorMessage = "*用户名不能为空";
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void cvPassword_login_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string password = txtPassword_login.Text.Trim();
        args.IsValid = false;
        if (password=="")
        {
            cvPassword_login.ErrorMessage = "*密码不能为空";
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void cvValidate_Login_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string text_validate = txtValidateCode_login.Text.Trim();
        string lbtn_validate = lbtnValidateCode_login.Text.Trim();
        args.IsValid = false;
        if (text_validate=="")
        {
            cvValidate_Login.ErrorMessage = "*验证码不能为空";
        }
        else if (text_validate != lbtn_validate)
        {
            cvValidate_Login.ErrorMessage = "*验证码不正确";
        }
        else
        {
            args.IsValid = true;
        }
    }
    #endregion
    
}