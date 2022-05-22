using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashV_API.Models
{
    [Table("TbMonths")]
    public class MonthModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
