using final_project.Models;
using final_project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace final_project.Controllers
{
    [Authorize]
    public class EmployeepageController : Controller
    {
       
        private readonly IEmployeeRepsoitory _employeeRepository;
        public EmployeepageController(IEmployeeRepsoitory db)
        {
            _employeeRepository = db;
        }

        
        public ActionResult Index()
        {
            
            return View(_employeeRepository.GetEmployees());
        }

        // GET: EmployeepageController/Details/5
        /*public ActionResult Details(int id)
        {
            return View();
        }*/

        // GET: EmployeepageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeepageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeView collection)
        {
            try
            {
                _employeeRepository.AddEmployee(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeepageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeepageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeView collection)
        {
            try
            {
                _employeeRepository.EditEmployee(collection, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        // POST: EmployeepageController/Delete/5
       /* 
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
               // _employeeRepository.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
