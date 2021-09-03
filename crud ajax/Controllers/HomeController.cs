using crud_ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud_ajax.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        EmployeeDB empDB1= new EmployeeDB();
        public JsonResult List()
        {
            return Json(empDB1.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Employee emp)
        {
            return Json(empDB1.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB1.ListAll().Find(x => x.employeeid.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Employee emp)
        {
            return Json(empDB1.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB1.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }

}