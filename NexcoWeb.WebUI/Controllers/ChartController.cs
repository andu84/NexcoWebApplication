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

        public ActionResult columnChart()
        {
            //List<Income> incomes = db.Incomes.ToList();
            //List<Expenditure> expenditures = db.Expenditures.ToList();

            return View();
        }
        public ActionResult VisualizeResults()
        {

            return Json(Result(), JsonRequestBehavior.AllowGet);
        }
        //public ActionResult VisualizeExpensesResults()
        //{
        //    return View();
        //}

        public ActionResult Result()
        {
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            List<Budget> budgets = db.Budgets.ToList();
            var query = from i in incomes
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
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
    }
}