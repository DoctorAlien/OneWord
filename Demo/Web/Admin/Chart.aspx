<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_index.master" AutoEventWireup="true" CodeFile="Chart.aspx.cs" Inherits="Admin_Chart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
    <div class="content-header user-content-header">
            <h1>
                报表统计
                <small>Chart</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> OneWord</a></li>
                <li class="active">Chart</li>
            </ol>
    </div>
    <section class="content">
       <div class="row">
        <div class="col-md-12">
        <div class="form-group">
            <label for="ddlYears">请选择报表年份</label>
            <asp:DropDownList ID="ddlYears" runat="server" AutoPostBack="True" 
                CssClass="form-control" style="margin-bottom:15px;" 
                onselectedindexchanged="ddlYears_SelectedIndexChanged"></asp:DropDownList>
        </div>
            
        </div>
        <div class="col-md-6">
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">注册统计</h3>

              <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            <div class="box-body">
              <div class="chart">
                <div class="text-center">
                    <asp:Chart ID="chartUsers" runat=server><Series><asp:Series Name="Series1"></asp:Series></Series>
                    <ChartAreas><asp:ChartArea Name="chartUsersArea"></asp:ChartArea></ChartAreas></asp:Chart>
                </div>  
              </div>
            </div>
          </div>
        </div>


        <div class="col-md-6">
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">一言统计</h3>

              <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            <div class="box-body">
              <div class="chart">
                <div class="text-center">
                    <asp:Chart ID="chartOneWord" runat=server><Series><asp:Series Name="Series1"></asp:Series></Series>
                    <ChartAreas><asp:ChartArea Name="chartOneWordArea"></asp:ChartArea></ChartAreas></asp:Chart>
                </div>  
              </div>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">关注热度</h3>

              <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            <div class="box-body">
              <div class="chart">
                <div class="text-center">
                    <asp:Chart ID="chartAttention" runat=server><Series><asp:Series Name="Series1"></asp:Series></Series>
                    <ChartAreas><asp:ChartArea Name="chartAttentionArea"></asp:ChartArea></ChartAreas></asp:Chart>
                </div>  
              </div>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">点赞热度</h3>

              <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            <div class="box-body">
              <div class="chart">
                <div class="text-center">
                    <asp:Chart ID="chartWordsLike" runat=server><Series><asp:Series Name="Series1"></asp:Series></Series>
                    <ChartAreas><asp:ChartArea Name="chartWordsLikeArea"></asp:ChartArea></ChartAreas></asp:Chart>
                </div>  
              </div>
            </div>
          </div>
        </div>
       </div>
    </section>
</div>
</asp:Content>

