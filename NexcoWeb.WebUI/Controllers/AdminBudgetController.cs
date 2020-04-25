using NexcoWeb.Domain.Abstract;
using NexcoWeb.Domain.Concrete;
using NexcoWeb.Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace NexcoWeb.WebUI.Controllers
{
    [Authorize]
    
    public class AdminBudgetController : Controller
    {
        private IBudgetRepository repositoryBudget;
        [Inject]
        public AdminBudgetController(IBudgetRepository repo)
        {
            repositoryBudget = repo;


        }


        public ActionResult IndexBudget()
        {

            return View(repositoryBudget.Budgets.OrderByDescending(p => p.BudgetId));

        }


        public ActionResult DetailBudget()
        {
            EFDbContext db = new EFDbContext();
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            var query = from i in incomes
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                        select new Budget { Income = i, Expenditure = ex };
            var Allincomes = from i in incomes
                             join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                             select new { ex.TotalExpense, i.TotalIncome, i.IncomeId, i.IncomeAddedOn };
            foreach (var item in Allincomes)
                db.Budgets.Add(new Budget()
                { TotalIncome = item.TotalIncome, TotalExpense = item.TotalExpense, BudgetAddedOn = item.IncomeAddedOn });
            db.SaveChanges();
            return View(query);
        }
       

        
        
    }
}
