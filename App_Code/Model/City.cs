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
using Ideal.UI;
using Ideal.Core.Xml;
using Ideal.UI.Builders;
using Ideal.Core.Imaging;
using System.Collections.Generic;
using Ideal.Core.Reflection.Validators;
using Ideal.Wision.Identity;
using Ideal.Wision;

[RelationBackendName("Cities"), CacheMode(RelationCacheMode.Super)]
public sealed class City : Entity<int, City>
{
    [Member("ID"), UiTitle("Код"), UiLocation(Location.None), PrimaryKey, AutoIncrement]
    protected int id;
    public int ID
    {
        get { return id; }
    }

    [Member, MaximumLength(256), MinimumStringLength(1), UiLocation(Location.Both), UiTitle("Название файла")]
    public string Name = string.Empty;

    [Member, UiTitle("Дата загрузки"), XmlCustomFormat("{0:d}")]
    public DateTime DateCreated;

    protected override void BeforeInsert()
    {
        this.DateCreated = DateTime.Now;
        base.BeforeInsert();
    }

    internal static int Get(string city)
    {
        string _city = city.Trim();
        foreach (City c in Schema.Cities.Cache.CachedEntities)
        {
            if (c.Name.Equals(_city, StringComparison.CurrentCultureIgnoreCase))
                return c.id;
        }

        City _c = Schema.Cities.CreateNew();
        _c.Name = _city;
        _c.Update();

        return _c.id;
    }
}