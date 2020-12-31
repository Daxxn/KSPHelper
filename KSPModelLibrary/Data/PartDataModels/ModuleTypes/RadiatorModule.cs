using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class RadiatorModule : IModule, IELoadModule
   {
      public string Name { get; set; }
      public int MaxEnergyTransfer { get; set; }
      public double OverCoolFactor { get; set; }
      public bool IsCoreRadiator { get; set; }
      public ElectricalLoadModule Electrical { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "maxEnergyTransfer":
               MaxEnergyTransfer = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "overcoolFactor":
               OverCoolFactor = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "isCoreRadiator":
               IsCoreRadiator = ParseMethods.ParseBool(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static RadiatorModule BuildModule(BaseObject obj)
      {
         var newInst = new RadiatorModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         newInst.Electrical = ElectricalLoadModule.BuildModule(obj.FindChildByProperty("name", "ElectricCharge"));
         return newInst;
      }

      public double Load
      {
         get
         {
            return Electrical.Rate;
         }
      }
   }
}
