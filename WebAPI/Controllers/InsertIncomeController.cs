using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    public class InsertIncomeController : Controller
    {
        // GET: InserrIncome
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(IncomeClass ic)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/income/");

            var insertIncome = hc.PostAsJsonAsync <IncomeClass>("income", ic);
            insertIncome.Wait();
           
            var saveIncome = insertIncome.Result;
            if(saveIncome.IsSuccessStatusCode)
            {
                ViewBag.message = ic.DescriptionIncome + "Is added successfully";
            }
            return View();
        }
    }
}