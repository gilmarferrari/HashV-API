using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashV_API.Models
{
    [Table("TbPasswords")]
    public class PasswordModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
    }
}
