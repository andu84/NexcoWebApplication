using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ExpenditureController : ApiController
    {
        public IHttpActionResult insertExpenditures(ExpenditureClass ec)
        {
            NexcoAppEntities nd = new NexcoAppEntities();
            nd.Expenditures.Add(new Expenditure()
            {
                ExpenditureId = ec.ExpenditureId,
                Entertaiment = ec.Entertaiment,
                Auto = ec.Auto,
                Clothing = ec.Clothing,
                ExpensesAddedOn = ec.ExpensesAddedOn,
                DescriptionExpenditure = ec.DescriptionExpenditure,
                Food = ec.Food,
                Loan = ec.Loan,
                HouseholdExpenses = ec.HouseholdExpenses,
                OtherExpenses = ec.OtherExpenses,
                Travel = ec.Travel,
            });
            nd.SaveChanges();
            return Ok();
        }
    }
}
