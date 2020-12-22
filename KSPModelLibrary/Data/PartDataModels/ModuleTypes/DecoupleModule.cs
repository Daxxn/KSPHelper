using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class DecoupleModule : IModule
   {
      public string Name { get; set; }
      public double EjectionForce { get; set; }

      public void SetProp(string prop, string value)
      {
         if (prop == "ejectionForce")
         {
            EjectionForce = ParseMethods.ParseDouble(value);
         }
      }
   }
}
