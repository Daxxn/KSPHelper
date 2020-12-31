using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public interface IEAltModule : IElectrical, IModule
   {
      double Charge { get; }
   }
}
