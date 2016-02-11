<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="vnesiOglas.aspx.cs" Inherits="OglasnikIT.vnesiOglas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <form runat="server" class="">

        <div class="form-group">
            <label>Наслов</label>
      
            <asp:TextBox ID="txtNaslov" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNaslov" ErrorMessage="Внесете наслов" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <label>Опис</label>
            <asp:TextBox ID="txtOpis" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOpis" ErrorMessage="Внесете Опис" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Град</label>
            <asp:DropDownList CssClass="form-control" ID="ddlGrad" runat="server">
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
        <div class="form-group">
            <label>Категорија</label>
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
        <div class="form-group">
            <label>Телефон</label>
            <asp:TextBox ID="txtTelefon" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTelefon" ErrorMessage="Внесете телефон" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Цена</label>
            <asp:TextBox ID="txtCena" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCena" ErrorMessage="Внесете Цена" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCena" ErrorMessage="Внесете број" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label>Валута</label>
            <asp:RadioButtonList ID="rblValuta" runat="server" RepeatLayout="flow" RepeatDirection="Horizontal" CssClass="btn-group" data-toggle="buttons">
                <asp:ListItem class="btn btn-default btn-xs active" Value="Денари" Selected="True">Денари</asp:ListItem>
                <asp:ListItem class="btn btn-default btn-xs" Value="Евра">Евра</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="form-group">
            <label>Слика(задолжителна)</label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
           
        </div>
        <div class="form-group">
            <label>Слика(опциона)</label>
            <asp:FileUpload ID="FileUpload2" runat="server" />
        </div>
         <div class="form-group">
            <label>Слика(опциона)</label>
            <asp:FileUpload ID="FileUpload3" runat="server" />
        </div>
         <div class="form-group">
            <label>Слика(опциона)</label>
            <asp:FileUpload ID="FileUpload4" runat="server" />
        </div>
        <asp:Button ID="btnVnesiOglas" runat="server" CssClass="btn btn-default" Text="Внеси оглас" OnClick="btnVnesiOglas_Click" />
        &nbsp &nbsp  &nbsp &nbsp  &nbsp &nbsp  &nbsp &nbsp
        <asp:Button ID="btnOtkaziOglas" runat="server" CssClass="btn btn-default" CausesValidation="False" Text="Откажи" />
    </form>
    </br>
    </br>
</asp:Content>
