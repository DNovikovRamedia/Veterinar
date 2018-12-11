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
using Ideal.Wision.Schema;
using Ideal.Wision;
using Ideal.Wision.Wislets.Model;
using System.Collections.Generic;
using Ideal.Entity;
using System.Globalization;
using System.Threading;

public partial class news_index : UserWintrol
{
    List<NewsTitle> nl = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        Env.CurrentLayout.ContentTitle = "Все новости";

        List<NewsTitle> l = NewsTitle.GetLatestNews(300).Items;
        xpvNews.CountPerPage = 9;
        xpvNews.ShowPageRange = false;
        xpvNews.List = l;


        /*начало Архив новостей*/

        nl = NewsTitle.GetLatestNews(300).Items;

        string year = Request["y"];
        if (null == year) year = DateTime.Now.Year.ToString();

        string month = Request["m"];
        if (null == month) month = DateTime.Now.Month.ToString();

        string day = Request["d"];
        if (null == day) day = DateTime.Now.Day.ToString();

        List<int> ly = GetNewsYears();
        List<List<int>> lm = GetNewsMonths();
        List<List<List<int>>> ld = GetNewsDays();

        List<int> cms = new List<int>();
        List<int> cds = new List<int>();

        bool useGrey;
        if (year == string.Empty)
        {
            useGrey = true;
            for (int i = 1; i < 13; i++) cms.Add(i);
        }
        else
        {
            for (int i = 0; i < ly.Count; i++)
            {
                if (ly[i].ToString() == year)
                {
                    cms = lm[i];
                    for (int ii = 0; ii < cms.Count; ii++)
                    {
                        if (cms[ii].ToString() == month)
                        {
                            cds = ld[i][ii];
                            break;
                        }
                    }
                    break;
                }
            }


            useGrey = false;
        }

        CultureInfo ci = Thread.CurrentThread.CurrentCulture;

        for (int i = 0; i < cms.Count; i++)
        {

            string mname = ci.DateTimeFormat.GetMonthName(cms[i]);

            if (useGrey)
            {
                ltMonths.Text += string.Format("<li style=\"color:#666666;\">{0}</li>", mname);
            }
            else
            {
                if (cms[i].ToString() == month)
                {
                    ltMonths.Text += string.Format("<li style=\"color:#2D4187;\"><b>{0}</b></li>", mname);
                    for (int ii = 0; ii < cds.Count; ii++)
                    {
                        /*DateTime date1 = new DateTime(int.Parse(year), cms[i], cds[i], 0, 0, 0);
                        string dname = ci.DateTimeFormat.GetDayName((DayOfWeek)date1.DayOfWeek);*/

                        if (useGrey)
                        {
                            ltDay.Text += string.Format("<li style=\"color:#666666;\">{0}</li>", cds[ii]);
                        }
                        else
                        {
                            if (cds[ii].ToString() == day)
                            {
                                ltDay.Text += string.Format("<li><b>{0}</b></li>", cds[ii]);
                            }
                            else
                            {
                                ltDay.Text += string.Format("<li><a href=\"index.aspx?y={0}&m={1}&d={2}\">{3}</a></li>", year, cms[i], cds[ii], cds[ii]);
                            }
                        }
                    }
                }
                else
                {
                    ltMonths.Text += string.Format("<li><a href=\"index.aspx?y={1}&m={0}\">{2}</a></li>", cms[i], year, mname);



                }
            }
        }


        for (int i = 0; i < ly.Count; i++)
        {

            if (ly[i].ToString() == year)
            {
                ltYears.Text += string.Format("<li><b>{0}</b></li>", ly[i]);
            }
            else
            {
                ltYears.Text += string.Format("<li><a href=\"index.aspx?y={0}\">{0}</a></li>", ly[i]);
            }
        }

        if (Request["y"] != null && Request["m"] != null && Request["d"] != null)
        {
            int iyear = int.Parse(year);
            int imonth = int.Parse(month);
            int iday = int.Parse(day);

            List<NewsTitle> news = NewsTitle.GetLatestNews(300).Items;

            List<NewsTitle> nnt = new List<NewsTitle>();
            foreach (NewsTitle nt in news)
            {
                if (nt.DateCreated.Year == iyear && nt.DateCreated.Month == imonth && nt.DateCreated.Day == iday)
                {
                    nnt.Add(nt);
                }
            }

            xpvNews.List = nnt;

        }
        else
        {
            xpvNews.List = l;
        }

        /*конец архив новостей*/



    }



    private List<List<int>> GetNewsMonths()
    {
        return (List<List<int>>)Env.Context.Items["ns#m"];
    }
    private List<List<List<int>>> GetNewsDays()
    {
        return (List<List<List<int>>>)Env.Context.Items["ns#d"];
    }

    private List<int> GetNewsYears()
    {
        List<int> lys = (List<int>)Env.Context.Items["ns#y"];

        if (null == lys)
        {
            lys = new List<int>();
            List<List<int>> lym = new List<List<int>>();
            List<List<int>> lyd = new List<List<int>>();
            List<List<List<int>>> lyds = new List<List<List<int>>>();

            List<NewsTitle> news = NewsTitle.GetLatestNews(300).Items;

            int prevyear = -1;
            int prevmonth = -1;
            int prevday = -1;
            int k = 0;

            foreach (NewsTitle nt in news)
            {
                int year = nt.DateCreated.Year;
                int month = nt.DateCreated.Month;
                int day = nt.DateCreated.Day;


                if (year != prevyear)
                {
                    lys.Add(year);
                    lym.Add(new List<int>());
                    prevyear = year;
                    prevmonth = -1;
                }

                if (month != prevmonth)
                {
                    lym[lys.Count - 1].Add(month);
                    lyd.Add(new List<int>());
                    k++;
                    lyds.Add(new List<List<int>>());
                    lyds[lym.Count - 1].Add(lyd[k - 1]);
                    prevmonth = month;
                    prevday = -1;
                }

                if (day != prevday)
                {
                    lyd[k - 1].Add(day);
                    prevday = day;
                }
            }

            Env.Context.Items["ns#y"] = lys;
            Env.Context.Items["ns#m"] = lym;
            Env.Context.Items["ns#d"] = lyds;
        }

        return lys;
    }
}
