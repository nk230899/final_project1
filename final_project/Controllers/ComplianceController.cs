using final_project.Models;
using final_project.Models.ViewModels;
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
        //int EId;
        
        public ComplianceController(IComplianceRepository repos)
        {
            complianceRepository = repos;
           // EId = 1002;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EmployeeLogin cred)
        {
            try
            {bool LoggedIn = complianceRepository.Validate(cred.EId, cred.password);
                if (LoggedIn)
                {
                    TempData["EId"] = cred.EId.ToString();
                    return RedirectToAction("List");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public IActionResult List()
        {
            int EId;
            if (TempData.ContainsKey("EId")) {
                EId = Int32.Parse(TempData.Peek("EId").ToString());
               
            }
            else return RedirectToAction("Index");

            return View(complianceRepository.MyRLs(EId));
        }

        
        public IActionResult Comments(int RLId)
        {
            TempData["RLId"] = RLId.ToString();
            int EId;
            if (TempData.ContainsKey("EId"))
            {
                EId = Int32.Parse(TempData.Peek("EId").ToString());
               
            }
            else return RedirectToAction("Index");

            return View(complianceRepository.MyComments(EId,RLId));
        }

        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentView comment)
        {
            try
            {
                int Reg=0;
                int Emp = 0;
                if (TempData.ContainsKey("RLId"))
                    Reg = Int32.Parse(TempData.Peek("RLId").ToString());
                if (TempData.ContainsKey("EId"))
                    Emp = Int32.Parse(TempData.Peek("EId").ToString());
                complianceRepository.AddComment(comment.Cmnt, Emp,Reg);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
