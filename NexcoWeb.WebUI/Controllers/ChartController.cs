using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using NexcoWeb.Domain.Concrete;
using NexcoWeb.Domain.Entities;
using NexcoWeb.WebUI.Models;

namespace NexcoWeb.WebUI.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public EFDbContext db = new EFDbContext();

        public ActionResult Result()
        {
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            List<Budget> budgets = db.Budgets.ToList();
            var minDate = DateTime.Now.AddMonths(-12);
            var query = from i in incomes
                        orderby i.IncomeAddedOn descending
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                        where i.IncomeAddedOn > minDate && i.IncomeAddedOn < DateTime.Now
                        select new Budget { Income = i, Expenditure = ex };                       
            return View(query);
        }

        public ActionResult ResultSalary()
        {
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            List<Budget> budgets = db.Budgets.ToList();
            var minDate = DateTime.Now.AddMonths(-12);
            var query = from i in incomes
                        orderby i.IncomeAddedOn descending
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                        where i.IncomeAddedOn > minDate && i.IncomeAddedOn < DateTime.Now
                        select new Budget { Income = i, Expenditure = ex };
            return View(query);
        }

        public ActionResult ResultPartialView()
        {
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            List<Budget> budgets = db.Budgets.ToList();
            var query = from i in incomes
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                        select new Budget { Income = i, Expenditure = ex };

            return View(query);
        }

        public ActionResult IncomeResults()
        {
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            List<Budget> budgets = db.Budgets.ToList();
            var minDate = DateTime.Now.AddMonths(-12);
            var query = from i in incomes
                        orderby i.IncomeAddedOn descending
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                        where i.IncomeAddedOn > minDate && i.IncomeAddedOn < DateTime.Now
                        select new Budget { Income = i, Expenditure = ex };
            return View(query);
        }

    }
}