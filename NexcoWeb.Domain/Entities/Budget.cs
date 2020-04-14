using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoWeb.Domain.Entities
{
    public class Budget
    {
        public int BudgetId { get; set; }
        public string DescriptionBudget { get; set; }
        public Income Income { get; set; }
        public Expenditure Expenditure { get; set; }

        

        public int? TotalBudget
        {

            get
            {

                return Income?.TotalIncome - Expenditure?.TotalExpense;

            }
            //set
            //{
            //    TotalBudget = value;
            //}

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
