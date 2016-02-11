<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="prebaraj.aspx.cs" Inherits="OglasnikIT.prebaraj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="panel panel-default">
        <div class="panel-body text-center">
            <form role="form" runat="server">
                <div class="form-horizontal form-inline">
                    <div class="form-group">
                        <label class="col-md-0 control-label"></label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtPrebaraj" CssClass="form-control" placeholder="Пребарај" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-4 control-label">Град</label>
                        <div class="col-md-8">

                            <asp:DropDownList CssClass="form-control" ID="ddlLokacija" runat="server">
                                <asp:ListItem>Цела Македонија</asp:ListItem>
                                <asp:ListItem>Битола</asp:ListItem>
                                <asp:ListItem>Велес</asp:ListItem>
                                <asp:ListItem>Гевгелија</asp:ListItem>
                                <asp:ListItem>Гостивар</asp:ListItem>
                                <asp:ListItem>Кавадарци</asp:ListItem>
                                <asp:ListItem>Кичево</asp:ListItem>
                                <asp:ListItem>Кочани</asp:ListItem>
                                <asp:ListItem>Куманово</asp:ListItem>
                                <asp:ListItem>Охрид</asp:ListItem>
                                <asp:ListItem>Прилеп</asp:ListItem>
                                <asp:ListItem>Скопје</asp:ListItem>
                                <asp:ListItem>Струмица</asp:ListItem>
                                <asp:ListItem>Тетово</asp:ListItem>
                                <asp:ListItem>Штип</asp:ListItem>
                                <asp:ListItem>Демир Хисар</asp:ListItem>
                                <asp:ListItem>Кратово</asp:ListItem>
                                <asp:ListItem>Берово</asp:ListItem>
                                <asp:ListItem>Крушево</asp:ListItem>
                                <asp:ListItem>Валандово</asp:ListItem>
                                <asp:ListItem>Радовиш</asp:ListItem>
                                <asp:ListItem>Неготино</asp:ListItem>
                                <asp:ListItem>Ресен</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-2 col-md-offset-1 control-label">Категорија</label>
                        <div class="col-md-6 col-md-offset-1">
                            <asp:DropDownList CssClass="form-control" ID="ddlKategorii" runat="server">
                                <asp:ListItem>Сите категории</asp:ListItem>
                                <asp:ListItem Value="ВОЗИЛА" disabled="true" style="background-color: gray; color: white; font-size: 25px;">ВОЗИЛА</asp:ListItem>
                                <asp:ListItem>Автомобили</asp:ListItem>
                                <asp:ListItem>Автоделови и опрема</asp:ListItem>
                                <asp:ListItem>Моторцикли</asp:ListItem>
                                <asp:ListItem disabled="true" style="background-color: gray; color: white; font-size: 25px;">ЖИВЕАЛИШТА</asp:ListItem>
                                <asp:ListItem>Куќи/Вили</asp:ListItem>
                                <asp:ListItem>Станови</asp:ListItem>
                                <asp:ListItem>Цимер/ка</asp:ListItem>
                                <asp:ListItem disabled="true" style="background-color: gray; color: white; font-size: 25px;">ЕЛЕКТРОНИКА</asp:ListItem>
                                <asp:ListItem>Мобилни телефони</asp:ListItem>
                                <asp:ListItem>Додатоци за мобилни телефони</asp:ListItem>
                                <asp:ListItem>Компјутери</asp:ListItem>
                                <asp:ListItem>Делови за компјутери</asp:ListItem>
                                <asp:ListItem disabled="true" style="background-color: gray; color: white; font-size: 25px;">БИЗНИС И РАБОТА</asp:ListItem>
                                <asp:ListItem>Деловен простор</asp:ListItem>
                                <asp:ListItem>Машини и инвентар</asp:ListItem>
                                <asp:ListItem>Услуги и работа</asp:ListItem>
                                <asp:ListItem>ДРУГО</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">

                        <div class="col-md-8 col-md-offset-4">
                            <asp:Button ID="btnPrebaraj" CssClass="btn btn-success" runat="server" Text="Пребарај" OnClick="btnPrebaraj_Click" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="Label1" Visible="false" runat="server" Text="Нема пронајдено огласи"></asp:Label>
                </div>
                <div class=" container">
                    <div class="">
                        <asp:GridView Width="95%" CssClass=" table table-hover table-striped" GridLines="None" ID="gvOglasi" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvOglasi_RowDataBound" AllowPaging="False" DataKeyNames="oglasiId" OnSelectedIndexChanged="gvOglasi_SelectedIndexChanged" AllowSorting="False">
                            <Columns>
                                <asp:BoundField DataField="datum" HeaderText="Датум">
                                    <ControlStyle Width="120px" />
                                    <HeaderStyle CssClass="text-center" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:HyperLinkField ItemStyle-VerticalAlign="Middle" DataNavigateUrlFields="oglasiId" DataNavigateUrlFormatString="~/OglasInfo.aspx?id={0}" NavigateUrl="~/OglasInfo.aspx" Text="Наслов" DataTextField="naslov" DataTextFormatString="{0}" HeaderText="Наслов">
                                    <ControlStyle Font-Bold="True" Width="100px" />
                                    <HeaderStyle CssClass="text-center " HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:HyperLinkField>
                                <asp:ImageField DataImageUrlField="slikaGlavna" HeaderText="Слика">
                                    <ControlStyle CssClass="img-responsive text-center center-block" Height="100px" Width="100px" />
                                    <HeaderStyle CssClass="text-center" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:ImageField>
                                <asp:BoundField DataField="opis" HeaderText="Опис">
                                    <ControlStyle Width="400px" />
                                    <HeaderStyle CssClass="text-center " HorizontalAlign="Center" VerticalAlign="Middle" />                              
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </form>
        </div>
    </div>



</asp:Content>
