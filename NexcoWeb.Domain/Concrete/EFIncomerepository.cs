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
    

        void IIncomeRepository.SaveIncome(Income income)
        {
            if (income.IncomeId == 0)
            {
                context.Incomes.Add(income);
            }
            else
            {
                Income dbEntry = context.Incomes.Find(income.IncomeId);
                if (dbEntry != null)
                {
                    dbEntry.DescriptionIncome = income.DescriptionIncome;
                    dbEntry.IncomeAddedOn = income.IncomeAddedOn;
                    dbEntry.InterestRate = income.InterestRate;
                    dbEntry.OtherIncome = income.OtherIncome;
                    dbEntry.OtherJob = income.OtherJob;
                    dbEntry.Salary = income.Salary;
                    dbEntry.TotalIncome = income.TotalIncome;
                }
            }
            context.SaveChanges();
        }
        public Income DeleteIncome(int IncomeId)
        {
            Income dbEntry = context.Incomes.Find(IncomeId);
            if (dbEntry != null)
            {
                context.Incomes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

