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

      public void SetProp(string prop, string value)
      {
         switch (prop)
         {
            case "PitchTorque":
               PitchTorque = ParseMethods.ParseInt(value);
               break;
            case "YawTorque":
               YawTorque = ParseMethods.ParseInt(value);
               break;
            case "RollTorque":
               RollTorque = ParseMethods.ParseInt(value);
               break;
            case "torqueResponseSpeed":
               TorqueResponseSpeed = ParseMethods.ParseDouble(value);
               break;
            default:
               break;
         }
      }
   }
}
