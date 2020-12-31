using KSPHelperWPF.Dialogs;
using KSPHelperWPF.Events;
using KSPHelperWPF.ViewModels.CalculatorViewModels;
using KSPHelperWPF.Views;

using KSPModelLibrary;
using KSPModelLibrary.CraftParser;
using KSPModelLibrary.Data;
using KSPModelLibrary.Data.PartDataModels;
using KSPModelLibrary.Data.ScienceDataModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KSPHelperWPF.ViewModels
{
   public class MainViewModel : ViewModel
   {
      #region - Fields & Properties
      private static MainViewModel _instance = new MainViewModel();

      public static event EventHandler<OpenCraftEventArgs> OpenNewCraftEvent;

      #region View Models
      public PartsViewModel PartsVM { get; set; } = new PartsViewModel();
      public ElectricalViewModel ElectricalVM { get; set; } = new ElectricalViewModel();
      public CommsViewModel CommsVM { get; set; } = new CommsViewModel();
      public SettingsDialogViewModel SettingsVM { get; set; } = new SettingsDialogViewModel(PathSettings.SettingsModel);
      public CalculatorsViewModel CalcsVM { get; set; } = new CalculatorsViewModel();
      #endregion

      public PartData AllParts { get; set; } = GameDataReader.AllPartData;
      public Science AllScience { get; set; } = GameDataReader.AllScienceData;

      public CraftModel OpenedCraft { get; set; } = CraftDataReader.Craft;
      #endregion

      #region - Constructors
      private MainViewModel()
      {
         OpenNewCraftEvent += MainViewModel_OpenNewCraftEvent;
      }
      #endregion

      #region - Methods
      private void MainViewModel_OpenNewCraftEvent(object sender, OpenCraftEventArgs e)
      {
         OpenedCraft = e.Craft;
      }
      public void GameDataReadEvent(object sender, EventArgs e)
      {
         // Move to either an AppSetting or to a settings view.
         try
         {
            GameDataReader.ReadGameData(@"B:\Games\steamapps\common\Kerbal Space Program\GameData");
         }
         catch (Exception ex)
         {
            ExceptionHandler.ShowException(ex);
         }
      }

      public void ExperimentReadEvent(object sender, EventArgs e)
      {
         try
         {
            GameDataReader.ReadScienceData();
         }
         catch (Exception ex)
         {
            ExceptionHandler.ShowException(ex);
         }
      }

      public void PartJsonReadEvent(object sender, EventArgs e)
      {
         try
         {
            GameDataReader.LoadJsonParts();
         }
         catch (Exception ex)
         {

            ExceptionHandler.ShowException(ex);
         }
      }

      public void ScienceJsonReadEvent(object sender, EventArgs e)
      {
         try
         {
            GameDataReader.LoadJsonScience();
         }
         catch (Exception ex)
         {
            ExceptionHandler.ShowException(ex);
         }
      }

      public void ModuleTestEvent(object sender, EventArgs e)
      {
         MessageBox.Show("Testing Event Only");
      }

      public void OpenPathSettingsEvent(object sender, EventArgs e )
      {
         SettingsDialog d = new SettingsDialog(SettingsVM);
         d.Show();
      }

      public void OpenCraftClickEvent(object sender, EventArgs e)
      {
         try
         {
            var newCraft = OpenCraft.OpenDialog();
            //PartsVM.Craft = newCraft;
            if (newCraft != null)
            {
               OpenNewCraftEvent?.Invoke(this, new OpenCraftEventArgs(newCraft));
            }
         }
         catch (Exception ex)
         {
            ExceptionHandler.ShowException(ex);
         }
      }
      #endregion

      #region - Full Properties
      public static MainViewModel Instance
      {
         get
         {
            if (_instance is null)
            {
               _instance = new MainViewModel();
            }
            return _instance;
         }
      }
      #endregion
   }
}
