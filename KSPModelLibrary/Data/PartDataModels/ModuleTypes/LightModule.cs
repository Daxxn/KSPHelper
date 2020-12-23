using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class LightModule : IModule
   {
      public string Name { get; set; }
      public double ElectricalLoad { get; set; }
      public bool UseResources { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "resourceAmount":
               ElectricalLoad = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "useResources":
               UseResources = ParseMethods.ParseBool(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static LightModule BuildModule(BaseObject obj)
      {
         var newInst = new LightModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }
   }
}
