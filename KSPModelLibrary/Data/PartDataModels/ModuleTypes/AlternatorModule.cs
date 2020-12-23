using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class AlternatorModule : IModule
   {
      public string Name { get; set; }
      public string EngineName { get; set; }
      public double ChargeRate { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         if (keyVal.Key == "name")
         {
            Name = keyVal.Value;
         }
         else if (keyVal.Key == "engineName")
         {
            EngineName = keyVal.Value;
         }
         else if (keyVal.Key == "rate")
         {
            ChargeRate = ParseMethods.ParseDouble(keyVal.Value);
         }
      }

      public static AlternatorModule BuildModule(BaseObject obj)
      {
         var newAlt = new AlternatorModule();
         foreach (var kv in obj.Values)
         {
            newAlt.SetProp(kv);
         }
         return newAlt;
      }
   }
}
