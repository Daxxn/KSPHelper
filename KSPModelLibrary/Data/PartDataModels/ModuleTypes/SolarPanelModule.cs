using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class SolarPanelModule : IModule, IEGenModule
   {
      public string Name { get; set; }
      public double ChargeRate { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         if (keyVal.Key == "name")
         {
            Name = keyVal.Value;
         }
         else if (keyVal.Key == "chargeRate")
         {
            ChargeRate = ParseMethods.ParseDouble(keyVal.Value);
         }
      }

      public static SolarPanelModule BuildModule(BaseObject obj)
      {
         var newInst = new SolarPanelModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }

      public double Charge
      {
         get
         {
            return ChargeRate;
         }
      }
   }
}
