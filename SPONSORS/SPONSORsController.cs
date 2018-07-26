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
    public class SPONSORsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: SPONSORs
        public ActionResult Index()
        {
            return View(db.SPONSOR.ToList());
        }

        // GET: SPONSORs/Details/5
        
        public JsonResult getJson()
        {
            var list = db.SPONSOR.Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public bool test(string id)
        {
            SUPPLIER sUPPLIER = db.SUPPLIER.Find(id);
            if (sUPPLIER != null)
            {
                return true;
            }
            return false;
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
                var list = db.SPONSOR.Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }
            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.SPONSOR.Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.SPONSOR.Where(n => n.SPONSOR_ID == value).Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.SPONSOR.Where(n => n.SPONSOR_NAME == value).Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                var list = db.SPONSOR.Where(n => n.PHONE_NUMBER == value).Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }


            var list2 = db.SPONSOR.Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }
        
        [HttpPost]
        public JsonResult Create01(string para01, string para02, string para03)
        {
            string id = para01;
            string name = para02;
            string number = para03;

            SPONSOR sPONSOR = db.SPONSOR.Find(id);
            SPONSOR newSponsor = new SPONSOR();

            newSponsor.SPONSOR_ID = id;
            newSponsor.SPONSOR_NAME = name;
            newSponsor.PHONE_NUMBER = number;

            
            if (sPONSOR == null)
            {
                db.SPONSOR.Add(newSponsor);
                db.SaveChanges();
            }

            var list = db.SPONSOR.Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(string para01, string para02, string para03)
        {
            string id = para01;
            string name = para02;
            string number = para03;
            
            /*
            if (id == null)
            {
                return Json(null);
            }
            */
            SPONSOR sPONSOR = db.SPONSOR.Find(id);
            /*
            if (eMPLOYEE == null)
            {
                //return Json(null);
            }
            */
            sPONSOR.SPONSOR_ID = id;
            sPONSOR.SPONSOR_NAME = name;
            sPONSOR.PHONE_NUMBER = number;

            db.Entry(sPONSOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }


            var list = db.SPONSOR.Select(n => new { SPONSOR_ID = n.SPONSOR_ID, SPONSOR_NAME = n.SPONSOR_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet); 
        }
        [HttpPost]
        public void Delete(string id)
        {
            if (id == null)
            {
                return;
            }
            SPONSOR sPONSOR = db.SPONSOR.Find(id);
            if (sPONSOR == null)
            {
                return;
            }

            db.SPONSOR.Remove(sPONSOR);
            db.SaveChanges();

        }

    }
}
