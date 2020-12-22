using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class GimbalModule : IModule
   {
      public string Name { get; set; }
      public double GimbalRange { get; set; }

      public void SetProp(string prop, string value)
      {
         switch (prop)
         {
            case "gimbalRange":
               GimbalRange = ParseMethods.ParseDouble(value);
               break;
            default:
               break;
         }
      }
   }
}
