using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class PropellantModule : IModule
   {
      public string Name { get; set; }
      public double Ratio { get; set; }
      public bool DrawGauge { get; set; }
      public double MinReserve { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "ratio":
               Ratio = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "DrawGauge":
               DrawGauge = ParseMethods.ParseBool(keyVal.Value);
               break;
            case "minResToLeave":
               MinReserve = ParseMethods.ParseDouble(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static PropellantModule BuildModule(BaseObject obj)
      {
         var newInst = new PropellantModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }
   }
}
