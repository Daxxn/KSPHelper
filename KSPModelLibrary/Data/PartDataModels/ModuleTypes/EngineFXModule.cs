using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class EngineFXModule : IModule
   {
      public string Name { get; set; }
      public string EngineID { get; set; }
      public bool ThrottleLocked { get; set; }
      public int MinThrust { get; set; }
      public int MaxThrust { get; set; }
      public int HeatProduction { get; set; }
      public double EngineAccelSpeed { get; set; }
      public double EngineDecelSpeed { get; set; }
      public EngineType EngineType { get; set; }
      public double EngineSpoolIdle { get; set; }
      public double EngineSpoolTime { get; set; }
      public List<PropellantModule> PropellentRequirements { get; set; } = new List<PropellantModule>();

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "engineID":
               EngineID = keyVal.Value;
               break;
            case "throttleLocked":
               ThrottleLocked = ParseMethods.ParseBool(keyVal.Value);
               break;
            case "minThrust":
               MinThrust = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "maxThrust":
               MaxThrust = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "heatProduction":
               HeatProduction = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "engineAccelerationSpeed":
               EngineAccelSpeed = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "engineDecelerationSpeed":
               EngineDecelSpeed = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "EngineType":
               bool success = Enum.TryParse(keyVal.Value, out EngineType result);
               if (success)
               {
                  EngineType = result;
               }
               break;
            case "engineSpoolIdle":
               EngineSpoolIdle = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "engineSpoolTime":
               EngineSpoolTime = ParseMethods.ParseDouble(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static EngineFXModule BuildModule(BaseObject obj)
      {
         var newInst = new EngineFXModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         foreach (var p in obj.GetChildren("PROPELLANT"))
         {
            var newProp = new PropellantModule();
            foreach (var pProp in p.Values)
            {
               newProp.SetProp(pProp);
            }
            newInst.PropellentRequirements.Add(newProp);
         }
         return newInst;
      }
   }
}
