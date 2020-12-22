using KSPModelLibrary.Data.PartDataModels.ModuleTypes;
using KSPModelLibrary.Data.PartDataModels.ResourceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels
{
   public class Part
   {
      //public static string[] SearchProps { get; } = new string[]
      //{
      //   "title", "category", "cost", "mass"
      //};

      public static Dictionary<string, Action<string, Part>> SearchProps = new Dictionary<string, Action<string, Part>>
      {
         { "name", (string name, Part part) => part.Name = name },
         { "title", (string prop, Part part) => part.Title = prop },
         { "category", (string prop, Part part) => part.Category = prop },
         { "cost", (string prop, Part part) =>
            {
               bool success = Int32.TryParse(prop, out int res);
               if (success) { part.Cost = res; }
            }
         },
         { "mass", (string prop, Part part) =>
            {
               bool success = Double.TryParse(prop, out double res);
               if (success) { part.Mass = res; }
            }
         }
      };

      public string Title { get; set; }
      public string Name { get; set; }
      public string Category { get; set; }
      public int Cost { get; set; }
      public double Mass { get; set; }
      public double DryMass { get; set; }
      public double WetMass { get; set; }
      public Dictionary<string, IModule> Modules { get; set; } = new Dictionary<string, IModule>();
      public Dictionary<string, IResource> Resources { get; set; } = new Dictionary<string, IResource>();
   }
}
