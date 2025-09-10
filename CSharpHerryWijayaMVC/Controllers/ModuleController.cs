using CSharpHerryWijayaMVC.Data;
using CSharpHerryWijayaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpHerryWijayaMVC.Controllers
{
    public class ModuleController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ModuleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var modules = dbContext.Module.Include(m => m.Details).ToList();
            var vm = new ModuleIndexViewModel { Modules = modules };
            return View(vm);
        }
        public void ModuleCategoryContains()
        {
            var moduleCategory = dbContext.ModuleCategory.ToList();
        }
        [HttpPost]
        public IActionResult AddModule([FromBody] PersonRequest request)
        {
            // Load all modules we care about
            var allModules = dbContext.Module
                .Include(m => m.Details)
                    .ThenInclude(d => d.ModuleStats)
                .Include(m => m.ModuleCategory)
                .Where(m => request.SelectedModules.Contains(m.Id) || m.Id == request.NewModuleId)
                .ToList();

            // If removing
            if (request.IsAdd == false)
            {
                // just drop the module id
                request.SelectedModules.Remove(request.NewModuleId);
            }
            else
            {
                // Add flow (your existing logic, category checks, etc.)
                var module = allModules.FirstOrDefault(m => m.Id == request.NewModuleId);
                if (module == null)
                    return Json(new { success = false, message = "Module not found" });

                if (request.SelectedModules.Contains(module.Id))
                    return Json(new { success = false, message = "Already selected" });

                // Category restriction check
                var selectedModules = dbContext.Module
                    .Include(m => m.ModuleCategory)
                    .Where(m => request.SelectedModules.Contains(m.Id))
                    .ToList();

                if (selectedModules.Any(sm => sm.ModuleCategory.Name == module.ModuleCategory.Name))
                    return Json(new { success = false, message = "Same category" });

                request.SelectedModules.Add(module.Id);
            }

            // Recalculate effects for all selected modules
            var selected = dbContext.Module
                .Include(m => m.Details)
                    .ThenInclude(d => d.ModuleStats)
                .Where(m => request.SelectedModules.Contains(m.Id))
                .ToList();

            var effects = new List<string>();
            var stats = new Dictionary<string, (double Value, string Type)>();
            var situational = new List<string>();

            foreach (var m in selected)
            {
                foreach (var detail in m.Details)
                {
                    if (stats.ContainsKey(detail.ModuleStats.Name))
                    {
                        var existing = stats[detail.ModuleStats.Name];
                        stats[detail.ModuleStats.Name] = (
                            existing.Value + detail.ValueModifier,
                            detail.ValueModifierType
                        );
                    }
                    else
                    {
                        if (detail.ValueModifierType == "situational")
                            situational.Add(m.Description);
                        else
                            stats[detail.ModuleStats.Name] = (
                                detail.ValueModifier,
                                detail.ValueModifierType
                            );
                    }
                }
            }

            foreach (var s in stats)
            {
                effects.Add(s.Value.Type == "percentage"
                    ? $"{s.Key} {s.Value.Value}%"
                    : $"{s.Key} {s.Value.Value}");
            }
            effects.AddRange(situational);

            request.SelectedModulesAjax = selected.Select(m => m.Name).ToList();
            request.EffectsAjax = effects;

            return Json(new { success = true, person = request });
        }

        //    [HttpPost]
        //    public IActionResult AddModule([FromBody] PersonRequest request)
        //    {

        //        var allModules = dbContext.Module
        //.Include(m => m.Details)
        //    .ThenInclude(d => d.ModuleStats)
        //.Include(m => m.ModuleCategory)
        //.Where(m => request.SelectedModules.Contains(m.Id) || m.Id == request.NewModuleId)
        //.ToList();

        //        var modulecategory = new List<string>();
        //        var moduledictionary = new Dictionary<string, (double Value, string Type)>();

        //        var module = allModules.FirstOrDefault(m => m.Id == request.NewModuleId);
        //        var existingModules = allModules.Where(m => request.SelectedModules.Contains(m.Id)).ToList();
        //        if (module == null)
        //            return Json(new { success = false, message = "Module not found" });

        //        if (request.SelectedModules.Contains(module.Id))
        //            return Json(new { success = false, message = "Already selected" });
        //        if (request.SelectedModules.Count() > 0)
        //        {
        //            var selectedModules = dbContext.Module
        //.Include(m => m.ModuleCategory)
        //.Where(m => request.SelectedModules.Contains(m.Id))
        //.ToList();

        //            foreach (var sm in selectedModules)
        //            {
        //                modulecategory.Add(sm.ModuleCategory.Name);
        //            }

        //        }
        //        if (modulecategory.Contains(module.ModuleCategory.Name))
        //            return Json(new { success = false, message = "Same category" });
        //        var moduledictionarySituational=new List<string>();
        //        // Add module effects to Person
        //        foreach (var m in existingModules.Append(module))
        //        {
        //            foreach (var detail in m.Details)
        //            {
        //                if (moduledictionary.ContainsKey(detail.ModuleStats.Name))
        //                {
        //                    // Get the existing tuple
        //                    var existing = moduledictionary[detail.ModuleStats.Name];

        //                    // Update Value, keep Type
        //                    moduledictionary[detail.ModuleStats.Name] = (
        //                        existing.Value + detail.ValueModifier,
        //                        detail.ValueModifierType
        //                    );
        //                }
        //                else
        //                {
        //                    // Add new tuple
        //                    if (detail.ValueModifierType == "situational") {
        //                        moduledictionarySituational.Add(m.Description);
        //                    }
        //                    else
        //                    {
        //                        moduledictionary[detail.ModuleStats.Name] = (
        //                            detail.ValueModifier,
        //                            detail.ValueModifierType
        //                        );
        //                    }

        //                }
        //            }
        //        }

        //         request.SelectedModules.Add(module.Id);

        //        var modulestatsAjax = new List<string>();
        //        foreach (var i in moduledictionary)
        //        {
        //            if (i.Value.Type == "percentage")
        //            {
        //                modulestatsAjax.Add($"{i.Key} {i.Value.Value}%");

        //            }
        //            else
        //            {
        //                modulestatsAjax.Add($"{i.Key} {i.Value.Value}");

        //            }
        //        }
        //        foreach(var i in moduledictionarySituational)
        //        {
        //            modulestatsAjax.Add(i);
        //        }
        //        request.EffectsAjax = modulestatsAjax;
        //        request.SelectedModulesAjax = allModules
        // .Where(m => request.SelectedModules.Contains(m.Id))
        // .Select(m => m.Name)
        // .ToList();
        //        return Json(new { success = true, person = request });
        //    }


    }
}
