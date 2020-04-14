using NexcoWeb.Domain.Abstract;
using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoWeb.Domain.Concrete
{
    public class EFExpenditureRepository : IExpenditureRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Expenditure> Expenditures
        {
            get { return context.Expenditures; }
        }
    }
}
