using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services;
using MySuperMarket.Models;

namespace MySuperMarket.Controllers
{
    public class EMPLOYEEsController : Controller
    {
        private MyMarket db = new MyMarket();


        public ActionResult Index()
        {
            return View();

        }


        public JsonResult getJson()
        {
            var list = db.EMPLOYEE.Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
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
                var list = db.EMPLOYEE.Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }
            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.EMPLOYEE.Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.EMPLOYEE.Where(n => n.EMPLOYEE_ID == value).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.EMPLOYEE.Where(n => n.EMPLOYEE_NAME == value).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                var list = db.EMPLOYEE.Where(n => n.SEX == value).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("3"))
            {
                var list = db.EMPLOYEE.Where(n => n.PHONE_NUMBER == value).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("4"))
            {
                int intA;
                int.TryParse(value, out intA);
                var list = db.EMPLOYEE.Where(n => n.SALARY == intA).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }
            var list2 = db.EMPLOYEE.Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 }, JsonRequestBehavior.AllowGet);

        }


        public JsonResult advancedSearch(string para01, string para02, string para03, string para04, string para05, string para06)
        {
            string id = para01;
            string name = para02;
            string salary_low = para03;
            string salary_high = para04;
            string sex = para05;
            string phone = para06;

            int low;
            int.TryParse(salary_low, out low);
            int high;
            int.TryParse(salary_high, out high);

            var list = from e in db.EMPLOYEE select e;
            if (id != "!!")
            {
                list = list.Where(s => s.EMPLOYEE_ID == id);
            }
            if (name != "!!")
            {
                list = list.Where(s => s.EMPLOYEE_NAME == name);
            }
            if (sex != "!!")
            {
                list = list.Where(s => s.SEX == sex);
            }
            if (phone != "!!")
            {
                list = list.Where(s => s.PHONE_NUMBER == phone);
            }
            if (salary_low != "!!")
            {
                list = list.Where(s => s.SALARY > low);
            }
            if (salary_high != "!!")
            {
                list = list.Where(s => s.SALARY < high);
            }

            var list2 = list.Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 });
        }

        public string accountAllPeople()
        {
            var accountAll = db.EMPLOYEE.Count();

            return accountAll.ToString();
        }

        public string accountMalePeople()
        {
            var list = db.EMPLOYEE.Where(n => n.SEX == "男").Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
            var accountMale = list.Count();
            return accountMale.ToString();
        }

        public string accountFemalePeople()
        {
            var list = db.EMPLOYEE.Where(n => n.SEX == "女").Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
            var accountFemale = list.Count();
            return accountFemale.ToString();
        }
        public string accountAllSalary()
        {
            var allSalary = db.EMPLOYEE.Sum(n => n.SALARY);
            return allSalary.ToString();
        }

        [HttpPost]
        public bool Test(string id)
        {
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            if (eMPLOYEE != null)
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public JsonResult Create(string para01, string para02, string para03, string para04, string para05)
        {
            string id = para01;
            string name = para02;
            string salary = para03;
            string sex = para04;
            string phone = para05;

            int intSalary;
            int.TryParse(salary, out intSalary);
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);

            EMPLOYEE newEmployee = new EMPLOYEE();

            newEmployee.EMPLOYEE_ID = id;
            newEmployee.EMPLOYEE_NAME = name;
            newEmployee.SALARY = intSalary;
            newEmployee.SEX = sex;
            newEmployee.PHONE_NUMBER = phone;

            if (eMPLOYEE == null)
            {
                db.EMPLOYEE.Add(newEmployee);
                db.SaveChanges();
            }

            var list = db.EMPLOYEE.Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(string para01, string para02, string para03, string para04, string para05)
        {
            string id = para01;
            string name = para02;
            string salary = para03;
            string sex = para04;
            string phone = para05;

            int intSalary;
            int.TryParse(salary, out intSalary);
            /*
            if (id == null)
            {
                return Json(null);
            }
            */
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            /*
            if (eMPLOYEE == null)
            {
                //return Json(null);
            }
            */
            eMPLOYEE.EMPLOYEE_NAME = name;
            eMPLOYEE.SALARY = intSalary;
            eMPLOYEE.SEX = sex;
            eMPLOYEE.PHONE_NUMBER = phone;

            db.Entry(eMPLOYEE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }


            var list = db.EMPLOYEE.Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE_NAME, SEX = n.SEX, PHONE_NUMBER = n.PHONE_NUMBER, SALARY = n.SALARY });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet); 
        }
        [HttpPost]
        public void Delete(string id)
        {
            if (id == null)
            {
                return;
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            if (eMPLOYEE == null)
            {
                return;
            }

            db.EMPLOYEE.Remove(eMPLOYEE);
            db.SaveChanges();

        }
        //最佳销量
        public string bestSale(string para01, string para02)
        {
            var start_date = Convert.ToDateTime(para01);
            var end_date = Convert.ToDateTime(para02);
            var list = db.SALES_LOT.Where(n => n.LOT_DATE > start_date && n.LOT_DATE < end_date).GroupBy(n => new { n.PRODUCT.PRODUCT_ATTRIBUTE.PRODUCT_NAME }).Select(n => new { PRODUCT_NAME = n.Key.PRODUCT_NAME, sum_num = n.Sum(i => i.LOT_NUMBER) });
            var max_num = list.Max(x => x.sum_num);
            var max = list.Where(x => x.sum_num == max_num).Select(n => new { PRODUCT_NAME = n.PRODUCT_NAME }).ToList();

            return max.First().PRODUCT_NAME;
        }
    }
}


