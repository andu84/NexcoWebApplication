using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoWeb.Domain.Entities
{
    public class Income
    {
        //The Id of income
        public int IncomeId { get; set; }
        //category of Incomes
        public int? Salary { get; set; }
        public int? InterestRate { get; set; }
        public int? OtherJob { get; set; }
        public int? OtherIncome { get; set; }
        public string DescriptionIncome { get; set; }
        public DateTime IncomeAddedOn { get; set; }
        [Required(ErrorMessage = "Period is required")]
        // Get and set the amount of total incomes
        public int? TotalIncome
        {
            get
            {
                return Salary + InterestRate + OtherJob + OtherIncome;
            }
            set { }
        }
        // Get the amount of total incomes to be displayed in string format
        public string DisplayTotalIncome
        {
            get
            {
                return $"£ { TotalIncome}";
            }
        }
        // get the IncomeAddedOn and set in string format like February 2019
        public string DisplayDateIncomes
        {
            get
            {
                return $"{IncomeAddedOn:Y} ";
            }
            set
            {

            }
        }

        public ICollection<Budget> Budgets { get; }
    }
}
