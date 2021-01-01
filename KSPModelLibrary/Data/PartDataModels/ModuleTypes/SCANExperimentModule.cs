using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class SCANExperimentModule : IModule
   {
      public string Name { get; set; }
      public string ExperimentType { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "experimentType":
               ExperimentType = keyVal.Value;
               break;
            default:
               break;
         }
      }

      public static SCANExperimentModule BuildModule(BaseObject obj)
      {
         var newInst = new SCANExperimentModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }
   }
}
