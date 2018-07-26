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
    public class SUPPLIERsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: SUPPLIERs
        public ActionResult Index()
        {
            return View(db.SUPPLIER.ToList());
        }

        // GET: SUPPLIERs/Details/5

        public JsonResult getJson()
        {
            var list = db.SUPPLIER.Select(n => new { SUPPLIER_ID = n.SUPPLIER_ID, SUPPLIER_NAME = n.SUPPLIER_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
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
                var list = db.SUPPLIER.Select(n => new { SUPPLIER_ID = n.SUPPLIER_ID, SUPPLIER_NAME = n.SUPPLIER_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }
            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.SUPPLIER.Select(n => new { SUPPLIER_ID = n.SUPPLIER_ID, SUPPLIER_NAME = n.SUPPLIER_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.SUPPLIER.Where(n => n.SUPPLIER_ID == value).Select(n => new { SUPPLIER_ID = n.SUPPLIER_ID, SUPPLIER_NAME = n.SUPPLIER_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.SUPPLIER.Where(n => n.SUPPLIER_NAME == value).Select(n => new { SUPPLIER_ID = n.SUPPLIER_ID, SUPPLIER_NAME = n.SUPPLIER_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                var list = db.SUPPLIER.Where(n => n.PHONE_NUMBER == value).Select(n => new { SUPPLIER_ID = n.SUPPLIER_ID, SUPPLIER_NAME = n.SUPPLIER_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }


            var list2 = db.SUPPLIER.Select(n => new { SUPPLIER_ID = n.SUPPLIER_ID, SUPPLIER_NAME = n.SUPPLIER_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Create01(string para01, string para02, string para03)
        {
            string id = para01;
            string name = para02;
            string number = para03;

            SUPPLIER sUPPLIER = db.SUPPLIER.Find(id);
            SUPPLIER newSupplier = new SUPPLIER();

            newSupplier.SUPPLIER_ID = id;
            newSupplier.SUPPLIER_NAME = name;
            newSupplier.PHONE_NUMBER = number;


            if (sUPPLIER == null)
            {
                db.SUPPLIER.Add(newSupplier);
                db.SaveChanges();
            }

            var list = db.SUPPLIER.Select(n => new { SUPPLIER_ID = n.SUPPLIER_ID, SUPPLIER_NAME = n.SUPPLIER_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(string para01, string para02, string para03)
        {
            string id = para01;
            string name = para02;
            string number = para03;
            
            SUPPLIER sUPPLIER = db.SUPPLIER.Find(id);
            
            sUPPLIER.SUPPLIER_ID = id;
            sUPPLIER.SUPPLIER_NAME = name;
            sUPPLIER.PHONE_NUMBER = number;

            db.Entry(sUPPLIER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }


            var list = db.SUPPLIER.Select(n => new { SUPPLIER_ID = n.SUPPLIER_ID, SUPPLIER_NAME = n.SUPPLIER_NAME, PHONE_NUMBER = n.PHONE_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void Delete(string id)
        {
            if (id == null)
            {
                return;
            }
            SUPPLIER sUPPLIER = db.SUPPLIER.Find(id);
            if (sUPPLIER == null)
            {
                return;
            }

            db.SUPPLIER.Remove(sUPPLIER);
            db.SaveChanges();

        }

    }
}
