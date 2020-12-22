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

      public void SetProp(string prop, string value)
      {
         switch (prop)
         {
            case "antennaType":
               bool success = Enum.TryParse(value, out AntennaType result);
               if (success)
               {
                  AntennaType = result;
               }
               break;
            case "packetInterval":
               PacketInterval = ParseMethods.ParseDouble(value);
               break;
            case "packetSize":
               PacketSize = ParseMethods.ParseDouble(value);
               break;
            case "packetResourceCost":
               PacketCost = ParseMethods.ParseDouble(value);
               break;
            case "antennaPower":
               AntennaPower = ParseMethods.ParseDouble(value);
               break;
            case "antennaCombinable":
               IsCombinable = ParseMethods.ParseBool(value);
               break;
            default:
               break;
         }
      }
   }
}
