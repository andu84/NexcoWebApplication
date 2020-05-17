using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoWeb.Domain.Entities
{
    public class Expenditure
    {
        //The id for Expenditure
        public int ExpenditureId { get; set; }

        //Categorys of Expenditures
        public int? Travel { get; set; }
        public int? Food { get; set; }
        public int? Entertaiment { get; set; }
        public int? Auto { get; set; }
        public int? HouseholdExpenses { get; set; }
        public int? Clothing { get; set; }
        public int? Loan { get; set; }
        public int? OtherExpenses { get; set; }
        public string DescriptionExpenditure { get; set; }
        [Required(ErrorMessage = "Period is required")]
        public DateTime ExpensesAddedOn { get; set; }
        // Get and set the amount of total expenses
        public int? TotalExpense
        {
            get
            {
               return TotalExpense = Travel + Entertaiment + Food + Auto + HouseholdExpenses + Clothing + Loan + OtherExpenses;             
            }
            set{ }
        }
        // Get the amount of total expenses to be displayed in string format
      
        public string DisplayTotalExpenses
        {
            get
            {
                return $"£ {TotalExpense} ";
            }
        }
        // get the ExpensesAddedOn and set in string fromat like February 2019
        public string DisplayDateExpenses
        {
            get
            {
                return $"{ExpensesAddedOn:Y} ";
            }
            set  { }
        }

        //The Budgets associated with this expenditures
        //public ICollection<Budget> Budgets { get; }
    }
}
