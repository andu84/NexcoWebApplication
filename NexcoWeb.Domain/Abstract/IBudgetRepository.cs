using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoWeb.Domain.Abstract
{
   public interface IBudgetRepository
    {
        IEnumerable<Budget> Budgets { get; }

        void SaveBudget(Budget budget);
        Budget DeleteBudget(int budgetId);
    }
}
