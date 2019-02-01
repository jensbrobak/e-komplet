using System;
using System.Collections.Generic;
using SQLite;

namespace demo.models
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
        //public IEnumerable<Wholesaler> WholesalerIDs { get; set; } - sql query
        public string ImageURL { get; set; }
    }
}
