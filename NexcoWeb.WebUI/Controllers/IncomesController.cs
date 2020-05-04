using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace NexcoWeb.WebUI.Controllers
{
    public class IncomesController : Controller
    {
        // GET: Incomes
        public ActionResult Index()
        {
            IEnumerable<Income> incomeList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Incomes").Result;
            incomeList = response.Content.ReadAsAsync<IEnumerable<Income>>().Result;
            return View(incomeList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            return View(new Income());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Incomes/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Income>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Income income)
        {

            // Web API call to insert new record into Incomes table
            // store the core results into response object
            // redirect to index action methods
            if (income.IncomeId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Incomes", income).Result;
                TempData["SuccessMessage2"] = string.Format("{0} has been saved Successfully", income.DisplayDateIncomes);
            }
           else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Incomes/"+income.IncomeId, income).Result;
                TempData["SuccessMessage2"] = string.Format("{0} has been Updated Successfully", income.DisplayDateIncomes);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete (int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Incomes/"+id.ToString()).Result;
            TempData["SuccessMessage2"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}