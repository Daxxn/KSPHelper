using ConfigReaderLibrary;
using FileSearchLibrary;
using KSPModelLibrary.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

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
      #endregion

      #region - Methods
      public static void ReadGameData(string rootPath)
      {
         string[] files = GetFiles(rootPath);
         List<BaseObject> data = CFGReader.ReadFiles(files, "PART");
         PartDataBuilder.Build(data);
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

         string[] foundFiles = FileSearch.FindFiles(root, Filters["dirs"], Filters["files"], Filters["exts"]);

         return foundFiles;
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
