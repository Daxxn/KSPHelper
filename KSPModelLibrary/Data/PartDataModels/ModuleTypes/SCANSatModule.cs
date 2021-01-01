using ConfigReaderLibrary;
using KSPModelLibrary.Data.PartDataModels.ResourceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class SCANSatModule : IModule, IELoadModule
   {
      public string Name { get; set; }
      public int SensorType { get; set; }
      public double FOV { get; set; }
      public int MinAltitude { get; set; }
      public int MaxAltitude { get; set; }
      public int BestAltitude { get; set; }
      public string ScanName { get; set; }
      public bool RequireLight { get; set; }
      public ElectricalResource Electrical { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "sensorType":
               SensorType = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "fov":
               FOV = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "min_alt":
               MinAltitude = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "max_alt":
               MaxAltitude = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "best_alt":
               BestAltitude = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "scanName":
               ScanName = keyVal.Value;
               break;
            case "requireLight":
               RequireLight = ParseMethods.ParseBool(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static SCANSatModule BuildModule(BaseObject obj)
      {
         var newInst = new SCANSatModule();
         foreach (var kv in obj.Values)
         {
            newInst.SetProp(kv);
         }

         if (obj.Children.Count > 0)
         {
            var elecChild = obj.GetChild("RESOURCE");
            if (elecChild != null)
            {
               newInst.Electrical = ResourceFactory.BuildResource<ElectricalResource>(elecChild);
               //foreach (var elecKV in elecChild.Values)
               //{
               //   newInst.Electrical.SetProp(elecKV);
               //}
            }
         }
         return newInst;
      }

      public double Load
      {
         get
         {
            return Electrical.Rate;
         }
      }
   }
}
