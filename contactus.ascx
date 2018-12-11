<%@ Control Language="C#" AutoEventWireup="true" CodeFile="contactus.ascx.cs" Inherits="contactus" %>
<asp:panel ID=pnlForm runat=server DefaultButton=btnSend CssClass="feedback">
    <table cellpadding="3" cellspacing="0" border="0">
        <tr>
            <td>
                Фамилия:</td>
            <td>
                <asp:TextBox ID="tbName" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="rfvName" runat="server" ErrorMessage="Укажите фамилия"
                    ControlToValidate="tbName"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Имя:</td>
            <td>
                <asp:TextBox ID="tbLastName" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Укажите имя" ControlToValidate="tbLastName"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Отчество:</td>
            <td align="left">
                <asp:TextBox ID="tbSurName" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Укажите отчество" ControlToValidate="tbSurName"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Адрес проживания:</td>
            <td>
                <asp:TextBox ID="tbAddres" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="Укажите адрес проживания" ControlToValidate="tbAddres"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Почтовый индекс:</td>
            <td>
                <asp:TextBox ID="tbPost" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator5" runat="server"
                    ErrorMessage="Укажите почтовый индекс" ControlToValidate="tbPost"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Ваш Email:</td>
            <td>
                <asp:TextBox ID="tbEmail" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="rfvEmail" runat="server" ErrorMessage="Укажите Email"
                    ControlToValidate="tbEmail"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td width="250px">
                Ваш телефон:</td>
            <td align="left" width="250px">
                <asp:TextBox ID="tbPhone" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="Укажите телефон" ControlToValidate="tbPhone"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Тема обращения:&nbsp;</td>
            <td>
                <asp:TextBox ID="tbSubject" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td>
            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator6" runat="server"
                    ErrorMessage="Укажите тему" ControlToValidate="tbSubject"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                Текст сообщения:<br />
                <br />
                <asp:TextBox ID="tbText" runat="server" BorderWidth="1px" Columns="60" Rows="8" TextMode="MultiLine"
                    Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <br />
                Приложить файл:</td>
            <td>
                <br />
                <input id="fileAttach" style="width: 250px" type="file" runat="server" /></td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <div style="text-align: justify; margin: 10px 0 0 0;">
                    <asp:CheckBox ID="cbAgree" runat="server" />
                    Настоящим даю свое согласие на обработку, любым допускаемым законом способом моих
                    персональных данных, указанных в настоящей анкете и сообщенных мною устно. Ваше
                    обращение будет рассмотрено в соответствии с учетом требований Федерального закона
                    от 2 мая 2006 года № 59-ФЗ «О порядке рассмотрения обращений граждан Российской
                    Федерации».
                </div>
                <br />
                <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Отправить запрос"
                    CssClass="send" /></td>
        </tr>
    </table>
</asp:panel>
<asp:panel ID=pnlThanks runat=server Visible=false>
Форма контакта была отправлена.
<p>Мы постараемся ответить в ближайшее время</p>
</asp:panel>