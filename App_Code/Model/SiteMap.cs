using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Ideal.Wision.Schema;
using Ideal.Wision;
using Ideal.Core.Xml;
using Ideal.Entity;
using Ideal.Core;
using System.Xml;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for SiteMap
/// </summary>
public class SiteMap
{
    static string vurl = string.Empty;

    public static MenuInfo GetSiteMap()
    {
        MenuInfo mis = new MenuInfo();
        vurl = Env.AppPath;
        mis.isRoot = true;
        GetChildNodes(ref mis, Env.WisionContext.CurrentPortal.ID, Env.AppPath);
        AddSpecNodes(ref mis);

        return mis;
    }

    private static void AddSpecNodes(ref MenuInfo mis)
    {
        foreach (KeyValuePair<string, string> page in DefineSpecPages())
        {
            MenuInfo mi = new MenuInfo();
            mi.Parent = mis;
            mi.Title = page.Value;
            mi.Url = page.Key;
            mi.IsCurrent = vurl.StartsWith(page.Key, StringComparison.CurrentCultureIgnoreCase);
            mis.AddItem(mi);
        }
    }

    private static Dictionary<string, string> DefineSpecPages()
    {
        Dictionary<string, string> sp = new Dictionary<string, string>();
        //sp.Add(string.Format("{0}/feedback.aspx", Env.AppPath), "Обратная связь");

        return sp;
    }

    private static void GetChildNodes(ref MenuInfo mis, Guid guid, string baseUrl)
    {
        MenuInfo mir = null;

        if (NodeTree.GetNode(guid) != null && NodeTree.GetNode(guid).Parent == null)
        {
            mir = new MenuInfo();
            mir.Title = "Главная";
            mir.Url = Env.AppPath + "/index.aspx";
            mir.Parent = mis;
            mir.IsCurrent = vurl.StartsWith(Env.AppPath + "/index.aspx", StringComparison.CurrentCultureIgnoreCase);
            mis.Items.Add(mir);

            mir = new MenuInfo();
            mir.Title = "Новости";
            mir.Url = Env.AppPath + "/news/";
            mir.Parent = mis;
            mir.IsCurrent = vurl.StartsWith(Env.AppPath + "/news/", StringComparison.CurrentCultureIgnoreCase);
            mis.Items.Add(mir);
        }

        foreach (ISchemaNode node in NodeTree.GetChildren(guid))
        {


            Ideal.Wision.Content.ContentSchemaNode cnode = (node as Ideal.Wision.Content.ContentSchemaNode);
            if (null != cnode)
            {
                Ideal.Wision.Dal.Content.ContentNode contentNode = cnode.ContentNode;
                string url = baseUrl + "/" + contentNode.UrlCompareWith;

                if (contentNode.UrlCompareWith.IndexOf(".aspx", StringComparison.CurrentCultureIgnoreCase) == -1)
                    url += "/";
                //MenuInfo mir = null;

                if ((!cnode.ShortName.Equals("департамент", StringComparison.CurrentCultureIgnoreCase)) && ((!cnode.ShortName.Equals("отчёты департамента", StringComparison.CurrentCultureIgnoreCase))) && ((!cnode.ShortName.Equals("контакты", StringComparison.CurrentCultureIgnoreCase))) && ((!cnode.ShortName.Equals("документы", StringComparison.CurrentCultureIgnoreCase))))
                {
                    mir = new MenuInfo();
                    mir.Title = cnode.ShortName;
                    mir.Url = url;
                    mir.Parent = mis;
                    mir.IsCurrent = vurl.StartsWith(url, StringComparison.CurrentCultureIgnoreCase);
                    mis.Items.Add(mir);

                    GetChildNodes(ref mir, node.ID, baseUrl + "/" + contentNode.UrlCompareWith);
                }
            }
        }
    }
}
public class MenuInfo
{
    [XmlMember]
    public string Title;

    [XmlMember]
    public string Url;

    [XmlMember]
    public bool isRoot = false;

    [XmlMember]
    public bool HasItems
    {
        get
        {
            if (null == Items)
                return false;

            return Items.Count > 0;
        }
    }

    public MenuInfo Parent;

    [XmlMember]
    public bool IsCurrent = false;

    [XmlMember]
    public XmlMemberList<MenuInfo> XmlItems;

    public List<MenuInfo> Items;

    public void AddItem(MenuInfo item)
    {
        if (null == Items)
            Items = new List<MenuInfo>();

        Items.Add(item);
    }

    public static MenuInfo GetCurrent(MenuInfo menu)
    {
        MenuInfo result = null;

        GetCurrentMenuItem(menu, ref result);

        return result;
    }

    private static void GetCurrentMenuItem(MenuInfo menu, ref MenuInfo res)
    {
        //MenuInfo mi = new MenuInfo();
        foreach (MenuInfo m in menu.Items)
        {
            if (m.IsCurrent)
            {
                res = m;
                GetCurrentMenuItem(m, ref res);
                break;
            }
        }
    }

    public MenuInfo()
    {
        this.Parent = null;
        this.Items = new List<MenuInfo>();

        XmlItems = new XmlMemberList<MenuInfo>(Items);
    }

}

public class XmlMemberList<T> : IXmlProducer, IEnumerable<T>
{
    public XmlMemberList(List<T> list)
    {
        items = list;
    }

    List<T> items;
    public List<T> Items
    {
        get { return items; }
        set { items = value; }
    }

    #region IXmlProducer Members

    public void ProduceXml(Ideal.Core.Xml.XmlBuilder currentBuilder, XmlProperty property, List<object> options)
    {
        List<MenuInfo> miList = items as List<MenuInfo>;
        if (miList != null)
        {
            if (miList.Count > 0)
            {
                BuildXmlMenuNode(currentBuilder, miList);
            }

        }
    }

    private static void BuildXmlMenuNode(Ideal.Core.Xml.XmlBuilder currentBuilder, List<MenuInfo> miList)
    {
        foreach (MenuInfo mi in miList)
        {
            currentBuilder.ProduceNestedElement("MenuInfo");

            currentBuilder.ProduceAttribute("IsCurrent", mi.IsCurrent.ToString());
            currentBuilder.ProduceAttribute("isRoot", mi.isRoot.ToString());

            BuildXmlMenuNode(currentBuilder, mi.Items);

            currentBuilder.ProduceAttribute("Title", mi.Title);
            currentBuilder.ProduceAttribute("Url", mi.Url);

            currentBuilder.NestedElementComplete();
        }
    }

    #endregion

    #region IEnumerable<T> Members

    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return items.GetEnumerator();
    }

    #endregion
}
