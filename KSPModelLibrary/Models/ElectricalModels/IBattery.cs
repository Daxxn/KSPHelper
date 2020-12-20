using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Models.ElectricalModels
{
   public interface IBattery : IPart
   {
      uint Capacity { get; set; }
   }
}
