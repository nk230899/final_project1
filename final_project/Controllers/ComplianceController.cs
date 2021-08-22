using final_project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Controllers
{
    public class ComplianceController : Controller
    {

        private readonly IComplianceRepository complianceRepository;
        int EId = 1002;
        public ComplianceController(IComplianceRepository repos)
        {
            complianceRepository = repos;
        }
        public IActionResult Index(int Id)
        {
            EId = Id;
            return View(complianceRepository.MyRLs(EId));
        }

        
        public IActionResult Comments(int RLId)
        {
            return View(complianceRepository.MyComments(EId,RLId));
        }

        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, string comment)
        {
            try
            {
                complianceRepository.AddComment(comment, EId,id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
