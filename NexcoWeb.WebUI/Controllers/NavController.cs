using NexcoWeb.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NexcoWeb.WebUI.Controllers
{
    public class NavController : Controller
    {

        private IBudgetRepository repository;

        public NavController(IBudgetRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string description = null)
        {
            ViewBag.SelectedDescription = description;
            IEnumerable<string> descriptions = repository.Budgets
                .Select(x => x.DescriptionBudget)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(descriptions) ;
        }
        public PartialViewResult MainMenu(string description = null)
        {
            ViewBag.SelectedDescription = description;
            IEnumerable<string> descriptions = repository.Budgets
                .Select(x => x.DescriptionBudget)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(descriptions);
        }
        public PartialViewResult CharMenu(string description = null)
        {
            ViewBag.SelectedDescription = description;
            IEnumerable<string> descriptions = repository.Budgets
                .Select(x => x.DescriptionBudget)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(descriptions);
        }
    }
}