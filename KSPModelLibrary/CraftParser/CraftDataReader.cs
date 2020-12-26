using ConfigReaderLibrary;
using KSPModelLibrary.Data.PartDataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.CraftParser
{
   public static class CraftDataReader
   {
      #region - Fields & Properties
      public static PartData AllPartData { get; } = GameDataReader.AllPartData;
      public static CraftModel Craft { get; set; }
      #endregion

      #region - Methods
      public static void ParseCraftFile(string path)
      {
         CFGReader reader = new CFGReader(path);
         BaseObject craftData = reader.ParseFile();

         Craft = new CraftModel();
         if (craftData.Values.ContainsKey("ship"))
         {
            Craft.CraftName = craftData.Values["ship"];
         }
         if (craftData.Values.ContainsKey("description"))
         {
            Craft.CraftDesc = craftData.Values["description"];
         }
         if (craftData.Values.ContainsKey("type"))
         {
            var success = Enum.TryParse(craftData.Values["type"], out BuildingType result);
            if (success)
            {
               Craft.Building = result;
            }
         }
         foreach (var partData in craftData.Children)
         {
            var stageNum = ParseMethods.ParseInt(partData.Values["dstg"]);
            if (!Craft.Stages.ContainsKey(stageNum))
            {
               var newStage = new Stage(stageNum);
               newStage.Parts.Add(FindPart(partData.Values["part"]));
               Craft.Stages.Add(stageNum, newStage);
            }
            else
            {
               Craft.Stages[stageNum].Parts.Add(
                  FindPart(partData.Values["part"])
               );
            }
         }

      }

      private static string CleanPartName(string rawPartName)
      {
         if (String.IsNullOrWhiteSpace(rawPartName))
         {
            return null;
         }

         var splitName = rawPartName.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);

         if (splitName.Length == 2)
         {
            return splitName[0].Replace('.', '_');
         }
         else
         {
            return null;
         }
      }

      private static PartRef FindPart(string name)
      {
         var partName = CleanPartName(name);

         Part foundPart = null;
         foreach (var part in AllPartData.Parts)
         {
            if (part.Name == partName)
            {
               foundPart = part;
               break;
            }
         }
         return new PartRef
         {
            Name = partName,
            Part = foundPart,
         };
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
