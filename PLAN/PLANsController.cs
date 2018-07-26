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
    public class PLANsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: PLANs
        public ActionResult Index()
        {
            var pLAN = db.PLAN.Include(p => p.PRODUCT_ATTRIBUTE);
            return View();
        }

        
        public JsonResult getJson()
        {
            var list = db.PLAN.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
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
                var list = db.PLAN.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }
            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.PLAN.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.PLAN.Where(n => n.PLAN_ID == value).Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.PLAN.Where(n => n.PRODUCT_ID == value).Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                var list = db.PLAN.Where(n => n.PRODUCT_ATTRIBUTE.PRODUCT_NAME == value).Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("3"))
            {
                var list = db.PLAN.Where(n => n.PRODUCT_ATTRIBUTE.SUPPLIER_ID == value).Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            
            var list2 = db.PLAN.Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }


        public JsonResult advancedSearch(string para01, string para02, string para03, string para04, string para05, string para06, string para07, string para08)
        {
            string id = para01;
            string pro_id = para02;
            string pro_name = para03;
            string sup_id = para04;
            string pur_min = para05;
            string pur_max = para06;
            string num_min = para07;
            string num_max = para08;

            int pur_low;
            int.TryParse(pur_min, out pur_low);
            int pur_high;
            int.TryParse(pur_max, out pur_high);
            int num_low;
            int.TryParse(num_min, out num_low);
            int num_high;
            int.TryParse(num_max, out num_high);

            var list = from e in db.PLAN select e;
            if (id != "!!")
            {
                list = list.Where(s => s.PLAN_ID == id);
            }
            if (pro_id != "!!")
            {
                list = list.Where(s => s.PRODUCT_ID == pro_id);
            }
            if (pro_name != "!!")
            {
                list = list.Where(s => s.PRODUCT_ATTRIBUTE.PRODUCT_NAME == pro_name);
            }
            if (sup_id != "!!")
            {
                list = list.Where(s => s.PRODUCT_ATTRIBUTE.SUPPLIER_ID == sup_id);
            }
            if (pur_min != "!!")
            {
                list = list.Where(s => s.PRODUCT_ATTRIBUTE.PURCHASE_PRICE > pur_low);
            }
            if (pur_max != "!!")
            {
                list = list.Where(s => s.PRODUCT_ATTRIBUTE.PURCHASE_PRICE < pur_high);
            }
            if (num_min != "!!")
            {
                list = list.Where(s => s.PLAN_NUM > num_low);
            }
            if (num_max != "!!")
            {
                list = list.Where(s => s.PLAN_NUM < num_high);
            }

            var list2 = list.Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 });
        }


        [HttpPost]
        public string test(string para01, string para02)
        {
            string id = para01;
            string pro_id = para02;

            PLAN pLAN = db.PLAN.Find(id);
            if (pLAN != null)
            {
                return "1";
            }
            PRODUCT_ATTRIBUTE pRODUCT = db.PRODUCT_ATTRIBUTE.Find(pro_id);
            if (pRODUCT == null)
            {
                return "2";
            }
            PLAN plAN = db.PLAN.Find(pro_id);
            if (pRODUCT != null)
            {
                return "3";
            }
            return "4";
        }

        [HttpPost]
        public JsonResult Create01(string para01, string para02, string para03)
        {
            string id = para01;
            string pro_id = para02;
            string plan_number = para03;

            int plan_num;
            int.TryParse(plan_number, out plan_num);

            PLAN pLAN = db.PLAN.Find(pro_id);
            PLAN newPlan = new PLAN();

            newPlan.PRODUCT_ID = pro_id;
            newPlan.PLAN_ID = id;
            newPlan.PLAN_NUM = plan_num;

            
            if (pLAN == null)
            {
                db.PLAN.Add(newPlan);
                db.SaveChanges();
            }

            var list = db.PLAN.Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(string para01, string para02, string para03, string para04, string para05, string para06)
        {
            string plan_id = para01;
            string pro_id = para02;
            string pro_name = para03;
            string sup_id = para04;
            string purchase = para05;
            string plan_number = para06;

            int pur;
            int.TryParse(purchase, out pur);
            int plan_num;
            int.TryParse(plan_number, out plan_num);
            /*
            if (id == null)
            {
                return Json(null);
            }
            */
            PLAN pLAN = db.PLAN.Find(plan_id);
            /*
            if (eMPLOYEE == null)
            {
                //return Json(null);
            }
            */
            pLAN.PLAN_ID = plan_id ;
            pLAN.PRODUCT_ID= pro_id;
            pLAN.PRODUCT_ATTRIBUTE.PRODUCT_NAME = pro_name;
            pLAN.PRODUCT_ATTRIBUTE.SUPPLIER_ID = sup_id;
            pLAN.PRODUCT_ATTRIBUTE.PURCHASE_PRICE = pur;
            pLAN.PLAN_NUM = plan_num ;

            db.Entry(pLAN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }


            var list = db.PLAN.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { PLAN_ID = n.PLAN_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SUPPLIER_ID = n.PRODUCT_ATTRIBUTE.SUPPLIER_ID, PURCHASE_PRICE = n.PRODUCT_ATTRIBUTE.PURCHASE_PRICE, PLAN_NUM = n.PLAN_NUM });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public void Delete(string id)
        {
            if (id == null)
            {
                return;
            }
            PLAN pLAN = db.PLAN.Find(id);
            if (pLAN == null)
            {
                return;
            }

            db.PLAN.Remove(pLAN);
            db.SaveChanges();

        }

    }
}
