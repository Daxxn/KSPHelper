using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class ResourceHarvesterModule : IModule
   {
      public string Name { get; set; }
      public double Efficiency { get; set; }
      public double EfficiencyBonus { get; set; }
      public bool GeneratesHeat { get; set; }
      public bool UseEngineerBonus { get; set; }
      public bool UseEngineerHeatBonus { get; set; }
      public double EngineerBonusBase { get; set; }
      public double EngineerEfficiencyFactor { get; set; }
      public double EngineerHeatFactor { get; set; }
      public List<InputResourceModule> ResourceInputs { get; set; } = new List<InputResourceModule>();

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            default:
               break;
         }
      }

      public static ResourceHarvesterModule BuildModule(BaseObject obj)
      {
         var newInst = new ResourceHarvesterModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }
   }
}
