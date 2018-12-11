using System;
using System.Collections.Generic;
using System.Text;
using Ideal.Wision.Schema;
using Ideal.Wision.Controls;
using Ideal.Wision;
using Ideal.Wision.Wislets.Model;
using System.Web.UI.WebControls;

namespace Veterinar
{
    public sealed class NewsItem : Wintrol
    {
        XsltView xvNewsItem;

        public NewsItem()
        {
            this.Init += new EventHandler(NewsItem_Init);
        }

        void NewsItem_Init(object sender, EventArgs e)
        {
			NewsTitle ni = NewsTitle.GetByID(new Guid(Env.WisionContext.GetRxKeyValue("niid")));
			Env.CurrentLayout.ContentTitle = ni.Name;
            
            xvNewsItem = new XsltView();
            xvNewsItem.ID = "xvni";
            xvNewsItem.StyleSheetLocation = "~/xsl/newsitem.xsl";
            xvNewsItem.XmlItem = ni;

            Literal nl = new Literal();
            nl.Text = "<div style='padding:7px 0 0 0;clear:both;'><div style='text-align:center;'>";            
            nl.Text += ni.SourceUrl.Replace("&lt;", "<").Replace("&gt;", ">");
            nl.Text += "</div>";

            this.Controls.Add(xvNewsItem);
            this.Controls.Add(nl);
        }
    }
}