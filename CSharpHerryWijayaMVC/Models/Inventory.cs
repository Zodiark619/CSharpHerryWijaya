namespace CSharpHerryWijayaMVC.Models
{
    //public class Inventory
    //{

    //    public Dictionary<string,int> InventoryItems {  get; set; }
    //}
    //public class Inventory
    //{
    //    public List<Item> Items { get; set; } = new();
    //}
    //public class InventoryItem
    //{
    //    public Item Item { get; set; }
    //    public int Quantity { get; set; }
    //}
    public class Inventory
    {
        public int Id { get; set; }  // primary key
        public List<InventoryItem> Items { get; set; } = new();
    }

    public class InventoryItem
    {
        public int Id { get; set; }          // primary key
     public int InventoryId {  get; set; }
        public int ItemId { get; set; }      // FK to Item
        public int Quantity { get; set; }

  public Inventory Inventory { get; set; }
        public Item Item { get; set; }           // navigation
    }
}
