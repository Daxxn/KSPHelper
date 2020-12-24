using ConfigReaderLibrary;
using FileSearchLibrary;
using JsonReaderLibrary;
using KSPModelLibrary.Data;
using KSPModelLibrary.Data.PartDataModels;
using KSPModelLibrary.Data.ScienceDataModels;
using System;
using System.Collections.Generic;
using System.IO;

using JsonReader = JsonReaderLibrary.JsonReader;

namespace KSPModelLibrary
{
   public static class GameDataReader
   {
      #region - Fields & Properties
      public static Dictionary<string, string[]> Filters { get; set; } = new Dictionary<string, string[]>
      {
         { "dirs", new string[] {"Parts\\"} },
         { "files", new string[0] },
         { "exts", new string[] {".cfg"} }
      };

      public static PartData AllPartData { get; set; }
      public static PartData AllPartDataTest { get; set; }
      public static Science AllScienceData { get; set; }
      public static Science AllScienceDataTest { get; set; }
      #endregion

      #region - Methods
      public static void ReadGameData(string rootPath)
      {
         try
         {
            string[] files = GetFiles(rootPath);
            List<BaseObject> data = CFGReader.ReadFiles(files);
            AllPartData = PartDataBuilder.Build(data);
         }
         catch (Exception e)
         {
            throw new Exception("Part Config Reader Error", e);
         }

         try
         {
            SaveData(DataType.PartData);
         }
         catch (Exception e)
         {
            throw new Exception("Part Data Save Error", e);
         }
      }

      public static void ReadScienceData()
      {
         try
         {
            var reader = new CFGReader(PathSettings.SettingsModel.ScienceDataPath);
            reader.ReadFile();
            var data = reader.ParseFile();
            AllScienceData = ScienceDataBuilder.BuildData(data);
         }
         catch (Exception e)
         {
            throw new Exception("Science Config Reader Error", e);
         }

         try
         {
            SaveData(DataType.ScienceData);
         }
         catch (Exception e)
         {
            throw new Exception("Science Data Save Error", e);
         }
      }

      public static void LoadJsonParts()
      {
         try
         {
            AllPartData = JsonReaderLibrary.JsonReader.OpenJsonFile<PartData>(
               PathSettings.PartDataSavePath
            );
         }
         catch (Exception e)
         {
            throw new Exception("Json Parts Data Error", e);
         }
      }

      public static void LoadJsonScience()
      {
         try
         {
            AllScienceData = JsonReaderLibrary.JsonReader.OpenJsonFile<Science>(
               PathSettings.ScienceDataSavePath
            );
         }
         catch (Exception e)
         {
            throw new Exception("Json Science Data Error", e);
         }
      }

      //public static async Task ReadGameDataAsync(string rootPath)
      //{
      //   string[] files = GetFiles(rootPath);
      //   List<BaseObject> data = await CFGReader.ReadFilesAsync(files);
      //   Console.WriteLine("Read all the data.");
      //}

      private static string[] GetFiles(string root)
      {
         if (!Directory.Exists(root))
         {
            throw new DirectoryNotFoundException(root);
         }

         string[] foundFiles = FileSearch_2.FilterFiles(
            PathSettings.AllPaths,
            PathSettings.SettingsModel.ExcludedFiles,
            PathSettings.SettingsModel.ExcludedPaths,
            PathSettings.SettingsModel.FileFilters,
            PathSettings.SettingsModel.DirFilters
         );

         return foundFiles;
      }

      public static void SaveData(DataType type)
      {
         switch (type)
         {
            case DataType.PartData:
               if (AllPartData is null)
               {
                  return;
               }
               JsonReader.SaveJsonFile(
                  PathSettings.PartDataSavePath,
                  AllPartData,
                  true
               );
               break;
            case DataType.ScienceData:
               if (AllScienceData is null)
               {
                  return;
               }
               JsonReader.SaveJsonFile(
                  PathSettings.ScienceDataSavePath,
                  AllScienceData,
                  true
               );
               break;
            default:
               throw new ArgumentException("DataType not found!");
         }
      }

      public static void SaveParsedPartData()
      {
         if (AllPartData is null)
         {
            return;
         }
         JsonReader.SaveJsonFile(
            PathSettings.SettingsModel.PartDataSavePath,
            AllPartData,
            true
         );
      }

      public static void SaveParsedScienceData()
      {
         if (AllScienceData is null)
         {
            return;
         }
         JsonReader.SaveJsonFile(
            PathSettings.ScienceDataSavePath,
            AllScienceData,
            true
         );
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
