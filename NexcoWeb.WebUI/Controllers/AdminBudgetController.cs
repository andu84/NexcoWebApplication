using NexcoWeb.Domain.Abstract;
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
        //
        
        public ActionResult IndexBudget()
        {
            
            return View(repositoryBudget.Budgets.OrderByDescending(p => p.BudgetId));
        }

     
    }
}
