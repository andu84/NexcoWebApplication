using NexcoWeb.Domain.Abstract;
using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoWeb.Domain.Concrete
{
    public class EFIncomeRepository : IIncomeRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Income> Incomes
        {
            get { return context.Incomes; }
        }
    }
}

