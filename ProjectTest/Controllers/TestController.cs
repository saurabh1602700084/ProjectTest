using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTest.Controllers
{
    public class TestController : Controller
    {
        happyEntities objt = new happyEntities();
        // GET: Test
        public ActionResult Index(tblEmployee1 emp)
        {
            tblEmployee1 ep = new tblEmployee1();
            if (emp != null)
            {
                ep.Name = emp.Name;
                ep.Gender = emp.Gender;
                ep.city = emp.city;
                return View(ep);
            }
            
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult AddStudent(tblEmployee1 emp)
        {
            tblEmployee1 ep = new tblEmployee1();
            if (ModelState.IsValid)
            {
                ep.Name = emp.Name;
                ep.Gender = emp.Gender;
                ep.city = emp.city;
            }
            objt.tblEmployee1.Add(ep);
            objt.SaveChanges();
            
                return View();
        }

        public ActionResult Show()
        {
            List<tblEmployee1> res = new List<tblEmployee1>();
             res = objt.tblEmployee1.ToList();
            return View(res);
        }

        public ActionResult Delete(int EmployeeID)
        {
            var res = objt.tblEmployee1.Where(x => x.EmployeeID == EmployeeID).FirstOrDefault();
            objt.tblEmployee1.Remove(res);
            objt.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}