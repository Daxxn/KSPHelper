using ConfigReaderLibrary;
using KSPModelLibrary.Data.PartDataModels.ResourceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class AlternatorModule : IModule, IEAltModule
   {
      public string Name { get; set; }
      public string EngineName { get; set; }
      public double ChargeRate { get; set; }
      public ElectricalResource Electrical { get; set; }

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
         if (obj.Children.Count == 1)
         {
            newAlt.Electrical = new ElectricalResource();
            foreach (var eleKV in obj.Children[0].Values)
            {
               newAlt.Electrical.SetProp(eleKV);
            }
         }
         return newAlt;
      }

      public double Charge
      {
         get
         {
            return Electrical.Rate;
         }
      }
   }
}
