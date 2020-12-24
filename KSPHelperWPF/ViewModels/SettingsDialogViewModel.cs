using KSPModelLibrary;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

using static KSPModelLibrary.PathSettings;

namespace KSPHelperWPF.ViewModels
{
   public enum FileType
   {
      Directory,
      File,
      PartialDir,
      PartialFile,
   }
   public class SettingsDialogViewModel : ViewModel
   {
      #region Properties
      private string _gameDataPath;
      private string _scienceDataPath;

      private string _partDataSavePath;
      private string _scienceDataSavePath;

      private string _vanillaPartPath;

      private ObservableCollection<string> _additionalPaths;
      private ObservableCollection<string> _dlcPaths;
      private ObservableCollection<string> _modPaths;
      private ObservableCollection<string> _excludedDirPaths;
      private ObservableCollection<string> _excludedFilePaths;

      private ObservableCollection<string> _fileFilters;
      private ObservableCollection<string> _dirFilters;
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

         _additionalPaths = new ObservableCollection<string>(settings.AdditionalPartPaths);
         _dlcPaths = new ObservableCollection<string>(settings.DLCPaths);
         _modPaths = new ObservableCollection<string>(settings.ModPaths);
         _excludedDirPaths = new ObservableCollection<string>(settings.ExcludedPaths);
         _excludedFilePaths = new ObservableCollection<string>(settings.ExcludedFiles);

         _fileFilters = new ObservableCollection<string>(settings.FileFilters);
         _dirFilters = new ObservableCollection<string>(settings.DirFilters);
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
            AdditionalPartPaths = AdditionalPaths.ToArray(),
            DLCPaths = DLCPaths.ToArray(),
            ModPaths = ModPaths.ToArray(),
            ExcludedPaths = ExcludedDirPaths.ToArray(),
            ExcludedFiles = ExcludedFilePaths.ToArray(),
            FileFilters = FileFilters.ToArray(),
            DirFilters = DirFilters.ToArray(),
         };
      }

      public bool CheckPath(string input, FileType type)
      {
         switch (type)
         {
            case FileType.Directory:
               return Directory.Exists(input);
            case FileType.File:
               return File.Exists(input);
            case FileType.PartialDir:
               return Directory.Exists(Path.Combine(GameDataPath, input));
            case FileType.PartialFile:
               return File.Exists(Path.Combine(GameDataPath, input));
            default:
               throw new ArgumentException("FileType not found");
         }
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
      public ObservableCollection<string> AdditionalPaths
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
      public ObservableCollection<string> DLCPaths
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
      public ObservableCollection<string> ModPaths
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
      public ObservableCollection<string> ExcludedDirPaths
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
      public ObservableCollection<string> ExcludedFilePaths
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
      public ObservableCollection<string> FileFilters
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
      public ObservableCollection<string> DirFilters
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
