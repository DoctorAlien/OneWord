<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_index.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="Admin_EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
        <div class="content-header user-content-header">
            <h1>
                编辑用户
                <small>EditUser</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> OneWord</a></li>
                <li class="active">EditUser</li>
            </ol>
        </div>

        <section class="content">
            <div class="row">
                <div class="col-xs-6">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">编辑成员</h3>
                        </div>
                        <form role="form">
                            <div class="box-body">
                                <div class="form-group">
                                    <label for="txtUUID">编号</label>
                                    <asp:TextBox ID="txtUUID" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtUserName">用户名</label>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtPassword">密码</label>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtMobile">手机号</label>
                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtCreateTime">创建时间</label>
                                    <asp:TextBox ID="txtCreateTime" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtCreateIP">创建IP</label>
                                    <asp:TextBox ID="txtCreateIP" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer">
                                <asp:Button ID="btnEdit" runat="server" Text="确认添加" CssClass="btn btn-primary" 
                                    onclick="btnEdit_Click"></asp:Button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

