using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashV_API.Models
{
    [Table("TbIncomings")]
    public class IncomingModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal GrossWage { get; set; }
        public decimal Discounts { get; set; }
        public int Year { get; set; }
        public int MonthID { get; set; }
        public int UserID { get; set; }
        public virtual MonthModel Month { get; set; }
        public virtual UserModel User { get; set; }
    }
}
