using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonDefteriCodeFirst.DataAccessLayer;

namespace TelefonDefteriCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            KayitTakipDBContext db = new KayitTakipDBContext();
            
            return View(db.Customers.ToList());
        }
    }
}