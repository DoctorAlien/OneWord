<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_index.master" AutoEventWireup="true" CodeFile="UsersList.aspx.cs" Inherits="Admin_UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
        <div class="content-header user-content-header">
            <h1>
                用户列表
                <small>UserList</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> OneWord</a></li>
                <li class="active">UsersList</li>
            </ol>
        </div>
        <div style="padding: 15px 15px 0 15px;margin-right: auto;margin-left: auto;">
            <a class="btn btn-info btn-sm" href="AddUser.aspx">添加成员</a>
        </div>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <!-- /.box-header -->
                        <div class="box-body">
                        <asp:Repeater ID="repUsersList" runat="server">
                        <HeaderTemplate>
                            <table id="user-list" class="table table-bordered table-striped">
                                <thead>
                                <tr>
                                    <th>编号</th>
                                    <th>用户名</th>
                                    <th>手机号</th>
                                    <th>注册时间</th>
                                    <th>注册IP</th>
                                    <th>操作</th>
                                </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                    <td><%#Eval("uuid") %></td>
                                    <td><%#Eval("username_") %></td>
                                    <td><%#Eval("mobile_") %></td>
                                    <td><%#Eval("create_time") %></td>
                                    <td><%#Eval("create_ip") %></td>
                                    <td>
                                        <a href="EditUser.aspx?uuid=<%#Eval("uuid") %>">编辑</a>&nbsp;&nbsp;&nbsp;
                                        <a href="DeleteUser.aspx?uuid=<%#Eval("uuid") %>" onclick="return confirm('确定删除?')">删除</a>
                                    </td>
                                </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                <tfoot>
                                <tr>
                                    <th>编号</th>
                                    <th>用户名</th>
                                    <th>手机号</th>
                                    <th>注册时间</th>
                                    <th>注册IP</th>
                                    <th>操作</th>
                                </tr>
                                </tfoot>
                            </table>
                        </FooterTemplate>
                        </asp:Repeater>
                            
                                
                                
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </section>
        <!-- /.content -->
    </div>
    <script>
        $(function () {
            $('#user-list').DataTable();
        });
</script>
</asp:Content>

