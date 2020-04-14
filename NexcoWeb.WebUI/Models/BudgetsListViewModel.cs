using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexcoWeb.WebUI.Models
{
    public class BudgetsListViewModel
    {
        public IEnumerable<Income> Incomes { get; set; }
        public IEnumerable<Expenditure> Expenditures { get; set; }
        public IEnumerable<Budget> Budgets { get; set; }
        public string CurrentDescription { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}