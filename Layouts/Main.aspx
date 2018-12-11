<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main"
    ValidateRequest="false" %>

<%@ Register Assembly="Ideal.Wision" Namespace="Ideal.Wision.Controls" TagPrefix="iwc" %>
<%@ Register Assembly="Ideal.Wision" Namespace="Ideal.Wision.Schema" TagPrefix="cc1" %>
<%@ Register Assembly="Ideal.WebTruth" Namespace="Ideal.WebTruth.Controls" TagPrefix="iwwt" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js"> <!--<![endif]-->
<head runat="server">
        <title></title>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="description" content="">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="/css/normalize.css">
        <link rel="stylesheet" href="/css/main.css">
        <link href='http://fonts.googleapis.com/css?family=PT+Sans:400,700,400italic,700italic&subset=latin,cyrillic' rel='stylesheet' type='text/css'>
        <%--<link rel="stylesheet" href="/css/vet.css">--%>
        <script src="/js/vendor/modernizr-2.6.2.min.js"></script>
        <%--<script src="/js/jquery-1.5.1.js"></script>  --%>      
        <script src="/js/plugins.js"></script>
        
        <script src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
        <script src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
        <link rel="stylesheet" href="/js/fancybox/jquery.fancybox-1.3.4.css">
        
        <script src="/js/main.js"></script>
</head>
<body>
<form id="cn12" runat="server">
        <!--[if lt IE 7]>
            <p class="browsehappy">Вы пользуетесь <strong>устаревшим</strong> браузером. Пожалуйста <a href="http://browsehappy.com/">обновите браузер</a>.</p>
        <![endif]-->   
       <div id="wrapper-header"> 
           <div id="header-special">
            <span id="uhvb" style="display:none;">
                <a href="javascript://" onclick="uvcl()"><img src="<%=AppPath %>/ii/special.png" alt="Версия для слабовидящих" /></a>
            </span>
           </div>
       <table bgcolor="#324b8e" background="<%=AppPath %>/ii/topbg.gif" width="100%" height="190"
        cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="212">
                <a href="<%=AppPath %>/index.aspx">
                    <img src="<%=AppPath %>/ii/logo.jpg" width="212" height="186" alt="Управление ветеринарии Костромской области" /></a></td>
            <td width="100%" align="left" valign="middle" style="background-image: url(<%=AppPath %>/ii/photo.jpg);
                background-position: right; background-repeat: no-repeat;">
                <div id="logo-text">                
                 <a href="<%=AppPath %>/index.aspx">
                    <img src="<%=AppPath %>/ii/logo-text.png" width="376" height="71" alt="Управление ветеринарии Костромской области" />
                 </a>
                <div id="date">
                    <%=DateTime.Now.ToString("dddd, dd MMMM, H:mm") %>
                </div>
                <div id="head-logo">
                  <a href="<%=AppPath %>/index.aspx">
                    <img src="<%=AppPath %>/ii/head_logo_new.png" alt="Управление ветеринарии Костромской области" /></a>
                </div>                
                </div>
            </td>
        </tr>
    </table>
    </div>
    
    <asp:Literal ID="ltTopMenu" runat="server" EnableViewState="false"></asp:Literal>
    
<%--    <table bgcolor="#2d4187" width="100%" height="40" cellpadding="0" cellspacing="0"
        border="0" class="btn">
        <tr>
            <td>
                <img src="<%=AppPath %>/ii/btn-l0.gif" width="26" height="40" /></td>
            <td class="mainMenuItem" width="17%" align="left" valign="middle" onmouseover="menuMouseOver('menu_div_1');"
                onmouseout="menuMouseOut(event, 'menu_div_1');">
                <center>
                    Главная</center>
                <div id="menu_div_1" class="menuContainer" style="display: none">
                    пункт1<br />
                    пункт2
                </div>
            </td>
            <td>
                <img src="<%=AppPath %>/ii/btn-r.gif" width="26" height="40" /></td>
            <td>
                <img src="<%=AppPath %>/ii/btn-l.gif" width="26" height="40" /></td>
            <td class="mainMenuItem" background="<%=AppPath %>/ii/btn-bg.gif" width="17%" align="left"
                valign="middle" onmouseover="menuMouseOver('menu_div_2');" onmouseout="menuMouseOut(event, 'menu_div_2');">
                <center>
                    <a href="<%=AppPath %>/dep/index.aspx">Департамент</a></center>
                <div id="menu_div_2" class="menuContainer" style="display: none">
                    Пункт меню</div>
            </td>
            <td>
                <img src="<%=AppPath %>/ii/btn-r.gif" width="26" height="40" /></td>
            <td>
                <img src="<%=AppPath %>/ii/btn-l.gif" width="26" height="40" /></td>
            <td class="mainMenuItem" background="<%=AppPath %>/ii/btn-bg.gif" width="17%" align="left"
                valign="middle" onmouseover="menuMouseOver('menu_div_3');" onmouseout="menuMouseOut(event, 'menu_div_3');">
                <center>
                    Документы</center>
                <div id="menu_div_3" class="menuContainer" style="display: none">
                    Пункт меню
                </div>
            </td>
            <td>
                <img src="<%=AppPath %>/ii/btn-r.gif" width="26" height="40" /></td>
            <td>
                <img src="<%=AppPath %>/ii/btn-l.gif" width="26" height="40" /></td>
            <td class="mainMenuItem" background="<%=AppPath %>/ii/btn-bg.gif" width="17%" align="left"
                valign="middle">
                <center>
                    Обращения</center>
            </td>
            <td>
                <img src="<%=AppPath %>/ii/btn-r.gif" width="26" height="40" /></td>
                <td>
                <img src="<%=AppPath %>/ii/btn-l.gif" width="26" height="40" /></td>
            <td class="mainMenuItem" background="<%=AppPath %>/ii/btn-bg.gif" width="17%" align="left"
                valign="middle">
                <center>
                   Контакты</center>
            </td>
            <td>
                <img src="<%=AppPath %>/ii/btn-r.gif" width="26" height="40" /></td>
            <td>
                <img src="<%=AppPath %>/ii/btn-l.gif" width="26" height="40" /></td>
            <td class="mainMenuItem" background="<%=AppPath %>/ii/btn-bg.gif" width="17%" align="left"
                valign="middle" onmouseover="menuMouseOver('menu_div_4');" onmouseout="menuMouseOut(event, 'menu_div_4');">
                <center>
                    Отраслевая информация</center>
                <div id="menu_div_4" class="menuContainer" style="display: none">
                    Пункт меню
                </div>
            </td>
            <td>
                <img src="<%=AppPath %>/ii/btn-r0.gif" width="26" height="40" /></td>
        </tr>
    </table>--%>
    
    <table cellpadding="0" cellspacing="0" border="0" width="100%" id="wrapper-content">
        <tr id="tr-first-wrapper-content">
            <td style="background-color: #eaebfa">
                <input style="width: 200px; border: solid 1px #707db0;" id="query" />
            </td>
            <td style="background-color: #eaebfa; white-space: nowrap; width: 300px">
                <input type="button" value="найти" style="width: 100px; border: solid 1px #707db0;
                    background-color: #345092;" onclick="javascript:window.location.href=document.getElementById('srcSite').checked ? '<%=AppPath%>/search.aspx?q=' + escape(document.getElementById('query').value) : '<%=AppPath%>/searchweb.aspx?q=' + escape(document.getElementById('query').value); return false;" />
                <input type="radio" id="srcSite" checked="checked" name="srcWhere" value="1" />&nbsp;<label
                    for="srcWhere1">на сайте</label>
                <input type="radio" id="srcWeb" name="srcWhere" value="2" />&nbsp;<label for="srcWhere2">в
                    интернете</label>
            </td>
            <td style="background-color: White; width: 63%">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="top" runat="server" id="tdLeft" runat="server">
                        <div style="height:5px; width:100%; background-color:White;"></div>
                            <asp:PlaceHolder ID="phMenu" runat="server" EnableViewState="false">
                            <ul id="left-menu">
                            <asp:Literal ID="ltLeftMenu" runat="server" EnableViewState="false"></asp:Literal>
                            <asp:Literal ID="ltLeftMenuForDocsItem" runat="server" EnableViewState="false" Visible="false"></asp:Literal>
                            </ul>                                                                    
                                <%--<div style="text-align: right;" id="layoutBannersContainer">
                                    <iwc:contentbox id="cbBanners" code="Banners" runat="server" />
                                </div> --%>                               
                            </asp:PlaceHolder>
                        </td>
                        <td style="width: 100%" valign="top">
                            <div id="content-wrapper">
                                <div id="nav">
                                    <iwc:navigator id="navMain" runat="server" rootname="Главная" partdivider="&nbsp;&gt;&nbsp;" />
                                </div>
                                <iwc:contenttitle visible="true" id="ContTitle" runat="server" titleformat="<h1>{0}</h1>" />
                                <cc1:container id="contDefault" runat="server" hideparentlevel="0" />
                                <asp:Literal ID="ltDateUpdated" runat="server" EnableViewState="false"></asp:Literal>
                            </div>
                            <div style="float: right;">
                                <a href="javascript:void(0);" onclick="printMode();">Версия для печати</a>

                                <script type="text/javascript">
                                function printMode()
                                {
                                    var content = $("content").innerHTML;
                                    var print = window.open("", "");
                                    print.document.write("<link rel='stylesheet' type='text/css' href='<%=AppPath %>/css/apk.css' />");
                                    print.document.write(content);
                                }
                                </script>

                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        
<%--            <td valign="top" align="center" style="padding-right: 10px;" runat="server" id="tdRight">
                <asp:Literal ID="ltInfoMenu" runat="server" EnableViewState="false"></asp:Literal>
            </td>--%>
        </tr>
    </table>
    
    <div id="sup-footer">   
        <asp:Panel ID="pnlBannerIndex" runat="server" Visible="false">
            <iwc:contentbox id="cbLayoutsBox" code="LayoutsBox" runat="server" />
        </asp:Panel>     
    </div>
    
    <div id="footer">
        <div id="foo-leftcol">
            &copy; Управление ветеринарии Костромской области <br />
             Все права защищены, 2014 год<br />
             При копировании информации, ссылка на сайт<br />            
            <a href="http://ramedia.ru">Разработка сайта</a>: компания &laquo;<a href="http://ramedia.ru">Рамедиа</a>&raquo;
        </div>        
        <div id="foo-rightcol">
           Российская Федерация, Костромская область, г. Кострома<br />
           156013, г.Кострома, ул.Галичская 98<br />
           тел./факс (4942) 55-33-03, E-mail: <a href="mailto:vet@adm44.ru ">vet@adm44.ru </a>
        </div>        
    </div>
</form>
    <iwwt:webtruthcollector runat="server" id="iwwtStats" />
</body>
</html>