using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test1.Models;

namespace test1.Controllers
{
    public class SALES_REPORTController : Controller
    {
        private MySuperMarket1 db = new MySuperMarket1();

        // GET: SALES_REPORT
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getJson()
        {
            var list = db.SALES_REPORT.Select(n => new { PRODUCT_ID = n.PRODUCT_ID, n.PRODUCT_NAME, TOT_MONEY = n.TOT_MONEY, TOT_NUM = n.TOT_NUM, SALE_MONTH = n.SALE_MONTH });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
    }
}
