using NexcoWeb.Domain.Abstract;
using NexcoWeb.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace NexcoWeb.WebUI.Controllers
{
    
    public class BudgetController : Controller
    {
        private readonly IBudgetRepository repository;
        public int PageSize = 4;

        public BudgetController(IBudgetRepository repo)
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

    }
}


