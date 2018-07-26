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
    public class PRODUCTsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: PRODUCTs
        public ActionResult Index()
        {
            var pRODUCT = db.PRODUCT.Include(p => p.PRODUCT_ATTRIBUTE);
            return View();
        }

        public ActionResult Put()
        {
            var pRODUCT = db.PRODUCT.Include(p => p.PRODUCT_ATTRIBUTE);
            return View(pRODUCT.ToList());
        }

        // GET: PRODUCTs/Create
        public ActionResult Create()
        {
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT_ATTRIBUTE, "PRODUCT_ID", "SUPPLIER_ID");
            return View();
        }

        public JsonResult getJson1()
        {
            var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getJson2()
        {
            var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, DISCOUNT = n.DISCOUNT });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getJson3()
        {
            var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, EXP = n.PRODUCT_ATTRIBUTE.EXP, DISCOUNT = n.DISCOUNT });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getJson4()
        {
            var list = db.PRODUCT.Include(n => n.SHELF).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult searchAllDiscount(string para01, string para02)
        {

            string search_type = "";
            if (para01 != null)
            {
                search_type = para01;
            }
            else
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Where(n => n.BATCH_ID == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Where(n => n.PRODUCT_ID == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Where(n => n.PRODUCT_ATTRIBUTE.PRODUCT_NAME == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("3"))
            {
                decimal intA;
                decimal.TryParse(value, out intA);
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Where(n => n.DISCOUNT == intA).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            var list1 = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, DISCOUNT = n.DISCOUNT });
            return Json(new { code = 0, msg = "", count = 1000, data = list1 }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult EditAllDiscount(string para01, string para02)
        {
            string product_id = para01;

            decimal discount;
            decimal.TryParse(para02, out discount);
            discount = discount / 100;


            var myProduct = db.PRODUCT.Where(n => n.PRODUCT_ID == product_id);

            foreach (var x in myProduct)
            {
                PRODUCT testProduct = db.PRODUCT.Find(x.BATCH_ID);
                testProduct.BATCH_ID = x.BATCH_ID;
                testProduct.PRODUCT_ID = x.PRODUCT_ID;
                testProduct.PRODUCT_DATE = x.PRODUCT_DATE;
                testProduct.BATCH_NUMBER = x.BATCH_NUMBER;
                testProduct.SHEIF_ID = x.SHEIF_ID;
                db.Entry(testProduct).State = EntityState.Modified;
                db.SaveChanges();
            }




            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            var list1 = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, DISCOUNT = n.DISCOUNT });
            return Json(new { code = 0, msg = "", count = 1000, data = list1 }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult searchBatchDiscount(string para01, string para02)
        {

            string search_type = "";
            if (para01 != null)
            {
                search_type = para01;
            }
            else
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, EXP = n.PRODUCT_ATTRIBUTE.EXP, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, EXP = n.PRODUCT_ATTRIBUTE.EXP, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Where(n => n.BATCH_ID == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, EXP = n.PRODUCT_ATTRIBUTE.EXP, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Where(n => n.PRODUCT_ID == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, EXP = n.PRODUCT_ATTRIBUTE.EXP, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Where(n => n.PRODUCT_ATTRIBUTE.PRODUCT_NAME == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, EXP = n.PRODUCT_ATTRIBUTE.EXP, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }
            else if (search_type.Equals("3"))
            {
                DateTime myTime = Convert.ToDateTime(value);
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Where(n => n.PRODUCT_DATE == myTime).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, EXP = n.PRODUCT_ATTRIBUTE.EXP, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("4"))
            {
                decimal intA;
                decimal.TryParse(value, out intA);
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Where(n => n.DISCOUNT == intA).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, EXP = n.PRODUCT_ATTRIBUTE.EXP, DISCOUNT = n.DISCOUNT });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            var list2 = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, EXP = n.PRODUCT_ATTRIBUTE.EXP, DISCOUNT = n.DISCOUNT });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EditBatchDiscount(string para01, string para02)
        {
            string batch_id = para01;
            string discount = para02;

            decimal myDiscount;
            decimal.TryParse(discount, out myDiscount);

            PRODUCT myProduct = db.PRODUCT.Find(batch_id);

            db.Entry(myProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }


            var list2 = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, EXP = n.PRODUCT_ATTRIBUTE.EXP, DISCOUNT = n.DISCOUNT });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult searchPut(string para01, string para02)
        {

            string search_type = "";
            if (para01 != null)
            {
                search_type = para01;
            }
            else
            {
                var list = db.PRODUCT.Include(n => n.SHELF).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.PRODUCT.Include(n => n.SHELF).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.PRODUCT.Include(n => n.SHELF).Where(n => n.BATCH_ID == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.PRODUCT.Include(n => n.SHELF).Where(n => n.PRODUCT_ID == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                var list = db.PRODUCT.Include(n => n.SHELF).Where(n => n.PRODUCT_ATTRIBUTE.PRODUCT_NAME == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("3"))
            {
                var list = db.PRODUCT.Include(n => n.SHELF).Where(n => n.SHEIF_ID == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("4"))
            {
                var list = db.PRODUCT.Include(n => n.SHELF).Where(n => n.SHELF.SHELF_AREA == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            var list2 = db.PRODUCT.Include(n => n.SHELF).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }



        public JsonResult advancedSearchPut(string para01, string para02, string para03, string para04, string para05)
        {
            string batch_id = para01;
            string product_id = para02;
            string product_name = para03;
            string shelf_id = para04;
            string shelf_area = para05;

            var list = from e in db.PRODUCT.Include(n => n.SHELF) select e;
            if (batch_id != "!!")
            {
                list = list.Where(s => s.BATCH_ID == batch_id);
            }
            if (product_id != "!!")
            {
                list = list.Where(s => s.PRODUCT_ID == product_id);
            }
            if (product_name != "!!")
            {
                list = list.Where(s => s.PRODUCT_ATTRIBUTE.PRODUCT_NAME == product_name);
            }
            if (shelf_id != "!!")
            {
                list = list.Where(s => s.SHEIF_ID == shelf_id);
            }
            if (shelf_area != "!!")
            {
                list = list.Where(s => s.SHELF.SHELF_AREA == shelf_area);
            }

            var list2 = list.Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 });
        }



        [HttpPost]
        public JsonResult EditPut(string para01, string para02)
        {
            string batch_id = para01;
            string shelf_id = para02;


            PRODUCT myProduct = db.PRODUCT.Find(batch_id);

            myProduct.SHEIF_ID = shelf_id;

            db.Entry(myProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }


            var list2 = db.PRODUCT.Include(n => n.SHELF).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, SHELF_ID = n.SHEIF_ID, SHELF_AREA = n.SHELF.SHELF_AREA });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);
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
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.PRODUCT.Include(n => n.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.PRODUCT.Include(s => s.PRODUCT_ATTRIBUTE).Where(n => n.BATCH_ID == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.PRODUCT.Include(s => s.PRODUCT_ATTRIBUTE).Where(n => n.PRODUCT_ID == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                var list = db.PRODUCT.Include(s => s.PRODUCT_ATTRIBUTE).Where(n => n.PRODUCT_ATTRIBUTE.PRODUCT_NAME == value).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("3"))
            {
                DateTime x = Convert.ToDateTime(value);
                var list = db.PRODUCT.Include(s => s.PRODUCT_ATTRIBUTE).Where(n => n.PRODUCT_DATE == x).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("4"))
            {
                int x;
                int.TryParse(value, out x);
                var list = db.PRODUCT.Include(s => s.PRODUCT_ATTRIBUTE).Where(n => n.BATCH_NUMBER == x).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }


            var list1 = db.PRODUCT.Include(s => s.PRODUCT_ATTRIBUTE).Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list1 }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult advancedSearch(string para01, string para02, string para03, string para04, string para05, string para06)
        {
            string bat_id = para01;
            string pro_id = para02;
            string pro_name = para03;
            string pro_date = para04;
            string num_min = para05;
            string num_max = para06;


            int num_low;
            int.TryParse(num_min, out num_low);
            int num_high;
            int.TryParse(num_max, out num_high);

            var list = from e in db.PRODUCT select e;
            if (bat_id != "!!")
            {
                list = list.Where(s => s.BATCH_ID == bat_id);
            }
            if (pro_id != "!!")
            {
                list = list.Where(s => s.PRODUCT_ID == pro_id);
            }
            if (pro_name != "!!")
            {
                list = list.Where(s => s.PRODUCT_ATTRIBUTE.PRODUCT_NAME == pro_name);
            }
            if (pro_date != "!!")
            {
                DateTime x = Convert.ToDateTime(pro_date);
                list = list.Where(s => s.PRODUCT_DATE == x);
            }
            if (num_min != "!!")
            {
                list = list.Where(s => s.BATCH_NUMBER > num_low);
            }
            if (num_max != "!!")
            {
                list = list.Where(s => s.BATCH_NUMBER < num_high);
            }

            var list2 = list.Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 });
        }

        [HttpPost]
        public JsonResult Edit(string para01, string para02)
        {
            string bat_id = para01;
            string number = para02;

            int x;
            int.TryParse(number, out x);

            PRODUCT pRODUCT = db.PRODUCT.Find(bat_id);
            
            pRODUCT.BATCH_ID = bat_id;
            pRODUCT.BATCH_NUMBER = x;

            db.Entry(pRODUCT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }


            var list = db.PRODUCT.Select(n => new { BATCH_ID = n.BATCH_ID, PRODUCT_ID = n.PRODUCT_ID, PRODUCT_NAME = n.PRODUCT_ATTRIBUTE.PRODUCT_NAME, PRODUCT_DATE = n.PRODUCT_DATE, BATCH_NUMBER = n.BATCH_NUMBER });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
    }
}

