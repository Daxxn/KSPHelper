using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class OutputResourceModule : IModule
   {
      public string Name { get; set; }
      public string ResourceName { get; set; }
      public double Ratio { get; set; }
      public double Rate { get; set; }
      public bool DumpExcess { get; set; }

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
            case "rate":
               Rate = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "DumpExcess":
               DumpExcess = ParseMethods.ParseBool(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static OutputResourceModule BuildModule(BaseObject obj)
      {
         var newInst = new OutputResourceModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }
   }
}
