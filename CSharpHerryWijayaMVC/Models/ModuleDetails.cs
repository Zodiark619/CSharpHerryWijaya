namespace CSharpHerryWijayaMVC.Models
{
    public class ModuleDetails
    {
        public int Id { get; set; }
        public int ModuleId {  get; set; }
        public double ValueModifier {  get; set; }
        public string ValueModifierType {  get; set; }





        public Module Module { get; set; }
    }
}
