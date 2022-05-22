using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashV_API.Models
{
    [Table("TbVersions")]
    public class VersionModel
    {
        public int ID { get; set; }
        public string Version { get; set; }
        public bool Required { get; set; }
    }
}
