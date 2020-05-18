namespace NexcoWeb.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Budgets", "Expenditure_ExpenditureId", "dbo.Expenditures");
            DropForeignKey("dbo.Budgets", "Income_IncomeId", "dbo.Incomes");
            DropIndex("dbo.Budgets", new[] { "Expenditure_ExpenditureId1" });
            DropIndex("dbo.Budgets", new[] { "Income_IncomeId1" });
            DropColumn("dbo.Budgets", "Expenditure_ExpenditureId");
            DropColumn("dbo.Budgets", "Income_IncomeId");
            RenameColumn(table: "dbo.Budgets", name: "Expenditure_ExpenditureId1", newName: "Expenditure_ExpenditureId");
            RenameColumn(table: "dbo.Budgets", name: "Income_IncomeId1", newName: "Income_IncomeId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Budgets", name: "Income_IncomeId", newName: "Income_IncomeId1");
            RenameColumn(table: "dbo.Budgets", name: "Expenditure_ExpenditureId", newName: "Expenditure_ExpenditureId1");
            AddColumn("dbo.Budgets", "Income_IncomeId", c => c.Int());
            AddColumn("dbo.Budgets", "Expenditure_ExpenditureId", c => c.Int());
            CreateIndex("dbo.Budgets", "Income_IncomeId1");
            CreateIndex("dbo.Budgets", "Expenditure_ExpenditureId1");
            AddForeignKey("dbo.Budgets", "Income_IncomeId", "dbo.Incomes", "IncomeId");
            AddForeignKey("dbo.Budgets", "Expenditure_ExpenditureId", "dbo.Expenditures", "ExpenditureId");
        }
    }
}
