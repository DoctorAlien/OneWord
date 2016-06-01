<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_index.master" AutoEventWireup="true" CodeFile="MusicsList.aspx.cs" Inherits="Admin_MusicsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
        <div class="content-header user-content-header">
            <h1>
                BGM列表
                <small>WordList</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> OneWord</a></li>
                <li class="active">MusicsList</li>
            </ol>
        </div>
        <div style="padding: 15px 15px 0 15px;margin-right: auto;margin-left: auto;">
            <a class="btn btn-info btn-sm" href="AddMusic.aspx">添加BGM</a>
        </div>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <!-- /.box-header -->
                        <div class="box-body">
                        <asp:Repeater ID="repMusicsList" runat="server">
                        <HeaderTemplate>
                            <table id="music-list" class="table table-bordered table-striped">
                                <thead>
                                <tr>
                                    <th>编号</th>
                                    <th>歌名</th>
                                    <th>作者</th>
                                    <th>地址</th>
                                    <th>缩略图</th>
                                    <th>状态</th>
                                    <th>操作</th>
                                </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                    <td><%#Eval("mbid") %></td>
                                    <td><%#Eval("title_") %></a></td>
                                    <td><%#Eval("author_") %></td>
                                    <td><%#Eval("url_") %></td>
                                    <td><img src="<%#Eval("picture_") %>" width="50px" height="50px"/></td>
                                    <td><%#Eval("status_").ToString()=="1"?"启用":"禁用" %></td>
                                    <td>
                                        <a href="BanMusic.aspx?mbid=<%#Eval("mbid") %>" onclick="return confirm('是否禁用')">禁用</a>&nbsp;&nbsp;&nbsp;
                                        <a href="UnBanMusic.aspx?mbid=<%#Eval("mbid") %>" onclick="return confirm('是否启用')">启用</a>&nbsp;&nbsp;&nbsp;
                                        <a href="DeleteMusic.aspx?mbid=<%#Eval("mbid") %>" onclick="return confirm('是否删除')">删除</a>
                                    </td>
                                </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                <tfoot>
                                <tr>
                                    <th>编号</th>
                                    <th>歌名</th>
                                    <th>作者</th>
                                    <th>地址</th>
                                    <th>缩略图</th>
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
            $('#music-list').DataTable();
        });
</script>
</asp:Content>

