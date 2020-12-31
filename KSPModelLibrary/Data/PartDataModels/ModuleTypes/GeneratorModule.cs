using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class GeneratorModule : IModule, IElectrical, IEGenModule
   {
      public string Name { get; set; } = "ModuleGenerator";
      public bool IsAlwaysActive { get; set; }
      public List<OutputResourceModule> ResourceOutput { get; set; } = new List<OutputResourceModule>();

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "isAlwaysActive":
               IsAlwaysActive = ParseMethods.ParseBool(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static GeneratorModule BuildModule(BaseObject obj)
      {
         var newInst = new GeneratorModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         foreach (var mod in obj.GetChildren("OUTPUT_RESOURCE"))
         {
            newInst.ResourceOutput.Add(OutputResourceModule.BuildModule(mod));
         }
         return newInst;
      }

      public double Charge
      {
         get
         {
            double output = 0;
            if (ResourceOutput.Count > 0)
            {
               foreach (var resOutput in ResourceOutput)
               {
                  if (resOutput.Name == "ElectricCharge")
                  {
                     output += resOutput.Rate;
                  }
               }
            }
            return output;
         }
      }
   }
}
