using System;
namespace demo.models
{
    public class UsedItem
    {
        public int ID { get; set; }
        public string WholesalerID { get; set; }
        public string Name { get; set; }
        public string Itemnumber { get; set; }
        public string ItemGroup { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
