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
    public class EXPENSEsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: EXPENSEs
        public ActionResult Index()
        {
            return View(db.EXPENSE.ToList());
        }

        public JsonResult getJson()
        {
            var list = db.EXPENSE.Select(n => new { EXPENSE_ID = n.EXPENSE_ID, EXPENSE_DATE = n.EXPENSE_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult search01(string id)
        {
            if (id == "!!")
            {
                var list2 = db.EXPENSE.Select(n => new { EXPENSE_ID = n.EXPENSE_ID, EXPENSE_DATE = n.EXPENSE_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
                return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);
            }
            string date_low_s = id.Substring(0, 4) + "-01-01";
            string date_high_s = id.Substring(7, 4) + "-12-31";
            var date_low = Convert.ToDateTime(date_low_s);
            var date_high = Convert.ToDateTime(date_high_s);
            var list = db.EXPENSE.Select(n => new { EXPENSE_ID = n.EXPENSE_ID, EXPENSE_DATE = n.EXPENSE_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult advancedSearch(string para01, string para02, string para03, string para04)
        {
            string type = "!!";
            if (para01 == "0")
                type = "进货";
            else if (para01 == "1")
                type = "工资";
            var expense_low = para02;
            var expense_high = para03;
            string date_low_s = "!!";
            string date_high_s = "!!";
            if (para04 != "!!")
            {
                date_low_s = para04.Substring(0, 4) + "-01-01";
                date_high_s = para04.Substring(5, 4) + "-12-31";
            }

            int e_min;
            int.TryParse(expense_low, out e_min);
            int e_max;
            int.TryParse(expense_high, out e_max);

            DateTime date_low = Convert.ToDateTime("2018 - 01 - 01");
            DateTime date_high = Convert.ToDateTime("2018 - 01 - 01");

            if (para04 != "!!")
            {
                date_low = Convert.ToDateTime(date_low_s);
                date_high = Convert.ToDateTime(date_high_s);
            }

            var list = from e in db.EXPENSE select e;
            if (type != "!!")
            {
                list = list.Where(s => s.TYPE == type);
            }
            if (expense_low != "!!")
            {
                list = list.Where(s => s.MONEY > e_min);
            }
            if (expense_high != "!!")
            {
                list = list.Where(s => s.MONEY < e_max);
            }
            if (date_low_s != "!!")
            {
                list = list.Where(s => s.EXPENSE_DATE > date_low);
            }
            if (date_high_s != "!!")
            {
                list = list.Where(s => s.EXPENSE_DATE < date_high);
            }
            var list2 = list.Select(n => new { EXPENSE_ID = n.EXPENSE_ID, EXPENSE_DATE = n.EXPENSE_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }
        public string totExpense(string para01, string para02, string para03)
        {
            var start_date = Convert.ToDateTime(para01);
            var end_date = Convert.ToDateTime(para02);
            var type = para03;
            var list = db.EXPENSE.Select(n => new { EXPENSE_ID = n.EXPENSE_ID, EXPENSE_DATE = n.EXPENSE_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
            if (type != "总和")
            {
                list = db.EXPENSE.Where(n => n.EXPENSE_DATE >= start_date && n.EXPENSE_DATE <= end_date && n.TYPE == para03).Select(n => new { EXPENSE_ID = n.EXPENSE_ID, EXPENSE_DATE = n.EXPENSE_DATE, MONEY = n.MONEY, TYPE = n.TYPE });
            }
            else
            {
                list = db.EXPENSE.Where(n => n.EXPENSE_DATE >= start_date && n.EXPENSE_DATE <= end_date).Select(n => new { EXPENSE_ID = n.EXPENSE_ID, EXPENSE_DATE = n.EXPENSE_DATE, MONEY = n.MONEY, TYPE = n.TYPE });

            }
            var tot = list.Sum(x => x.MONEY);

            return tot.ToString();
        }
    }
}
