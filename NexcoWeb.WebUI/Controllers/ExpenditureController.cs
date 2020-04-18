using NexcoWeb.Domain.Abstract;
using NexcoWeb.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace NexcoWeb.WebUI.Controllers
{
    
    public class ExpenditureController : Controller
    {
        private readonly IExpenditureRepository repository;
        public int PageSize = 4;

        public ExpenditureController(IExpenditureRepository repo)
        {
            repository = repo;
        }
        // GET: Expenditure
        public ViewResult List(string description, int page = 1)
        {
            ExpendituresListViewModel model = new ExpendituresListViewModel
            {
                Expenditures = repository.Expenditures
                    .Where(p => description == null || p.DescriptionExpenditure == description)
                    .OrderByDescending(p => p.ExpensesAddedOn)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    PerPage = PageSize,
                    Total = repository.Expenditures.Count()
                },
                CurrentDescription = description
            };
            return View(model);
        }




    }
}

