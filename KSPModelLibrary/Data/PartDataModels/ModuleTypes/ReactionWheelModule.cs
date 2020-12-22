using KSPModelLibrary.Data.PartDataModels.ResourceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class ReactionWheelModule : IModule
   {
      public string Name { get; set; }
      public ElectricalLoadModule Electrical { get; set; }

      public void SetProp(string prop, string value)
      {
         throw new NotImplementedException();
      }
   }
}
