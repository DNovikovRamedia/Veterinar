using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ideal.Wision.Schema;
using Ideal.Entity;
using Ideal.Wision.Identity;
using Ideal.Wision;
using Ideal.Wision.Controls;
using Ideal.UI.Web;
using System.Collections.Generic;
using Ideal.Wision.Wislets.Model;
using System.IO;

public partial class Main : Layout
{
    void Page_Init(object sender, EventArgs e)
    {
        pnlBannerIndex.Visible = Env.PageIsRoot;

        /*if (Env.PageIsRoot || Env.RawUrl.Contains("/news/") || Env.RawUrl.Contains("/gallery/") || Env.RawUrl.Contains("/photos/") )
        {*/
            tdLeft.Width = "0px";
            phMenu.Visible = false;
        /*}
        else
        {
            tdLeft.Width = "215px";
            phMenu.Visible = true;
        }*/

        /*if (Env.RawUrl.Contains("/docs/"))
        {
            forDocsItem();
            ltLeftMenuForDocsItem.Visible = Env.RawUrl.Contains("/docs/");
        }*/
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CssFile = Env.AppPath + "/css/vet.css?v=1.1";

        this.AddLineToHeader(@"<script src=""https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.js"" type=""text/javascript""></script>");
        Env.CurrentLayout.AddLineToHeader(String.Format(@"
<link href='{0}/favicon.ico' type='image/x-icon' rel='shortcut icon' />", Env.AppPath));
        Env.CurrentLayout.AddLineToHeader(String.Format(@"
<link href='{0}/favicon.ico' type='image/x-icon' rel='icon' />", Env.AppPath));

        /*Версия для слабовидящих*/
        this.AddLineToHeader(@"<script src=""" + Env.AppPath + @"/js/special/uhpv-full.min.js"" type=""text/javascript""></script>");
        this.AddLineToHeader(@"<script src=""" + Env.AppPath + @"/js/special/initial.js"" type=""text/javascript""></script>");
        Env.CurrentLayout.AddLineToHeader(String.Format(@"<link href='{0}/js/special/special.css' type='text/css' rel='stylesheet' />", Env.AppPath));
        /*Версия для сдабовидящих конец*/

        /*if (Env.RawUrl.Contains("/treat/1/index.aspx"))
        {
            this.DefaultContainer.Controls.Add(Page.LoadControl("~/request.ascx"));
        }*/

        List<MenuInfo> menu = GetLeftMenu();

        int i = 1;
        string currentItem = String.Empty;
        ltTopMenu.Text = String.Format(@"<div id='menu'>
                        <table bgcolor='#2d4187' width='100%' height='40' cellpadding='0' cellspacing='0'
        border='0' class='btn'>
                         <tr>
");

        foreach (MenuInfo mi1 in menu)
        {
            string href = (mi1.HasItems) ? mi1.Items[0].Url : mi1.Url;
            string url = (mi1.HasItems) ? " url='" + mi1.Url + "'" : String.Empty;
            ltTopMenu.Text += String.Format(@"<td align='right'><img src='{0}/ii/btn-l.gif' width='26' height='40' /></td>", Env.AppPath);
            ltTopMenu.Text += String.Format(@"<td onclick='javascript:window.location.href=""{2}"";' class='mainMenuItem' width='17%' align='left' valign='middle' id='mi{0}'><a href='{2}'><center>{3}</center></a></td>",
                i, mi1.IsCurrent ? "tdMenuCurr" : "tdMenu",
                href, mi1.Title, url, mi1.Url);
            ltTopMenu.Text += String.Format(@"<td ><img src='{0}/ii/btn-r.gif' width='26' height='40' /></td>", Env.AppPath);

            if (mi1.IsCurrent)
                currentItem = "mi" + i.ToString();

            if (mi1.IsCurrent && mi1.HasItems)
            {
                tdLeft.Width = "215px";
                phMenu.Visible = true;

                int j = 1;
                foreach (MenuInfo mi2 in mi1.Items)
                {
                    ltLeftMenu.Text += string.Format(@"<li id='mi{0}_{1}' class='menu2'><a href='{2}'>{4}{3}{5}</a></li>",
                        i, j, mi2.Url, mi2.Title,
                        mi2.IsCurrent ? "<span style='color:#D70804;'>" : "",
                        mi2.IsCurrent ? "</span>" : "");
                    j++;
                    if (mi2.IsCurrent)
                        currentItem = "mi" + i.ToString();
                }

                //if (mi1.Title.ToLower() == "документы")
                //{
                //    int jj = 1;
                //    foreach (MenuInfo mi2 in mi1.Items)
                //    {
                //        ltLeftMenuForDocsItem.Text += string.Format(@"<li id='mi{0}_{1}' class='menu2'><a href='{2}'>{4}{3}{5}</a></li>",
                //            i, jj, mi2.Url, mi2.Title,
                //            mi2.IsCurrent ? "<span style='color:#D70804;'>" : "",
                //            mi2.IsCurrent ? "</span>" : "");
                //        j++;
                //        if (mi2.IsCurrent)
                //            currentItem = "mi" + i.ToString();
                //    }
                //}
            }

            i++;
        }
        ltTopMenu.Text += String.Format(@"</tr></table>");
    }

    void forDocsItem()
    {
        List<MenuInfo> menu = GetLeftMenu();

        int i = 1;
        string currentItem = String.Empty;

        foreach (MenuInfo mi1 in menu)
        {
            string href = (mi1.HasItems) ? mi1.Items[0].Url : mi1.Url;
            string url = (mi1.HasItems) ? " url='" + mi1.Url + "'" : String.Empty;

            int j = 1;
            if (mi1.Title.ToLower() == "документы")
            {
                int jj = 1;
                foreach (MenuInfo mi2 in mi1.Items)
                {
                    ltLeftMenuForDocsItem.Text += string.Format(@"<li id='mi{0}_{1}' class='menu2'><a href='{2}'>{4}{3}{5}</a></li>",
                        i, jj, mi2.Url, mi2.Title,
                        mi2.IsCurrent ? "<span style='color:#D70804;'>" : "",
                        mi2.IsCurrent ? "</span>" : "");
                    j++;
                }
            }
            i++;
        }
    }

    protected override Container DefaultContainer
    {
        get { return contDefault; }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        if (null != Env.CurrentLayout.ContentTitle)
        {
            if (Env.CurrentLayout.ContentTitle.Length > 0)
            {
                this.Header.Title = "Управления ветеринарии Костромской области: " + Env.CurrentLayout.ContentTitle;
            }
            else
            {
                this.Header.Title = "Официальный сайт Управления ветеринарии Костромской области";
            }
        }

        base.Render(writer);
    }

    List<MenuInfo> GetLeftMenu()
    {
        List<MenuInfo> list = new List<MenuInfo>();
        string vurl = Env.RawPagePath;

        MenuInfo mir = new MenuInfo();
        mir.Title = "Главная";
        mir.Url = Env.AppPath + "/index.aspx";
        mir.Parent = null;
        mir.IsCurrent = vurl.StartsWith(Env.AppPath + "/index.aspx", StringComparison.CurrentCultureIgnoreCase);
        list.Add(mir);

        //mir = new MenuInfo();
        //mir.Title = "Новости";
        //mir.Url = Env.AppPath + "/news/0083b67e-b88f-4248-9eeb-042c554e9566/";
        //mir.Parent = null;
        //mir.IsCurrent = vurl.StartsWith(Env.AppPath + "/news/", StringComparison.CurrentCultureIgnoreCase);
        //list.Add(mir);

        foreach (ISchemaNode node in NodeTree.GetChildren(Env.WisionContext.CurrentPortal.ID))
        {
            Ideal.Wision.Content.ContentSchemaNode cnode = (node as Ideal.Wision.Content.ContentSchemaNode);
            if (null != cnode)
            {
                mir = new MenuInfo();
                mir.Title = cnode.ShortName;
                mir.Url = cnode.Url;
                mir.Parent = null;
                mir.IsCurrent = vurl.StartsWith(cnode.Url, StringComparison.CurrentCultureIgnoreCase);

                /*if (mir.Title.ToLower() == "документы")
                {
                    MenuInfo mir2 = new MenuInfo();
                    mir2.Title = "Нормативные правовые акты";
                    mir2.Url = Env.AppPath + "/doc/acts.aspx";
                    mir2.Parent = null;
                    mir2.IsCurrent = vurl.StartsWith(Env.AppPath + "/doc/acts.aspx", StringComparison.CurrentCultureIgnoreCase);
                    mir.AddItem(mir2);

                    mir2 = new MenuInfo();
                    mir2.Title = "Обсуждение проектов нормативных правовых актов";
                    mir2.Url = Env.AppPath + "/doc/bill.aspx";
                    mir2.Parent = null;
                    mir2.IsCurrent = vurl.StartsWith(Env.AppPath + "/doc/bill.aspx", StringComparison.CurrentCultureIgnoreCase);
                    mir.AddItem(mir2);
                }*/

                foreach (ISchemaNode node2 in NodeTree.GetChildren(node.ID))
                {
                    Ideal.Wision.Content.ContentSchemaNode cnode2 = (node2 as Ideal.Wision.Content.ContentSchemaNode);
                    if (null != cnode2)
                    {
                        MenuInfo mir2 = new MenuInfo();
                        mir2.Title = cnode2.ShortName;
                        mir2.Url = cnode2.Url;
                        mir2.Parent = null;
                        mir2.IsCurrent = vurl.StartsWith(cnode2.Url, StringComparison.CurrentCultureIgnoreCase);
                        mir.AddItem(mir2);
                    }
                }

                list.Add(mir);

            }
        }

        MenuInfo mir0 = new MenuInfo();
        mir0.Title = "Обращения граждан";
        mir0.Url = Env.AppPath + "/contactus.aspx";
        mir0.Parent = null;
        mir0.IsCurrent = vurl.StartsWith(Env.AppPath + "/contactus.aspx", StringComparison.CurrentCultureIgnoreCase);
        list.Add(mir0);

        return list;
    }
}