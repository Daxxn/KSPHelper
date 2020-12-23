using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class RCSModule : IModule
   {
      public string Name { get; set; }
      public double Thrust { get; set; }
      public ResourceType ResourceName { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "thrusterPower":
               Thrust = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "resourceName":
               bool success = Enum.TryParse(keyVal.Value, out ResourceType result);
               if (success)
               {
                  ResourceName = result;
               }
               break;
            default:
               break;
         }
      }

      public static RCSModule BuildModule(BaseObject obj)
      {
         var newInst = new RCSModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }
   }
}
