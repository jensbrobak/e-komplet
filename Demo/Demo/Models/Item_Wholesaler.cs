using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Demo.Models
{
    [Table("Items_Wholesalers")]
    public class Item_Wholesaler
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Item))]
        public string Itemnumber { get; set; }
        [ForeignKey(typeof(Wholesaler))]
        public int WholesalerID { get; set; }
    }
}
