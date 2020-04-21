using NexcoWeb.Domain.Concrete;
using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
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
            return View(query);
        }
        public ActionResult Statistics()
        {
            EFDbContext db = new EFDbContext();
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            var result = from i in incomes
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                        select new Budget { Income = i, Expenditure = ex };
            return View(result);
        }
    }
}