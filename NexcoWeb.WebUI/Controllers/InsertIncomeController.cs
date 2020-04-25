using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Async;


namespace NexcoWeb.WebUI.Controllers
{
    public class InsertIncomeController : Controller
    {
        // GET: InserrIncome
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Income ic)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:60191/api/income/");

            var insertIncome = hc.PostAsJsonAsync<Income>("income", ic);
            insertIncome.Wait();

            var saveIncome = insertIncome.Result;
            if (saveIncome.IsSuccessStatusCode)
            {
                ViewBag.message = ic.DescriptionIncome + "Is added successfully";
            }
            return View();
        }
    }
}