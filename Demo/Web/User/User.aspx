<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User_User" debug="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="../Css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="../Css/public.css">
    <link rel="stylesheet" type="text/css" href="../Css/OwO.min.css">
    <link rel="Stylesheet" type="text/css" href="../Css/APlayer.min.css" />
    <script type="text/javascript" src="../Js/jquery-2.2.1.min.js"></script>
    <script type="text/javascript" src="../Js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Js/OwO.min.js"></script>
    <script type="text/javascript" src="../Js/remaining-num.js"></script>
    <script type="text/javascript" src="../Js/APlayer.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navbar navbar-lightskyblue">
    <div class="container">
        <div class="navbar-header pull-left">
            <a href="User.aspx" class="navbar-brand">一言</a>
        </div>
        <div class="navbar-brand pull-right">
            <a href="../LogOut.aspx">退出</a>
        </div>
    </div>
</div>
<div class="oneword-feed">
    <div class="oneword-feed-context">
        <div class="edit-panel">
            <div class="edit-panel-head">
                <strong>写下你所喜欢的那一句话，与大家分享</strong>
                <small id="remaining" style="float:right;line-height: 28px;color: #8c8c8c"></small>
            </div>
            <div class="edit-panel-body">
                <asp:TextBox ID="txtOneWord" runat="server" CssClass="textarea-reset OwO-textarea" TextMode="MultiLine" onkeyup="checkLength(this,100,'remaining');" maxlength="100"></asp:TextBox>
            </div>
            <div class="edit-panel-foot" style="height: 30px;">
                <span class="OwO"></span>
                <asp:Button ID="btnPublish" runat="server" Text="发表" 
                    CssClass="btn btn-warning pull-right" onclick="btnPublish_Click" />
            </div>
        </div>
        <div style="height: 14px;margin-bottom: 15px;font-size: 16px;">
            <div class="pull-right">
                <asp:LinkButton ID="lbtnRefresh" runat="server" onclick="lbtnRefresh_Click"><i class="fa fa-refresh fa-spin"></i><span>&nbsp;刷新</span></asp:LinkButton>
            </div>
        </div>
        <asp:Repeater ID="repOneWord" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <div class="random-oneword">
            <div class="random-oneword-head">
                <div class="random-pic">
                    <img src="../Image/guest.png" class="img-circle" style="width: 60px;height: 60px;">
                </div>
                <div class="random-info">
                    <div><strong><%#Eval("username_") %></strong></div>
                    <div><%#Eval("create_time") %></div>
                </div>
            </div>
            <div class="random-oneword-body">
                <blockquote><%#Eval("word_") %></blockquote>
            </div>
            <div class="random-oneword-foot">
                <div class="random-oneword-like">
                    <a href="AddLike.aspx?wbid=<%#Eval("wbid") %>"><i class="fa fa-size-1 fa-margin-1 fa-thumbs-o-up"></i>
                    <span style="font-size: 16px;"> <%#Eval("number_").ToString() != "" ? Eval("number_") : "0"%></span>
                    </a>
                </div>
            </div>
        </div>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
        </asp:Repeater>
        <asp:LinkButton ID="lbtnRefresh_bottom" runat="server" 
            CssClass="refresh-bottom btn btn-block btn-lg btn-info" 
            onclick="lbtnRefresh_bottom_Click">随机获取五条OneWord</asp:LinkButton>
    </div>
    <asp:Repeater ID="repAside" runat="server">
    <ItemTemplate>
        <div class="oneword-feed-aside">
        <center style="margin-top: 40px;">
            <img class="img-circle" src="../Image/guest.png" style="width: 100px;height: 100px;">
            <div style="color: #4a4744;font-size: 22px;"><strong><a href="UserCenter.aspx"><%#Eval("username_") %></a></strong></div>
        </center>
        <div>
            <div class="oneword-aside-text"><strong><a href="UserCenter.aspx"><%#Eval("count_words_a1") %></a></strong></div>
            <div class="oneword-aside-text"><strong><%#Eval("sum_number_a1").ToString()!=""? Eval("sum_number_a1"):"0"%></strong></div>
            <span class="oneword-aside-icon"><i class="fa fa-size-1 fa-commenting-o"></i></span>
            <span class="oneword-aside-icon"><i class="fa fa-size-1 fa-thumbs-o-up"></i></span>
        </div>
    </div>
    </ItemTemplate>
    </asp:Repeater>
    <asp:Panel ID="pnlAsideNull" runat="server" Visible="False">
        <div class="oneword-feed-aside">
        <center style="margin-top: 40px;">
            <img class="img-circle" src="../Image/guest.png" style="width: 100px;height: 100px;">
            <div style="color: #4a4744;font-size: 22px;"><strong><a href="UserCenter.aspx">
                <asp:Label ID="lblUserName" runat="server"></asp:Label></a></strong></div>
        </center>
        <div>
            <div class="oneword-aside-text"><strong><a href="UserCenter.aspx">0</a></strong></div>
            <div class="oneword-aside-text"><strong>0</strong></div>
            <span class="oneword-aside-icon"><i class="fa fa-size-1 fa-commenting-o"></i></span>
            <span class="oneword-aside-icon"><i class="fa fa-size-1 fa-thumbs-o-up"></i></span>
        </div>
    </div>
    </asp:Panel>
</div>

<div id="side-music" class="fixed-music aplayer"></div>
<div id="side-top" class="fixed-top" style="display:none;">
    <img src="../Image/top_icon.png" width="50px" height="50px"/>
</div>

<script type="text/javascript">
    var OwO_demo = new OwO({
        logo: '<i class="fa fa-size-1 fa-smile-o">&nbsp;表情</i>',
        container: document.getElementsByClassName('OwO')[0],
        target: document.getElementsByClassName('OwO-textarea')[0],
        api: './OwO.json',
        position: 'down',
        width: '618px;',
        maxHeight: '250px'
    });
    $("#side-top").click(function () {
        $(document.body).animate({ 'scrollTop': 0 }, 888);
        $("#side-top").css("display", "none");
    });
    window.onload = function () {
        window.onscroll = function () {
            $('#side-music').addClass('fixed-music');
            $('#side-top').css('display', 'block');
            if ($(document).scrollTop() == 0) {
                $("#side-top").css("display", "none");
            }
        }
    };
</script>
    </form>
    <asp:Repeater ID="repMusic" runat="server">
    <ItemTemplate>
        <script type="text/javascript">
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
