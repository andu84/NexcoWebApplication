//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Income
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Income()
        {
            this.Budgets = new HashSet<Budget>();
            this.Budgets1 = new HashSet<Budget>();
        }
    
        public int IncomeId { get; set; }
        public Nullable<int> Salary { get; set; }
        public Nullable<int> InterestRate { get; set; }
        public Nullable<int> OtherJob { get; set; }
        public Nullable<int> OtherIncome { get; set; }
        public string DescriptionIncome { get; set; }
        public System.DateTime IncomeAddedOn { get; set; }
        public int TotalIncome { get; set; }
        public Nullable<int> Budget_BudgetId { get; set; }
        public Nullable<int> Budget_BudgetId1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Budget> Budgets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Budget> Budgets1 { get; set; }
        public virtual Budget Budget { get; set; }
        public virtual Budget Budget1 { get; set; }
    }
}
