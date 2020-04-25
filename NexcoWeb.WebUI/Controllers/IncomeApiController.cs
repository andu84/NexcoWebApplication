using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NexcoWeb.Domain;
using NexcoWeb.Domain.Entities;



namespace NexcoWeb.WebUI.Controllers
{
    public class IncomeApiController : ApiController
    {
        public IHttpActionResult insertIncomes(Income ic)
        {
            NexcoAppEntities nd = new NexcoAppEntities();
            nd.Incomes.Add(new Income()
            {
                Salary = ic.Salary,
                InterestRate = ic.InterestRate,
                OtherIncome = ic.OtherIncome,
                OtherJob = ic.OtherJob,
                IncomeAddedOn = ic.IncomeAddedOn,
                DescriptionIncome = ic.DescriptionIncome
            });
            nd.SaveChanges();
            return Ok();
        }
    }
}
