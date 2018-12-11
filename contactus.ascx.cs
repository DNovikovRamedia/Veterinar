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
using Ideal.Core.Net;
using System.IO;
using Ideal.Wision.IO;

public partial class contactus : UserWintrol
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Env.CurrentLayout.ContentTitle = "Обращения граждан";
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (Page.IsValid && cbAgree.Checked)
        {
            /*SmtpPerson person = new SmtpPerson(tbEmail.Text, tbName.Text);
            SmtpPerson Veterinar = new SmtpPerson("info@Veterinar.ru", "Veterinar.ru");*/
            //SmtpPerson Veterinar = new SmtpPerson("Veterinar@mail.ru", "Veterinar.ru");

            string text = string.Format(@"
{5}
<table cellpadding=3 border=1>
<tr><td>ФИО<td>{0}
<tr><td>Адрес проживания<td>{6}
<tr><td>Почтовый индекс<td>{7}
<tr><td>Email<td>{1}
<tr><td>Телефон<td>{2}
<tr><td>Тема<td>{3}
</table>
{4}
", tbName.Text.Trim() + " " + tbLastName.Text.Trim() + " " + tbSurName.Text.Trim(), tbEmail.Text, tbPhone.Text, tbSubject.Text, tbText.Text.Replace("\n", "<br>").Replace("\r", ""), DateTime.Now, tbAddres.Text.Trim(), tbPost.Text.Trim());

            SmtpPerson sp = new SmtpPerson((tbEmail.Text.Trim() != String.Empty) ? tbEmail.Text.Trim() : "unknown@unknown.ru", tbName.Text.Trim() + " " + tbLastName.Text.Trim() + " " + tbSurName.Text.Trim());

            foreach (string email in Variables.OrderEmails)
            {                                
                SmtpPerson sa = new SmtpPerson(email, "Администратор сайта");
                SmtpMessage sm = new SmtpMessage(sp, sa, true);
                sm.Subject = tbSubject.Text;
                sm.Body = text;
                if (fileAttach.PostedFile.FileName.Length > 0)
                {
                    string tempFolder = Environment.GetEnvironmentVariable("TEMP");
                    string filePath = tempFolder + @"\" + Path.GetFileName(fileAttach.PostedFile.FileName);
                    fileAttach.PostedFile.SaveAs(filePath);
                    sm.AddAttachment(new SmtpAttachment(filePath));
                }
                Mail.Send(sm);
            }

            pnlForm.Visible = false;
            pnlThanks.Visible = true;
        }
        else
        {
            Env.RegisterStartupMessage("agree", "Вы должны дать согласие на обработку персональных данных!");
        }
    }
}