using NexcoWeb.Domain.Abstract;
using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
     
        public void SaveExpenditure(Expenditure expenditure)
        {
            if (expenditure.ExpenditureId == 0)
            {
                context.Expenditures.Add(expenditure);
            }
            else
            {
                Expenditure dbEntry = context.Expenditures.Find(expenditure.ExpenditureId);
                if (dbEntry != null)
                {
                    dbEntry.DescriptionExpenditure = expenditure.DescriptionExpenditure;
                    dbEntry.Entertaiment = expenditure.Entertaiment;
                    dbEntry.Food = expenditure.Food;
                    dbEntry.HouseholdExpenses = expenditure.HouseholdExpenses;
                    dbEntry.Loan = expenditure.Loan;
                    dbEntry.OtherExpenses = expenditure.OtherExpenses;
                    dbEntry.Travel = expenditure.Travel;
                    dbEntry.Auto = expenditure.Auto;
                    dbEntry.ExpensesAddedOn = expenditure.ExpensesAddedOn;
                    dbEntry.Clothing = expenditure.Clothing;
                }
            }
            context.SaveChanges();
        }
        public Expenditure DeleteExpenditure(int expenditureId)
        {
            Expenditure dbEntry = context.Expenditures.Find(expenditureId);
            if (dbEntry != null)
            {
                context.Expenditures.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
