<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_index.master" AutoEventWireup="true" CodeFile="Setting.aspx.cs" Inherits="Admin_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
        <div class="content-header user-content-header">
            <h1>
                设置
                <small>Setting</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> OneWord</a></li>
                <li class="active">Setting</li>
            </ol>
        </div>

        <div class="content">
            <div class="row">
                <div class="col-xs-6">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">修改密码</h3>
                        </div>
                        <div>
                            <div class="box-body">
                                <div class="form-group">
                                    <label for="txtOldPassword">旧密码</label>
                                    <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" placeholder="旧密码"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtNewPassword">新密码</label>
                                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" placeholder="新密码"></asp:TextBox>
                                </div>
                            </div>
                            <div class="box-footer">
                                <asp:Button ID="btnChangePassword" runat="server" Text="确认修改" 
                                    CssClass="btn btn-primary" onclick="btnChangePassword_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

