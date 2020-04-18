using NexcoWeb.Domain.Entities;
using System.Collections.Generic;

namespace NexcoWeb.WebUI.Models
{
    public class BudgetsListViewModel
    {
        public IEnumerable<Income> Incomes { get; set; }
        public IEnumerable<Expenditure> Expenditures { get; set; }
        public IEnumerable<Budget> Budgets { get; set; }
        public string CurrentDescription { get; set; }
        public PagingInfo PagingInfo { get; set; }
        //public List<Income> IncomeList { get; set; }
        //public List<Expenditure> ExpenditureList { get; set; }
    }
}