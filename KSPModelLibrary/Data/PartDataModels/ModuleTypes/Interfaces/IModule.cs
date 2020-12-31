using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   /// <summary>
   /// Contains data for a part.
   /// </summary>
   public interface IModule : IPartDataType
   {
      string Name { get; set; }

      void SetProp(KeyValuePair<string, string> keyVal);
   }
}
