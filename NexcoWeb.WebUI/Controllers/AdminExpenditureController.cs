using NexcoWeb.Domain.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NexcoWeb.WebUI.Controllers
{
    public class AdminExpenditureController : Controller
    {
        private IExpenditureRepository repositoryExpenditure;
        [Inject]
        public AdminExpenditureController(IExpenditureRepository repo)
        {
            repositoryExpenditure = repo;

        }

        public ActionResult IndexExpenditure()
        {

            return View(repositoryExpenditure.Expenditures);
        }


    }
}