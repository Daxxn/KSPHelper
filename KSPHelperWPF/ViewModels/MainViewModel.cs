using KSPModelLibrary;
using KSPModelLibrary.Data;
using KSPModelLibrary.Data.PartDataModels;
using KSPModelLibrary.Data.ScienceDataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPHelperWPF.ViewModels
{
   public class MainViewModel : ViewModel
   {
      #region - Fields & Properties
      private static MainViewModel _instance = new MainViewModel();

      #region View Models
      public ElectricalViewModel ElectricalVM { get; set; } = new ElectricalViewModel();
      public CommsViewModel CommsVM { get; set; } = new CommsViewModel();
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
         GameDataReader.ReadGameData(@"B:\Games\steamapps\common\Kerbal Space Program\GameData");
      }

      public void ExperimentReadEvent(object sender, EventArgs e)
      {
         GameDataReader.ReadScienceData();
      }

      public void PartJsonReadEvent(object sender, EventArgs e)
      {
         GameDataReader.LoadJsonParts();
      }

      public void ScienceJsonReadEvent(object sender, EventArgs e)
      {
         GameDataReader.LoadJsonScience();
      }

      public void ModuleTestEvent(object sender, EventArgs e)
      {
         var parsedParts = GameDataReader.AllPartData.Parts.FindAll((part) => part.Category == "Electrical");
         //var savedParts = AllPartsTest.Parts.Find((part) => part.Category == "Electrical");
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
