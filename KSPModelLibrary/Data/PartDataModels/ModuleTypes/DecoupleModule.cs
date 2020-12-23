using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class DecoupleModule : IModule
   {
      public string Name { get; set; }
      public double EjectionForce { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         if (keyVal.Key == "name")
         {
            Name = keyVal.Value;
         }
         else if (keyVal.Key == "ejectionForce")
         {
            EjectionForce = ParseMethods.ParseDouble(keyVal.Value);
         }
      }

      public static DecoupleModule BuildModule(BaseObject obj)
      {
         var newDecupler = new DecoupleModule();
         foreach (var kv in obj.Values)
         {
            newDecupler.SetProp(kv);
         }
         return newDecupler;
      }
   }
}
