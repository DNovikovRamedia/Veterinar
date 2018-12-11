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

[RelationBackendName("Items")]
public sealed class Item : Entity<int, Item>
{
    [Member("ID"), UiTitle("Код"), UiLocation(Location.None), PrimaryKey]
    protected int id;
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    [Member, Indexed] // 0 = flat, ...
    public int Kind;

    [Member, Indexed] // 0 = sale; 1 = rent
    public int Sale;

    [Member, Indexed]
    public int CityID;

    [XmlMember]
    public string CityName
    {
        get
        {
            return Schema.Cities[this.CityID].Name;
        }
    }

    [Member, MaximumLength(256)]
    public string Specific = string.Empty;

    [Member]
    public int RoomCount;

    [Member]
    public int Floor;

    [Member]
    public int FloorsTotal;

    [Member, MaximumLength(256)]
    public string Material = string.Empty;

    [Member]
    public double SquareTotal;

    [Member]
    public double SquareLiving;

    [Member]
    public double SquareKitchen;

    [Member]
    public double SquareGround;

    [Member, MaximumLength(256)]
    public string Address = string.Empty;

    [Member, MaximumLength(1024)]
    public string Details = string.Empty;

    [Member]
    public int Price;

    [Member, UiTitle("Дата загрузки"), XmlCustomFormat("{0:d}")]
    public DateTime DateCreated;

    protected override void BeforeInsert()
    {
        this.DateCreated = DateTime.Now;
        base.BeforeInsert();
    }
}