using ConfigReaderLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.ScienceDataModels
{
   public class Experiment
   {
      public string Id { get; set; }
      public string Title { get; set; }
      public int BaseValue { get; set; }
      public int ScienceCap { get; set; }
      public double DataScale { get; set; }

      public void SetProp(KeyValuePair<string, string> keyVal)
      {
         switch (keyVal.Key)
         {
            case "id":
               Id = keyVal.Value;
               break;
            case "title":
               Title = keyVal.Value;
               break;
            case "baseValue":
               BaseValue = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "scienceCap":
               ScienceCap = ParseMethods.ParseInt(keyVal.Value);
               break;
            case "dataScale":
               DataScale = ParseMethods.ParseDouble(keyVal.Value);
               break;
            default:
               break;
         }
      }

      public static Experiment Build(BaseObject obj)
      {
         var newExp = new Experiment();
         foreach (var kv in obj.Values)
         {
            newExp.SetProp(kv);
         }
         return newExp;
      }
   }
}
