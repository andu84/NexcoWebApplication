using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class BudgetController : ApiController
    {
        public IHttpActionResult insertBudgets(BudgetClass ib)
        {
            NexcoAppEntities nd = new NexcoAppEntities();
            nd.Budgets.Add(new Budget()
            {
               BudgetId = ib.BudgetId,
               DescriptionBudget = ib.DescriptionBudget,
               BudgetAddedOn = ib.BudgetAddedOn
            });
            nd.SaveChanges();
            return Ok();
        }     
    }
}
