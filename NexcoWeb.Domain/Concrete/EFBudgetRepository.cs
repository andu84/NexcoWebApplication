using NexcoWeb.Domain.Abstract;
using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
