using System.ComponentModel.DataAnnotations.Schema;

namespace HashV_API.Models
{
    [Table("TbBudgets")]
    public class BudgetModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int MonthID { get; set; }
        public int UserID { get; set; }
        public virtual MonthModel Month { get; set; }
        public virtual UserModel User { get; set; }
    }
}
