using System;
using System.Collections.Generic;
using System.Text;
using Ideal.Wision.Schema.Admin;
using Ideal.Wision.Schema;
using Ideal.WebTruth.Controls;
using System.Web.UI.WebControls;
//using Aspose.Excel;
using Ideal.UI.Web;
using System.Web.UI.HtmlControls;
using Ideal.Wision;

//namespace Veterinar
//{
//    [AdminWintrol("4968F88C-57F4-4268-8AA1-F3729533A187", typeof(VeterinarAdminGroup), "Загрузка предложений", "Размещение предложений на сайте")]
//    public sealed class ParseXls : Wintrol
//    {
//        Literal lt;
//        HtmlInputFile hif;

//        public ParseXls()
//        {
//            this.Init += new EventHandler(ParseXls_Init);
//        }

//        void ParseXls_Init(object sender, EventArgs e)
//        {
//            this.Controls.Add(Factory.CreateLiteralViewstateless("Укажите файл XLS:"));

//            hif = new HtmlInputFile();
//            hif.ID = "hif";
//            this.Controls.Add(hif);

//            this.Controls.Add(Factory.CreateLiteralViewstatelessNbsp());

//            Button btn = new Button();
//            btn.Text = "Запустить";
//            btn.Click += new EventHandler(btn_Click);
//            this.Controls.Add(btn);

//            lt = new Literal();
//            lt.EnableViewState = false;
//            this.Controls.Add(lt);
//        }

//        void btn_Click(object sender, EventArgs e)
//        {
//            if (null == hif.PostedFile)
//                return;

//            if (string.IsNullOrEmpty(hif.PostedFile.FileName))
//                return;

//            string fileName = Env.Server.MapPath("~/upload.xls");
//            hif.PostedFile.SaveAs(fileName);

//            License licExcel = new Aspose.Excel.License();
//            licExcel.SetLicense((System.IO.Stream)null);
//            Excel file = new Excel();
//            file.Open(fileName);
//            int trows = 0, added = 0, updtd = 0;

//            Worksheet ws = file.Worksheets[0];

//            int crow = 1;
//            while (true)
//            {
//                int id = 0, rooms = 0, floor = 0, floort = 0, price = 0;
//                double squaret = 0, squarel = 0, squarek = 0, squareg = 0;
//                string sid = ws.Cells[crow, 0].StringValue.Trim();
//                if (string.IsNullOrEmpty(sid))
//                    break;

//                int.TryParse(sid, out id);
//                if (id == 0)
//                    break;

//                int.TryParse(ws.Cells[crow, 1].StringValue.Trim(), out rooms);
//                string specific = ws.Cells[crow, 2].StringValue.Trim();
//                string city = ws.Cells[crow, 3].StringValue.Trim();
//                string address = ws.Cells[crow, 4].StringValue.Trim();
//                int.TryParse(ws.Cells[crow, 5].StringValue.Trim(), out floor);
//                string material = ws.Cells[crow, 6].StringValue.Trim();
//                int.TryParse(ws.Cells[crow, 7].StringValue.Trim(), out floort);
//                double.TryParse(ws.Cells[crow, 8].StringValue.Trim().Replace(',', '.').Replace('\xa0', ' ').Replace(" ", "").Trim(),
//                    System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out squaret);
//                double.TryParse(ws.Cells[crow, 9].StringValue.Trim().Replace(',', '.').Replace('\xa0', ' ').Replace(" ", "").Trim(),
//                    System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out squarel);
//                double.TryParse(ws.Cells[crow, 10].StringValue.Trim().Replace(',', '.').Replace('\xa0', ' ').Replace(" ", "").Trim(),
//                    System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out squarek);
//                double.TryParse(ws.Cells[crow, 11].StringValue.Trim().Replace(',', '.').Replace('\xa0', ' ').Replace(" ", "").Trim(),
//                    System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out squareg);
//                string descr = ws.Cells[crow, 12].StringValue.Trim();
//                double dprice = 0;
//                double.TryParse(ws.Cells[crow, 13].StringValue.Trim().Replace(',', '.').Replace('\xa0', ' ').Replace(" ", "").Trim(),
//                    System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out dprice);
//                price = Convert.ToInt32(dprice);

//                Item item = Schema.Items[id];
//                if (null == item)
//                {
//                    item = Schema.Items.CreateNew();
//                    item.ID = id;
//                    added++;
//                }
//                else
//                {
//                    updtd++;
//                }

//                item.Address = address;
//                item.CityID = City.Get(city);
//                item.Details = descr;
//                item.Floor = floor;
//                item.FloorsTotal = floort;
//                item.Kind = 0;
//                item.Material = material;
//                item.Price = price;
//                item.RoomCount = rooms;
//                item.Sale = 0;
//                item.Specific = specific;
//                item.SquareGround = squareg;
//                item.SquareKitchen = squarek;
//                item.SquareLiving = squarel;
//                item.SquareTotal = squaret;
//                item.Update();

//                crow++;
//                trows++;
//            }

//            lt.Text = string.Format("<br/><br/>всего {0:n0} добавлено {1:n0} обновлено {2:n0}", trows, added, updtd);
//        }
//    }
//}