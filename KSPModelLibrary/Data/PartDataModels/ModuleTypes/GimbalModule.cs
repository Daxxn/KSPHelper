using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class GimbalModule : IModule
   {
      public string Name { get; set; }
      public double GimbalRange { get; set; }
      public int GimbalResponseSpeed { get; set; }
      public bool UseGimbalResSpeed { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "gimbalRange":
               GimbalRange = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "gimbalResponseSpeed":
               GimbalResponseSpeed = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "useGimbalResponseSpeed":
               UseGimbalResSpeed = ParseMethods.ParseBool(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static GimbalModule BuildModule(BaseObject obj)
      {
         var newInst = new GimbalModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }
         return newInst;
      }
   }
}
