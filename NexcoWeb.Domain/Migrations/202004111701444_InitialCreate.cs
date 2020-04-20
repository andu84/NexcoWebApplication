﻿namespace NexcoWeb.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        BudgetId = c.Int(nullable: false, identity: true),
                        DescriptionBudget = c.String(),
                        TotalBudget = c.Int(),
                        Expenditure_ExpenditureId = c.Int(),
                        Expenditure_ExpenditureId1 = c.Int(),
                        Income_IncomeId = c.Int(),
                        Income_IncomeId1 = c.Int(),
                    })
                .PrimaryKey(t => t.BudgetId)
                .ForeignKey("dbo.Expenditures", t => t.Expenditure_ExpenditureId)
                .ForeignKey("dbo.Expenditures", t => t.Expenditure_ExpenditureId1)
                .ForeignKey("dbo.Incomes", t => t.Income_IncomeId)
                .ForeignKey("dbo.Incomes", t => t.Income_IncomeId1)
                .Index(t => t.Expenditure_ExpenditureId)
                .Index(t => t.Expenditure_ExpenditureId1)
                .Index(t => t.Income_IncomeId)
                .Index(t => t.Income_IncomeId1);
            
            CreateTable(
                "dbo.Expenditures",
                c => new
                    {
                        ExpenditureId = c.Int(nullable: false, identity: true),
                        Travel = c.Int(),
                        Entertaiment = c.Int(),
                        Auto = c.Int(),
                        HouseholdExpenses = c.Int(),
                        Clothing = c.Int(),
                        Loan = c.Int(),
                        OtherExpenses = c.Int(),
                        DescriptionExpenditure = c.String(),
                        ExpensesAddedOn = c.DateTime(nullable: false),
                        TotalExpense = c.Int(),
                        Budget_BudgetId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenditureId)
                .ForeignKey("dbo.Budgets", t => t.Budget_BudgetId)
                .Index(t => t.Budget_BudgetId);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        IncomeId = c.Int(nullable: false, identity: true),
                        Salary = c.Int(),
                        InterestRate = c.Int(),
                        OtherJob = c.Int(),
                        OtherIncome = c.Int(),
                        DescriptionIncome = c.String(),
                        IncomeAddedOn = c.DateTime(nullable: false),
                        TotalIncome = c.Int(),
                        Budget_BudgetId = c.Int(),
                    })
                .PrimaryKey(t => t.IncomeId)
                .ForeignKey("dbo.Budgets", t => t.Budget_BudgetId)
                .Index(t => t.Budget_BudgetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Budgets", "Income_IncomeId1", "dbo.Incomes");
            DropForeignKey("dbo.Budgets", "Income_IncomeId", "dbo.Incomes");
            DropForeignKey("dbo.Incomes", "Budget_BudgetId", "dbo.Budgets");
            DropForeignKey("dbo.Budgets", "Expenditure_ExpenditureId1", "dbo.Expenditures");
            DropForeignKey("dbo.Budgets", "Expenditure_ExpenditureId", "dbo.Expenditures");
            DropForeignKey("dbo.Expenditures", "Budget_BudgetId", "dbo.Budgets");
            DropIndex("dbo.Incomes", new[] { "Budget_BudgetId" });
            DropIndex("dbo.Expenditures", new[] { "Budget_BudgetId" });
            DropIndex("dbo.Budgets", new[] { "Income_IncomeId1" });
            DropIndex("dbo.Budgets", new[] { "Income_IncomeId" });
            DropIndex("dbo.Budgets", new[] { "Expenditure_ExpenditureId1" });
            DropIndex("dbo.Budgets", new[] { "Expenditure_ExpenditureId" });
            DropTable("dbo.Incomes");
            DropTable("dbo.Expenditures");
            DropTable("dbo.Budgets");
        }
    }
}
