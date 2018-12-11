using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ideal.Entity;
using System.Collections.Generic;
using Ideal.Wision.Core;

[RelationBackendNamePrefix("inv")]
public sealed class Schema : RelationalSchema
{
    Relation<int, City> cities;
    public static Relation<int, City> Cities
    {
        get { return Instance.cities; }
    }

    Relation<int, Item> items;
    public static Relation<int, Item> Items
    {
        get { return Instance.items; }
    }
    
    static Schema instance = null;
    static Schema Instance
    {
        get
        {
            if (null == instance)
                instance = new Schema(WisionApplication.DefaultBackendAdapter);
            return instance;
        }
    }

    public Schema(Adapter adapter)
        : base(adapter)
    { }

    public override List<EntityProperties> CreateRelations()
    {
        cities = new Relation<int, City>(adapter, this);
        items = new Relation<int, Item>(adapter, this);
        
        List<EntityProperties> lp;

        lp = new List<EntityProperties>();
        lp.Add(cities.EntityProperties);
        lp.Add(items.EntityProperties);
               
        return lp;
    }
}