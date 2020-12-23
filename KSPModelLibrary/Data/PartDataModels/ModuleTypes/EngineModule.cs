using ConfigReaderLibrary;
using System;
using System.Collections.Generic;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class EngineModule : IModule
   {
      public string Name { get; set; }
      public double MinThrust { get; set; }
      public double MaxThrust { get; set; }
      public EngineType EngineType { get; set; }
      public bool IsGimbal { get; set; }
      //public AlternatorModule Alternator { get; set; }
      public List<PropellantModule> PropellentRequirements { get; set; } = new List<PropellantModule>();

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "minThrust":
               MinThrust = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "maxThrust":
               MaxThrust = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "EngineType":
               bool success = Enum.TryParse(keyVal.Value, out EngineType result);
               if (success)
               {
                  EngineType = result;
               }
               break;
            default:
               break;
         }
      }

      public static EngineModule BuildModule(BaseObject obj)
      {
         var newInst = new EngineModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         //var newAlt = AlternatorModule.BuildModule(obj.FindChildByProperty("name", ModuleType.ModuleAlternator.ToString()));
         foreach (var p in obj.GetChildren("PROPELLANT"))
         {
            var newProp = PropellantModule.BuildModule(p);
            if (newProp != null)
            {
               newInst.PropellentRequirements.Add(newProp);
            }
         }
         return newInst;
      }
   }
}
