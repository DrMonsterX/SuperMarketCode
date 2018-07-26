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
    public class VIPsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: VIPs
        public ActionResult Index()
        {
            var vIP = db.VIP.Include(v => v.EMPLOYEE);
            return View();
        }


        public JsonResult getJson()
        {
            var list = db.VIP.Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });
            return Json(new { code = 0, msg = "", count = 1000, data = list });
        }
        [HttpPost]
        public JsonResult search01(string para01, string para02)
        {
            string type = "";
            if (para01 != null)
            {
                type = para01;
            }
            else
            {
                var list = db.VIP.Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }
            string searchString = "";
            if (para02 != null)
            {
                searchString = para02;
            }
            else
            {
                var list = db.VIP.Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }


            if (type.Equals("1"))
            {
                var list = db.VIP.Where(s => s.VIP_ID == searchString).Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });

                return Json(new { code = 0, msg = "", count = 1000, data = list }); ;
            }
            else if (type.Equals("2"))
            {
                var list = db.VIP.Where(s => s.VIP_NAME == searchString).Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }); ;
            }
            else if (type.Equals("3"))
            {
                var list = db.VIP.Where(s => s.SEX == searchString).Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }); ;
            }
            else if (type.Equals("4"))
            {
                var list = db.VIP.Where(s => s.PHONE_NUMBER == searchString).Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }); ;
            }
            else if (type.Equals("5"))
            {
                var list = db.VIP.Where(s => s.CREDITS == long.Parse(searchString)).Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }); ;
            }
            else if (type.Equals("6"))
            {
                var list = db.VIP.Where(s => s.EMPLOYEE_ID == searchString).Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }); ;
            }
            else
            {
                var list = db.VIP.Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult advancedSearch(string para01, string para02, string para03, string para04, string para05, string para06, string para07)
        {
            string v_id = para01;
            string name = para02;
            string sex = para03;
            string phone = para04;
            string credits_min = para05;
            string credits_max = para06;
            string e_id = para07;

            int min;
            int.TryParse(credits_min, out min);
            int max;
            int.TryParse(credits_max, out max);

            var list = from e in db.VIP select e;
            if (v_id != "!!")
            {
                list = list.Where(s => s.VIP_ID == v_id);
            }
            if (name != "!!")
            {
                list = list.Where(s => s.VIP_NAME == name);
            }
            if (sex != "!!")
            {
                list = list.Where(s => s.SEX == sex);
            }
            if (phone != "!!")
            {
                list = list.Where(s => s.PHONE_NUMBER == phone);
            }
            if (credits_min != "!!")
            {
                list = list.Where(s => s.CREDITS > min);
            }
            if (credits_max != "!!")
            {
                list = list.Where(s => s.CREDITS < max);
            }

            var list2 = list.Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID }).ToList();

            return Json(new { code = 0, msg = "", count = 1000, data = list2 });
        }

        [HttpPost]
        public JsonResult Edit(string para01, string para02, string para03, string para04, string para05, string para06)
        {
            string v_id = para01;
            string name = para02;
            string sex = para03;
            string phone = para04;
            string credits = para05;
            string e_id = para06;

            int intCredits;
            int.TryParse(credits, out intCredits);
            /*
            if (id == null)
            {
                return Json(null);
            }
            */
            VIP vIP = db.VIP.Find(v_id);
            /*
            if (eMPLOYEE == null)
            {
                //return Json(null);
            }
            */
            vIP.VIP_NAME = name;
            vIP.SEX = sex;
            vIP.PHONE_NUMBER = phone;
            vIP.CREDITS = intCredits;
            vIP.EMPLOYEE_ID = e_id;

            db.Entry(vIP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            var list = db.VIP.Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID });
            return Json(new { code = 0, msg = "", count = 1000, data = list });
        }

        [HttpPost]
        public bool test(string id)
        {
            VIP vIP = db.VIP.Find(id);
            if (vIP != null)
            {
                return true;
            }
            return false;
        }
        [HttpPost]
        public JsonResult Create01(string para01, string para02, string para03, string para04, string para05, string para06)
        {
            string VIP_ID = para01;
            string VIP_NAME = para02;
            string SEX = para03;
            string PHONE_NUMBER = para04;
            short CREDITS;
            string EMPLOYEE_ID = para06;


            short.TryParse(para05, out CREDITS);
            VIP newVIP = new VIP();

            newVIP.VIP_ID = VIP_ID;
            newVIP.VIP_NAME = VIP_NAME;
            newVIP.SEX = SEX;
            newVIP.PHONE_NUMBER = PHONE_NUMBER;
            newVIP.CREDITS = CREDITS;
            newVIP.EMPLOYEE_ID = EMPLOYEE_ID;

            //缺少误填判断
            db.VIP.Add(newVIP);
            db.SaveChanges();

            var list = db.VIP.Select(n => new { VIP_ID = n.VIP_ID, VIP_NAME = n.VIP_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, CREDITS = n.CREDITS, EMPLOYEE_ID = n.EMPLOYEE_ID }).ToList();
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Delete(string id)
        {
            if (id == null)
            {
                return;
            }
            VIP vIP = db.VIP.Find(id);
            if (vIP == null)
            {
                return;
            }

            db.VIP.Remove(vIP);
            db.SaveChanges();

        }
    }
}
