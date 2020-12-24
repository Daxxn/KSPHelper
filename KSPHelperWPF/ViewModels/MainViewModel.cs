using KSPHelperWPF.Views;

using KSPModelLibrary;
using KSPModelLibrary.Data;
using KSPModelLibrary.Data.PartDataModels;
using KSPModelLibrary.Data.ScienceDataModels;
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

      #region View Models
      public ElectricalViewModel ElectricalVM { get; set; } = new ElectricalViewModel();
      public CommsViewModel CommsVM { get; set; } = new CommsViewModel();
      public SettingsDialogViewModel SettingsVM { get; set; } = new SettingsDialogViewModel(PathSettings.SettingsModel);
      #endregion

      public PartData AllParts { get; set; } = GameDataReader.AllPartData;
      public Science AllScience { get; set; } = GameDataReader.AllScienceData;
      public PartData AllPartsTest { get; set; } = GameDataReader.AllPartDataTest;
      public Science AllScienceTest { get; set; } = GameDataReader.AllScienceDataTest;
      #endregion

      #region - Constructors
      private MainViewModel() { }
      #endregion

      #region - Methods
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
            //if (ex.InnerException != null)
            //{
            //   MessageBox.Show(ex.InnerException.Message, $"ERROR!! {ex.Message}");
            //}
            //else
            //{
            //   MessageBox.Show(ex.InnerException.Message, "Error!");
            //}
            ExceptionHandler.ShowException(ex);
         }
      }

      public void ModuleTestEvent(object sender, EventArgs e)
      {
         //var parsedParts = GameDataReader.AllPartData.Parts.FindAll((part) => part.Category == "Electrical");
         //var ex = new Exception("Test Outer Exception", new Exception("Test Inner Exception"));
         //ExceptionHandler.ShowException(ex);
         MessageBox.Show("Test");
      }

      public void OpenPathSettingsEvent(object sender, EventArgs e )
      {
         SettingsDialog d = new SettingsDialog(SettingsVM);
         d.Show();
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
