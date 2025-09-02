namespace CSharpHerryWijayaMVC.Models
{
    //public class Research
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public TimeSpan Duration {  get; set; }
    //    public Dictionary<string, int> Requirements { get; set; }
    //}
    //public class ResearchRequirement
    //{
    //    public Item Item { get; set; }
    //    public int Quantity { get; set; }  // how many of this item is required
    //}
    public class ResearchRequirement
    {
        public int Id { get; set; }          // primary key for the table
        public int ResearchId { get; set; }  // FK to Research
        public int ItemId { get; set; }      // FK to Item
        public int Quantity { get; set; }    // how many are required

        public Research Research { get; set; } // navigation
        public Item Item { get; set; }         // navigation
    }
    public class Research
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public List<ResearchRequirement> Requirements { get; set; } = new();
    }
}
