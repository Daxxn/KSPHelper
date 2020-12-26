using FileSearchLibrary;
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
      public static string[] PartPaths { get; set; }
      public static string[] SciencePaths { get; set; }

      public class PathSettingModel
      {
         public string CraftFolder { get; set; }
         public string ProjectPath { get; set; }
         public string GameDataPath { get; set; }
         public string PartDataSavePath { get; set; }
         public string ScienceDataSavePath { get; set; }
         public string[] ExcludedDirs { get; set; }
         public string[] ExcludedFiles { get; set; }

         public string ScienceFilter { get; set; }
         public string PartFilter { get; set; }

         public string CraftDialogFilter { get; set; }
      }
      #endregion

      #region - Methods
      public static void OnStartup()
      {
         string projectDir = FindProjectDir(Environment.CurrentDirectory);
         SettingsModel = JsonReader.OpenJsonFile<PathSettingModel>(Path.Combine(projectDir, PathSettingLocation));
         GetGameDataDirectories();
         SettingsModel.ProjectPath = projectDir;
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

      public static string GetNestedProjPath(string childPath)
      {
         return Path.Combine(SettingsModel.ProjectPath, childPath);
      }

      public static void GetGameDataDirectories()
      {
         string[] partFiles = FileSearch_2.GetFiles(SettingsModel.GameDataPath, SettingsModel.PartFilter);
         PartPaths = FileSearch_2.FilterFiles(partFiles, SettingsModel.ExcludedFiles, SettingsModel.ExcludedDirs);
         SciencePaths = FileSearch_2.GetFiles(SettingsModel.GameDataPath, SettingsModel.ScienceFilter);
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
