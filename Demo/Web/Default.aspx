<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="Css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="Css/public.css">
    <link rel="stylesheet" type="text/css" href="Css/clouds.css">
    <script src="Js/jquery-2.2.1.min.js"></script>
    <script src="Js/bootstrap.min.js"></script>
    <script src="Js/clouds.js"></script>
    <script src="Js/app.js"></script>
</head>
<body>
    <form id="form1" runat="server">

    <div id="far-clouds" class="stage far-clouds"></div>
    <div id="near-clouds" class="stage near-clouds"></div>

    <div class="content" style="height:100%">
        <div class="login-form">
        <div class="login-header">
            <div class="login-logo">一言</div>
            <div class="login-title">留下你所喜欢的那一句句话，与大家分享</div>
        </div>
        <div class="login-body">
            <div class="login-register">
                <a href="#register" id="btn-register-top" class="login-active">注册</a>
                <a href="#login" id="btn-login-top">登陆</a>
            </div>
            <div id="register" style="display: block">
                <div class="register-main">
                    <div class="">
                        <asp:TextBox ID="txtUserName_register" runat="server" placeholder="用户名"></asp:TextBox>
                        <asp:CustomValidator ID="cvUserName_register" runat="server" 
                            ControlToValidate="txtUserName_register" 
                            onservervalidate="cvUserName_register_ServerValidate" 
                            ValidateEmptyText="True" CssClass="text-red" 
                            ValidationGroup="group_register"></asp:CustomValidator>
                    </div>
                    <div class="">
                        <asp:TextBox ID="txtPassword_register" runat="server" placeholder="密码(不少于6位)" TextMode="Password"></asp:TextBox>
                        <asp:CustomValidator ID="cvPassword_register" runat="server" 
                            CssClass="text-red" ValidateEmptyText="True" 
                            ControlToValidate="txtPassword_register" 
                            onservervalidate="cvPassword_register_ServerValidate" 
                            ValidationGroup="group_register" ></asp:CustomValidator>
                    </div>
                    <div class="">
                        <asp:TextBox ID="txtMobile_register" runat="server" placeholder="手机号(仅支持中国大陆)" CssClass="txtMobile_register"></asp:TextBox>
                        <asp:CustomValidator ID="cvMobile_register" runat="server" CssClass="text-red" 
                            ControlToValidate="txtMobile_register" ValidateEmptyText="True" 
                            onservervalidate="cvMobile_register_ServerValidate" 
                            ValidationGroup="group_register"></asp:CustomValidator>
                    </div>
                    <div>
                        <asp:TextBox ID="txtValidateCode_register" runat="server" CssClass="txt-validate-code" placeholder="验证码"></asp:TextBox>
                        <asp:LinkButton ID="lbtnValidateCode_register" runat="server" 
                            CssClass="validate-code" onclick="lbtnValidateCode_register_Click"></asp:LinkButton>
                        <asp:CustomValidator ID="cvValidate_register" runat="server" 
                            ControlToValidate="txtValidateCode_register" CssClass="text-red" 
                            ValidateEmptyText="True" onservervalidate="cvValidate_register_ServerValidate" 
                            ValidationGroup="group_register"></asp:CustomValidator>
                    </div>
                </div>
                <div class="register-btn">
                    <asp:Button ID="btnRegister" runat="server" Text="注册" 
                        CssClass="btn-block btn btn-primary" onclick="btnRegister_Click" 
                        ValidationGroup="group_register" />
                </div>
            </div>
            <div id="login" style="display: none">
                <div class="login-main">
                    <div class="">
                        <asp:TextBox ID="txtUserName_login" runat="server" placeholder="用户名"></asp:TextBox>
                        <asp:CustomValidator ID="cvUserName_login" runat="server" CssClass="text-red" ControlToValidate="txtUserName_login" ValidateEmptyText="True" onservervalidate="cvUserName_login_ServerValidate" ValidationGroup="group_login"></asp:CustomValidator>
                    </div>
                    <div class="">
                        <asp:TextBox ID="txtPassword_login" runat="server" placeholder="密码" TextMode="Password"></asp:TextBox>
                        <asp:CustomValidator ID="cvPassword_login" runat="server" CssClass="text-red" ControlToValidate="txtPassword_login" ValidateEmptyText="True" onservervalidate="cvPassword_login_ServerValidate" ValidationGroup="group_login"></asp:CustomValidator>
                    </div>
                    <div>
                        <asp:TextBox ID="txtValidateCode_login" runat="server" CssClass="txt-validate-code" placeholder="验证码"></asp:TextBox>
                        <asp:LinkButton ID="lbtnValidateCode_login" runat="server" 
                            CssClass="validate-code" onclick="lbtnValidateCode_login_Click"></asp:LinkButton>
                        <asp:CustomValidator ID="cvValidate_Login" runat="server" ControlToValidate="txtValidateCode_login" CssClass="text-red" ValidateEmptyText="True" onservervalidate="cvValidate_Login_ServerValidate" ValidationGroup="group_login"></asp:CustomValidator>
                    </div>
                </div>
                <div class="login-btn">
                    <asp:Button ID="btnLogin" runat="server" Text="登陆" 
                        CssClass="btn-block btn btn-primary" onclick="btnLogin_Click" ValidationGroup="group_login"/>
                </div>
            </div>
        </div>
        <div class="login-footer">
            © 2016&nbsp;&nbsp;一言@C#&nbsp;PoweredBy&nbsp;DoctorAlien
        </div>
    </div>
    </div>

    <div class="navbar-fixed-bottom ow-bottom-random">
        <asp:Repeater ID="repRandomWord" runat="server">
        <ItemTemplate>
            <span><%#Eval("word_") %></span>
            <span style="margin-left:15px;"><%#Eval("create_time") %></span>
        </ItemTemplate>
        <FooterTemplate>
            <div class="pull-right">
                <asp:LinkButton ID="lbtnRefresh" runat="server" onclick="lbtnRefresh_Click">
                    <i class="fa fa-refresh fa-spin"></i>
                    Refresh
                </asp:LinkButton>
            </div>
        </FooterTemplate>
        </asp:Repeater>
    </div>
    <script>
        function registerClick() {
            $('#btn-register-top').addClass('login-active');
            $('#btn-login-top').removeClass('login-active');
            $('#register').css('display', 'block');
            $("#login").css('display', 'none');
        };
        function loginClick() {
            $('#btn-login-top').addClass('login-active');
            $('#btn-register-top').removeClass('login-active');
            $('#login').css('display', 'block');
            $("#register").css('display', 'none');
        };
        window.onload = function () {
            if (window.location.hash == "#register") {
                registerClick();
            } else if (window.location.hash == "#login") {
                loginClick();
            } else {
                registerClick();
            }
        };
        $('#btn-register-top').click(function () {
            registerClick();
        });
        $('#btn-login-top').click(function () {
            loginClick();
        });
    </script>
    </form>
</body>
</html>
