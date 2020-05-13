using NexcoWeb.Domain.Abstract;
using NexcoWeb.Domain.Concrete;
using NexcoWeb.Domain.Entities;
using NexcoWeb.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;

namespace NexcoWeb.WebuI.Controllers
{
    public class IncomeExpenditureController : Controller
    {
        private readonly IBudgetRepository repository;
        public int PageSize = 4;

        public IncomeExpenditureController(IBudgetRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string description, int page = 1)
        {
            BudgetsListViewModel model = new BudgetsListViewModel
            {
                Budgets = repository.Budgets
                .Where(p => description == null || p.DescriptionBudget == description)
                .OrderByDescending(p => p.BudgetId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    PerPage = PageSize,
                    Total = repository.Budgets.Count()
                },
                CurrentDescription = description
            };

            return View(model);
        }
        // GET: IncomeExpenditure
        public EFDbContext db = new EFDbContext();
        
        public ActionResult Index()
        {
        List<Income> incomes = db.Incomes.ToList();
        List<Expenditure> expenditures = db.Expenditures.ToList();
        List<Budget> budgets = db.Budgets.ToList();
        var query = from i in incomes
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                        select new Budget { Income = i, Expenditure = ex };
          
            return View(query);
        }
        public ActionResult SaveDb()
        {
            
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            List<Budget> budgets = db.Budgets.ToList();
            var Allincomes =
                            from i in incomes
                            join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                            select new { ex.TotalExpense, i.TotalIncome, i.IncomeId, i.IncomeAddedOn };

            foreach (var item in Allincomes)
            {

                db.Budgets.Add(new Budget()
                { TotalIncome = item.TotalIncome, TotalExpense = item.TotalExpense, BudgetAddedOn = item.IncomeAddedOn });

            }
            db.SaveChanges();
            //Response.Redirect(Request.Url.ToString(), false);
            return View();
        }
        public ActionResult LastThreeMounts()
        {        
            List<Income> incomes = db.Incomes.ToList();
            List<Expenditure> expenditures = db.Expenditures.ToList();
            var minDate = DateTime.Now.AddMonths(-3);
            var result = from i in incomes
                        join ex in expenditures on i.IncomeAddedOn equals ex.ExpensesAddedOn
                        where i.IncomeAddedOn > minDate && i.IncomeAddedOn < DateTime.Now 
                        select new Budget { Income = i, Expenditure = ex };
            
            return View(result);
        }
    }
}