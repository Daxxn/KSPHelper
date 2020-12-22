using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KSPModelLibrary
{
   public static class FileSettingsManager
   {
      #region - Fields & Properties
      private static readonly char Delimiter = ',';
      private static string RootPath { get; } = PathSettings.Default.GameDataPath;
      #endregion

      #region - Methods
      public static string[] BuildGameDataDirectories()
      {
         var gameDataPath = PathSettings.Default.GameDataPath;
         var AdditionalPaths = ParseSetting(PathSettings.Default.AdditionalPartDirs);
         var DLCPaths = ParseSetting(PathSettings.Default.DLCDirs);
         var ModPaths = ParseSetting(PathSettings.Default.ModDirs);
         var ExcludedPaths = ParseSetting(PathSettings.Default.ExcludedDirs);

         List<string> allPaths = new List<string>();
         allPaths.AddRange(AdditionalPaths);
         allPaths.AddRange(DLCPaths);
         allPaths.AddRange(ModPaths);
         allPaths.Where((path) => !ExcludedPaths.Contains(path));
         return allPaths.ToArray();
      }

      private static string[] ParseSetting(string settingValue)
      {
         try
         {
            string[] values = settingValue.Split(Delimiter, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < values.Length; i++)
            {
               values[i] = values[i].Trim();
            }
            return values;
         }
         catch (Exception)
         {
            throw;
         }
      }

      private static string[] CombinePaths(string[] addonPaths)
      {
         List<string> paths = new List<string>();
         foreach (var addon in addonPaths)
         {
            paths.Add(Path.Combine(RootPath, addon));
         }
         return paths.ToArray();
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
