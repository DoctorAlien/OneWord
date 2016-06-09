<%@ Page Title="" Language="C#" MasterPageFile="~/User/_index.master" AutoEventWireup="true" CodeFile="MyAttention.aspx.cs" Inherits="User_MyAttention" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="margin-top:70px;">
        <asp:Repeater ID="repMyAttention" runat="server">
        <ItemTemplate>
            <div class="col-xs-4" style="margin-bottom:20px;">
            <div style="height:75px;background-color:#ccc;padding:8px 15px;box-shadow:3px 3px 3px #ccc">
                <div class="pull-left">
                    <img src="../Image/guest.png" class="img-circle" style="width: 60px;height: 60px;">
                </div>
                <div class="pull-left" style="margin-left:10px;margin-top:8px;">
                    <strong><a href="UserOW.aspx?uuidto=<%#Eval("uuid_to") %>"><%#Eval("username_") %></a></strong>
                    <div>关注于<%#Eval("create_time", "{0:yyyy-mm-dd}")%></div>
                </div>
                <div class="pull-right" style="margin-top:22px;">
                    <a href="OperateAttention.aspx?uuidto=<%#Eval("uuid_to") %>" class="cancel-attention-btn attention-cancel-reload">取消关注</a>
                </div>
            </div>
        </div>
        </ItemTemplate>
        </asp:Repeater>
        <asp:Panel ID="pnlMyAttentionNull" runat="server" Visible="False">
            <div class="col-xs-8 col-xs-offset-2">
            <div class="attention-error text-center" style="border:solid 1px #ccc;box-shadow:3px 3px 3px #ccc">
                还未关注任何人,返回<a href="User.aspx">选择心仪的撰写人?</a>
            </div>
        </div>
        </asp:Panel>
    </div>
</asp:Content>

