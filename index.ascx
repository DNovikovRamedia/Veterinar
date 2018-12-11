<%@ Control Language="C#" AutoEventWireup="true" CodeFile="index.ascx.cs" Inherits="index" %>
<%@ Register Assembly="Ideal.Wision" Namespace="Ideal.Wision.Controls" TagPrefix="iwc" %>

<h1>Новости</h1>
<div style="width:100%;">
<iwc:xsltlistview runat="server" id="xlvNews" stylesheetlocation="~/xsl/news.xsl"/> 
</div>
<div style="clear:both;"></div>
<div style="color: #32649e;font-size: 15pt;font-weight: bold;text-align: center;width: 100%;">
 <a href="<%=AppPath %>/news/index.aspx">Все новости...</a>
</div>
<div style="clear:both;"></div>
<div style="width:100%;">
<iwc:contentbox id="cbIndex" runat="server" code="Index" />
</div>