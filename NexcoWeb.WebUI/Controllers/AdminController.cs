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

        //private IBudgetRepository repositoryBudget;


        //public AdminController(IBudgetRepository repo)
        //{
        //    repositoryBudget = repo;

        //}
        //public ActionResult IndexBudget()
        //{
        //    return View(repositoryBudget.Budgets);
        //}



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

        public ViewResult EditIncome(int incomeId)
        {
            Income income = repositoryIncome.Incomes.FirstOrDefault
                (p => p.IncomeId == incomeId);
            return View(income);
        }

        //private IExpenditureRepository repositoryExpenditure;

        //public AdminController(IExpenditureRepository repo)
        //{
        //    repositoryExpenditure = repo;

        //}

        //public ActionResult IndexExpenditure()
        //{

        //    return View(repositoryExpenditure.Expenditures);
        //}






    }
}