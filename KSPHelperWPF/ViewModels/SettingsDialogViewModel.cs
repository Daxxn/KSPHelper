using KSPHelperWPF.Models.SettingsModels;
using KSPModelLibrary;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
      private SettingPath _gameDataPath;
      private SettingPath _scienceDataPath;

      private SettingPath _partDataSavePath;
      private SettingPath _scienceDataSavePath;

      private SettingPath _vanillaPartPath;

      private ObservableCollection<SettingPath> _additionalPaths;
      private ObservableCollection<SettingPath> _dlcPaths;
      private ObservableCollection<SettingPath> _modPaths;
      private ObservableCollection<SettingPath> _excludedDirPaths;
      private ObservableCollection<SettingPath> _excludedFilePaths;

      private ObservableCollection<SettingPath> _fileFilters;
      private ObservableCollection<SettingPath> _dirFilters;
      #endregion

      #region Constructors
      public SettingsDialogViewModel( ) { }
      public SettingsDialogViewModel( PathSettingModel settings )
      {
         //_gameDataPath = new SettingPath(settings.GameDataPath);
         //_scienceDataPath = new SettingPath(settings.ScienceDataPath);
         //_vanillaPartPath = new SettingPath(settings.VanillaPath, _gameDataPath);

         //_partDataSavePath = new SettingPath(settings.PartDataSavePath);
         //_scienceDataSavePath = new SettingPath(settings.ScienceDataSavePath);

         //_additionalPaths = new ObservableCollection<SettingPath>(SettingPath.NewArray(_gameDataPath, settings.AdditionalPartPaths));
         //_dlcPaths = new ObservableCollection<SettingPath>(SettingPath.NewArray(_gameDataPath, settings.DLCPaths));
         //_modPaths = new ObservableCollection<SettingPath>(SettingPath.NewArray(_gameDataPath, settings.ModPaths));
         //_excludedDirPaths = new ObservableCollection<SettingPath>(SettingPath.NewArray(_gameDataPath, settings.ExcludedPaths));
         //_excludedFilePaths = new ObservableCollection<SettingPath>(SettingPath.NewArray(_gameDataPath, settings.ExcludedFiles));

         //_fileFilters = new ObservableCollection<SettingPath>(SettingPath.NewArray(null, settings.FileFilters));
         //_dirFilters = new ObservableCollection<SettingPath>(SettingPath.NewArray(null, settings.DirFilters));
      }
      #endregion

      #region Methods
      public void WindowCloseEvent(object sender, CancelEventArgs e )
      {
         //SettingsModel = new PathSettingModel
         //{
         //   GameDataPath = GameDataPath,
         //   ScienceDataPath = ScienceDataPath,
         //   PartDataSavePath = PartDataSavePath,
         //   ScienceDataSavePath = ScienceDataSavePath,
         //   VanillaPath = VanillaPartPath,
         //   AdditionalPartPaths = AdditionalPaths.ToArray(),
         //   DLCPaths = DLCPaths.ToArray(),
         //   ModPaths = ModPaths.ToArray(),
         //   ExcludedPaths = ExcludedDirPaths.ToArray(),
         //   ExcludedFiles = ExcludedFilePaths.ToArray(),
         //   FileFilters = FileFilters.ToArray(),
         //   DirFilters = DirFilters.ToArray(),
         //};
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
               return Directory.Exists(Path.Combine(GameDataPath.FullPath, input));
            case FileType.PartialFile:
               return File.Exists(Path.Combine(GameDataPath.FullPath, input));
            default:
               throw new ArgumentException("FileType not found");
         }
      }

      public void AddEvent(object sender, RoutedEventArgs e)
      {
         var btn = sender as Button;
         var list = btn.DataContext as ObservableCollection<SettingPath>;
         list.Add(new SettingPath("", list[0].ParentPath));
      }

      public void ListDeleteEvent(object sender, RoutedEventArgs e)
      {
         var btn = sender as Button;
         var Setting = btn.DataContext as SettingPath;

         var success = AdditionalPaths.Remove(Setting);
         if (success)
         {
            return;
         }
         success = DLCPaths.Remove(Setting);
         if (success)
         {
            return;
         }
         success = ModPaths.Remove(Setting);
         if (success)
         {
            return;
         }
         success = ExcludedDirPaths.Remove(Setting);
         if (success)
         {
            return;
         }
         success = ExcludedFilePaths.Remove(Setting);
         if (success)
         {
            return;
         }
         success = FileFilters.Remove(Setting);
         if (success)
         {
            return;
         }
         success = DirFilters.Remove(Setting);
         if (success)
         {
            return;
         }
      }
      #endregion

      #region Full Properties
      public SettingPath GameDataPath
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
      public SettingPath ScienceDataPath
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
      public SettingPath PartDataSavePath
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
      public SettingPath ScienceDataSavePath
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
      public SettingPath VanillaPartPath
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
      public ObservableCollection<SettingPath> AdditionalPaths
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
      public ObservableCollection<SettingPath> DLCPaths
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
      public ObservableCollection<SettingPath> ModPaths
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
      public ObservableCollection<SettingPath> ExcludedDirPaths
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
      public ObservableCollection<SettingPath> ExcludedFilePaths
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
      public ObservableCollection<SettingPath> FileFilters
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
      public ObservableCollection<SettingPath> DirFilters
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
