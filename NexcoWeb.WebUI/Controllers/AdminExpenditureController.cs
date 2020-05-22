using NexcoWeb.Domain.Abstract;
using NexcoWeb.Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NexcoWeb.WebUI.Controllers
{
    [Authorize]
    public class AdminExpenditureController : Controller
    {
        private IExpenditureRepository repositoryExpenditure;
        [Inject]
        public AdminExpenditureController(IExpenditureRepository repo)
        {
            repositoryExpenditure = repo;
        }
 
        public ViewResult Create()
        {
            return View(new Expenditure());
        }
        [HttpPost]
        public ActionResult Create(Expenditure expenditure)
        {
           
            if (ModelState.IsValid)
            {
             
                repositoryExpenditure.SaveExpenditure(expenditure);
                TempData["message"] = string.Format("The Expenses from {0} has been added",
                    expenditure.DisplayDateExpenses);             
                return RedirectToAction("../Expenditure/List","");
            }
            else
            {
                return View(expenditure);
            }
        }

        public ViewResult EditExpenditure(int expenditureId)
        {
            Expenditure expenditure = repositoryExpenditure.Expenditures.FirstOrDefault
                (p => p.ExpenditureId == expenditureId);
            return View(expenditure);
        }

        [HttpPost]
        public ActionResult EditExpenditure(Expenditure expenditure)
        {
            if (ModelState.IsValid)
            {
                repositoryExpenditure.SaveExpenditure(expenditure);
                TempData["message"] = string.Format("The Expenses from {0} has been updated",
                    expenditure.DisplayDateExpenses);
                return RedirectToAction("../Expenditure/List");
            }
            else
            {
                return View(expenditure);
            }
        }
       
        [HttpPost]
        public ActionResult DeleteExpenditure(int expenditureId)
        {
            Expenditure deletedExpenditure = repositoryExpenditure.DeleteExpenditure(expenditureId);
            if (deletedExpenditure != null)
            {
                TempData["message"] = string.Format("The Expenses from {0} was deleted",
                    deletedExpenditure.DisplayDateExpenses);
            }
            return RedirectToAction("../Expenditure/List");
        }
    }
}