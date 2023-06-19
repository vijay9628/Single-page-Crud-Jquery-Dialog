using Kolte_Technologies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kolte_Technologies.Controllers
{
    public class HomeController : Controller
    {
        vijayEntities db = new vijayEntities();
        public ActionResult Index()
        {
            var data = db.contacts.ToList();
            return View(data);
        }

        public JsonResult create()
        {
            return Json (JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult create(contact con)
        {
            db.contacts.Add(con);
            db.SaveChanges();
            return Json(con,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int id)
        {
            contact c = new contact();
            var data = db.contacts.Where(x=>x.Contactid==id).FirstOrDefault();
            c.Contactid = data.Contactid;
            c.name = data.name;
            c.city = data.city;
            c.email = data.email;
            c.dob = data.dob;
            c.contact_no = data.contact_no;
            return Json(c,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Edit(contact con)
        {
            if(con.Contactid >0)
            {
                contact c = new contact();
                db.Entry(con).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
           
            return Json(con);
        }
        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var data = db.contacts.Find(Id);
            db.contacts.Remove(data);
            db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}