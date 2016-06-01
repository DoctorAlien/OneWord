<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_index.master" AutoEventWireup="true" CodeFile="WordsList.aspx.cs" Inherits="Admin_WordList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
        <div class="content-header user-content-header">
            <h1>
                一言列表
                <small>WordList</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> OneWord</a></li>
                <li class="active">WordsList</li>
            </ol>
        </div>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <!-- /.box-header -->
                        <div class="box-body">
                        <asp:Repeater ID="repWordsList" runat="server">
                        <HeaderTemplate>
                            <table id="word-list" class="table table-bordered table-striped">
                                <thead>
                                <tr>
                                    <th>编号</th>
                                    <th>用户名</th>
                                    <th>一言</th>
                                    <th>编写时间</th>
                                    <th>状态</th>
                                    <th>操作</th>
                                </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                    <td><%#Eval("wbid") %></td>
                                    <td><a href="EditUser.aspx?uuid=<%#Eval("uuid") %>"><%#Eval("username_") %></a></td>
                                    <td><%#Eval("word_") %></td>
                                    <td><%#Eval("create_time") %></td>
                                    <td><%#Eval("status_").ToString()=="1"?"启用":"禁用" %></td>
                                    <td>
                                        <a href="BanWord.aspx?wbid=<%#Eval("wbid") %>" onclick="return confirm('是否禁用')">禁用</a>&nbsp;&nbsp;&nbsp;
                                        <a href="UnBanWord.aspx?wbid=<%#Eval("wbid") %>" onclick="return confirm('是否启用')">启用</a>&nbsp;&nbsp;&nbsp;
                                        <a href="DeleteWord.aspx?wbid=<%#Eval("wbid") %>" onclick="return confirm('是否删除')">删除</a>
                                    </td>
                                </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                <tfoot>
                                <tr>
                                    <th>编号</th>
                                    <th>用户名</th>
                                    <th>一言</th>
                                    <th>编写时间</th>
                                    <th>状态</th>
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
            $('#word-list').DataTable();
        });
</script>
</asp:Content>

