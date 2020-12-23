using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ResourceTypes
{
   public interface IResource
   {
      string Name { get; set; }
      int Amount { get; set; }
      int MaxAmount { get; set; }
      void SetProp(KeyValuePair<string, string> keyVal);
   }
}
