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
    public class SUPPORTsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: SUPPORTs
        public ActionResult Index()
        {
            var sUPPORT = db.SUPPORT.Include(s => s.INCOME).Include(s => s.SPONSOR);
            return View();
        }


        public JsonResult getJson()
        {
            var list = db.SUPPORT.Include(n => n.INCOME).Include(n => n.SPONSOR).Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
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

                var list = db.SUPPORT.Include(n => n.INCOME).Include(n => n.SPONSOR).Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }
            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.SUPPORT.Include(n => n.INCOME).Include(n => n.SPONSOR).Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }



            if (search_type.Equals("0"))
            {

                var list = db.SUPPORT.Where(n => n.SPONSOR_ID == value).Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.SUPPORT.Where(n => n.SPONSOR.SPONSOR_NAME == value).Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                int money;
                int.TryParse(value, out money);
                var list = db.SUPPORT.Where(n => n.MONEY == money).Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("3"))
            {
                DateTime myTime = Convert.ToDateTime(value);
                var list = db.SUPPORT.Where(n => n.SUPPORT_DATE == myTime).Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }


            var list2 = db.SUPPORT.Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }


        public JsonResult advancedSearch(string para01, string para02, string para03, string para04, string para05, string para06)
        {
            string id = para01;
            string name = para02;
            string inc_id = para03;
            string money_low = para04;
            string money_high = para05;
            string date = para06;

            int low;
            int.TryParse(money_low, out low);

            int high;
            int.TryParse(money_high, out high);

            //SUPPORT su = db.SUPPORT.Find(para01,para03);
            //string setet = su.SUPPORT_DATE.ToString();


            var list = from e in db.SUPPORT select e;
            if (id != "!!")
            {
                list = list.Where(s => s.SPONSOR_ID == id);
            }
            if (name != "!!")
            {
                list = list.Where(s => s.SPONSOR.SPONSOR_NAME == name);
            }
            if (inc_id != "!!")
            {
                list = list.Where(s => s.INCOME_ID == inc_id);
            }
            if (money_low != "!!")
            {
                list = list.Where(s => s.MONEY > low);
            }
            if (money_high != "!!")
            {
                list = list.Where(s => s.MONEY < high);
            }
            if (date != "!!")
            {
                DateTime x = Convert.ToDateTime(date);
                list = list.Where(s => s.SUPPORT_DATE == x);
            }

            var list2 = list.Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 });
        }


        // [HttpPost]
        //public bool test(string para01,string para02)
        // {
        //   string id = para01;
        //   string income_id = para02;
        //   SUPPORT sUPPORT = db.SUPPORT.Find(id,income_id);
        //   if (sUPPORT != null)
        //   {
        //       return true;
        //   }
        //   return false;
        //}

        [HttpPost]
        public string test(string para01, string para02)
        {
            string id = para01;
            string income_id = para02;

            SUPPORT sUPPORT = db.SUPPORT.Find(id, income_id);
            if (sUPPORT != null)
            {
                return "1";
            }
            SPONSOR myid = db.SPONSOR.Find(id);
            if (myid == null)
            {
                return "2";
            }
            INCOME myincome_id = db.INCOME.Find(income_id);
            if (myincome_id == null)
            {
                return "3";
            }
            return "4";
        }

        [HttpPost]
        public JsonResult Create01(string para01, string para02, string para03)
        {
            string sup_id = para01;
            string income_id = para02;
            string spo_money = para03;

            //var list2 = db.INCOME.Where(n => n.INCOME_ID == income_id).Select(n => new { INCOME_DATE = n.INCOME_DATE });
            INCOME list2 = db.INCOME.Find(income_id);
            int money;
            int.TryParse(spo_money, out money);

            SUPPORT sUPPORT = db.SUPPORT.Find(sup_id, income_id);
            SUPPORT newSupport = new SUPPORT();

            newSupport.SPONSOR_ID = sup_id;
            newSupport.INCOME_ID = income_id;
            newSupport.MONEY = money;
            newSupport.SUPPORT_DATE = list2.INCOME_DATE;

            

            if (sUPPORT == null)
            {
                db.SUPPORT.Add(newSupport);
                db.SaveChanges();
            }

            var list = db.SUPPORT.Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(string para01, string para02, string para03)
        {
            string id = para01;
            string spo_money = para02;
            string date = para03;

            int money;
            int.TryParse(spo_money, out money);
            /*
            if (id == null)
            {
                return Json(null);
            }
            */
            SUPPORT sUPPORT = db.SUPPORT.Find(id);
            /*
            if (eMPLOYEE == null)
            {
                //return Json(null);
            }
            */
            sUPPORT.SPONSOR_ID = id;
            sUPPORT.MONEY = money;
            sUPPORT.SUPPORT_DATE = Convert.ToDateTime(date);

            db.Entry(sUPPORT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }


            var list = db.SUPPORT.Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR.SPONSOR_NAME, INCOME_ID = n.INCOME_ID, MONEY = n.MONEY, SUPPORT_DATE = n.SUPPORT_DATE });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public void Delete(string id)
        {
            if (id == null)
            {
                return;
            }
            SUPPORT sUPPORT = db.SUPPORT.Find(id);
            if (sUPPORT == null)
            {
                return;
            }

            db.SUPPORT.Remove(sUPPORT);
            db.SaveChanges();

        }
    }
}
