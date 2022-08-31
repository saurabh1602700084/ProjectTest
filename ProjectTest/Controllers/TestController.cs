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
                List<tblEmployee1> res = objt.tblEmployee1.ToList();
                ViewBag.EmpList = res;
                return View(ep);
            }
           
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult AddStudent(tblEmployee1 emp)
        {
            tblEmployee1 ep = new tblEmployee1();

            if (emp.EmployeeID==0)
            {
                if (ModelState.IsValid)
                {
                    ep.Name = emp.Name;
                    ep.Gender = emp.Gender;
                    ep.city = emp.city;
                    ep.EmployeeID = emp.EmployeeID;
                }

                objt.tblEmployee1.Add(ep);
                objt.SaveChanges();

                
            }
            else
            {
                var emp2 = objt.tblEmployee1.Where(m => m.EmployeeID == emp.EmployeeID).FirstOrDefault();
                emp2.Name = emp.Name;
                emp2.Gender = emp.Gender;
                emp2.city = emp.city;
                emp2.EmployeeID = emp.EmployeeID;

                objt.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult Show()
        {
             List<tblEmployee1> res = new List<tblEmployee1>();
            res = objt.tblEmployee1.ToList();
           // ViewBag.EmpList = res;
            return RedirectToAction("Index");
            // return View();
        }

        [HttpPost]
        public ActionResult Edit(string EmployeeID)
        {
            var emp2 = objt.tblEmployee1.Where(x => x.EmployeeID.ToString() ==EmployeeID).FirstOrDefault();
           

               objt.SaveChanges();
            //return RedirectToAction("Show");
            return PartialView("Edit", emp2);
        }



        public ActionResult Delete(string EmployeeID)
        {
            var res = objt.tblEmployee1.Where(x => x.EmployeeID.ToString() == EmployeeID).FirstOrDefault();
            objt.tblEmployee1.Remove(res);
            objt.SaveChanges();
            return RedirectToAction("Show");
        }

        public ActionResult Details(string EmployeeID)
        {
            var res1 = objt.tblEmployee1.Where(x => x.EmployeeID.ToString() == EmployeeID).FirstOrDefault();
            return PartialView("Details",res1);
        }

        //public JsonResult Details(string EmployeeID)
        //{
        //    var res1 = objt.tblEmployee1.Where(x => x.EmployeeID.ToString() == EmployeeID).FirstOrDefault();
        //    return Json(res1, JsonRequestBehavior.AllowGet);

        //}

    }
}