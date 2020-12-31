using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class ElectricalLoadModule : IModule, IElectrical
   {
      public string Name { get; set; }
      public double DrawRate { get; set; }
      public double Rate { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         if (keyVal.Key == "name")
         {
            Name = keyVal.Value;
         }
         else if (keyVal.Key == "rate")
         {
            Rate = ParseMethods.ParseDouble(keyVal.Value);
         }
         else if (keyVal.Key == "drawRate")
         {
            DrawRate = ParseMethods.ParseDouble(keyVal.Value);
         }
      }

      public static ElectricalLoadModule BuildModule(BaseObject obj)
      {
         var newInst = new ElectricalLoadModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }
   }
}
