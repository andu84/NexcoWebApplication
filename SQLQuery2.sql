

SELECT Incomes.TotalIncome - Expenditures.TotalExpense FROM Incomes
INNER JOIN Expenditures ON
Incomes.IncomeAddedOn = Expenditures.ExpensesAddedOn
