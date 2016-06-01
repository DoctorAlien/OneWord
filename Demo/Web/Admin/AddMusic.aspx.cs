using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddMusic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        #region 上传文件
        Random ran = new Random();
        //获取前端input type file中的值
        string upload_Music = inputUrl.Value;
        string upload_Picture = inputPic.Value;
        //存储路径
        string save_Music = "";
        string save_Picture = "";
        //数据库存储
        string sql_Music = "";
        string sql_Picture = "";

        if (upload_Music != "")
        {
            int idx_m = upload_Music.LastIndexOf(".");
            string suffix_m = upload_Music.Substring(idx_m);
            save_Music = BLL.CommonBLL.GetMD5(DateTime.Now.Ticks.ToString() + ran.Next(10000, 99999) + ran.Next(10000, 99999)) + suffix_m;
        }
        if (upload_Picture != "")
        {
            int idx_p = upload_Picture.LastIndexOf(".");
            string suffix_p = upload_Picture.Substring(idx_p);
            save_Picture = BLL.CommonBLL.GetMD5(DateTime.Now.Ticks.ToString() + ran.Next(10000, 99999) + ran.Next(10000, 99999)) + suffix_p;
        }
        try
        {
            if (upload_Music != "")
            {
                string path = Server.MapPath("~/BGM/Music/");
                inputUrl.PostedFile.SaveAs(path + save_Music);
                sql_Music = path + save_Music;
            }
            if (upload_Picture != "")
            {
                string path = Server.MapPath("~/BGM/Picture/");
                inputPic.PostedFile.SaveAs(path + save_Picture);
                sql_Picture = path + save_Picture;
            }
        }
        catch (Exception)
        {
            throw;
        }
        #endregion
        string title = txtTitle.Text.Trim();
        string author = txtAuthor.Text.Trim();
        string url = sql_Music.ToString().Trim();
        string picture = sql_Picture.ToString().Trim();
        if (BLL.AdminBLL.InsertBGM(title,author,url,picture))
        {
            Response.Redirect("MusicsList.aspx");
        }
    }
    protected void btnInsert_out_Click(object sender, EventArgs e)
    {
        string title = txtTitle_out.Text.Trim();
        string author = txtAuthor_out.Text.Trim();
        string url = txtUrl_out.Text.Trim();
        string picture = txtPicture_out.Text.Trim();
        if (BLL.AdminBLL.InsertBGM(title, author, url, picture))
        {
            Response.Redirect("MusicsList.aspx");
        }
    }
}