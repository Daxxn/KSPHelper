using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public interface IModule
   {
      string Name { get; set; }

      void SetProp(string prop, string value);
   }
}
