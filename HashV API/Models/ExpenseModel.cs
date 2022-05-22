using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashV_API.Models
{
    [Table("TbExpenses")]
    public class ExpenseModel
    {
        public int ID { get; set; }
        public string Service { get; set; }
        public decimal Amount { get; set; }
        public int BudgetID { get; set; }
        public bool Paid { get; set; }
        public virtual BudgetModel Budget { get; set; }
    }
}
