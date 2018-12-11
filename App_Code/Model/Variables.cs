using System;
using System.Collections.Generic;
using System.Text;
using Ideal.Wision;

public class Variables
{
    static Guid guidTimeSessionExpires = new Guid("{4F14F5FC-5312-4ad9-87E4-840DECDC829B}");
    static int timeSessionExpires = -1;
    public static int TimeSessionExpires
    {
        get
        {
            if (timeSessionExpires < 0)
            {
                Ideal.Wision.Settings.Store.RetrieveInt(guidTimeSessionExpires, Guid.Empty, ref timeSessionExpires);
            }
            return timeSessionExpires;
        }
        set
        {
            if (value > 0)
            {
                timeSessionExpires = value;
                Ideal.Wision.Settings.Store.StoreInt(guidTimeSessionExpires, Guid.Empty, timeSessionExpires);
            }
        }
    }

    static Guid guidTimeSessionBegin = new Guid("{2F5199F4-3D16-4ac7-94A7-51505F4B667E}");
    static int timeSessionBegin = -1;
    public static int TimeSessionBegin
    {
        get
        {
            if (timeSessionBegin < 0)
            {
                Ideal.Wision.Settings.Store.RetrieveInt(guidTimeSessionBegin, Guid.Empty, ref timeSessionBegin);
            }
            return timeSessionBegin;
        }
        set
        {
            if (value > 0)
            {
                timeSessionBegin = value;
                Ideal.Wision.Settings.Store.StoreInt(guidTimeSessionBegin, Guid.Empty, timeSessionBegin);
            }
        }
    }

    static Guid guidDefaultPasswordPeriod = new Guid("{3B5B8CDF-4A91-484f-BA55-686444E8A898}");
    static int defaultPasswordPeriod = -1;
    public static int DefaultPasswordPeriod
    {
        get
        {
            if (defaultPasswordPeriod < 0)
            {
                Ideal.Wision.Settings.Store.RetrieveInt(guidDefaultPasswordPeriod, Guid.Empty, ref defaultPasswordPeriod);
            }
            return defaultPasswordPeriod;
        }
        set
        {
            if (value > 0)
            {
                defaultPasswordPeriod = value;
                Ideal.Wision.Settings.Store.StoreInt(guidDefaultPasswordPeriod, Guid.Empty, defaultPasswordPeriod);
            }
        }
    }


    static Guid guidOrderEmail = new Guid("{39EEDE01-8D63-4e29-B1EF-2F0E0C992FD2}");
    static string orderEmail = string.Empty;
    public static string OrderEmail
    {
        get
        {
            if (orderEmail == string.Empty)
            {
                Ideal.Wision.Settings.Store.RetrieveString(guidOrderEmail, Guid.Empty, ref orderEmail);
            }
            return orderEmail;
        }
        set
        {
            orderEmail = value;
            Ideal.Wision.Settings.Store.StoreString(guidOrderEmail, Guid.Empty, orderEmail);
        }
    }

    public static List<string> OrderEmails
    {
        get
        {
            List<string> list = new List<string>();

            foreach (string s in Variables.OrderEmail.Split(','))
                list.Add(s);

            return list;
        }
    }







}