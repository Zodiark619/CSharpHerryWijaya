namespace CSharpHerryWijayaMVC.Models
{
    public class PersonRequest
    {
    //   public Dictionary<string,double>? Data { get; set; }
    public List<string> Description { get; set; }
        public List<int> SelectedModules { get; set; } = new();
        public int NewModuleId { get; set; }
    }
}
