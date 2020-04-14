using NexcoWeb.Domain.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NexcoWeb.WebUI.Controllers
{
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

            return View(repositoryBudget.Budgets);
        }
    }
}