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
    public class SALES_LOTController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: SALES_LOT
        public ActionResult Index()
        {
            var sALES_LOT = db.SALES_LOT.Include(s => s.INCOME);
            return View(sALES_LOT.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult getJson()
        {
            var list = db.SALES_LOT.Include(s => s.PRODUCT).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, LOT_NUMBER = n.LOT_NUMBER, MONEY = n.MONEY, LOT_DATE = n.LOT_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult getJosnMonthly()
        {

            var list = db.SALES_LOT.Include(s => s.PRODUCT).Select(n => new { PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult search01(string id)
        {
            var date = Convert.ToDateTime(id);
            var list = db.SALES_LOT.Where(n=>n.LOT_DATE==date).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, LOT_NUMBER = n.LOT_NUMBER, MONEY = n.MONEY, LOT_DATE = n.LOT_DATE });

            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult search02(string id)
        {
            var list = db.SALES_LOT.Where(n => n.BATCH_ID==id).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, LOT_NUMBER = n.LOT_NUMBER, MONEY = n.MONEY, LOT_DATE = n.LOT_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult advancedSearch(string para01, string para02, string para03, string para04, string para05, string para06, string para07, string para08)
        {
            var b_id = para01;
            var p_id = para02;
            var name = para03;
            var num_min = para04;
            var num_max = para05;
            var money_min = para06;
            var money_max = para07;
            var l_date = para08;

            DateTime date;
            int n_min;
            int.TryParse(num_min, out n_min);
            int n_max;
            int.TryParse(num_max, out n_max);

            int m_min;
            int.TryParse(money_min, out m_min);
            int m_max;
            int.TryParse(money_max, out m_max);

            //PRODUCT pRODUCT = db.PRODUCT.Find(b_id);
            //sALES_LOT.PRODUCT = pRODUCT;

            var list = from e in db.SALES_LOT select e;
            if (b_id != "!!")
            {
                list = list.Where(s => s.BATCH_ID == b_id);
            }
            if (p_id != "!!")
            {
                list = list.Where(s => s.PRODUCT.PRODUCT_ID == p_id);
            }
            if (name != "!!")
            {
                list = list.Where(s => s.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME == name);
            }
            if (l_date != "!!")
            {
                date = Convert.ToDateTime(l_date);
                list = list.Where(s => s.LOT_DATE == date);
            }
            if (num_min != "!!")
            {
                list = list.Where(s => s.LOT_NUMBER > n_min);
            }
            if (num_max != "!!")
            {
                list = list.Where(s => s.LOT_NUMBER < n_max);
            }
            if (money_min != "!!")
            {
                list = list.Where(s => s.MONEY > m_min);
            }
            if (money_max != "!!")
            {
                list = list.Where(s => s.MONEY < m_max);
            }
            var list2=list.Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, LOT_NUMBER = n.LOT_NUMBER, MONEY = n.MONEY, LOT_DATE = n.LOT_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);
            //return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult creatRecord(string para01, string para02, string para03)
        {
            var b_id = para01;
            int num;
            int.TryParse(para02, out num);
            var date = Convert.ToDateTime(para03);

            SALES_LOT sALES_LOT = new SALES_LOT();

            PRODUCT pRODUCT = db.PRODUCT.Find(b_id);
            sALES_LOT.PRODUCT = pRODUCT;
            PRODUCT_ATTRIBUTE pRODUCT_ATTRIBUTE = db.PRODUCT_ATTRIBUTE.Find(pRODUCT.PRODUCT_ID);
            

            sALES_LOT.BATCH_ID = b_id;
            sALES_LOT.PRODUCT.PRODUCT_ID = pRODUCT.PRODUCT_ID;
            sALES_LOT.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME = pRODUCT_ATTRIBUTE.PRODUCT_NAME;
            sALES_LOT.LOT_NUMBER = num;
            sALES_LOT.MONEY = num*pRODUCT_ATTRIBUTE.SELL_PRICE*pRODUCT.DISCOUNT;
            sALES_LOT.LOT_DATE = date;

            db.SALES_LOT.Add(sALES_LOT);
            db.SaveChanges();

            var list = db.SALES_LOT.Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME, LOT_NUMBER = n.LOT_NUMBER, MONEY = n.MONEY, LOT_DATE = n.LOT_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }

        //最佳销量
        public string bestSale(string para01, string para02)
        {
            var start_date = Convert.ToDateTime(para01);
            var end_date = Convert.ToDateTime(para02);
            var list = db.SALES_LOT.Where(n => n.LOT_DATE > start_date && n.LOT_DATE < end_date).GroupBy(n => new { n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME }).Select(n => new { PRODUCT_NAME = n.Key.PRODUCT_NAME, sum_num = n.Sum(i => i.LOT_NUMBER) });
            var max_num = list.Max(x => x.sum_num);
            var max = list.Where(x => x.sum_num == max_num).Select(n => new { PRODUCT_NAME = n.PRODUCT_NAME }).ToList();

            if (max.Count!= 0)
            {
                return max.First().PRODUCT_NAME;
            }
            return "暂无";
        }

    }
}
