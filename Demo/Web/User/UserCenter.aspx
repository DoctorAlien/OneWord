<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserCenter.aspx.cs" Inherits="User_UserCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../Css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="../Css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="../Css/public.css">
    <link rel="Stylesheet" type="text/css" href="../Css/APlayer.min.css" />
    <script type="text/javascript" src="../Js/jquery-2.2.1.min.js"></script>
    <script type="text/javascript" src="../Js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Js/APlayer.min.js"></script>
    
    <title></title>
</head>
<body style="background: url('../Image/user_center_banner.jpg') no-repeat top center;background-color:#0d3b6c">
    <form id="form1" runat="server">
    <div class="container">
        <div class="header-banner text-center" style="width:100%;" >
            <img src="../Image/guest.png"/>
            <div class="banner-text">
                <strong><asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label></strong>
            </div>
            
        </div>
        <div class="container">
            <div class="uc-navbar">
                <ul class="text-center">
                    <a href="#myow"><li class="uc-center-tab" id="my-ow-btn">我的一言</li></a>
                    <a href="#mysetting"><li class="uc-center-tab" id="my-setting-btn">管理中心</li></a>
                    <a href="User.aspx"><li class="uc-center-tab">返回首页</li></a>
                </ul>
            </div>
        </div>
        <div class="container" id="MyOneWord">
        <div class="pull-left" style="width:30%;">
            <div class="uc-aside">
                <asp:Repeater ID="repAside" runat="server">
                <ItemTemplate>
                    <div class="oneword-aside-text"><strong><%#Eval("count_words_a1") %></strong></div>
                    <div class="oneword-aside-text"><strong><%#Eval("sum_number_a1").ToString()!=""? Eval("sum_number_a1"):"0"%></strong></div>
                    <span class="oneword-aside-icon"><i class="fa fa-size-1 fa-commenting-o"></i></span>
                    <span class="oneword-aside-icon"><i class="fa fa-size-1 fa-thumbs-o-up"></i></span>
                </ItemTemplate>
                </asp:Repeater>
                <asp:Panel ID="pnlAsideNull" runat="server" Visible="False">
                    <div class="oneword-aside-text"><strong>0</strong></div>
                    <div class="oneword-aside-text"><strong>0</strong></div>
                    <span class="oneword-aside-icon"><i class="fa fa-size-1 fa-commenting-o"></i></span>
                    <span class="oneword-aside-icon"><i class="fa fa-size-1 fa-thumbs-o-up"></i></span>
                </asp:Panel>
            </div>
            <div class="uc-aside" style="padding-top:0 !important">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="search-oneword" 
                    placeholder="搜索我的OneWord" onkeydown="if (window.event.keyCode==13) {btnSearchClick();}"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" style="display:none;"/>
            </div>
        </div>
            <div class="ow-panel">
                <asp:Panel ID="pnlMyOW" runat="server">
                    <asp:Repeater ID="repMyOW" runat="server">
                    <ItemTemplate>
                        <div class="user-oneword">
                    <div class="user-oneword-head">
                        <div class="ow-pic pull-left">
                            <img src="../Image/guest.png" class="img-circle" style="width: 60px;height: 60px;">
                        </div>
                        <div class="ow-info">
                            <div><strong><%#Eval("username_")%></strong></div>
                            <div><%#Eval("create_time")%></div>
                        </div>
                    </div>
                    <div class="user-oneword-body">
                        <blockquote><%#Eval("word_") %></blockquote>
                    </div>
                    <div class="user-oneword-foot">
                        <div class="ow-operate pull-right">
                            <a href="DeleteOW.aspx?wbid=<%#Eval("wbid") %>"><i class="fa fa-size-1 fa-margin-1 fa-trash-o"></i></a>
                            <span style="font-size:16px;"></span>
                        </div>
                    </div>
                </div>
                    </ItemTemplate>
                </asp:Repeater>
                </asp:Panel>
                
                <asp:Panel ID="pnlErrorSearchNull" runat="server" Visible="False">
                    <div class="user-oneword">
                    <div class="user-oneword-body margin-0">
                        <div class="user-oneword-error text-center">找不到符合条件的OneWord，返回<a href="UserCenter.aspx">查看全部OneWord？</a></div>
                    </div>
                    
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlErrorLoadNull" runat="server" Visible="False">
                    <div class="user-oneword">
                    <div class="user-oneword-body margin-0">
                        <div class="user-oneword-error text-center">还未撰写OneWord，返回<a href="User.aspx">撰写你的第一条OneWord？</a></div>
                    </div>
                    
                    </div>
                </asp:Panel>
            </div>
        </div>
        <div class="container" id="MySetting" style="display:none">
            <div style="background-color:#071a37;margin-top:15px;padding:0 15% 0 10%;color:#ccc">
                <div class="form-horizontal" style="padding:25px 0 5px 0;">
                    <div class="form-group">
                        <label for="txtUUID" class="col-sm-2 control-label">编号</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtUUID" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtUserName" class="col-sm-2 control-label">用户名</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtPassword" class="col-sm-2 control-label">密码</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtMobile" class="col-sm-2 control-label">手机号</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtCreateTime" class="col-sm-2 control-label">创建时间</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtCreateTime" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtCreateIP" class="col-sm-2 control-label">创建IP</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtCreateIP" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <asp:Button ID="btnEdit" runat="server" Text="确认修改" 
                            CssClass="btn btn-info pull-right" onclick="btnEdit_Click" />
                    </div>
                </div>
            </div>
            
        </div>
    </div>
    
    <div id="side-music" class="fixed-music aplayer"></div>
    <div id="side-top" class="fixed-top" style="display:none;">
        <img src="../Image/top_icon.png" width="50px" height="50px"/>
    </div>
    </form>
    <script type="text/javascript">
        $("#side-top").click(function () {
            $(document.body).animate({ 'scrollTop': 0 }, 888);
            $("#side-top").css("display","none");
        });
        function myOWClick() {
            $('#my-ow-btn').addClass('uc-tab-active');
            $('#my-setting-btn').removeClass('uc-tab-active');
            $('#MyOneWord').css('display','block');
            $('#MySetting').css('display','none');
        };
        function mySettingClick() {
            $('#my-setting-btn').addClass('uc-tab-active');
            $('#my-ow-btn').removeClass('uc-tab-active');
            $('#MySetting').css('display', 'block');
            $('#MyOneWord').css('display', 'none');
        };
        window.onload = function () {
            if (window.location.hash == "#myow") {
                myOWClick();
            } else if (window.location.hash == "#mysetting") {
                mySettingClick();
            } else {
                myOWClick();
            };
            window.onscroll = function () {
                $('#side-music').addClass('fixed-music');
                $('#side-top').css('display', 'block');
                if ($(document).scrollTop() == 0) {
                    $("#side-top").css("display", "none");
                }
            }
        };
        $('#my-ow-btn').click(function(){
            myOWClick();
        });
        $('#my-setting-btn').click(function(){
            mySettingClick();
        });

        function btnSearchClick() {
            document.getElementById("btnSearch").click();
        }
    </script>
    <asp:Repeater ID="repMusic" runat="server">
    <ItemTemplate>
        <script>
            var music = new APlayer({
                element: document.getElementById('side-music'),
                narrow: true,
                autoplay: false,
                showlrc: false,
                mutex: true,
                theme: '#e6d0b2',
                music: {
                    title: '<%#Eval("title_") %>',
                    author: '<%#Eval("author_") %>',
                    url: '<%#Eval("url_") %>',
                    pic: '<%#Eval("picture_") %>'
                }
            });
            music.init();
        </script>
    </ItemTemplate>
    </asp:Repeater>
</body>
</html>
