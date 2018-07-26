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
    public class PRODUCT_ATTRIBUTEController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: PRODUCT_ATTRIBUTE
        public ActionResult Index()
        {
            var pRODUCT_ATTRIBUTE = db.PRODUCT_ATTRIBUTE.Include(p => p.SUPPLIER);
            return View(pRODUCT_ATTRIBUTE.ToList());
        }

        public JsonResult getJson()
        {
            var list = db.PRODUCT_ATTRIBUTE.Select(n => new { PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_NAME, SUPPLIER_ID = n.SUPPLIER_ID, PURCHASE_PRICE = n.PURCHASE_PRICE, SELL_PRICE = n.SELL_PRICE, EXP = n.EXP, TOTAL = n.TOTAL });
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
                var list = db.PRODUCT_ATTRIBUTE.Select(n => new { PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_NAME, SUPPLIER_ID = n.SUPPLIER_ID, PURCHASE_PRICE = n.PURCHASE_PRICE, SELL_PRICE = n.SELL_PRICE, EXP = n.EXP, TOTAL = n.TOTAL });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }
            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.PRODUCT_ATTRIBUTE.Select(n => new { PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_NAME, SUPPLIER_ID = n.SUPPLIER_ID, PURCHASE_PRICE = n.PURCHASE_PRICE, SELL_PRICE = n.SELL_PRICE, EXP = n.EXP, TOTAL = n.TOTAL });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.PRODUCT_ATTRIBUTE.Where(n=>n.PRODUCT_ID==value).Select(n => new { PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_NAME, SUPPLIER_ID = n.SUPPLIER_ID, PURCHASE_PRICE = n.PURCHASE_PRICE, SELL_PRICE = n.SELL_PRICE, EXP = n.EXP, TOTAL = n.TOTAL });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.PRODUCT_ATTRIBUTE.Where(n => n.PRODUCT_NAME == value).Select(n => new { PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_NAME, SUPPLIER_ID = n.SUPPLIER_ID, PURCHASE_PRICE = n.PURCHASE_PRICE, SELL_PRICE = n.SELL_PRICE, EXP = n.EXP, TOTAL = n.TOTAL });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                var list = db.PRODUCT_ATTRIBUTE.Where(n => n.SUPPLIER_ID == value).Select(n => new { PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_NAME, SUPPLIER_ID = n.SUPPLIER_ID, PURCHASE_PRICE = n.PURCHASE_PRICE, SELL_PRICE = n.SELL_PRICE, EXP = n.EXP, TOTAL = n.TOTAL });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }
            var list2 = db.PRODUCT_ATTRIBUTE.Select(n => new { PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_NAME, SUPPLIER_ID = n.SUPPLIER_ID, PURCHASE_PRICE = n.PURCHASE_PRICE, SELL_PRICE = n.SELL_PRICE, EXP = n.EXP, TOTAL = n.TOTAL });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }


        public JsonResult advancedSearch(string para01, string para02, string para03, string para04, string para05, string para06, string para07, string para08, string para09)
        {
            string id = para01;
            string p_price_min = para02;
            string p_price_max = para03;
            string s_price_min = para04;
            string s_price_max = para05;
            string exp_min = para06;
            string exp_max = para07;
            string tot_min = para08;
            string tot_max = para09;

            int p_min;
            int.TryParse(p_price_min, out p_min);
            int p_max;
            int.TryParse(p_price_max, out p_max);
            int s_min;
            int.TryParse(s_price_min, out s_min);
            int s_max;
            int.TryParse(s_price_max, out s_max);
            int e_min;
            int.TryParse(exp_min, out e_min);
            int e_max;
            int.TryParse(exp_max, out e_max);
            int t_min;
            int.TryParse(tot_min, out t_min);
            int t_max;
            int.TryParse(tot_max, out t_max);

            var list = from e in db.PRODUCT_ATTRIBUTE select e;
            if (id != "!!")
            {
                list = list.Where(s => s.PRODUCT_ID == id);
            }
            if (p_price_min != "!!")
            {
                list = list.Where(s => s.PURCHASE_PRICE > p_min);
            }
            if (p_price_max != "!!")
            {
                list = list.Where(s => s.PURCHASE_PRICE < p_max);
            }
            if (s_price_min != "!!")
            {
                list = list.Where(s => s.SELL_PRICE > s_min);
            }
            if (s_price_max != "!!")
            {
                list = list.Where(s => s.SELL_PRICE < s_max);
            }
            if (exp_min != "!!")
            {
                list = list.Where(s => s.EXP > e_min);
            }
            if (exp_max != "!!")
            {
                list = list.Where(s => s.EXP < e_max);
            }
            if (tot_min != "!!")
            {
                list = list.Where(s => s.TOTAL > t_min);
            }
            if (tot_max != "!!")
            {
                list = list.Where(s => s.TOTAL < t_max);
            }

            var list2 = list.Select(n => new { PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_NAME, SUPPLIER_ID = n.SUPPLIER_ID, PURCHASE_PRICE = n.PURCHASE_PRICE, SELL_PRICE = n.SELL_PRICE, EXP = n.EXP, TOTAL = n.TOTAL });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult Create(string para01, string para02, string para03, string para04, string para05, string para06, string para07)
        {
            string p_id = para01;
            string name = para02;
            string s_id = para03;
            string p_price = para04;
            string s_price = para05;
            string exp = para06;
            string total = para07;

            int p_p;
            int.TryParse(p_price, out p_p);
            int s_p;
            int.TryParse(s_price, out s_p);
            int int_exp;
            int.TryParse(exp, out int_exp);
            int int_tot;
            int.TryParse(total, out int_tot);

            PRODUCT_ATTRIBUTE pRODUCT_ATTRIBUTE = db.PRODUCT_ATTRIBUTE.Find(p_id);

            PRODUCT_ATTRIBUTE newPRODUCT_ATTRIBUTE = new PRODUCT_ATTRIBUTE();

            newPRODUCT_ATTRIBUTE.PRODUCT_ID = p_id;
            newPRODUCT_ATTRIBUTE.PRODUCT_NAME = name;
            newPRODUCT_ATTRIBUTE.SUPPLIER_ID = s_id;
            newPRODUCT_ATTRIBUTE.PURCHASE_PRICE = p_p;
            newPRODUCT_ATTRIBUTE.SELL_PRICE = s_p;
            newPRODUCT_ATTRIBUTE.EXP = int_exp;
            newPRODUCT_ATTRIBUTE.TOTAL = int_tot;

            if (pRODUCT_ATTRIBUTE == null)
            {
                db.PRODUCT_ATTRIBUTE.Add(newPRODUCT_ATTRIBUTE);
                db.SaveChanges();
            }

            var list = db.PRODUCT_ATTRIBUTE.Select(n => new { PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_NAME, SUPPLIER_ID = n.SUPPLIER_ID, PURCHASE_PRICE = n.PURCHASE_PRICE, SELL_PRICE = n.SELL_PRICE, EXP = n.EXP, TOTAL = n.TOTAL });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult editRecord(string para01, string para02, string para03, string para04, string para05, string para06, string para07)
        {
            string p_id = para01;
            string name = para02;
            string s_id = para03;
            string p_price = para04;
            string s_price = para05;
            string exp = para06;
            string total = para07;

            int p_p;
            int.TryParse(p_price, out p_p);
            int s_p;
            int.TryParse(s_price, out s_p);
            int int_exp;
            int.TryParse(exp, out int_exp);
            int int_tot;
            int.TryParse(total, out int_tot);
            
            PRODUCT_ATTRIBUTE newPRODUCT_ATTRIBUTE = db.PRODUCT_ATTRIBUTE.Find(p_id);

            newPRODUCT_ATTRIBUTE.PRODUCT_NAME = name;
            newPRODUCT_ATTRIBUTE.SUPPLIER_ID = s_id;
            newPRODUCT_ATTRIBUTE.PURCHASE_PRICE = p_p;
            newPRODUCT_ATTRIBUTE.SELL_PRICE = s_p;
            newPRODUCT_ATTRIBUTE.EXP = int_exp;
            newPRODUCT_ATTRIBUTE.TOTAL = int_tot;

            db.Entry(newPRODUCT_ATTRIBUTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            var list = db.PRODUCT_ATTRIBUTE.Select(n => new { PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_NAME, SUPPLIER_ID = n.SUPPLIER_ID, PURCHASE_PRICE = n.PURCHASE_PRICE, SELL_PRICE = n.SELL_PRICE, EXP = n.EXP, TOTAL = n.TOTAL });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Delete(string id)
        {
            if (id == null)
            {
                return;
            }
            PRODUCT_ATTRIBUTE pRODUCT_ATTRIBUTE = db.PRODUCT_ATTRIBUTE.Find(id);
            if (pRODUCT_ATTRIBUTE == null)
            {
                return;
            }

            db.PRODUCT_ATTRIBUTE.Remove(pRODUCT_ATTRIBUTE);
            db.SaveChanges();

        }
    }
}
