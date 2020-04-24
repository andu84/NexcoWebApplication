using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class IncomeController : ApiController
    {
        public IHttpActionResult insertIncomes(IncomeClass ic)
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
