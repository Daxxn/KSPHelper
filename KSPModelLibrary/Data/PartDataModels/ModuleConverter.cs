using KSPModelLibrary.Data.PartDataModels.ModuleTypes;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels
{
   public class ModuleConverter : CustomCreationConverter<IModule>
   {
      public override IModule Create(Type objectType)
      {
         return null;
      }
   }
}
