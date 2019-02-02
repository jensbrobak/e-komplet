using System;
using SQLite;

namespace Demo.Models
{
    [Table("Wholesalers")]
    public class Wholesaler
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string LogoURL { get; set; }
    }
}
