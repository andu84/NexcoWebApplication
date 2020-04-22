using NexcoWeb.Domain.Concrete;
using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NexcoWeb.WebUI.Controllers
{
    public class IncomeExpenditureController : Controller
    {
        // GET: IncomeExpenditure
        public ActionResult Index()
        {
            EFDbContext db = new EFDbContext();
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            var query = from i in incomes
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                        select new Budget { Income = i, Expenditure = ex };
            var Allincomes = from i in incomes
                             join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                             select new { ex.TotalExpense, i.TotalIncome , i.IncomeId, i.IncomeAddedOn};
            foreach (var item in Allincomes)
                db.Budgets.Add(new Budget()
                { TotalIncome = item.TotalIncome, TotalExpense = item.TotalExpense, BudgetAddedOn = item.IncomeAddedOn });
            db.SaveChanges();
            return View(query);
        }
        public ActionResult LastThreeMounts()
        {
            EFDbContext db = new EFDbContext();
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            var minDate = DateTime.Now.AddMonths(-3);
            var result = from i in incomes
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                        where i.IncomeAddedOn > minDate
                        select new Budget { Income = i, Expenditure = ex };
            
            return View(result);
        }
    }
}