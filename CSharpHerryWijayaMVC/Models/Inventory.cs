namespace CSharpHerryWijayaMVC.Models
{
    //public class Inventory
    //{

    //    public Dictionary<string,int> InventoryItems {  get; set; }
    //}
    public class Inventory
    {
        public List<Item> Items { get; set; } = new();
    }
    public class InventoryItem
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
