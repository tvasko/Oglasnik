﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="loginReg.aspx.cs" Inherits="OglasnikIT.loginReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
      
    </script>
    <br/>
    <br/>
    <br/>
    <br/>
    	<form runat="server" class="row">
			<div class="col-md-6 col-md-offset-3">
				<div class="panel panel-login">
					<div class="panel-heading">
						<div class="row">
							<div class="col-xs-6">
								<a href="#" class="active" id="login-form-link">Логирај се</a>
							</div>
							<div class="col-xs-6">
								<a href="#" id="register-form-link">Регистрирај се</a>
							</div>
						</div>
						<hr>
					</div>
					<div class="panel-body">
						<div class="row">
							<div class="col-lg-12">
								<div id="loginform"  style="display: block;">
									<div class="form-group">
                                        <asp:TextBox ID="usernameLogin" TabIndex="1" CssClass="form-control" placeholder="Корисничко име" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
                                         <asp:TextBox ID="passwordLogin" TabIndex="2" CssClass="form-control" placeholder="Лозинка" runat="server" TextMode="Password"></asp:TextBox>	
									</div>
									
									<div class="form-group">
										<div class="row">
											<div class="col-sm-6 col-sm-offset-3">
                                                <asp:Button ID="btnLogIn" runat="server" TabIndex="4" CssClass="form-control btn btn-login" Text="Логирај се" OnClick="btnLogIn_Click" />
												</div>
										</div>
									</div>
								</div>
								<div id="registerform" style="display: none;">
									<div class="form-group">
                                        <asp:TextBox ID="usernameRegister" TabIndex="1" CssClass="form-control" placeholder="Корисничко име" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
                                         <asp:TextBox ID="emailRegister" TabIndex="1" CssClass="form-control" placeholder="Email Адреса" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
                                         <asp:TextBox ID="passwordRegister" TabIndex="2" CssClass="form-control" placeholder="Лозинка" runat="server" TextMode="Password"></asp:TextBox>
										
									</div>
									<div class="form-group">
                                        <asp:TextBox ID="nameRegister" TabIndex="3" CssClass="form-control" placeholder="Име" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-6 col-sm-offset-3">
                                                <asp:Button ID="btnRegister" runat="server" TabIndex="4" CssClass="form-control btn btn-register" Text="Регистрирај се" OnClick="btnRegister_Click" />
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</form>
    <style>
        body {
    padding-top: 90px;
}
.panel-login {
	border-color: #ccc;
	-webkit-box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
	-moz-box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
	box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
}
.panel-login>.panel-heading {
	color: #00415d;
	background-color: #fff;
	border-color: #fff;
	text-align:center;
}
.panel-login>.panel-heading a{
	text-decoration: none;
	color: #666;
	font-weight: bold;
	font-size: 15px;
	-webkit-transition: all 0.1s linear;
	-moz-transition: all 0.1s linear;
	transition: all 0.1s linear;
}
.panel-login>.panel-heading a.active{
	color: #029f5b;
	font-size: 18px;
}
.panel-login>.panel-heading hr{
	margin-top: 10px;
	margin-bottom: 0px;
	clear: both;
	border: 0;
	height: 1px;
	background-image: -webkit-linear-gradient(left,rgba(0, 0, 0, 0),rgba(0, 0, 0, 0.15),rgba(0, 0, 0, 0));
	background-image: -moz-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
	background-image: -ms-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
	background-image: -o-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
}
.panel-login input[type="text"],.panel-login input[type="email"],.panel-login input[type="password"] {
	height: 45px;
	border: 1px solid #ddd;
	font-size: 16px;
	-webkit-transition: all 0.1s linear;
	-moz-transition: all 0.1s linear;
	transition: all 0.1s linear;
}
.panel-login input:hover,
.panel-login input:focus {
	outline:none;
	-webkit-box-shadow: none;
	-moz-box-shadow: none;
	box-shadow: none;
	border-color: #ccc;
}
.btn-login {
	background-color: #59B2E0;
	outline: none;
	color: #fff;
	font-size: 14px;
	height: auto;
	font-weight: normal;
	padding: 14px 0;
	text-transform: uppercase;
	border-color: #59B2E6;
}
.btn-login:hover,
.btn-login:focus {
	color: #fff;
	background-color: #53A3CD;
	border-color: #53A3CD;
}
.forgot-password {
	text-decoration: underline;
	color: #888;
}
.forgot-password:hover,
.forgot-password:focus {
	text-decoration: underline;
	color: #666;
}

.btn-register {
	background-color: #1CB94E;
	outline: none;
	color: #fff;
	font-size: 14px;
	height: auto;
	font-weight: normal;
	padding: 14px 0;
	text-transform: uppercase;
	border-color: #1CB94A;
}
.btn-register:hover,
.btn-register:focus {
	color: #fff;
	background-color: #1CA347;
	border-color: #1CA347;
}

    </style>
   
</asp:Content>
