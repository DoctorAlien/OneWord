<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_index.master" AutoEventWireup="true" CodeFile="AddMusic.aspx.cs" Inherits="Admin_AddMusic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
        <div class="content-header user-content-header">
            <h1>
                添加BGM
                <small>AddMusic</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> OneWord</a></li>
                <li class="active">AddMusic</li>
            </ol>
        </div>

        <section class="content">
            <div class="row">
                <div class="col-xs-6">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">添加BGM</h3>
                            <div class="pull-right">直接上传</div>
                        </div>
                        <form role="form" id="up-in">
                            <div class="box-body">
                                <div class="form-group">
                                    <label for="txtTitle">歌名</label>
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAuthor">歌手</label>
                                    <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="fulUrl">歌曲</label>
                                    <input type="file" runat="server" class="form-control" id="inputUrl" />
                                </div>
                                <div class="form-group">
                                    <label for="fulPicture">缩略图</label>
                                    <input type="file" runat="server" class="form-control" id="inputPic" />
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer">
                                <asp:Button ID="btnInsert" runat="server" Text="上传BGM" 
                                    CssClass="btn btn-primary" onclick="btnInsert_Click"></asp:Button>
                            </div>
                        </form>
                    </div>
                </div>

                <div class="col-xs-6">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">添加BGM</h3>
                            <div class="pull-right">外链上传</div>
                        </div>
                        <div id="up-out">
                            <div class="box-body">
                                <div class="form-group">
                                    <label for="txtTitle_out">歌名</label>
                                    <asp:TextBox ID="txtTitle_out" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtAuthor_out">歌手</label>
                                    <asp:TextBox ID="txtAuthor_out" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtUrl_out">歌曲</label>
                                    <asp:TextBox ID="txtUrl_out" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtPicture_out">缩略图</label>
                                    <asp:TextBox ID="txtPicture_out" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer">
                                <asp:Button ID="btnInsert_out" runat="server" Text="上传BGM" 
                                    CssClass="btn btn-primary" onclick="btnInsert_out_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

