using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class InputResourceModule : IModule
   {
      public string Name { get; set; }
      public string ResourceName { get; set; }
      public double Ratio { get; set; }
      public FlowMode FlowMode { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "ResourceName":
               ResourceName = keyVal.Value;
               break;
            case "Ratio":
               Ratio = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "FlowMode":
               bool success = Enum.TryParse(keyVal.Value, out FlowMode result);
               if (success)
               {
                  FlowMode = result;
               }
               break;
            default:
               break;
         }
      }

      public static InputResourceModule BuildModule(BaseObject obj)
      {
         var newInst = new InputResourceModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }
   }
}
