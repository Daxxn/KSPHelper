using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class ElectricalLoadModule : IModule
   {
      public string Name { get; set; }
      public double DrawRate { get; set; }
      //public double HybernationMultiplier { get; set; }

      public void SetProp(string prop, string value)
      {
         switch (prop)
         {
            case "rate":
               DrawRate = ParseMethods.ParseDouble(value);
               break;
            //case "hasHibernation":
            //   HybernationMultiplier
            default:
               break;
         }
      }
   }
}
