using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class BudgetClass
    {
        public int BudgetId { get; set; }
        public string DescriptionBudget { get; set; }
        public Income Income { get; set; }
        public Expenditure Expenditure { get; set; }
        public int? TotalIncome { get; set; }
        public int? TotalExpense { get; set; }
        public DateTime BudgetAddedOn { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Expenditure> Expenditures { get; set; }



        public int? TotalBudget
        {

            get
            {

                return TotalIncome - TotalExpense;

            }
            set
            {

            }

        }



        public string DisplayTextBudget
        {
            get
            {

                return $"The available Budget is {TotalBudget}";
            }

        }
    }
}
