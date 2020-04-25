using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexcoWeb.WebUI.Models
{
    public class IncomeExpenditure
    {
        public List<Income> IncomeList { get; set; }
        public List<Expenditure> ExpenditureList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}