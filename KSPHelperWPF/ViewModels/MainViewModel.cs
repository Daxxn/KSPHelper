using KSPModelLibrary;
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
