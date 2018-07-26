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
    public class SHELvesController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: SHELves
        public ActionResult Index()
        {
            return View(db.SHELF.ToList());
        }

        public JsonResult getJson()
        {
            var list = db.SHELF.Where(n => n.SHELF_ID != "0").Select(n => new { SHELF_ID = n.SHELF_ID, SHELF_AREA = n.SHELF_AREA });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult searchShelf(string para01, string para02)
        {

            string search_type = "";
            if (para01 != null)
            {
                search_type = para01;
            }
            else
            {
                var list = db.SHELF.Where(n => n.SHELF_ID != "0").Select(n => new { SHELF_ID = n.SHELF_ID, SHELF_AREA = n.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.SHELF.Where(n => n.SHELF_ID != "0").Select(n => new { SHELF_ID = n.SHELF_ID, SHELF_AREA = n.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.SHELF.Where(n => n.SHELF_ID != "0").Where(n => n.SHELF_ID == value).Select(n => new { SHELF_ID = n.SHELF_ID, SHELF_AREA = n.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.SHELF.Where(n => n.SHELF_ID != "0").Where(n => n.SHELF_AREA == value).Select(n => new { SHELF_ID = n.SHELF_ID, SHELF_AREA = n.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            var list2 = db.SHELF.Where(n => n.SHELF_ID != "0").Select(n => new { SHELF_ID = n.SHELF_ID, SHELF_AREA = n.SHELF_AREA });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public string test(string para01, string para02)
        {
            string shelf_id = para01;
            string shelf_area = para02;


            SHELF myShelf = db.SHELF.Find(shelf_id);
            if (myShelf == null)
            {
                return "1";
            }
            else return "2";
        }
        [HttpPost]
        public JsonResult createShelf(string para01, string para02)
        {
            string shelf_id = para01;
            string shelf_area = para02;

            SHELF newShelf = new SHELF();
            newShelf.SHELF_ID = shelf_id;
            newShelf.SHELF_AREA = shelf_area;
            db.SHELF.Add(newShelf);
            db.SaveChanges();

            var list2 = db.SHELF.Where(n => n.SHELF_ID != "0").Select(n => new { SHELF_ID = n.SHELF_ID, SHELF_AREA = n.SHELF_AREA });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult editShelf(string para01, string para02)
        {
            string shelf_id = para01;
            string shelf_area = para02;

            SHELF myShelf = db.SHELF.Find(shelf_id);
            myShelf.SHELF_AREA = shelf_area;

            db.Entry(myShelf).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            var list2 = db.SHELF.Where(n => n.SHELF_ID != "0").Select(n => new { SHELF_ID = n.SHELF_ID, SHELF_AREA = n.SHELF_AREA });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Delete(string id)
        {
            SHELF myShelf = db.SHELF.Find(id);
            if (myShelf == null)
            {
                return;
            }

            db.SHELF.Remove(myShelf);
            db.SaveChanges();
        }

    }
}
