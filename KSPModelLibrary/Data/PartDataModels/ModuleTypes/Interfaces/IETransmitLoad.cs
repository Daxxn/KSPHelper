using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   interface IETransmitLoad : IElectrical, IModule
   {
      double TransmitLoad { get; }
   }
}
