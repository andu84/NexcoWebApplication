using NexcoWeb.Domain.Entities;
using System.Collections.Generic;

namespace NexcoWeb.Domain.Abstract
{
    public interface IExpenditureRepository
    {
        IEnumerable<Expenditure> Expenditures { get; }

        void SaveExpenditure(Expenditure expenditure);
        Expenditure DeleteExpenditure(int expenditureId);
    }
}
