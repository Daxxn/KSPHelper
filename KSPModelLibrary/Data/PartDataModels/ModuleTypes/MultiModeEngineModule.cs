using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class MultiModeEngineModule : IModule
   {
      public string Name { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            default:
               break;
         }
      }

      public static MultiModeEngineModule BuildModule(BaseObject obj)
      {
         var newInst = new MultiModeEngineModule();
         //.....
         return newInst;
      }
   }
}
