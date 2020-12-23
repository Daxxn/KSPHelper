using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class AirIntakeModule : IModule
   {
      public AirIntakeModule()
      {
      }

      public string Name { get; set; }
      public double Area { get; set; }
      public double IntakeSpeed { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "area":
               Area = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "intakeSpeed":
               IntakeSpeed = ParseMethods.ParseDouble(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static AirIntakeModule BuildModule(BaseObject obj)
      {
         var newAirIntake = new AirIntakeModule();
         foreach (var kv in obj.Values)
         {
            newAirIntake.SetProp(kv);
         }
         return newAirIntake;
      }
   }
}
