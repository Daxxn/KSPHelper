using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class ResourceConverterModule : IModule, IEGenModule, IELoadModule
   {
      public string Name { get; set; }
      public string ConverterName { get; set; }
      public double FillAmount { get; set; }
      public bool GeneratesHeat { get; set; }
      public bool UseEngineerBonus { get; set; }
      public List<InputResourceModule> ResourceInputs { get; set; } = new List<InputResourceModule>();
      public List<OutputResourceModule> ResourceOutputs { get; set; } = new List<OutputResourceModule>();

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "ConverterName":
               ConverterName = keyVal.Value;
               break;
            case "FillAmount":
               FillAmount = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "GeneratesHeat":
               GeneratesHeat = ParseMethods.ParseBool(keyVal.Value);
               break;
            case "UseSpecialistBonus":
               UseEngineerBonus = ParseMethods.ParseBool(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static ResourceConverterModule BuildModule(BaseObject obj)
      {
         var newInst = new ResourceConverterModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }

         var resourceReqs = obj.GetChildren("INPUT_RESOURCE");
         foreach (var req in resourceReqs)
         {
            newInst.ResourceInputs.Add(InputResourceModule.BuildModule(req));
         }

         resourceReqs = obj.GetChildren("OUTPUT_RESOURCE");
         foreach (var req in resourceReqs)
         {
            newInst.ResourceOutputs.Add(OutputResourceModule.BuildModule(req));
         }

         return newInst;
      }

      public double Charge
      {
         get
         {
            double output = 0;
            if (ResourceOutputs.Count > 0)
            {
               foreach (var resOut in ResourceOutputs)
               {
                  if (resOut.ResourceName == "ElectricCharge")
                  {
                     if (resOut.Rate > 0)
                     {
                        output += resOut.Rate;
                     }
                     else
                     {
                        output += resOut.Ratio;
                     }
                  }
               }
            }
            return output;
         }
      }

      public double Load
      {
         get
         {
            double output = 0;
            if (ResourceInputs != null)
            {
               foreach (var resInput in ResourceInputs)
               {
                  if (resInput.ResourceName == "ElectricCharge")
                  {
                     output += resInput.Ratio;
                  }
               }
            }
            return output;
         }
      }
   }
}
