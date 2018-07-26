using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySuperMarket.Models;

namespace MySuperMarket.Controllers
{
    public class INCOMEsController : Controller
    {
        private MyMarket db = new MyMarket();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getJson()
        {
            var list = db.INCOME.Select(n => new { INCOME_ID = n.INCOME_ID, INCOME_DATE = n.INCOME_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult search01(string id)
        {
            if (id == "!!")
            {
                var list2 = db.INCOME.Select(n => new { INCOME_ID = n.INCOME_ID, INCOME_DATE = n.INCOME_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
                return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);
            }
            string date_low_s = id.Substring(0, 4) + "-01-01";
            string date_high_s = id.Substring(7, 4) + "-12-31";
            var date_low = Convert.ToDateTime(date_low_s);
            var date_high = Convert.ToDateTime(date_high_s);
            var list = db.INCOME.Where(n => n.INCOME_DATE >= date_low && n.INCOME_DATE <= date_high).Select(n => new { INCOME_ID = n.INCOME_ID, INCOME_DATE = n.INCOME_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult advancedSearch(string para01, string para02, string para03, string para04)
        {
            string type = "!!";
            if (para01 == "0")
                type = "销售";
            else if (para01 == "1")
                type = "赞助";
            var income_low = para02;
            var income_high = para03;
            string date_low_s = "!!";
            string date_high_s = "!!";
            if (para04 != "!!")
            {
                date_low_s = para04.Substring(0, 4) + "-01-01";
                date_high_s = para04.Substring(5, 4) + "-12-31";
            }

            int i_min;
            int.TryParse(income_low, out i_min);
            int i_max;
            int.TryParse(income_high, out i_max);

            DateTime date_low = Convert.ToDateTime("2018 - 01 - 01");
            DateTime date_high = Convert.ToDateTime("2018 - 01 - 01");

            if (para04 != "!!")
            {
                date_low = Convert.ToDateTime(date_low_s);
                date_high = Convert.ToDateTime(date_high_s);
            }


            var list = from e in db.INCOME select e;
            if (type != "!!")
            {
                list = list.Where(s => s.TYPE == type);
            }
            if (income_low != "!!")
            {
                list = list.Where(s => s.MONEY > i_min);
            }
            if (income_high != "!!")
            {
                list = list.Where(s => s.MONEY < i_max);
            }
            if (date_low_s != "!!")
            {
                list = list.Where(s => s.INCOME_DATE > date_low);
            }
            if (date_high_s != "!!")
            {
                list = list.Where(s => s.INCOME_DATE < date_high);
            }
            var list2 = list.Select(n => new { INCOME_ID = n.INCOME_ID, INCOME_DATE = n.INCOME_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }
        public string totIncome(string para01, string para02, string para03)
        {
            var start_date = Convert.ToDateTime(para01);
            var end_date = Convert.ToDateTime(para02);
            var type = para03;
            var list = db.INCOME.Select(n => new { INCOME_ID = n.INCOME_ID, INCOME_DATE = n.INCOME_DATE, MONEY = n.MONEY, TYPE = n.TYPE }); ;
            if (type != "总和")
            {
                list = db.INCOME.Where(n => n.INCOME_DATE >= start_date && n.INCOME_DATE <= end_date && n.TYPE == para03).Select(n => new { INCOME_ID = n.INCOME_ID, INCOME_DATE = n.INCOME_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
            }
            else
            {
                list = db.INCOME.Where(n => n.INCOME_DATE >= start_date && n.INCOME_DATE <= end_date).Select(n => new { INCOME_ID = n.INCOME_ID, INCOME_DATE = n.INCOME_DATE, MONEY = n.MONEY, TYPE = n.TYPE });

            }
            var tot = list.Sum(x => x.MONEY);
            return tot.ToString();
        }
    }
}
