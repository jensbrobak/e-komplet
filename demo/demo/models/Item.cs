using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Demo.Models
{
    [Table("Items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string Itemnumber { get; set; }
        public string ItemGroup { get; set; }
        public double Price { get; set; }
        [OneToMany]
        public List<Wholesaler> WholesalerIDs { get; set; }
        public string ImageURL { get; set; }
    }
}
