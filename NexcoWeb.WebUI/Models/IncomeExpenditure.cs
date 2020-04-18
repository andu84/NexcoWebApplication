using NexcoWeb.Domain.Entities;
using System.Collections.Generic;

namespace NexcoWeb.WebUI.Models
{
    public class IncomeExpenditure
    {
        public List<Income> IncomeList { get; set; }
        public List<Expenditure> ExpenditureList { get; set; }
    }
}