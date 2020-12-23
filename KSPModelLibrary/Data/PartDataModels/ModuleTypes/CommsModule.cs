using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class CommsModule : IModule
   {
      public string Name { get; set; }
      public AntennaType AntennaType { get; set; }
      public double PacketInterval { get; set; }
      public double PacketSize { get; set; }
      public double PacketCost { get; set; }
      public double AntennaPower { get; set; }
      public bool IsCombinable { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "antennaType":
               bool success = Enum.TryParse(keyVal.Value, out AntennaType result);
               if (success)
               {
                  AntennaType = result;
               }
               break;
            case "packetInterval":
               PacketInterval = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "packetSize":
               PacketSize = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "packetResourceCost":
               PacketCost = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "antennaPower":
               AntennaPower = ParseMethods.ParseDouble(keyVal.Value);
               break;
            case "antennaCombinable":
               IsCombinable = ParseMethods.ParseBool(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static CommsModule BuildModule(BaseObject obj)
      {
         var newComms = new CommsModule();
         foreach (var kv in obj.Values)
         {
            newComms.SetProp(kv);
         }
         return newComms;
      }
   }
}
