using System;
using System.Collections.Generic;
using System.Text;
using Ideal.Wision.Schema.Admin;
using Ideal.Wision.Schema;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Ideal.Wision;
using Veterinar;

[AdminWintrol("{EF488E8B-0C6A-4283-85EE-D46538EE988B}", typeof(VeterinarAdminGroup), "Настройки сайта", "Управление настройками сайта")]
public class Settings : Wintrol
{
    Button btnSave = null;
    TextBox tbTimeSessionBegin = null;
    TextBox tbTimeSessionExpires = null;
    TextBox tbDefaultPasswordPeriod = null;
    TextBox tbAdminEmail = null;

    public Settings()
    {
        this.Init += new EventHandler(Settings_Init);
    }

    void Settings_Init(object sender, EventArgs e)
    {
        this.ID = "Settings";

        btnSave = new Button();
        btnSave.Text = "Сохранить";
        btnSave.Click += new EventHandler(btnSave_Click);

        tbTimeSessionBegin = new TextBox();
        tbTimeSessionBegin.ID = "tbTSB";
        tbTimeSessionBegin.EnableViewState = false;
        tbTimeSessionBegin.Width = Unit.Pixel(30);
        tbTimeSessionBegin.Text = Variables.TimeSessionBegin.ToString();

        tbTimeSessionExpires = new TextBox();
        tbTimeSessionExpires.ID = "tbTSE";
        tbTimeSessionExpires.EnableViewState = false;
        tbTimeSessionExpires.Width = Unit.Pixel(30);
        tbTimeSessionExpires.Text = Variables.TimeSessionExpires.ToString();

        tbDefaultPasswordPeriod = new TextBox();
        tbDefaultPasswordPeriod.ID = "tbDPP";
        tbDefaultPasswordPeriod.EnableViewState = false;
        tbDefaultPasswordPeriod.Width = Unit.Pixel(30);
        tbDefaultPasswordPeriod.Text = Variables.DefaultPasswordPeriod.ToString();

        tbAdminEmail = new TextBox();
        tbAdminEmail.ID = "tbOE";
        tbAdminEmail.EnableViewState = false;
        tbAdminEmail.Width = Unit.Pixel(300);
        tbAdminEmail.Text = Variables.OrderEmail;

        HtmlTable table = new HtmlTable();

        HtmlTableRow row = new HtmlTableRow();
        row.Style.Add(System.Web.UI.HtmlTextWriterStyle.Width, "300px");
        HtmlTableCell cell = new HtmlTableCell();
        cell.InnerText = "Время (в минутах) неактивности пользователя, после которого сессия закрывается :";
        row.Cells.Add(cell);

        cell = new HtmlTableCell();

        RangeValidator rv = new RangeValidator();
        rv.ControlToValidate = tbTimeSessionExpires.ID;
        rv.ErrorMessage = "*";
        rv.Type = ValidationDataType.Integer;
        rv.MinimumValue = "1";
        rv.MaximumValue = int.MaxValue.ToString();
        cell.Controls.Add(tbTimeSessionExpires);
        cell.Controls.Add(rv);
        row.Cells.Add(cell);
        //table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Style.Add(System.Web.UI.HtmlTextWriterStyle.Width, "300px");
        cell = new HtmlTableCell();
        cell.InnerText = "Время (в минутах) после установки сессионного пароля, в течение которого пользователь может начать сессию :";
        row.Cells.Add(cell);

        cell = new HtmlTableCell();
        rv = new RangeValidator();
        rv.ControlToValidate = tbTimeSessionBegin.ID;
        rv.ErrorMessage = "*";
        rv.Type = ValidationDataType.Integer;
        rv.MinimumValue = "1";
        rv.MaximumValue = int.MaxValue.ToString();
        cell.Controls.Add(tbTimeSessionBegin);
        cell.Controls.Add(rv);
        row.Cells.Add(cell);
        //table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Style.Add(System.Web.UI.HtmlTextWriterStyle.Width, "300px");
        cell = new HtmlTableCell();
        cell.InnerText = "Период (кол-во дней), на который выдаётся пароль новым клиентам :";
        row.Cells.Add(cell);

        cell = new HtmlTableCell();
        rv = new RangeValidator();
        rv.ControlToValidate = tbDefaultPasswordPeriod.ID;
        rv.ErrorMessage = "*";
        rv.Type = ValidationDataType.Integer;
        rv.MinimumValue = "1";
        rv.MaximumValue = int.MaxValue.ToString();
        cell.Controls.Add(tbDefaultPasswordPeriod);
        cell.Controls.Add(rv);
        row.Cells.Add(cell);
        //table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Style.Add(System.Web.UI.HtmlTextWriterStyle.Width, "300px");
        cell = new HtmlTableCell();
        cell.InnerText = "Email для приема писем посетителей";
        row.Cells.Add(cell);

        cell = new HtmlTableCell();
        //RegularExpressionValidator rev = new RegularExpressionValidator();
        //rev.ControlToValidate = tbAdminEmail.ID;
        //rev.ErrorMessage = "*";
        //rev.ValidationExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        cell.Controls.Add(tbAdminEmail);
        //cell.Controls.Add(rev);
        row.Cells.Add(cell);
        table.Rows.Add(row);


        this.Controls.Add(table);
        this.Controls.Add(btnSave);
    }

    void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        Variables.TimeSessionBegin = int.Parse(tbTimeSessionBegin.Text);
        Variables.TimeSessionExpires = int.Parse(tbTimeSessionExpires.Text);
        Variables.DefaultPasswordPeriod = int.Parse(tbDefaultPasswordPeriod.Text);
        Variables.OrderEmail = tbAdminEmail.Text.Trim();
        Env.RegisterStartupMessage("settingsWasSaved", "Настройки успешно сохранены.");
    }
}