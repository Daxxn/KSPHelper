using JsonReaderLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KSPModelLibrary
{
   public static class PathSettings
   {
      #region - Fields & Properties
      private static readonly string PathSettingLocation = @"KSPModelLibrary\SaveData\GameDataPaths.json";
      public static PathSettingModel SettingsModel { get; set; }
      public static string[] AllPaths { get; set; }

      public class PathSettingModel
      {
         public string GameDataPath { get; set; }
         public string[] AdditionalPartPaths { get; set; }
         public string VanillaPath { get; set; }
         public string[] DLCPaths { get; set; }
         public string[] ModPaths { get; set; }
         public string[] ExcludedPaths { get; set; }
         public string[] ExcludedFiles { get; set; }
         public string[] FileFilters { get; set; }
         public string[] DirFilters { get; set; }
      }
      #endregion

      #region - Methods
      public static void OnStartup()
      {
         string projectDir = FindProjectDir(Environment.CurrentDirectory);
         SettingsModel = JsonReader.OpenJsonFile<PathSettingModel>(Path.Combine(projectDir, PathSettingLocation));
         BuildGameDataDirectories();
      }

      public static void OnExit()
      {
         //JsonReader.SaveJsonFile(PathSettingLocation, SettingsModel);
      }

      private static string FindProjectDir(string workingDir)
      {
         //string output = "";
         var currentDir = new DirectoryInfo(workingDir);
         if (currentDir.Name.ToLower() == "ksphelper")
         {
            return workingDir;
         }
         else
         {
            return FindProjectDir(currentDir.Parent.FullName);
         }
      }

      public static void BuildGameDataDirectories()
      {
         var gameDataPath = SettingsModel.GameDataPath;

         List<string> allPaths = new List<string>();
         allPaths.Add(Path.Combine(gameDataPath, SettingsModel.VanillaPath));
         allPaths.AddRange(CombinePaths(SettingsModel.AdditionalPartPaths));
         allPaths.AddRange(CombinePaths(SettingsModel.DLCPaths));
         allPaths.AddRange(CombinePaths(SettingsModel.ModPaths));
         allPaths.Where((path) => !SettingsModel.ExcludedPaths.Contains(path));
         AllPaths = allPaths.ToArray();
      }
      private static string[] CombinePaths(string[] addonPaths)
      {
         List<string> paths = new List<string>();
         foreach (var addon in addonPaths)
         {
            paths.Add(Path.Combine(SettingsModel.GameDataPath, addon));
         }
         return paths.ToArray();
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
