using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class CommandModule : IModule
   {
      public string Name { get; set; }
      public int CrewCapacity { get; set; }
      public int MinimumCrew { get; set; }


      public void SetProp(string prop, string value)
      {
         switch (prop)
         {
            case "minimumCrew":
               MinimumCrew = ParseMethods.ParseInt(value);
               break;
            // REPLACE
            case "CrewCap":
               CrewCapacity = ParseMethods.ParseInt(value);
               break;
            default:
               break;
         }
      }
   }
}
