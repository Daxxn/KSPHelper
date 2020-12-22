using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class PropellentModule : IModule
   {
      public string Name { get; set; }
      public double Ratio { get; set; }
      public bool DrawGauge { get; set; }

      public void SetProp(string prop, string value)
      {
         switch (prop)
         {
            case "ratio":
               Ratio = ParseMethods.ParseDouble(value);
               break;
            case "DrawGauge":
               DrawGauge = ParseMethods.ParseBool(value);
               break;
            default:
               break;
         }
      }
   }
}
