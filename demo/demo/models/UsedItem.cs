using System;
using SQLite;

namespace demo.models
{
    [Table("UsedItems")]
    public class UsedItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int WholesalerID { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string Itemnumber { get; set; }
        public string ItemGroup { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
