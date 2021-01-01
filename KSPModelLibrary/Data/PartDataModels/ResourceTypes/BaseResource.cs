using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ResourceTypes
{
   public class BaseResource
   {
      public string Name { get; set; }
      public int Amount { get; set; }
      public int MaxAmount { get; set; }
      public double Rate { get; set; }
      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "name":
               Name = keyVal.Value;
               break;
            case "amount":
               Amount = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "maxAmount":
               MaxAmount = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "rate":
               Rate = ParseMethods.ParseDouble(keyVal.Value);
               break;
            default:
               break;
         }
      }
   }
}
