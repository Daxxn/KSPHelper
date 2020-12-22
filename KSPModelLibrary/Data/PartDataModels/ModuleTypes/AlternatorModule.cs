﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class AlternatorModule : IModule
   {
      public string Name { get; set; }
      public double ChargeRate { get; set; }

      public void SetProp(string prop, string value)
      {
         if (prop == "rate")
         {
            ChargeRate = ParseMethods.ParseDouble(value);
         }
      }
   }
}
