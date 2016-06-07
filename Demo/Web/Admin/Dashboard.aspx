<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_index.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Admin_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <div class="content-header user-content-header">
            <h1>
                控制面板
                <small>Control</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> OneWord</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </div>

        <section class="content">
            <div class="row">
                <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-aqua">
                        <div class="inner">
                            <h3><asp:Label ID="lblOneWord" runat="server"></asp:Label></h3>
                            <p>一言</p>
                        </div>
                        <div class="icon">
                            <i class="fa fa-commenting-o"></i>
                        </div>
                        <a href="WordsList.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-green">
                        <div class="inner">
                            <h3><asp:Label ID="lblUsersNumber" runat="server"></asp:Label></h3>
                            <p>用户</p>
                        </div>
                        <div class="icon">
                            <i class="fa fa-user-plus"></i>
                        </div>
                        <a href="UsersList.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>

                <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-yellow">
                        <div class="inner">
                            <h3><asp:Label ID="lblBGMNumber" runat="server" Text="Label"></asp:Label></h3>
                            <p>BGM</p>
                        </div>
                        <div class="icon">
                            <i class="fa fa-music"></i>
                        </div>
                        <a href="MusicsList.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

