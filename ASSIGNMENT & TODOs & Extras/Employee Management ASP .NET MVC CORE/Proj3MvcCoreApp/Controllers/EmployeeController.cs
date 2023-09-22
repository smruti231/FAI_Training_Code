using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proj3MvcCoreApp.Models;

namespace Proj3MvcCoreApp.Controllers
    {
    public class EmployeeController : Controller
        {
        private readonly IDBComponent component;
        public EmployeeController(IDBComponent component)
            {
                this.component = component;
            }
        public IActionResult Index()
            {
            var model = component.GetAllEmployees();
            return View(model);
            }

        public IActionResult OnShow(int id)
            {
            var model = component.GetEmployee(id);
            ViewBag.Dept = component.GetDept(model.DeptId);
            return View("View", model);
            }

        public IActionResult AddNew()
            {
            var model = new Employee();
            List<SelectListItem> list = new List<SelectListItem>();
            var depts = component.GetAllDepts();
            foreach(var dept in depts)
                {
                list.Add(new SelectListItem { Text = dept.DeptName, Value = dept.Id.ToString() });
                }
            ViewBag.Departments = list;
            return View(model);
            }
        [HttpPost]
        public IActionResult AddNew(Employee postedData) 
            {
            component.AddEmployee(postedData);
            return RedirectToAction("Index");
            }

        public IActionResult Edit(int id)
            {
            var employee = component.GetEmployee(id);
            if(employee == null)
                {
                return NotFound();
                }
            List<SelectListItem> list = new List<SelectListItem>();
            var depts = component.GetAllDepts();
            foreach(var dept in depts)
                {
                list.Add(new SelectListItem { Text = dept.DeptName,Value = dept.Id.ToString() });
                }
            ViewBag.Departments = list;
            return View(employee);
            }

        [HttpPost]
        public IActionResult Edit(Employee updateEmployee)
            {
            if(ModelState.IsValid)
                {
                try
                    {
                    component.UpdateEmployee(updateEmployee);
                    return RedirectToAction("Index");
                    }
                catch(Exception ex)
                    {
                    ModelState.AddModelError(string.Empty, "Error updating Employee" + ex.Message);
                    }
                }
            List<SelectListItem> list = new List<SelectListItem>();
            var depts = component.GetAllDepts();
            foreach(var dept in depts)
                {
                list.Add(new SelectListItem { Text = dept.DeptName, Value = dept.Id.ToString() });
                }
            ViewBag.Departments = list;
            return View(updateEmployee);
            }

        public IActionResult Delete(int id)
            {
            try
                {
                component.DeleteEmployee(id);
                return RedirectToAction("Index");
                }
            catch (Exception ex)
                {
                return RedirectToAction("Index", new { errorMessage = ex.Message });
                }
            }

        }
    }
