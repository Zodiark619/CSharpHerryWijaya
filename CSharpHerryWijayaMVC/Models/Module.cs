namespace CSharpHerryWijayaMVC.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // navigation property (one module → many details)
        public List<ModuleDetails> Details { get; set; } 
        public string Description { get; set; }
        public int ModuleCategoryId {  get; set; }
        public ModuleCategory ModuleCategory { get; set; }
        public int? DescendantId {  get; set; }
        public Descendant Descendant { get; set; }
    }
}
