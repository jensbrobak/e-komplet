using System;
namespace demo.models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Itemnumber { get; set; }
        public string ItemGroup { get; set; }
        public double Price { get; set; }
        public int WholesalerIDs { get; set; }
        public string ImageURL { get; set; }
    }
}
