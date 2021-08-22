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
    public class DepartmentPageController : Controller
    {

        private readonly IDepartmentRepository _departmentrepository;
        public DepartmentPageController(IDepartmentRepository departmentRepository)
        {
            _departmentrepository = departmentRepository;
        }
       
        // GET: DepartmentPageController
        public ActionResult Index()
        {
           
            return View(_departmentrepository.GetDepartments());
        }

       
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentPageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentView collection)
        {
            try
            {
                _departmentrepository.AddDepartment(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentPageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentPageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentView collection)
        {
            try
            {
                _departmentrepository.EditDepartment(collection, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentPageController/Delete/5
        public ActionResult Delete(int id)
        {
            _departmentrepository.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

        // POST: DepartmentPageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
