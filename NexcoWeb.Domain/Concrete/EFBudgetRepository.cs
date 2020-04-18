using NexcoWeb.Domain.Abstract;
using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace NexcoWeb.Domain.Concrete
{

    public class EFBudgetRepository : IBudgetRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Budget> Budgets
        {
            get { return context.Budgets; }
        }

        

        public void SaveBudget(Budget budget)
        {
            if (budget.BudgetId == 0)
            {
                context.Budgets.Add(budget);
            }
            else
            {
                Budget dbEntry = context.Budgets.Find(budget.BudgetId);
                if (dbEntry != null)
                {
                    dbEntry.DescriptionBudget = budget.DescriptionBudget;
                    dbEntry.TotalBudget = budget.TotalBudget;
                    dbEntry.TotalIncome = budget.TotalIncome;
                    dbEntry.TotalExpense = budget.TotalExpense;
                    
                }
            }
            context.SaveChanges();
        }
        public Budget DeleteBudget(int BudgetId)
        {
            Budget dbEntry = context.Budgets.Find(BudgetId);
            if (dbEntry != null)
            {
                context.Budgets.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
