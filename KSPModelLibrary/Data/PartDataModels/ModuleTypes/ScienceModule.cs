﻿using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class ScienceModule : ModuleFactory, IModule
   {
      public string Name { get; set; }
      public string ExperimentID { get; set; }
      public bool Rerunable { get; set; }
      public double TransmitScale { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "experimentID":
               ExperimentID = keyVal.Value;
               break;
            case "rerunnable":
               Rerunable = ParseMethods.ParseBool(keyVal.Value);
               break;
            case "xmitDataScalar":
               TransmitScale = ParseMethods.ParseDouble(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static ScienceModule BuildModule(BaseObject obj)
      {
         var newInst = new ScienceModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }
   }
}
