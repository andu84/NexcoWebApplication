using NexcoWeb.Domain.Abstract;
using NexcoWeb.Domain.Entities;
using NexcoWeb.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NexcoWeb.WebUI.Controllers
{
    
    public class IncomeController : Controller
    {
        private readonly IIncomeRepository repository;
        public int PageSize = 4;

        public IncomeController(IIncomeRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string description, int page = 1) 
        { 
           IncomesListViewModel model = new IncomesListViewModel
           { 
            Incomes = repository.Incomes
                    .Where(p => description == null || p.DescriptionIncome == description)
                    .OrderByDescending(p => p.IncomeAddedOn)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    PerPage = PageSize,
                    Total = repository.Incomes.Count()
                },
                CurrentDescription = description
           };
            return View(model);
        }

    }
}