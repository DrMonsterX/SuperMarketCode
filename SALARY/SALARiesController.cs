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
    public class SALARiesController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: SALARies
        public ActionResult Index()
        {
            var sALARY = db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE);
            return View(sALARY.ToList());
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
                var list = db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE.EMPLOYEE_NAME, SALARY_DATE = n.SALARY_DATE, SALARY = n.EMPLOYEE.SALARY, EXPENSE_ID = n.EXPENSE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            string value = "";
            if (para02 != null)
            {
                value = para02;
            }
            else
            {
                var list = db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE.EMPLOYEE_NAME, SALARY_DATE = n.SALARY_DATE, SALARY = n.EMPLOYEE.SALARY, EXPENSE_ID = n.EXPENSE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
            }

            if (search_type.Equals("0"))
            {
                var list = db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE).Where(n => n.EMPLOYEE_ID == value).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE.EMPLOYEE_NAME, SALARY_DATE = n.SALARY_DATE, SALARY = n.EMPLOYEE.SALARY, EXPENSE_ID = n.EXPENSE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("1"))
            {
                var list = db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE).Where(n => n.EMPLOYEE.EMPLOYEE_NAME == value).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE.EMPLOYEE_NAME, SALARY_DATE = n.SALARY_DATE, SALARY = n.EMPLOYEE.SALARY, EXPENSE_ID = n.EXPENSE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("2"))
            {
                DateTime myTime = Convert.ToDateTime(value);
                var list = db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE).Where(n => n.SALARY_DATE == myTime).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE.EMPLOYEE_NAME, SALARY_DATE = n.SALARY_DATE, SALARY = n.EMPLOYEE.SALARY, EXPENSE_ID = n.EXPENSE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            else if (search_type.Equals("3"))
            {
                int intA;
                int.TryParse(value, out intA);
                var list = db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE).Where(n => n.EMPLOYEE.SALARY == intA).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE.EMPLOYEE_NAME, SALARY_DATE = n.SALARY_DATE, SALARY = n.EMPLOYEE.SALARY, EXPENSE_ID = n.EXPENSE_ID });
                return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);

            }

            var list1 = db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE.EMPLOYEE_NAME, SALARY_DATE = n.SALARY_DATE, SALARY = n.EMPLOYEE.SALARY, EXPENSE_ID = n.EXPENSE_ID });
            return Json(new { code = 0, msg = "", count = 1000, data = list1 }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult advancedSearch(string para01, string para02, string para03, string para04, string para05, string para06)
        {
            string id = para01;
            string name = para02;
            string salary_low = para03;
            string salary_high = para04;
            string date = para05;
            string expense_id = para06;

            int low;
            int.TryParse(salary_low, out low);
            int high;
            int.TryParse(salary_high, out high);

            var list = from e in db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE) select e;
            if (id != "!!")
            {
                list = list.Where(s => s.EMPLOYEE_ID == id);
            }
            if (name != "!!")
            {
                list = list.Where(s => s.EMPLOYEE.EMPLOYEE_NAME == name);
            }
            if (date != "!!")
            {
                DateTime myTime = Convert.ToDateTime(date);
                list = list.Where(s => s.SALARY_DATE == myTime);
            }
            if (salary_low != "!!")
            {
                list = list.Where(s => s.EMPLOYEE.SALARY > low);
            }
            if (salary_high != "!!")
            {
                list = list.Where(s => s.EMPLOYEE.SALARY < high);
            }
            if (expense_id != "!!")
            {
                list = list.Where(s => s.EXPENSE_ID == expense_id);
            }

            var list2 = list.Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE.EMPLOYEE_NAME, SALARY_DATE = n.SALARY_DATE, SALARY = n.EMPLOYEE.SALARY, EXPENSE_ID = n.EXPENSE_ID });
            return Json(new { code = 0, msg = "", count = 1000, data = list2 });
        }


        [HttpPost]
        public string test(string para01, string para02, string para03)
        {
            string employee_id = para01;
            string expense_id = para02;

            SALARY mySalary = db.SALARY.Find(expense_id, employee_id);
            if (mySalary != null)
            {
                return "1";
            }
            EXPENSE myExpense = db.EXPENSE.Find(expense_id);
            if (myExpense == null)
            {
                return "2";
            }
            EMPLOYEE myEmployee = db.EMPLOYEE.Find(employee_id);
            if (myEmployee == null)
            {
                return "3";
            }
            return "4";
        }
        [HttpPost]
        public JsonResult Create(string para01, string para02, string para03)
        {
            string employee_id = para01;
            string expense_id = para02;
            string date = para03;

            SALARY newSalary = new SALARY();
            newSalary.EXPENSE_ID = expense_id;
            newSalary.EMPLOYEE_ID = employee_id;
            newSalary.SALARY_DATE = Convert.ToDateTime(date);

            EMPLOYEE myEmployee = db.EMPLOYEE.Find(employee_id);
            EXPENSE myExpense = db.EXPENSE.Find(expense_id);
            myExpense.MONEY = myExpense.MONEY + myEmployee.SALARY;
            db.Entry(myExpense).State = EntityState.Modified;

            db.SALARY.Add(newSalary);
            db.SaveChanges();

            var list = db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE.EMPLOYEE_NAME, SALARY_DATE = n.SALARY_DATE, SALARY = n.EMPLOYEE.SALARY, EXPENSE_ID = n.EXPENSE_ID });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getJson()
        {
            var list = db.SALARY.Include(s => s.EMPLOYEE).Include(s => s.EXPENSE).Select(n => new { EMPLOYEE_ID = n.EMPLOYEE_ID, EMPLOYEE_NAME = n.EMPLOYEE.EMPLOYEE_NAME, SALARY_DATE = n.SALARY_DATE, SALARY = n.EMPLOYEE.SALARY, EXPENSE_ID = n.EXPENSE_ID });
            return Json(new { code = 0, msg = "", count = 1000, data = list }, JsonRequestBehavior.AllowGet);
        }
    }
}
