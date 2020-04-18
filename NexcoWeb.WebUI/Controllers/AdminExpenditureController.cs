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
    
    public class AdminExpenditureController : Controller
    {
        private IExpenditureRepository repositoryExpenditure;
        [Inject]
        public AdminExpenditureController(IExpenditureRepository repo)
        {
            repositoryExpenditure = repo;

        }

        public ActionResult IndexExpenditure()
        {

            return View(repositoryExpenditure.Expenditures);
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
                TempData["message"] = string.Format("{0} has been saved",
                    expenditure.DescriptionExpenditure);
                return RedirectToAction("../Expenditure/List");
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
                TempData["message"] = string.Format("{0} has been saved",
                    expenditure.DescriptionExpenditure);
                return RedirectToAction("IndexExpenditure");
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
                TempData["message"] = string.Format("{0} was deleted",
                    deletedExpenditure.DescriptionExpenditure);
            }
            return RedirectToAction("IndexExpenditure");
        }
    }
}