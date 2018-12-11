<%@ Control Language="C#" AutoEventWireup="true" CodeFile="contactus.ascx.cs" Inherits="contactus" %>
<asp:panel ID=pnlForm runat=server DefaultButton=btnSend CssClass="feedback">
    <table cellpadding="3" cellspacing="0" border="0">
        <tr>
            <td>
                �������:</td>
            <td>
                <asp:TextBox ID="tbName" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="rfvName" runat="server" ErrorMessage="������� �������"
                    ControlToValidate="tbName"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                ���:</td>
            <td>
                <asp:TextBox ID="tbLastName" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="������� ���" ControlToValidate="tbLastName"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                ��������:</td>
            <td align="left">
                <asp:TextBox ID="tbSurName" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="������� ��������" ControlToValidate="tbSurName"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                ����� ����������:</td>
            <td>
                <asp:TextBox ID="tbAddres" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="������� ����� ����������" ControlToValidate="tbAddres"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                �������� ������:</td>
            <td>
                <asp:TextBox ID="tbPost" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator5" runat="server"
                    ErrorMessage="������� �������� ������" ControlToValidate="tbPost"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                ��� Email:</td>
            <td>
                <asp:TextBox ID="tbEmail" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td align="left">
                <asp:RequiredFieldValidator ForeColor="Red" ID="rfvEmail" runat="server" ErrorMessage="������� Email"
                    ControlToValidate="tbEmail"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td width="250px">
                ��� �������:</td>
            <td align="left" width="250px">
                <asp:TextBox ID="tbPhone" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="������� �������" ControlToValidate="tbPhone"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                ���� ���������:&nbsp;</td>
            <td>
                <asp:TextBox ID="tbSubject" runat="server" BorderWidth="1px" Columns="30" Width="250px"></asp:TextBox></td>
            <td>
            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator6" runat="server"
                    ErrorMessage="������� ����" ControlToValidate="tbSubject"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                ����� ���������:<br />
                <br />
                <asp:TextBox ID="tbText" runat="server" BorderWidth="1px" Columns="60" Rows="8" TextMode="MultiLine"
                    Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <br />
                ��������� ����:</td>
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
                    ��������� ��� ���� �������� �� ���������, ����� ����������� ������� �������� ����
                    ������������ ������, ��������� � ��������� ������ � ���������� ���� �����. ����
                    ��������� ����� ����������� � ������������ � ������ ���������� ������������ ������
                    �� 2 ��� 2006 ���� � 59-�� �� ������� ������������ ��������� ������� ����������
                    ���������.
                </div>
                <br />
                <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="��������� ������"
                    CssClass="send" /></td>
        </tr>
    </table>
</asp:panel>
<asp:panel ID=pnlThanks runat=server Visible=false>
����� �������� ���� ����������.
<p>�� ����������� �������� � ��������� �����</p>
</asp:panel>