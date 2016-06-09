<%@ Page Title="" Language="C#" MasterPageFile="~/User/_index.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User_UserTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="oneword-feed" style="margin-top:70px;">
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
                    <div><strong><a href="OperateAttention.aspx?uuidto=<%#Eval("uuid") %>"><%#Eval("username_") %></a></strong></div>
                    <div><%#Eval("create_time") %></div>
                </div>
            </div>
            <div class="random-oneword-body">
                <blockquote><%#Eval("word_") %></blockquote>
            </div>
            <div class="random-oneword-foot">
                <div class="pull-right">
                    <a href="AddLike.aspx?wbid=<%#Eval("wbid") %>"><i class="fa fa-size-1 fa-margin-1 fa-thumbs-o-up"></i>
                    <span style="font-size: 16px;"> <%#Eval("number_").ToString() != "" ? Eval("number_") : "0"%></span>
                    </a>
                </div>
                <%--<div class="pull-right">
                    <a href=""><i class="fa fa-size-1 fa-margin-1 fa-flag"></i>
                    <span style="font-size: 16px;"> 关注此人</span>
                    </a>
                </div>--%>
            </div>
        </div>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
        </asp:Repeater>
        <asp:LinkButton ID="lbtnRefresh_bottom" runat="server" 
            CssClass="refresh-bottom btn btn-block btn-lg btn-info" 
            onclick="lbtnRefresh_bottom_Click">随机获取五条OneWord</asp:LinkButton>
    </div>
    <div class="pull-right">
    <asp:Panel ID="pnlAsideNull" runat="server" Visible="False">
        <div class="oneword-feed-aside">
        <center style="padding-top:40px;">
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
    <asp:Repeater ID="repAside" runat="server">
    <ItemTemplate>
        <div class="oneword-feed-aside">
        <center style="padding-top:40px;">
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

    <div class="oneword-recommend-aside">
        <div style="padding-left:10px;">
            <h4>今日推荐</h4>
        </div>
        <asp:Repeater ID="repAttentionRandom" runat="server">
        <ItemTemplate>
            <div class="aside-recommend-body">
            <div class="pull-left">
                <img src="../Image/guest.png" class="img-circle" style="width: 50px;height: 50px;">
            </div>
            <div class="pull-left" style="margin-left:10px;margin-top:5px;">
                <strong><%#Eval("username_") %></strong>
                <div>注册于<%#Eval("create_time", "{0:yyyy-mm-dd}")%></div>
            </div>
            <div class="pull-right" style="margin-top:15px;">
                <a>
                    <i class="fa fa-plus"></i>
                    <a href="OperateAttention.aspx?uuidto=<%#Eval("uuid") %>">关注</a>
                </a>
            </div>
        </div>
        </ItemTemplate>
            
        </asp:Repeater>
        
        
        <div class="text-center">
            <h5>
                <a>
                    <asp:LinkButton ID="lbtnAttentionRandomChange" runat="server" onclick="lbtnAttentionRandomChange_Click">换一批</asp:LinkButton>
                    <i class="fa fa-hand-o-right"></i>
                </a>
            </h5>
        </div>
    </div>
    </div>

    
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
</script>
</asp:Content>

