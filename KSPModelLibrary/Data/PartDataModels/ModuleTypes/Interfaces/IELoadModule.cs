using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public interface IELoadModule : IElectrical, IModule
   {
      double Load { get; }
   }
}
