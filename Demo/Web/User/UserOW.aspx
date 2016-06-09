<%@ Page Title="" Language="C#" MasterPageFile="~/User/_index.master" AutoEventWireup="true" CodeFile="UserOW.aspx.cs" Inherits="User_UserOW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container"  style="margin-top:70px;">
    <div class="col-xs-offset-2 col-xs-8 text-center">
        <asp:Repeater ID="repAttentionInfo" runat="server">
        <ItemTemplate>
            <img src="../Image/guest.png" class="img-circle" width="150px" height="150px"/>
            <div><h3><strong><%#Eval("username_") %></strong></h3></div>
            <div style="margin:15px auto 20px auto">
            <a href="OperateAttention.aspx?uuidto=<%#Eval("uuid") %>" class="cancel-attention-btn">
            取消关注
            </a>
            </div>
        </ItemTemplate>
        </asp:Repeater>
        
        
    </div>
    <asp:Repeater ID="repAttentionOW" runat="server">
        <ItemTemplate>
            <div class="col-xs-offset-2 col-xs-8 attention-ow">
            <div>
            <h4><strong>Date:<%#Eval("create_time") %></strong></h4>
            </div>
            <blockquote><%#Eval("word_") %></blockquote>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Panel ID="pnlAttentionOWNull" runat="server" Visible="False">
        <div class="col-xs-8 col-xs-offset-2">
            <div class="attention-error text-center" style="border:solid 1px #ccc;box-shadow:3px 3px 3px #ccc">
                该用户还未撰写任何OneWord,返回<a href="MyAttention.aspx">查看其他人的OneWord?</a>
            </div>
    </div>
    </asp:Panel>
    
</div>
</asp:Content>

