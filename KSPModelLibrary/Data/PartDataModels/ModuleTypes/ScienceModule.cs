using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class ScienceModule : ModuleFactory, IModule
   {
      public string Name { get; set; }
      public string ExperimentID { get; set; }
      public bool Rerunable { get; set; }
      public double TransmitScale { get; set; }

      public void SetProp(string prop, string value)
      {
         switch (prop)
         {
            case "name":
               Name = prop;
               break;
            case "experimentID":
               ExperimentID = prop;
               break;
            case "rerunnable":
               Rerunable = ParseMethods.ParseBool(value);
               break;
            case "xmitDataScalar":
               TransmitScale = ParseMethods.ParseDouble(value);
               break;
            default:
               break;
         }
      }
   }
}
