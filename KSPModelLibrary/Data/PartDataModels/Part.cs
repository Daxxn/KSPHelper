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
               part.Cost = ParseMethods.ParseInt(prop);
            }
         },
         { "mass", (string prop, Part part) =>
            {
               part.Mass = ParseMethods.ParseDouble(prop);
            }
         },
         { "CrewCapacity", (string prop, Part part) =>
            {
               part.CrewCapacity = ParseMethods.ParseInt(prop);
            }
         },
         { "TechRequired", (string prop, Part part) =>
            {
               part.TechRequired = prop;
            }
         }
      };

      public static TModule Converter<TModule>(IModule module) where TModule : class
      {
         return module as TModule;
      }

      public string Title { get; set; }
      public string Name { get; set; }
      public string Category { get; set; }
      public int Cost { get; set; }
      public double Mass { get; set; }
      public double DryMass { get; set; }
      public double WetMass { get; set; }
      public int CrewCapacity { get; set; }
      public string TechRequired { get; set; }
      public List<IModule> Modules { get; set; } = new List<IModule>();
      public List<IResource> Resources { get; set; } = new List<IResource>();
   }
}
