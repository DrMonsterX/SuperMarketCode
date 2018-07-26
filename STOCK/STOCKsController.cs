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
    public class STOCKsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: STOCKs
        public ActionResult Index()
        {
            var sTOCK = db.STOCK.Include(s => s.EXPENSE).Include(s => s.PLAN).Include(s => s.PRODUCT);
            return View();
        }

        public JsonResult getJson()
        {
            var list = db.STOCK.Include(n => n.EXPENSE).Include(n => n.PLAN).Include(n => n.PRODUCT).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult search01(string para01, string para02)
        {

            string search_type = "";
            if (para01 != null)
            {
                search_type = para01;
            }
            else
            {
                var list = db.STOCK.Include(n => n.EXPENSE).Include(n => n.PLAN).Include(n => n.PRODUCT).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.STOCK.Include(n => n.EXPENSE).Include(n => n.PLAN).Include(n => n.PRODUCT).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.STOCK.Include(s => s.EXPENSE).Include(s => s.PLAN).Where(n => n.STOCK_ID == value).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.STOCK.Include(s => s.EXPENSE).Include(s => s.PLAN).Where(n => n.BATCH_ID == value).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                var list = db.STOCK.Include(s => s.EXPENSE).Include(s => s.PLAN).Where(n => n.PRODUCT.PRODUCT_ID == value).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("3"))
            {
                var list = db.STOCK.Include(s => s.EXPENSE).Include(s => s.PLAN).Where(n => n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME == value).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("4"))
            {
                var list = db.STOCK.Include(s => s.EXPENSE).Include(s => s.PLAN).Where(n => n.PLAN_ID == value).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("5"))
            {
                var list = db.STOCK.Include(s => s.EXPENSE).Include(s => s.PLAN).Where(n => n.EXPENSE_ID == value).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("6"))
            {
                int num;
                int.TryParse(value, out num);
                var list = db.STOCK.Include(s => s.EXPENSE).Include(s => s.PLAN).Where(n => n.STOCK_NUM == num).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("7"))
            {
                DateTime time = Convert.ToDateTime(value);
                var list = db.STOCK.Include(s => s.EXPENSE).Include(s => s.PLAN).Where(n => n.STOCK_DATE == time).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            var list1 = db.STOCK.Include(s => s.EXPENSE).Include(s => s.PLAN).Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list1 }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult advancedSearch(string para01, string para02, string para03, string para04, string para05, string para06, string para07, string para08, string para09)
        {
            string stock_id = para01;
            string bat_id = para02;
            string pro_id = para03;
            string pro_name = para04;
            string plan_id = para05;
            string ex_id = para06;
            string num_min = para07;
            string num_max = para08;
            string sto_date = para09;


            int num_low;
            int.TryParse(num_min, out num_low);
            int num_high;
            int.TryParse(num_max, out num_high);

            var list = from e in db.STOCK select e;
            if (stock_id != "!!")
            {
                list = list.Where(s => s.STOCK_ID == stock_id);
            }
            if (bat_id != "!!")
            {
                list = list.Where(s => s.BATCH_ID == bat_id);
            }
            if (pro_id != "!!")
            {
                list = list.Where(s => s.PRODUCT.PRODUCT_ID == pro_id);
            }
            if (pro_name != "!!")
            {
                list = list.Where(s => s.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME == pro_name);
            }
            if (plan_id != "!!")
            {
                list = list.Where(s => s.PLAN_ID == plan_id);
            }
            if (ex_id != "!!")
            {
                list = list.Where(s => s.EXPENSE_ID == ex_id);
            }
            if (num_min != "!!")
            {
                list = list.Where(s => s.STOCK_NUM > num_low);
            }
            if (num_max != "!!")
            {
                list = list.Where(s => s.STOCK_NUM < num_high);
            }
            if (sto_date != "!!")
            {
                DateTime x = Convert.ToDateTime(sto_date);
                list = list.Where(s => s.STOCK_DATE == x);
            }

            var list2 = list.Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 });
        }

        [HttpPost]
        public string test(string para01, string para02, string para03)
        {
            string stock_id = para01;
            string plan_id = para02;
            string expense_id = para03;

            STOCK sTOCK = db.STOCK.Find(stock_id);
            if (sTOCK != null)
            {
                return "1";
            }
            EXPENSE eXPENSE = db.EXPENSE.Find(expense_id);
            if (eXPENSE == null)
            {
                return "2";
            }
            PLAN pLAN = db.PLAN.Find(plan_id);
            if (pLAN == null)
            {
                return "3";
            }
            return "4";
        }

        [HttpPost]
        public JsonResult Create01(string para01, string para02, string para03, string para04, string para05, string para06, string para07)
        {
            string stock_id = para01;
            string bat_id = para02;
            string plan_id = para03;
            string pro_date = para04;
            string expense_id = para05;
            string stock_num = para06;
            string stock_date = para07;


            int num;
            int.TryParse(stock_num, out num);
            DateTime x = Convert.ToDateTime(stock_date);
            DateTime y = Convert.ToDateTime(pro_date);

            PRODUCT pRODUCT = db.PRODUCT.Find(bat_id);
            PLAN pLAN = db.PLAN.Find(plan_id);
            PRODUCT newProduct = new PRODUCT();
            newProduct.PRODUCT_ID = pLAN.PRODUCT_ID;
            newProduct.SHEIF_ID = "0";
            newProduct.DISCOUNT = 1;
            newProduct.BATCH_ID = bat_id;
            newProduct.BATCH_NUMBER = num;
            newProduct.PRODUCT_DATE = y;
            if (pRODUCT == null)
            {
                db.PRODUCT.Add(newProduct);
                db.SaveChanges();
            }

            STOCK sTOCK = db.STOCK.Find(stock_id);
            STOCK newStock = new STOCK();

            newStock.STOCK_ID = stock_id;
            newStock.BATCH_ID = bat_id;
            newStock.EXPENSE_ID = expense_id;
            newStock.STOCK_NUM = num;
            newStock.STOCK_DATE = x;
            newStock.PLAN_ID = plan_id;

            if (sTOCK == null)
            {
                db.STOCK.Add(newStock);
                db.SaveChanges();
            }

            var list = db.STOCK.Select(n => new { STOCK_ID = n.STOCK_ID, BATCH_ID = n.PRODUCT.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PLAN_ID = n.PLAN_ID, EXPENSE_ID = n.EXPENSE_ID, STOCK_NUM = n.STOCK_NUM, STOCK_DATE = n.STOCK_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }

    }
}
