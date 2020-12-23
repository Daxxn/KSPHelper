using ConfigReaderLibrary;
using KSPModelLibrary.Data.PartDataModels.ResourceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class ReactionWheelModule : IModule
   {
      public string Name { get; set; }

      public int PitchTorque { get; set; }
      public int YawTorque { get; set; }
      public int RollTorque { get; set; }
      public double TorqueResponseSpeed { get; set; }
      public ElectricalLoadModule Electrical { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "PitchTorque":
               PitchTorque = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "YawTorque":
               YawTorque = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "RollTorque":
               RollTorque = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "torqueResponseSpeed":
               TorqueResponseSpeed = ParseMethods.ParseDouble(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static ReactionWheelModule BuildModule(BaseObject obj)
      {
         var newInst = new ReactionWheelModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         newInst.Electrical = new ElectricalLoadModule();
         var elec = obj.GetChild("RESOURCE");
         foreach (var kv in elec.Values)
         {
            newInst.Electrical.SetProp(kv);
         }
         return newInst;
      }
   }
}
