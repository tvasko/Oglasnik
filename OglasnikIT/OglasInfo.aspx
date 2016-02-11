<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="OglasInfo.aspx.cs" Inherits="OglasnikIT.OglasInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div>
        <form runat="server">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <asp:Label CssClass="h3" ID="lblNaslov" runat="server" Text="Наслов"></asp:Label>
                        <div class="pull-right">
                            <asp:Button CssClass="btn-sm btn btn-success" Visible="false" ID="btnOdobriOglas" runat="server" Text="Одобри" OnClick="btnOdobriOglas_Click"  />
                            <asp:Button CssClass="btn-sm btn btn-warning" Visible="false" ID="btnIzmeniOglas" runat="server" Text="Измени" OnClick="btnIzmeniOglas_Click" />
                            <asp:Button CssClass="btn-sm  btn btn-danger" Visible="false" ID="btnIzbrisiOglas" runat="server" Text="Избриши" OnClick="btnIzbrisiOglas_Click" />
                        </div>
                    </h3>
                </div>
                <div class="panel-body">
                    <div class="col-md-7 col-lg-7">
                        <asp:Image CssClass="center-block text-center img-responsive img-thumbnail" ID="imgSlika1" runat="server" AlternateText="Не постои слика за прикажување !" ForeColor="Red" />
                    </div>
                    <div class=" center-block text-center col-md-5 col-lg-5">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:ImageButton CssClass="text-center img-responsive img-thumbnail" ID="imgS1" runat="server" Height="200px" Width="200px" AlternateText="Нема слика!" OnClick="imgS1_Click" />
                            </div>
                            <div class="col-md-6">
                                <asp:ImageButton CssClass="text-center img-responsive img-thumbnail" ID="imgS2" runat="server" Height="200px" Width="200px" AlternateText="Нема слика!" OnClick="imgS2_Click" />
                            </div>
                        </div>
                        <div class="row">
                            <label></label>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:ImageButton CssClass="text-center img-responsive img-thumbnail" ID="imgS3" runat="server" Height="200px" Width="200px" AlternateText="Нема слика!" OnClick="imgS3_Click" />
                            </div>
                            <div class="col-md-6">
                                <asp:ImageButton CssClass="text-center img-responsive img-thumbnail" ID="imgS4" runat="server" Height="200px" Width="200px" AlternateText="Нема слика!" OnClick="imgS4_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-group">
                        <h3>
                            <label>Цена:</label>
                            <asp:Label CssClass="label label-info" ID="lblCena" runat="server" Text="0"></asp:Label>
                        </h3>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <h4>
                                    <label>Категорија:</label>
                                    <asp:Label CssClass="label label-info" ID="lblKategorija" runat="server" Text="0"></asp:Label>
                                </h4>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <h4>
                                    <label>Град:</label>
                                    <asp:Label CssClass="label label-info" ID="lblGrad" runat="server" Text="0"></asp:Label>
                                </h4>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <h4>
                                    <label>Датум на објава:</label>
                                    <asp:Label CssClass="label label-info" ID="lblDatum" runat="server" Text="0"></asp:Label>
                                </h4>
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:TextBox CssClass="form-control disabled" Style="resize: none" ID="txtOpis" runat="server" Text="Опис" Rows="15" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="form-group">
                        <h3>
                            <span class="glyphicon glyphicon-earphone"></span>
                            <asp:Label CssClass="" ID="lblIme" runat="server" Text="Корисник:"></asp:Label>
                            <asp:Label CssClass="label label-info" ID="lblTelefon" runat="server" Text="070999333"></asp:Label>
                        </h3>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
