using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KSPHelperWPF.Models.SettingsModels
{
   public class SettingPath
   {
      #region - Fields & Properties
      public string FilePath { get; set; }
      public SettingPath ParentPath { get; set; }
      #endregion

      #region - Constructors
      public SettingPath(string filePath) => FilePath = filePath;
      public SettingPath(string filePath, SettingPath parent)
      {
         FilePath = filePath;
         ParentPath = parent;
      }
      #endregion

      #region - Methods
      public static SettingPath[] NewArray(SettingPath parent, string[] paths)
      {
         SettingPath[] newPaths = new SettingPath[paths.Length];
         for (int i = 0; i < newPaths.Length; i++)
         {
            newPaths[i] = new SettingPath(paths[i], parent);
         }
         return newPaths;
      }
      #endregion

      #region - Full Properties
      public string FullPath
      {
         get
         {
            if (ParentPath is null)
            {
               return FilePath;
            }
            else
            {
               return Path.Combine(ParentPath.FullPath, FilePath);
            }
         }
      }
      #endregion
   }
}
