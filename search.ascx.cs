using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ideal.Wision;
using Ideal.Wision.Controls;
using Ideal.Wision.Schema;

public partial class search : UserWintrol
{

    void Page_Init()
    {
        Env.CurrentLayout.ContentTitle = "Поиск по сайту";

        SiteSearch ss = new SiteSearch();
        ss.ID = "ss";
        this.Controls.Add(ss);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
