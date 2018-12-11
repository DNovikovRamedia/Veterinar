<%@ Control Language="C#" AutoEventWireup="true" CodeFile="index.ascx.cs" Inherits="news_index" %>
<%@ Register Assembly="Ideal.Wision" Namespace="Ideal.Wision.Controls" TagPrefix="iwc" %>

<table width="100%">
    <tr>
        <td  style="width: 90%; vertical-align:top;">
            <iwc:xsltpagedview runat="server" id="xpvNews" stylesheetlocation="~/xsl/news.xsl"></iwc:xsltpagedview>          
        </td>
       <td valign="top">
            <table class="Archive" cellpadding="0" cellspacing="0">
                <tr>
                    <th colspan="3" style="background:#F1F5F7;">
                        Архив новостей
                    </th>
                </tr>
                <tr>
                    <td style="width: 33%">
                       <ul>
                           <asp:Literal ID="ltDay" runat="server" EnableViewState="false" />
                       </ul>
                    </td>
                    <td style="width: 33%">
                        <ul>
                            <asp:Literal ID="ltMonths" runat="server" EnableViewState="false" />
                        </ul>
                    </td>
                    <td style="width: 33%">
                        <ul>
                            <asp:Literal ID="ltYears" runat="server" EnableViewState="false" />
                        </ul>
                    </td>
                </tr>
                <tr>
                 <td colspan="3" align="center">
                  <a href="<%=AppPath %>/news/index.aspx">Весь период</a>
                 </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
