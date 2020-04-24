﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ExpenditureClass
    {
        public Budget Budget { get; set; }    
        public int ExpenditureId { get; set; }
        public int? Travel { get; set; }
        public int? Food { get; set; }
        public int? Entertaiment { get; set; }
        public int? Auto { get; set; }
        public int? HouseholdExpenses { get; set; }
        public int? Clothing { get; set; }
        public int? Loan { get; set; }
        public int? OtherExpenses { get; set; }
        public string DescriptionExpenditure { get; set; }
       
        public DateTime ExpensesAddedOn { get; set; }
        public int? TotalExpense
        {
            get
            {
                return TotalExpense = Travel + Entertaiment + Food + Auto + HouseholdExpenses + Clothing + Loan + OtherExpenses;

            }
            set
            {

            }
        }
        public string DisplayTextExpenses
        {
            get
            {

                return $"The total Expenses is {TotalExpense} ";
            }

        }
        public string DisplayTotalExpenses
        {
            get
            {
                return $"£ {TotalExpense} ";
            }
        }
        public string DisplayDateExpenses
        {
            get
            {
                return $"{ExpensesAddedOn:Y} ";
            }
        }


        public ICollection<Budget> Budgets { get; set; }
    }
}