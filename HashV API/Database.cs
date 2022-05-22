using HashV_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HashV_API
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) { }
        public DbSet<BudgetModel> Budgets { get; set; }
        public DbSet<MonthModel> Months { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<YearModel> Years { get; set; }
        public DbSet<ExpenseModel> Expenses { get; set; }
        public DbSet<IncomingModel> Incomings { get; set; }
        public DbSet<PasswordModel> Passwords { get; set; }
        public DbSet<SoftwareModel> Softwares { get; set; }
        public DbSet<VersionModel> Versions { get; set; }
    }
}
