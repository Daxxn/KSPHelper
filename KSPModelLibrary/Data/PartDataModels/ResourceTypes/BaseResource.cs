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
      public void SetProp(string prop, string value)
      {
         switch (prop)
         {
            case "amount":
               Amount = ParseMethods.ParseInt(value);
               break;
            case "maxAmount":
               MaxAmount = ParseMethods.ParseInt(value);
               break;
            default:
               break;
         }
      }
   }
}
