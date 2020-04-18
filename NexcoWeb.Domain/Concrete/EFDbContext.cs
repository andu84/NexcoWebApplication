using NexcoWeb.Domain.Entities;
using System.Data.Entity;

namespace NexcoWeb.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Budget> Budgets { get; set; }
    }
}
