using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class EngineModule : IModule
   {
      public string Name { get; set; }
      public double MinThrust { get; set; }
      public double MaxThrust { get; set; }
      public EngineType EngineType { get; set; }
      public bool IsGimbal { get; set; }
      public List<PropellentModule> PropellentRequirements { get; set; }

      public void SetProp(string prop, string value)
      {
         switch (prop)
         {
            case "minThrust":
               MinThrust = ParseMethods.ParseDouble(value);
               break;
            case "maxThrust":
               MaxThrust = ParseMethods.ParseDouble(value);
               break;
            case "EngineType":
               bool success = Enum.TryParse(value, out EngineType result);
               if (success)
               {
                  EngineType = result;
               }
               break;
            default:
               break;
         }
      }
   }
}
