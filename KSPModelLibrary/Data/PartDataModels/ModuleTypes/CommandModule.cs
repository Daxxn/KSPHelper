using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class CommandModule : IModule, IELoadModule
   {
      public string Name { get; set; }
      public int CrewCapacity { get; set; }
      public int MinimumCrew { get; set; }
      public ElectricalLoadModule Electrical { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "minimumCrew":
               MinimumCrew = ParseMethods.ParseInt(keyVal.Value);
               break;
            // REPLACE
            case "CrewCap":
               CrewCapacity = ParseMethods.ParseInt(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static CommandModule BuildModule(BaseObject obj)
      {
         var newCommand = new CommandModule();
         foreach (var keyVal in obj.Values)
         {
            newCommand.SetProp(keyVal);
         }
         if (obj.Children.Count > 0)
         {
            var electricalChild = obj.Children.Find(child => child.Key == "RESOURCE");
            if (electricalChild != null)
            {
               newCommand.Electrical = ElectricalLoadModule.BuildModule(electricalChild);
            }
         }
         return newCommand;
      }

      public double Load
      {
         get
         {
            if (Electrical != null)
            {
               return Electrical.Rate;
            }
            else
            {
               return 0;
            }
         }
      }
   }
}
