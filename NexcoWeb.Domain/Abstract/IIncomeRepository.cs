using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoWeb.Domain.Abstract
{
    public interface IIncomeRepository
    {
        IEnumerable<Income> Incomes { get;  }
    }
}
