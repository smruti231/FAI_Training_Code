using Microsoft.AspNetCore.Mvc;
using Proj3MvcCoreApp.Models;

namespace Proj3MvcCoreApp.Controllers
    {
    public class HomeController : Controller
        {
        public string Index()
            {
            return "Hello SMRUTI";
            }

        public int AddedNumber()
            {
            return 1234;
            }
        //public object Employee()
        //    {
        //    return new
        //        {
        //        EmpId = 1,
        //        EmpName = "Test",
        //        EmpAddress = "Test Address"
        //        };

        public ViewResult Employee()
            {
            var model = new Employee()
                {
                Id = 1,
                Name = "Test",
                Address = "tstAddress",
                Salary = 34567,
                DeptId = 2
                };
            return View(model);
            }

            }
        }
