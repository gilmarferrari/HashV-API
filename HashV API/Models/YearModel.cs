using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashV_API.Models
{
    [Table("TbYears")]
    public class YearModel
    {
        public int ID { get; set; }
        public int Year { get; set; }
    }
}
