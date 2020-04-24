using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class IncomeClass
    {
        public Budget Budget { get; set; }
      
        public int IncomeId { get; set; }
        public int? Salary { get; set; }
        public int? InterestRate { get; set; }
        public int? OtherJob { get; set; }
        public int? OtherIncome { get; set; }
        public string DescriptionIncome { get; set; }
        public DateTime IncomeAddedOn { get; set; }      
        public int? TotalIncome
        {
            get
            {
                return Salary + InterestRate + OtherJob + OtherIncome;
            }
            set { }
        }




        public string DisplayTextIncomes
        {
            get
            {

                return $"The total Income is {Salary + InterestRate + OtherJob + OtherIncome}";
            }

        }

        public string DisplayTotalIncome
        {
            get
            {
                return $"£ { TotalIncome}";
            }
        }

        public string DisplayDateIncomes
        {
            get
            {
                return $"{IncomeAddedOn:Y} ";
            }
        }

        public ICollection<Budget> Budgets { get; set; }
    }
}
