﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels
{
   public class PartData
   {
      public static readonly double LiquidFuelMassPerUnit = 0.5;
      public static readonly double OxidizerMassPerUnit = 0.5;
      public List<Part> Parts { get; set; } = new List<Part>();
   }
}
