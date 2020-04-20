namespace NexcoWeb.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Budgets", "TotalIncome", c => c.Int());
            AddColumn("dbo.Budgets", "TotalExpense", c => c.Int());
            AddColumn("dbo.Expenditures", "Food", c => c.Int());
            AddColumn("dbo.Expenditures", "Budget_BudgetId1", c => c.Int());
            AddColumn("dbo.Incomes", "Budget_BudgetId1", c => c.Int());
            AlterColumn("dbo.Incomes", "TotalIncome", c => c.Int(nullable: false));
            CreateIndex("dbo.Expenditures", "Budget_BudgetId1");
            CreateIndex("dbo.Incomes", "Budget_BudgetId1");
            AddForeignKey("dbo.Expenditures", "Budget_BudgetId1", "dbo.Budgets", "BudgetId");
            AddForeignKey("dbo.Incomes", "Budget_BudgetId1", "dbo.Budgets", "BudgetId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "Budget_BudgetId1", "dbo.Budgets");
            DropForeignKey("dbo.Expenditures", "Budget_BudgetId1", "dbo.Budgets");
            DropIndex("dbo.Incomes", new[] { "Budget_BudgetId1" });
            DropIndex("dbo.Expenditures", new[] { "Budget_BudgetId1" });
            AlterColumn("dbo.Incomes", "TotalIncome", c => c.Int());
            DropColumn("dbo.Incomes", "Budget_BudgetId1");
            DropColumn("dbo.Expenditures", "Budget_BudgetId1");
            DropColumn("dbo.Expenditures", "Food");
            DropColumn("dbo.Budgets", "TotalExpense");
            DropColumn("dbo.Budgets", "TotalIncome");
            DropTable("dbo.Users");
        }
    }
}
