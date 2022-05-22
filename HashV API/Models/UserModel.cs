using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HashV_API.Models
{
    [Table("TbUsers")]
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RecoveryCodes { get; set; }
        public bool FullAccess { get; set; }
        public DateTime? LastConnection { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
