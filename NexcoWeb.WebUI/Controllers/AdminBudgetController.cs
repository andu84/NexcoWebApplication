using NexcoWeb.Domain.Abstract;
using NexcoWeb.Domain.Entities;
using Ninject;
using System.Linq;
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

        public ViewResult Create()
        {
            return View(new Budget());
        }
        [HttpPost]
        public ActionResult Create(Budget budget)
        {
            if (ModelState.IsValid)
            {
                repositoryBudget.SaveBudget(budget);
                TempData["message"] = string.Format("{0} has been added",
                    budget.DescriptionBudget);
                return RedirectToAction("../Budget/List");
            }
            else
            {
                return View(budget);
            }
        }

        public ViewResult EditBudget(int budgetId)
        {
            Budget budget = repositoryBudget.Budgets.FirstOrDefault
                (p => p.BudgetId == budgetId);
            return View(budget);
        }

        [HttpPost]
        public ActionResult EditBudget(Budget budget)
        {
            if (ModelState.IsValid)
            {
                repositoryBudget.SaveBudget(budget);
                TempData["message"] = string.Format("{0} has been saved",
                    budget.DescriptionBudget);
                return RedirectToAction("IndexBudget");
            }
            else
            {
                return View(budget);
            }
        }

        [HttpPost]
        public ActionResult DeleteBudget(int BudgetId)
        {
            Budget deletedBudget = repositoryBudget.DeleteBudget(BudgetId);
            if (deletedBudget != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deletedBudget.DescriptionBudget);
            }
            return RedirectToAction("IndexBudget");
        }
    }
}
