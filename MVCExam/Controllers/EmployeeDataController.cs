using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeDataController : Controller
    {
        public ViewResult AllEmployees()
        {
            var context = new EmployeeDatabase();
            var model = context.EmpTables.ToList();
            return View(model);
        }
        public ViewResult Find(string id)
        {
            int empId = int.Parse(id);
            var context = new EmployeeDatabase();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpId == empId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Find(EmpTable emp)
        {
            var context = new EmployeeDatabase();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpId == emp.EmpId);
            model.Name = emp.Name;
            model.Address = emp.Address;
            model.Salary = emp.Salary;
            context.SaveChanges();
            return RedirectToAction("AllEmployees");
        }
        public ViewResult NewEmployee()
        {
            var model = new EmpTable();
            return View(model);
        }
        [HttpPost]
        public ActionResult NewEmployee(EmpTable emp)
        {
            try
            {
                var context = new EmployeeDatabase();
                context.EmpTables.Add(emp);
                context.SaveChanges();
                return RedirectToAction("AllEmployees");
            }
            catch
            {
                return RedirectToAction("AllEmployees");
            }
        }
        public ActionResult Delete(string id)
        {
            int empId = int.Parse(id);
            var context = new EmployeeDatabase();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpId == empId);
            context.EmpTables.Remove(model);
            context.SaveChanges();
            return RedirectToAction("AllEmployees");
        }
    }
}