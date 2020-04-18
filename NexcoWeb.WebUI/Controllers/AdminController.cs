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
    
    public class AdminController : Controller
    {
        private IIncomeRepository repositoryIncome;
        [Inject]
        public AdminController(IIncomeRepository repo)
        {
            repositoryIncome = repo;


        }
        public ActionResult IndexIncome()
        {
            return View(repositoryIncome.Incomes);
        }

        public ViewResult Create()
        {
            return View(new Income());
        }
        [HttpPost]
        public ActionResult Create(Income income)
        {
            if (ModelState.IsValid)
            {
                repositoryIncome.SaveIncome(income);
                TempData["message"] = string.Format("{0} has been added",
                    income.DescriptionIncome);
                return RedirectToAction("../Income/List");
            }
            else
            {
                return View(income);
            }
        }
        public ViewResult EditIncome(int incomeId)
        {
            Income income = repositoryIncome.Incomes.FirstOrDefault
                (p => p.IncomeId == incomeId);
            return View(income);
        }


        [HttpPost]
        public ActionResult EditIncome(Income income)
        {
            if (ModelState.IsValid)
            {
                repositoryIncome.SaveIncome(income);
                TempData["message"] = string.Format("{0} has been saved",
                    income.DescriptionIncome);
                return RedirectToAction("IndexIncome");
            }
            else
            {
                return View(income);
            }
        }
        [HttpPost]
        public ActionResult DeleteIncome(int IncomeId)
        {
            Income deletedIncome = repositoryIncome.DeleteIncome(IncomeId);
            if (deletedIncome != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deletedIncome.DescriptionIncome);
            }
            return RedirectToAction("IndexIncome");
        }


    }
}