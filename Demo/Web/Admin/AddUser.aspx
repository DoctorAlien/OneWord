<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_index.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="Admin_AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
        <div class="content-header user-content-header">
            <h1>
                添加用户
                <small>AddUser</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> OneWord</a></li>
                <li class="active">AddUser</li>
            </ol>
        </div>

        <section class="content">
            <div class="row">
                <div class="col-xs-6">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">添加成员</h3>
                        </div>
                        <form role="form">
                            <div class="box-body">
                                <div class="form-group">
                                    <label for="txtUserName">用户名</label>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"  placeholder="用户名"></asp:TextBox>
                                </div>
                                <div class="form-control">
                                    <span style="color: red">PS&nbsp;:&nbsp;默认密码111111</span>
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer">
                                <asp:Button ID="btnInsert" runat="server" Text="确认添加" 
                                    CssClass="btn btn-primary" onclick="btnInsert_Click"></asp:Button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

