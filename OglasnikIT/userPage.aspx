<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="userPage.aspx.cs" Inherits="OglasnikIT.userPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div class=" container">
        <form runat="server" class="">
            <div class="row center-block text-center">
                <asp:Label ID="lblNemaOglasi" Visible="false" runat="server" Text="Немате внесено ваши огласи!"></asp:Label>
            </div>
            <asp:GridView Width="95%" CssClass=" table table-hover table-striped" GridLines="None" ID="gvOglasi1" runat="server" AutoGenerateColumns="False" DataKeyNames="oglasiId" AllowSorting="False" OnRowDataBound="gvOglasi1_RowDataBound">
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
            <div class="row center-block text-center">
                <asp:Label ID="lblNemaOdobreniOglasi" Visible="false" runat="server" Text="Не постојат одобрени огласи!"></asp:Label>
            </div>
            <asp:GridView Width="95%" CssClass=" text-center center-block table table-hover table-striped" Visible="false" GridLines="None" ID="gvAdminOdobri" runat="server" AutoGenerateColumns="False" DataKeyNames="oglasiId" AllowSorting="False" Caption="Одобрени огласи" OnRowDataBound="gvAdminOdobri_RowDataBound">
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
        </form>
    </div>
</asp:Content>
