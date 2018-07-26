using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySuperMarket.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public class account
        {
            public string id { get; set; }
            public string password { get; set; }
        }

        public bool login_check(string para01, string para02)
        {
            List<account> list = new List<account>();
            list.Add(new account { id = "18817516109", password = "password" });
            list.Add(new account { id = "18916267650", password = "password" });
            list.Add(new account { id = "16547951234", password = "password" });
            list.Add(new account { id = "15534561234", password = "password" });
            list.Add(new account { id = "19115973682", password = "password" });
            list.Add(new account { id = "13325130013", password = "password" });
            list.Add(new account { id = "17110169852", password = "password" });
            list.Add(new account { id = "17862154368", password = "password" });

            foreach(var item in list)
            {
                if(item.id==para01)
                {
                    if(item.password==para02)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
    }
}