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
    public class RLController : Controller
    {
        // GET: RLController
        private readonly IRLRepository _repos;

        public RLController(IRLRepository Repos)
        {
            _repos = Repos;
        }
        public ActionResult Index()
        {
            return View(_repos.GetRL());
        }

        // GET: RLController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RLController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RLController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RLView collection)
        {
            try
            {
                _repos.AddRL(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RLController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RLController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: RLController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RLController/Delete/5
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
