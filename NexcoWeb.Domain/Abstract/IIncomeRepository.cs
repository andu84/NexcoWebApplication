using NexcoWeb.Domain.Entities;
using System.Collections.Generic;

namespace NexcoWeb.Domain.Abstract
{
    public interface IIncomeRepository
    {
        IEnumerable<Income> Incomes { get; }

        void SaveIncome(Income income);
        Income DeleteIncome(int incomeId);
    }
}
