using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoWeb.Domain.Concrete
{
   public class EFDbContext : DbContext
    {
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
