using KSPModelLibrary;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using static KSPModelLibrary.PathSettings;

namespace KSPHelperWPF.ViewModels
{
   public class SettingsDialogViewModel : ViewModel
   {
      #region Properties
      private string _gameDataPath;
      private string _scienceDataPath;

      private string _partDataSavePath;
      private string _scienceDataSavePath;

      private string _vanillaPartPath;

      private string[] _additionalPaths;
      private string[] _dlcPaths;
      private string[] _modPaths;
      private string[] _excludedDirPaths;
      private string[] _excludedFilePaths;

      private string[] _fileFilters;
      private string[] _dirFilters;
      #endregion

      #region Constructors
      public SettingsDialogViewModel( ) { }
      public SettingsDialogViewModel( PathSettingModel settings )
      {
         _gameDataPath = settings.GameDataPath;
         _scienceDataPath = settings.ScienceDataPath;
         _vanillaPartPath = settings.VanillaPath;

         _partDataSavePath = settings.PartDataSavePath;
         _scienceDataSavePath = settings.ScienceDataSavePath;

         _additionalPaths = settings.AdditionalPartPaths;
         _dlcPaths = settings.DLCPaths;
         _modPaths = settings.ModPaths;
         _excludedDirPaths = settings.ExcludedPaths;
         _excludedFilePaths = settings.ExcludedFiles;

         _fileFilters = settings.FileFilters;
         _dirFilters = settings.DirFilters;
      }
      #endregion

      #region Methods
      public void WindowCloseEvent(object sender, CancelEventArgs e )
      {
         SettingsModel = new PathSettingModel
         {
            GameDataPath = GameDataPath,
            ScienceDataPath = ScienceDataPath,
            PartDataSavePath = PartDataSavePath,
            ScienceDataSavePath = ScienceDataSavePath,
            VanillaPath = VanillaPartPath,
            AdditionalPartPaths = AdditionalPaths,
            DLCPaths = DLCPaths,
            ModPaths = ModPaths,
            ExcludedPaths = ExcludedDirPaths,
            ExcludedFiles = ExcludedFilePaths,
            FileFilters = FileFilters,
            DirFilters = DirFilters,
         };
      }
      #endregion

      #region Full Properties
      public string GameDataPath
      {
         get
         {
            return _gameDataPath;
         }
         set
         {
            _gameDataPath = value;
            OnPropertyChanged(nameof(GameDataPath));
         }
      }
      public string ScienceDataPath
      {
         get
         {
            return _scienceDataPath;
         }
         set
         {
            _scienceDataPath = value;
            OnPropertyChanged(nameof(ScienceDataPath));
         }
      }
      public string PartDataSavePath
      {
         get
         {
            return _partDataSavePath;
         }
         set
         {
            _partDataSavePath = value;
            OnPropertyChanged(nameof(PartDataSavePath));
         }
      }
      public string ScienceDataSavePath
      {
         get
         {
            return _scienceDataSavePath;
         }
         set
         {
            _scienceDataSavePath = value;
            OnPropertyChanged(nameof(ScienceDataSavePath));
         }
      }
      public string VanillaPartPath
      {
         get
         {
            return _vanillaPartPath;
         }
         set
         {
            _vanillaPartPath = value;
            OnPropertyChanged(nameof(VanillaPartPath));
         }
      }
      public string[] AdditionalPaths
      {
         get
         {
            return _additionalPaths;
         }
         set
         {
            _additionalPaths = value;
            OnPropertyChanged(nameof(AdditionalPaths));
         }
      }
      public string[] DLCPaths
      {
         get
         {
            return _dlcPaths;
         }
         set
         {
            _dlcPaths = value;
            OnPropertyChanged(nameof(DLCPaths));
         }
      }
      public string[] ModPaths
      {
         get
         {
            return _modPaths;
         }
         set
         {
            _modPaths = value;
            OnPropertyChanged(nameof(ModPaths));
         }
      }
      public string[] ExcludedDirPaths
      {
         get
         {
            return _excludedDirPaths;
         }
         set
         {
            _excludedDirPaths = value;
            OnPropertyChanged(nameof(ExcludedDirPaths));
         }
      }
      public string[] ExcludedFilePaths
      {
         get
         {
            return _excludedFilePaths;
         }
         set
         {
            _excludedFilePaths = value;
            OnPropertyChanged(nameof(ExcludedFilePaths));
         }
      }
      public string[] FileFilters
      {
         get
         {
            return _fileFilters;
         }
         set
         {
            _fileFilters = value;
            OnPropertyChanged(nameof(FileFilters));
         }
      }
      public string[] DirFilters
      {
         get
         {
            return _dirFilters;
         }
         set
         {
            _dirFilters = value;
            OnPropertyChanged(nameof(DirFilters));
         }
      }
      #endregion
   }
}
