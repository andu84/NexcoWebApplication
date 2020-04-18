using NexcoWeb.Domain.Entities;
using System.Collections.Generic;

namespace NexcoWeb.Domain.Abstract
{
    public interface IBudgetRepository
    {
        IEnumerable<Budget> Budgets { get; }

        void SaveBudget(Budget budget);
        Budget DeleteBudget(int budgetId);
    }
}
