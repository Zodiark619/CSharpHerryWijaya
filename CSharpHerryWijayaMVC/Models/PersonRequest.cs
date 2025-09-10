namespace CSharpHerryWijayaMVC.Models
{
    public class PersonRequest
    {
    //   public Dictionary<string,double>? Data { get; set; }
    public List<string> EffectsAjax { get; set; }
        public List<int> SelectedModules { get; set; } = new();
        public int NewModuleId { get; set; }

        // Add this
        public List<string> SelectedModulesAjax { get; set; } = new();
        // 👇 Add this
        public bool IsAdd { get; set; }
    }
}
